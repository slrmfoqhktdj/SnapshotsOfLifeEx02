using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;
using System.Linq;

namespace SnapshotsOfLifeEx02
{
    public partial class ChoiceWindow : Form
    {

        private Color selectedColor = Color.FromArgb(255, 205, 18);

        private bool s_box1 = false, s_box2 = false, s_box3 = false, s_box4 = false, s_box5 = false, s_box6 = false, s_box7 = false, s_box8 = false;

        private int penWidth = 6;

        private List<string> selectedPictures = new List<string>() { }; // 선택된 사진 리스트

        private List<string> pictures = new List<string>() { };     // 넘겨받은 사진 리스트

        private Image frame;    // 넘겨받은 테마
        private string frame_name;    // 넘겨받은 테마 이름

        private int limit_select = 4;

        private bool themaType = false;    // 순서가 정해진 테마인지 아닌지  false: 안정해진 테마, true : 정해진 테마

        private PictureData pictureData = new PictureData();    // 사진 규격 데이터

        private string folderPath = "";

        /*private string print_picture_name = ""; // 프린트할 사진 이름*/

        private Image bg = Image.FromFile("./ui/background.png");

        private Image uncomplete_btn_down_img = Image.FromFile("./ui/uncompletebutton_down.png");

        private Image uncomplete_btn_up_img = Image.FromFile("./ui/uncompletebutton_up.png");

        private Image complete_btn_down_img = Image.FromFile("./ui/completebutton_down.png");

        private Image complete_btn_up_img = Image.FromFile("./ui/completebutton_up.png");

        private Image[] selected_num = new Image[] { Image.FromFile("./ui/selected_num_1.png"), Image.FromFile("./ui/selected_num_2.png"), Image.FromFile("./ui/selected_num_3.png"), Image.FromFile("./ui/selected_num_4.png") };


        private void ChoiceWindow_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void next_MouseDown(object sender, MouseEventArgs e)
        {

            if (selectedPictures.Count < limit_select)
            {
                next.BackgroundImage = uncomplete_btn_down_img;
            }
            else
            {
                next.BackgroundImage = complete_btn_down_img;
            }
        }

        private void next_MouseUp(object sender, MouseEventArgs e)
        {

            if (selectedPictures.Count < limit_select)
            {
                next.BackgroundImage = uncomplete_btn_up_img;
            }
            else
            {
                next.BackgroundImage = complete_btn_up_img;
            }
        }


        public ChoiceWindow(List<string> pictures, string folderPath, Image frame, string frame_name)
        {
            InitializeComponent();

            this.pictures = pictures;
            this.folderPath = folderPath;
            this.frame = frame;
            this.frame_name = frame_name;
            themaType = pictureData.ThemaType(this.frame_name);

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;

            pictureBox1.Name = this.pictures[0];
            pictureBox2.Name = this.pictures[1];
            pictureBox3.Name = this.pictures[2];
            pictureBox4.Name = this.pictures[3];
            pictureBox5.Name = this.pictures[4];
            pictureBox6.Name = this.pictures[5];
            pictureBox7.Name = this.pictures[6];
            pictureBox8.Name = this.pictures[7];

            pictureBox1.Image = Image.FromFile(pictureBox1.Name);
            pictureBox2.Image = Image.FromFile(pictureBox2.Name);
            pictureBox3.Image = Image.FromFile(pictureBox3.Name);
            pictureBox4.Image = Image.FromFile(pictureBox4.Name);
            pictureBox5.Image = Image.FromFile(pictureBox5.Name);
            pictureBox6.Image = Image.FromFile(pictureBox6.Name);
            pictureBox7.Image = Image.FromFile(pictureBox7.Name);
            pictureBox8.Image = Image.FromFile(pictureBox8.Name);



            panel1.BackgroundImage = bg;
            next.BackgroundImage = uncomplete_btn_up_img;



            if (themaType)
            {
                // 순서가 정해진 테마

                pictureBox1.Click += (s, e) => ClickPictureBox_c(s, e, ref pictureBox1, ref pictureBox2);
                pictureBox2.Click += (s, e) => ClickPictureBox_c(s, e, ref pictureBox2, ref pictureBox1);
                pictureBox3.Click += (s, e) => ClickPictureBox_c(s, e, ref pictureBox3, ref pictureBox4);
                pictureBox4.Click += (s, e) => ClickPictureBox_c(s, e, ref pictureBox4, ref pictureBox3);
                pictureBox5.Click += (s, e) => ClickPictureBox_c(s, e, ref pictureBox5, ref pictureBox6);
                pictureBox6.Click += (s, e) => ClickPictureBox_c(s, e, ref pictureBox6, ref pictureBox5);
                pictureBox7.Click += (s, e) => ClickPictureBox_c(s, e, ref pictureBox7, ref pictureBox8);
                pictureBox8.Click += (s, e) => ClickPictureBox_c(s, e, ref pictureBox8, ref pictureBox7);
            }
            else
            {
                // 순서가 없는 민짜 테마

                pictureBox1.Click += (s, e) => ClickPictureBox(s, e, ref pictureBox1, ref pictureBox9, ref s_box1);
                pictureBox2.Click += (s, e) => ClickPictureBox(s, e, ref pictureBox2, ref pictureBox10, ref s_box2);
                pictureBox3.Click += (s, e) => ClickPictureBox(s, e, ref pictureBox3, ref pictureBox11, ref s_box3);
                pictureBox4.Click += (s, e) => ClickPictureBox(s, e, ref pictureBox4, ref pictureBox12, ref s_box4);
                pictureBox5.Click += (s, e) => ClickPictureBox(s, e, ref pictureBox5, ref pictureBox13, ref s_box5);
                pictureBox6.Click += (s, e) => ClickPictureBox(s, e, ref pictureBox6, ref pictureBox14, ref s_box6);
                pictureBox7.Click += (s, e) => ClickPictureBox(s, e, ref pictureBox7, ref pictureBox15, ref s_box7);
                pictureBox8.Click += (s, e) => ClickPictureBox(s, e, ref pictureBox8, ref pictureBox16, ref s_box8);
            }


            /*g.Clear(picture_bg_color);   // 흰색 배경*/
            // 배경 붙이기 (프린터와의 문제로 배경이 약간씩 남아버림)
            /*string[] split_frame_name = frame_name.Split('/');
            string bg_frame = string.Join("/", split_frame_name[0], split_frame_name[1], "bg_" + split_frame_name[2]);
            Image bg_frame_img = Image.FromFile(bg_frame);*/

        }

        private void ChoiceWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            pictureBox1.Dispose();
            pictureBox2.Dispose();
            pictureBox3.Dispose();
            pictureBox4.Dispose();
            pictureBox5.Dispose();
            pictureBox6.Dispose();
            pictureBox7.Dispose();
            pictureBox8.Dispose();
            pictureBox9.Dispose();
            pictureBox10.Dispose();
            pictureBox11.Dispose();
            pictureBox12.Dispose();
            pictureBox13.Dispose();
            pictureBox14.Dispose();
            pictureBox15.Dispose();
            pictureBox16.Dispose();
        }

        // 순서가 정해진 테마 클릭이벤트
        private void ClickPictureBox_c(object sender, EventArgs e, ref PictureBox box_m, ref PictureBox box_o)
        {

            box_o.Image = Image.FromFile(box_o.Name);


            OnSelectedDraw(ref box_m);

            selectedPictures.Add(box_m.Name);
            selectedPictures.Remove(box_o.Name);


            if (selectedPictures.Count < limit_select)
            {
                next.BackgroundImage = uncomplete_btn_up_img;
            }
            else
            {
                next.BackgroundImage = complete_btn_up_img;
            }


            selectedPictures = selectedPictures.Distinct().ToList();
            selectedPictures.Sort();

        }

        // 순서가 없는 테마 클릭이벤트
        private void ClickPictureBox(object sender, EventArgs e, ref PictureBox box_m, ref PictureBox box_n, ref bool s_bool)
        {


            if (!s_bool) // 선택이 안되어 있을때
            {

                if (selectedPictures.Count == limit_select)
                {
                    return;
                }

                OnSelectedDraw(ref box_m);
                selectedPictures.Add(box_m.Name);
                box_n.Image = selected_num[selectedPictures.Count - 1];

            }
            else // 선택이 되어 있을때
            {
                box_m.Image = Image.FromFile(box_m.Name);
                selectedPictures.Remove(box_m.Name);
                box_n.Image = null;     // 번호 아이콘 삭제
                OnSelectedDrawNum();    // 번호 아이콘 순서대로 재배열
            }

            s_bool = !s_bool;

            if (selectedPictures.Count < limit_select)
            {
                next.BackgroundImage = uncomplete_btn_up_img;
            }
            else
            {
                next.BackgroundImage = complete_btn_up_img;
            }


        }

        // 순서가 정해진 테마 이미지 다운 이벤트
        private Bitmap DownPictureBox_c(string print_picture_name)
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
            foreach (string filename in selectedPictures)
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


            g2.Dispose();
            bitmap2.Dispose();

            
           

            return bitmap;

        }

        // 순서가 정해지지않은 테마 이미지 다운 이벤트
        private Bitmap DownPictureBox(string print_picture_name)
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
            float start_y = pictureData.GetFirstDistance();


            g.DrawImage(pictureData.CropAndResizeBitmap((Bitmap)frame, pictureData.GetPictureWidthDistance() * 2 + pictureData.GetPictureWidth(), pictureData.GetFirstDistance() + pictureData.GetPictureHeight() * 4 + pictureData.GetPictureHeightDistance() * 3 + pictureData.GetLastDistance()), 0, 0);

            //사진 붙이기
            foreach (string filename in selectedPictures)
            {
                Image i = Image.FromFile(filename);

                g.DrawImage(pictureData.CropAndResizeBitmap((Bitmap)i, pictureData.GetPictureWidth(), pictureData.GetPictureHeight()), start_x, start_y);

                start_y = start_y + pictureData.GetPictureHeight() + pictureData.GetPictureHeightDistance();
            }


            //왼쪽
            g2.DrawImage(bitmap, pictureData.GetFrameStartX(), pictureData.GetFrameStartY(), bitmap.Width, bitmap.Height + 1);
            //오른쪽
            g2.DrawImage(bitmap, pictureData.GetFrameStartX() + bitmap.Width, pictureData.GetFrameStartY(), bitmap.Width + 3, bitmap.Height + 1);

            bitmap2.Save(print_picture_name);


            g2.Dispose();
            bitmap2.Dispose();

            


            return bitmap;

        }


        private void next_Click(object sender, EventArgs e)
        {

            foreach (string m in selectedPictures)
            {
                Console.WriteLine(m);
            }





            if (selectedPictures.Count < limit_select)
            {
                return;
            }

            DateTime now = DateTime.Now;
            string fileName = "Com_" + now.ToString("yyyyMMddHHmmssFFF") + ".jpg";
            string print_picture_name = Path.Combine(folderPath, fileName);

            PreViewWindow pw = null;


            if (themaType)
            {
                /*pw = new PreViewWindow(print_picture_name, DownPictureBox_c(print_picture_name));*/
            }
            else
            {
        /*        pw = new PreViewWindow(print_picture_name, DownPictureBox(print_picture_name));*/
            }

            


            
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate { pw.ShowDialog(); }));
            }
            else
            {
                try
                {
                    pw.ShowDialog();
                }
                catch (Exception e1)
                {
                    Console.WriteLine(e1);
                }


            }


            

            this.Dispose();



        }




        private void OnSelectedDraw(ref PictureBox box)
        {

            Pen pen = new Pen(selectedColor);
            pen.Width = penWidth;

            /*using (Graphics g = box.CreateGraphics())
            {
                g.DrawRectangle(pen, 0, 0, box.Width , box.Height );
            }*/

            using (Graphics g = box.CreateGraphics())
            {
                // 이미지의 원래 크기
                int originalWidth = box.Image.Width;
                int originalHeight = box.Image.Height;

                // 이미지 비율 계산
                float originalAspectRatio = (float)originalWidth / originalHeight;
                float pictureBoxAspectRatio = (float)box.Width / box.Height;

                int zoomedWidth, zoomedHeight;
                int startx, starty;

                if (originalAspectRatio > pictureBoxAspectRatio)
                {
                    // 너비가 더 긴 경우
                    zoomedWidth = box.Width;
                    zoomedHeight = (int)(box.Width / originalAspectRatio);
                    startx = 0;
                    starty = (box.Height - zoomedHeight) / 2;
                }
                else
                {
                    // 높이가 더 긴 경우
                    zoomedHeight = box.Height;
                    zoomedWidth = (int)(box.Height * originalAspectRatio);
                    startx = (box.Width - zoomedWidth) / 2;
                    starty = 0;
                }

                g.DrawRectangle(pen, startx, starty, zoomedWidth, zoomedHeight);
            }

        }

        private void OnSelectedDrawNum()
        {

            if (selectedPictures.Count == 0)
            {
                return;
            }

            List<PictureBox> pl = new List<PictureBox>() { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8 };
            List<PictureBox> pln = new List<PictureBox>() { pictureBox9, pictureBox10, pictureBox11, pictureBox12, pictureBox13, pictureBox14, pictureBox15, pictureBox16 };

            foreach ((string, int) n in selectedPictures.Select((value, index) => (value, index)))
            {
                foreach ((PictureBox, int) pli in pl.Select((value, index) => (value, index)))
                {
                    if (pli.Item1.Name == n.Item1)
                    {
                        pln[pli.Item2].Image = selected_num[n.Item2];
                        break;
                    }
                }
            }


        }


    }
}
