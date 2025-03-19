using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;



namespace SnapshotsOfLifeEx02
{
    public partial class MainWindow : Form, IObserver
    {
        private CameraController _controller = null;
        private IObserver formAs = null;
        private ActionSource _actionSource = new ActionSource();
        private List<ActionListener> _actionListenerList = new List<ActionListener>();
        private IntPtr[] _volumes = new IntPtr[2];
        private int _volume_count = 0;
        private List<string> pictures = new List<string>(){ };
        private int TakePicture = 4;  //사진찍는 횟수
        private Timer t = new Timer();  // 카운트 타이머
        private int timer_time; // 현재 카운트 타이머 시간
        /*private int timer_time_limit = 6;   // 카운트 타이머 초 수 - 0 포함*/
        private int timer_time_limit = 4;  // 카운트 타이머 초 수 - 0 포함

        private Timer s_t = new Timer();  // 셔터 타이머
        private int shutter_animation_interval = 10;
        private List<IObserver> _observerList = new List<IObserver>();

        private List<Image> _frame_bg_list = new List<Image>(); // 테마 자른 이미지 리스트
        private PictureData pictureData = new PictureData();    // 사진 규격 데이터

        private int Image_Width = 520;
        private int Image_Height = 380;

        private string folderPath = "./pictures";
        private string uiPath = "./ui";

        //대기 화면
       /* private Image intro = Image.FromFile("./ui/intro.png"); */
        //대기 영상
        private string introVideoUrl = "./ui/intro.mp4";

        private Image bg = Image.FromFile("./ui/main.png");
        /*private Image start_up_btn = Image.FromFile("./ui/startbutton_up.png");
        private Image start_down_btn = Image.FromFile("./ui/startbutton_down.png");
        private Image picture_up_btn = Image.FromFile("./ui/picturebutton_up.png");
        private Image picture_down_btn = Image.FromFile("./ui/picturebutton_down.png");*/
        private Image back_up_btn = Image.FromFile("./ui/back_arrow_up.png");
        private Image back_down_btn = Image.FromFile("./ui/back_arrow_down.png");

        private Image[] flash_pictures = { Image.FromFile("./ui/flash01.png") , Image.FromFile("./ui/flash02.png"), Image.FromFile("./ui/flash03.png"), Image.FromFile("./ui/flash04.png"), Image.FromFile("./ui/flash05.png"),
                                            Image.FromFile("./ui/flash06.png") ,Image.FromFile("./ui/flash07.png") ,Image.FromFile("./ui/flash08.png") ,Image.FromFile("./ui/flash09.png") ,};

       /* private Image[] flash_count_pictures = { Image.FromFile("./ui/count_0.png"), Image.FromFile("./ui/count_1.png"), Image.FromFile("./ui/count_2.png"), Image.FromFile("./ui/count_3.png"), Image.FromFile("./ui/count_4.png"), Image.FromFile("./ui/count_5.png") };*/

        private Image[] flash_count_pictures = { Image.FromFile("./ui/count_3_big.png"), Image.FromFile("./ui/count_2_big.png"), Image.FromFile("./ui/count_1_big.png"),  Image.FromFile("./ui/transparent_bg.png") };

        private Image[] take_count_pictures = { Image.FromFile("./ui/take_1.png"), Image.FromFile("./ui/take_2.png"), Image.FromFile("./ui/take_3.png"), Image.FromFile("./ui/take_4.png") };

        private int flash_pictures_count = 0;

       /* private Image picture_animation;*/

        private long maxSizeByte = 1024 * 1024 * 500; // 최고 용량 (500MB)
        private int deleteFilesCount = 20;   // 용량 초과시 지울 파일 개수

        private Image selected_frame;   // 선택된 테마 이미지
        private string selected_frame_name;   // 선택된 테마 이름
        private bool mirror_option = false;

        private bool themaType = false;    // 순서가 정해진 테마인지 아닌지  false: 안정해진 테마, true : 정해진 테마

        private DB db;

        private string db_mirror_key = "Mirror";    // db 에 거울값이 저장된 컬럼이름
        private string db_frame_key = "Frame";

        private string cameraEffectSoundPath = "./sound/camera.mp3";
        private string cameraCountSoundPath = "./sound/onetwothree.mp3";
        private string waitPleaseSoundPath = "./sound/waitplease.mp3";
        private string startSoundPath = "./sound/start.mp3";
        private string pictureCountSoundPath = "./sound/picturecount.mp3";
        

        private WMPLib.WindowsMediaPlayer cameraEffectPlayer = new WMPLib.WindowsMediaPlayer();
        private WMPLib.WindowsMediaPlayer cameraCountPlayer = new WMPLib.WindowsMediaPlayer();
        private WMPLib.WindowsMediaPlayer waitPleasePlayer = new WMPLib.WindowsMediaPlayer();
        private WMPLib.WindowsMediaPlayer startSoundPlayer = new WMPLib.WindowsMediaPlayer();
        private WMPLib.WindowsMediaPlayer pictureCountPlayer = new WMPLib.WindowsMediaPlayer();

        private bool isRunning = false;     // 현재 진행중 여부

        /*private int printCurrentPage = 0;   // 현재 프린트 중인 패이지 수*/

        public MainWindow(ref CameraController controller)
        {
            uint err = EDSDKLib.EDSDK.EDS_ERR_OK;
            // Get initial volume
            EDSDKLib.EDSDK.EdsVolumeInfo outVolumeInfo;

            formAs = this;
            InitializeComponent();

            // 화면 및 픽쳐박스 버벅임 줄이기
            /*SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();*/

            this.DoubleBuffered = true;

            _controller = controller;
            err = EDSDKLib.EDSDK.EdsGetChildCount(_controller.GetModel().Camera, out _volume_count);

            _actionListenerList.Add((ActionListener)_controller);

            _actionListenerList.ForEach(actionListener => _actionSource.AddActionListener(ref actionListener));


            _observerList.Add((IObserver)evfPictureBox1);

            System.Threading.Thread.Sleep(1000);
            
            _observerList.ForEach(observer => _controller.GetModel().Add(ref observer));

            evfPictureBox1.Parent = take_picture_count_box;
            evfPictureBox1.SetActionSource(ref _actionSource);
            evfPictureBox1.Visible = false;

           /* takePictureButton.SetActionSource(ref _actionSource);


            actionButton5.SetActionSource(ref _actionSource);
            actionButton5.Command = ActionEvent.Command.START_EVF*/;
            

            t.Interval = 1000;
            t.Tick += new EventHandler(timer_Event);
            timer_time = timer_time_limit;

            s_t.Interval = shutter_animation_interval;
            s_t.Tick += new EventHandler(shutter_timer_Event);


            pictureBox2.Parent = panel1;
            /*pictureBox2.Parent = pictureBox1;*/
           /* pictureBox2.Location = new Point((pictureBox1.Width / 2) - (pictureBox2.Width / 2), (pictureBox1.Height / 2) - (pictureBox2.Height / 2));*/
            pictureBox2.Image = null;

           

            take_picture_count_box.Parent = panel1;
            

            pictureBox1.Parent = evfPictureBox1;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Size = new Size(evfPictureBox1.Size.Width, evfPictureBox1.Size.Height);




            /*panel1.BackgroundImage = intro;*/
            /*actionButton5.BackgroundImage = start_up_btn;
            takePictureButton.BackgroundImage = picture_up_btn;*/
            button1.BackgroundImage = back_up_btn;
            button1.Enabled = false;
            button1.Visible = false;

           

            // 사진 저장 폴더 생성
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            _controller.EndEvf();   // 시작시 초기화


            // DS버전이 아닐시 스타트를 따로 해줘야함
            if (!_controller.GetModel().isTypeDS)
            {
                _actionSource.FireEvent(ActionEvent.Command.REMOTESHOOTING_START, IntPtr.Zero);
            }


            // 설정값 불러오기
            db = new DB();

            mirror_option = (db.GetSetting(db_mirror_key) == 1);

            evfPictureBox1.Mirror_mode = mirror_option;

            selected_frame_name = db.GetStringSetting(db_frame_key);

            /*Console.WriteLine("load = " + selected_frame_name);*/

            if (selected_frame_name == null)
            {
                 selected_frame_name = Directory.GetFiles("./ui/", "frame*.png").ToArray()[0];
            }




            axWindowsMediaPlayer1.URL = introVideoUrl;
            axWindowsMediaPlayer1.settings.setMode("loop", true);   // 반복 재생
            axWindowsMediaPlayer1.uiMode = "none";      // 재생바 없애기


            cameraEffectPlayer.URL = cameraEffectSoundPath;
            cameraEffectPlayer.controls.stop(); // url을 넣자마자 자동재생되기 때문에 멈춘상태에서 대기

            cameraCountPlayer.URL = cameraCountSoundPath;
            cameraCountPlayer.controls.stop();

            waitPleasePlayer.URL = waitPleaseSoundPath;
            waitPleasePlayer.controls.stop();

            startSoundPlayer.URL = startSoundPath;
            startSoundPlayer.controls.stop();

            pictureCountPlayer.URL = pictureCountSoundPath;
            pictureCountPlayer.controls.stop();



           

        }


        private void button1_Click(object sender, EventArgs e)
        {
            toIntro();
        }

        

        private void MainWindow_Load(object sender, EventArgs e)
        {
           
           
        }
        

     

        public void Update(Observable from, CameraEvent e)
        {
            CameraEvent.Type eventType = e.GetEventType();

            switch (eventType)
            {
                case CameraEvent.Type.SHUT_DOWN:

                    MessageBox.Show("Camera is disconnected");

                    this.Close();

                    break;

                case CameraEvent.Type.PROPERTY_CHANGED:

                    break;

                case CameraEvent.Type.ANGLEINFO:

                    break;

                case CameraEvent.Type.MOUSE_CURSOR:

                    break;

                case CameraEvent.Type.DOWNLOAD_COMPLETE:
                    /*Console.WriteLine("CameraEvent.Type.DOWNLOAD_COMPLETE");*/
                    /*bool result = evfPictureBox1.ChangeBackImage();
                    if (result)
                    {
                        ChoiceWindow cw = new ChoiceWindow();
                        cw.Owner = this;
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new MethodInvoker(delegate { cw.ShowDialog(); }));
                        }
                        else
                        {
                            cw.ShowDialog();
                        }

                        this.DialogResult = DialogResult.OK;
                        

                        *//* Program.cw.Show();
                         Program.mw.Hide();*//*
                    }*/

                    break;

                default:
                    break;
            }


        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {

            _controller.EndEvf();

            Application.DoEvents();
            _actionSource.FireEvent(ActionEvent.Command.END_ROLLPITCH, IntPtr.Zero);
            _actionSource.FireEvent(ActionEvent.Command.END_EVF, IntPtr.Zero);
            if (!_controller.GetModel().isTypeDS)
            {
                _actionSource.FireEvent(ActionEvent.Command.REMOTESHOOTING_STOP, IntPtr.Zero);
            }
            _actionSource.FireEvent(ActionEvent.Command.PRESS_OFF, IntPtr.Zero);
            _actionSource.FireEvent(ActionEvent.Command.EVF_AF_OFF, IntPtr.Zero);
            _observerList.ForEach(observer => _controller.GetModel().Remove(ref observer));

            t.Stop();
            s_t.Stop();

            cameraEffectPlayer.close();
            cameraEffectPlayer = null;

            cameraCountPlayer.close();
            cameraCountPlayer = null;

            waitPleasePlayer.close();
            waitPleasePlayer = null;

            startSoundPlayer.close();
            startSoundPlayer = null;

            pictureCountPlayer.close();
            pictureCountPlayer = null;


            _actionSource.FireEvent(ActionEvent.Command.CLOSING, IntPtr.Zero);
            _actionListenerList.ForEach(actionListener => _actionSource.RemoveActionListener(ref actionListener));
        }



        private void timer_Event(object sender, System.EventArgs e)
        {
            if (timer_time == 0)    // 0초일때 사진을 찍음
            {

                
                cameraEffectPlayer.controls.play();

             

                s_t.Start();

                timer_time = timer_time_limit;
                pictureBox2.Image = null;
                t.Stop();
                picture_downHandler();

                
                
                return;
            }

            if(timer_time == 3)
            {
                take_picture_count_box.BackgroundImage = take_count_pictures[pictures.Count];    // 현재 찍은 사진 갯수
                cameraCountPlayer.controls.play();
            }

            
            
            
            pictureBox2.Image = flash_count_pictures[timer_time-1];
            timer_time--;
            
        }

        private void picture_downHandler()
        {
            DateTime now = DateTime.Now;
            string fileName = now.ToString("yyyyMMddHHmmssFFF") + ".jpg";

            fileName = Path.Combine(folderPath,fileName);


            // 사이즈 변환가능
            /*Bitmap bitmap = ModifyImage((Bitmap)evfPictureBox1.Image, 520, 380, 72f);*/
            using (Bitmap bitmap = pictureData.CropAndResizeBitmap((Bitmap)evfPictureBox1.Image,Image_Width+ (pictureData.GetPictureWidthDistance()*2),Image_Height+ pictureData.GetPictureHeightDistance()))
            {
                bitmap.Save(fileName, ImageFormat.Jpeg);
            }
               
            /*evfPictureBox1.Image.Save(fileName);*/

            pictures.Add(fileName);

           
           


            if (pictures.Count == TakePicture)
            {
                /*ChoiceWindow cw = new ChoiceWindow(pictures, folderPath , selected_frame, selected_frame_name);
                *//* cw.Owner = this;*//*
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate { cw.ShowDialog(); }));
                }
                else
                {
                    cw.ShowDialog();

                }

               

                this.DialogResult = DialogResult.OK;*/


               



                // 마지막 셔터 효과가 나타나지 않기 때문에
                Delay(1000);



                // 사진 갯수 선택하기
                pictureCountPlayer.controls.play();

                CountWindow cw = new CountWindow();
                cw.Owner = this;
               

                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate { cw.ShowDialog(); }));
                }
                else
                {
                    cw.ShowDialog();

                }


                int selected_picture_count = cw.selected_picture_count;

                

                


                string final_fileName = "Com_" + now.ToString("yyyyMMddHHmmssFFF") + ".jpg";
                string print_picture_name = Path.Combine(folderPath, final_fileName);

                /*Console.WriteLine("print_picture_name = " + print_picture_name);*/

                Image preview_img;

                if (themaType)
                {
                    preview_img =  DownPictureBox_c(print_picture_name, selected_frame);
                }
                else
                {
                    preview_img = DownPictureBox(print_picture_name, selected_frame);
                }

                toIntro();


                waitPleasePlayer.controls.play();

                PreViewWindow pw = new PreViewWindow(print_picture_name,preview_img,selected_picture_count);
                pw.Owner = this;
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate { pw.ShowDialog(); }));
                }
                else
                {        
                     pw.ShowDialog();
                }

               




                cw.Dispose();
                pw.Dispose();


               /* PrintingPicture(print_picture_name, selected_picture_count);*/


                pictures.Clear();

                

                

                /*cw.Dispose();*/
            }
            else
            {

                

                //테마 테두리 있게
                if (themaType)
                {
                    evfPictureBox1.backimg = _frame_bg_list[pictures.Count];

                    
                }



                t.Start();
            }


            GC.Collect();



        }


        


        private void inShutter()
        {

            /*Bitmap canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            int iWidth = canvas.Width;
            int iHeight = canvas.Height;

            using (Graphics g = Graphics.FromImage(canvas))
            {

                SolidBrush black = new SolidBrush(Color.Black);

                Rectangle rectLeft = new Rectangle(0, 0, iWidth / 2 - 100, iHeight);
                Rectangle rectRight = new Rectangle(iWidth / 2 + 100, 0, iWidth, iHeight);
                g.FillRectangle(black, rectLeft);
                g.FillRectangle(black, rectRight);

                pictureBox1.Image = canvas;
            }*/

            pictureBox1.Image = flash_pictures[flash_pictures_count];
            flash_pictures_count++;
        }


        private void outShutter()
        {
            pictureBox1.Image = null;
            flash_pictures_count = 0;
        }


        private void shutter_timer_Event(object sender, System.EventArgs e)
        {
            if (flash_pictures_count < flash_pictures.Length)
            {
                inShutter();
            }
            else
            {
                s_t.Stop();
                outShutter();

            }

        }

        private void PicturesDelete()
        {
            List<FileInfo> files = Directory.GetFiles(folderPath)
            .Select(f => new FileInfo(f))
            .OrderBy(f => f.CreationTime) // 생성일 기준으로 정렬
            .ToList();

            long currentSize = files.Sum(f => f.Length);

            Console.WriteLine("lenght = " + currentSize);

            if (currentSize < maxSizeByte)
            {
                return;
            }


            for (int i = 0; i < deleteFilesCount; i++)
            {
                FileInfo oldestFile = files.First();
                files.RemoveAt(0);

                try
                {
                    File.Delete(oldestFile.FullName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("파일 삭제 오류 발생 : " + ex.Message);
                }
            }
        }

        private void toIntro()
        {
            _controller.EndEvf();
            evfPictureBox1.Visible = false;

            axWindowsMediaPlayer1.Visible = true;
            axWindowsMediaPlayer1.Ctlcontrols.play();

            button1.Visible = false;
            button1.Enabled = false;

            take_picture_count_box.BackgroundImage = null;

            /*panel1.BackgroundImage = intro;*/

            isRunning = false;
        }




        // 순서가 정해진 테마 이미지 다운 이벤트
        private Image DownPictureBox_c(string print_picture_name, Image frame)
        {

            // 반쪽 사진
            Bitmap bitmap = new Bitmap(pictureData.GetPictureWidth() + (int)(pictureData.GetPictureWidthDistance() * 2), (int)(pictureData.GetFirstDistance() + (pictureData.GetPictureHeight() * 4) + (pictureData.GetPictureHeightDistance() * 3) + pictureData.GetLastDistance()));
            Graphics g = Graphics.FromImage(bitmap);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.Half;
            g.Clear(pictureData.GetPictureBGColor());

            // 전체 사진
            Bitmap bitmap2 = new Bitmap(pictureData.GetEntryWidth(), pictureData.GetEntryHeight());
            Graphics g2 = Graphics.FromImage(bitmap2);
            g2.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g2.PixelOffsetMode = PixelOffsetMode.Half;
            g2.Clear(pictureData.GetPictureBGColor());





            float start_x = 0;
            float start_y = pictureData.GetFirstDistance() - pictureData.GetPictureHeightDistanceUpper();



            Image _frame = pictureData.CropAndResizeBitmap((Bitmap)frame, pictureData.GetPictureWidthDistance() * 2 + pictureData.GetPictureWidth(), pictureData.GetFirstDistance() + pictureData.GetPictureHeight() * 4 + pictureData.GetPictureHeightDistance() * 3 + pictureData.GetLastDistance());

            

            Image upperImg = pictureData.ImageCut(_frame, 0, 0, _frame.Width, (int)(pictureData.GetFirstDistance() - pictureData.GetPictureHeightDistanceUpper()));
            Image bottomImg = pictureData.ImageCut(_frame, 0, pictureData.GetFirstDistance() + (pictureData.GetPictureHeight() * 4) + (pictureData.GetPictureHeightDistance() * 3) + pictureData.GetPictureHeightDistanceUpper(), _frame.Width, (int)(_frame.Height));


            //윗부분
            g.DrawImage(upperImg, 0, 0);

            //사진 붙이기
            foreach (string filename in pictures)
            {
                Image i = Image.FromFile(filename);

                g.DrawImage(i, start_x, start_y, i.Width, i.Height);

                start_y = start_y + i.Height;
            }

            //아랫부분
            g.DrawImage(bottomImg, start_x, pictureData.GetFirstDistance() + (pictureData.GetPictureHeight() * 4) + (pictureData.GetPictureHeightDistance() * 3) + pictureData.GetPictureHeightDistanceBottom());



            //왼쪽
            g2.DrawImage(bitmap, pictureData.GetFrameStartX(), pictureData.GetFrameStartY(), bitmap.Width, bitmap.Height + 1);
            //오른쪽
            g2.DrawImage(bitmap, pictureData.GetFrameStartX() + bitmap.Width, pictureData.GetFrameStartY(), bitmap.Width + 3, bitmap.Height + 1);

            bitmap2.Save(print_picture_name);


            Image preview_img = (Image)bitmap.Clone();

            g2.Dispose();
            bitmap2.Dispose();

            g.Dispose();
            bitmap.Dispose();

            return preview_img;

        }

        // 순서가 정해지지않은 테마 이미지 다운 이벤트
        private Image DownPictureBox(string print_picture_name, Image frame)
        {

            // 반쪽 사진
            Bitmap bitmap = new Bitmap(pictureData.GetPictureWidth() + (int)(pictureData.GetPictureWidthDistance() * 2), (int)(pictureData.GetFirstDistance() + (pictureData.GetPictureHeight() * 4) + (pictureData.GetPictureHeightDistance() * 3) + pictureData.GetLastDistance()));
            Graphics g = Graphics.FromImage(bitmap);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.Half;
            g.Clear(pictureData.GetPictureBGColor());

            // 전체 사진
            Bitmap bitmap2 = new Bitmap(pictureData.GetEntryWidth(), pictureData.GetEntryHeight());
            Graphics g2 = Graphics.FromImage(bitmap2);
            g2.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g2.PixelOffsetMode = PixelOffsetMode.Half;
            g2.Clear(pictureData.GetPictureBGColor());



       

            float start_x = pictureData.GetPictureWidthDistance();
            // 글씨가 아래에 있는 경우 
            float start_y = pictureData.GetFirstDistanceStartY();       // + 임의값 : 오차값으로인한 밀림


            //사진 붙이기
            foreach (string filename in pictures)
            {
                Image i = Image.FromFile(filename);

                g.DrawImage(pictureData.CropAndResizeBitmap((Bitmap)i, pictureData.GetPictureWidth(), pictureData.GetPictureHeight()), start_x, start_y);

                start_y = start_y + pictureData.GetPictureHeight() + pictureData.GetPictureHeightDistance();
            }


            g.DrawImage(pictureData.CropAndResizeBitmap((Bitmap)frame, pictureData.GetPictureWidthDistance() * 2 + pictureData.GetPictureWidth(), pictureData.GetFirstDistance() + pictureData.GetPictureHeight() * 4 + pictureData.GetPictureHeightDistance() * 3 + pictureData.GetLastDistance()), 0, 0);


            Console.WriteLine(bitmap.Width + ", "+ bitmap.Height);


            //왼쪽
            g2.DrawImage(bitmap, pictureData.GetFrameStartX(), pictureData.GetFrameStartY(), bitmap.Width, bitmap.Height + 1);
            //오른쪽
            g2.DrawImage(bitmap, pictureData.GetFrameStartX() + bitmap.Width, pictureData.GetFrameStartY(), bitmap.Width + 3, bitmap.Height + 1);

            bitmap2.Save(print_picture_name);


            Image preview_img = (Image)bitmap.Clone();


            g2.Dispose();
            bitmap2.Dispose();

            g.Dispose();
            bitmap.Dispose();

            return preview_img;

        }

        /*private void PrintingPicture(string printImagePath, int count)
        {

            

            using (PrintDocument pd = new PrintDocument())
            {
                pd.PrintPage += new PrintPageEventHandler((s, e) => PrintDocument_PrintPage(s,e, printImagePath , count));
                pd.BeginPrint += new PrintEventHandler((s,e) =>  PrintDocument_BeginPrint(s,e));
                pd.EndPrint += new PrintEventHandler((s, e) => PrintDocument_EndPrint(s, e));
                pd.DefaultPageSettings.Landscape = true;

                try
                {
                    pd.Print();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    this.Dispose();
                }

            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e, string printImagePath, int count)
        {
            // 이미지 로드
            Image image = Image.FromFile(printImagePath);
            

            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            // 이미지 크기 조정 (옵션)
            e.Graphics.DrawImage(image, e.PageBounds);

            printCurrentPage++;

            if(printCurrentPage < count)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }

        }

        private void PrintDocument_BeginPrint(object sender, PrintEventArgs e)
        {
            Console.WriteLine("BeginPrint");
        }

        private void PrintDocument_EndPrint(object sender, PrintEventArgs e)
        {
            Console.WriteLine("EndPrint");

        }*/


        private static DateTime Delay(int MS)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }

            return DateTime.Now;
        }




        private void evfPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

       /* private void actionButton5_MouseDown(object sender, MouseEventArgs e)
        {
            actionButton5.BackgroundImage = start_down_btn;
        }

        private void actionButton5_MouseUp(object sender, MouseEventArgs e)
        {
            actionButton5.BackgroundImage = start_up_btn;
        }

        private void takePictureButton_MouseDown(object sender, MouseEventArgs e)
        {
            takePictureButton.BackgroundImage = picture_down_btn;
        }

        private void takePictureButton_MouseUp(object sender, MouseEventArgs e)
        {
            takePictureButton.BackgroundImage = picture_up_btn;
        }*/

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            button1.BackgroundImage = back_down_btn;
        }
        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            button1.BackgroundImage = back_up_btn;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == (Keys.Enter))
            {
                if(!isRunning)
                {


                    isRunning = true;

                    take_picture_count_box.BackgroundImage = take_count_pictures[0];

                    selected_frame = Image.FromFile(selected_frame_name);

                    themaType = pictureData.ThemaType(selected_frame_name);

                    if (themaType)
                    {

                        // 테두리 이미지 넣기
                        _frame_bg_list.Clear(); //초기화

                        _frame_bg_list.Add(pictureData.ImageCut(selected_frame, 0, pictureData.GetFrameFirstDistance() - pictureData.GetFramePictureHeightDistanceUpper(), selected_frame.Width, (int)(pictureData.GetFramePictureHeight() + (pictureData.GetFramePictureHeightDistance()))));
                        _frame_bg_list.Add(pictureData.ImageCut(selected_frame, 0, pictureData.GetFrameFirstDistance() + pictureData.GetFramePictureHeight() - pictureData.GetFramePictureHeightDistanceUpper() + pictureData.GetFramePictureHeightDistance(), selected_frame.Width, (int)(pictureData.GetFramePictureHeight() + (pictureData.GetFramePictureHeightDistance()))));
                        _frame_bg_list.Add(pictureData.ImageCut(selected_frame, 0, pictureData.GetFrameFirstDistance() + (pictureData.GetFramePictureHeight() * 2) + pictureData.GetFramePictureHeightDistanceUpper() + pictureData.GetFramePictureHeightDistance(), selected_frame.Width, (int)(pictureData.GetFramePictureHeight() + (pictureData.GetFramePictureHeightDistance()))));
                        _frame_bg_list.Add(pictureData.ImageCut(selected_frame, 0, pictureData.GetFrameFirstDistance() + (pictureData.GetFramePictureHeight() * 3) + pictureData.GetFramePictureHeightDistanceUpper() + (pictureData.GetFramePictureHeightDistance() * 2), selected_frame.Width, (int)(pictureData.GetFramePictureHeight() + (pictureData.GetFramePictureHeightDistance()))));


                        evfPictureBox1.backimg = _frame_bg_list[0];

                        evfPictureBox1.selected_ThemaType = true;


                    }
                    else
                    {
                        evfPictureBox1.selected_ThemaType = false;
                    }


                    axWindowsMediaPlayer1.Ctlcontrols.stop();
                    axWindowsMediaPlayer1.Visible = false;


                    

                    PicturesDelete();

                    panel1.BackgroundImage = bg;

                    /*actionButton5.Visible = false;
                    actionButton5.Enabled = false;

                    

                    takePictureButton.Visible = false;
                    takePictureButton.Enabled = false;*/


                    evfPictureBox1.Mirror_mode = mirror_option;

                    evfPictureBox1.Visible = true;

                    _controller.StartEvf();     // 영상 시작


                    startSoundPlayer.controls.play();

                    t.Start();
                }

               

                

            }
            else if(e.KeyData == (Keys.S))
            {

                FrameWindow fw = new FrameWindow(selected_frame_name,mirror_option);
                fw.Owner = this;
               
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate { fw.ShowDialog(); }));
                }
                else
                {
                    fw.ShowDialog();

                }


                if (fw.selected_picture_name != null)
                {

                    selected_frame_name = fw.selected_picture_name;
                  
                    db.SaveSettingString(db_frame_key, selected_frame_name);
             
                   
                }


                if (mirror_option != null)
                {
                    mirror_option = fw.mirror_option;
                    if (mirror_option)
                    {
                        db.SaveSetting(db_mirror_key, 1);
                    }
                    else
                    {
                        db.SaveSetting(db_mirror_key, 0);
                    }
                    
                }


                fw.Dispose();

                GC.Collect();
            }

        }
    }
}
