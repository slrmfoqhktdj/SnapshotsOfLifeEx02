using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Printing;
using System.Threading.Tasks;

namespace SnapshotsOfLifeEx02
{
    public partial class PreViewWindow : Form
    {

        private string printImagePath = "";
        private int count = 1;              // 넘겨 받은 프린트 해야할 페이지 수
        private int printCurrentPage = 0;   // 현재 프린트 중인 패이지 수
        private Timer t = new Timer();  // 창 유지 타이머
        private int timer_time; // 현재 카운트 타이머 시간
        private PictureData pictureData = new PictureData();    // 사진 규격 데이터
        private int timer_time_limit = 13;  // 카운트 타이머 초 수 (13초 정도)

        private Image bg = Image.FromFile("./ui/background_preview.png");

        private Image preview_text = Image.FromFile("./ui/preview_text.png");

        private string preview_text_origin = ".";
        private string preview_text_set = "";

       /* private string printName = "DS-RX1";*/

        public PreViewWindow(string printImagePath, Image previewImage, int count)
        {
            InitializeComponent();

            Console.WriteLine(printImagePath);

            try
            {
                this.printImagePath = printImagePath;
                this.count = count;
               

                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Image = previewImage;

                pictureBox2.Image = preview_text;

                /*previewImage.Dispose();*/

                panel1.BackgroundImage = bg;

                label1.Text = preview_text_set;

                timer_time_limit = pictureData.GetTimerTimeLimit() * count;


                t.Interval = 1000;
                t.Tick += new EventHandler(timer_Event);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }



            t.Start();





            // 프린트
            PrintingPicture();


        }

        private void PrintingPicture()
        {
            using (PrintDocument pd = new PrintDocument())
            {
                pd.PrintPage += new PrintPageEventHandler((s, e) => PrintDocument_PrintPage(s, e, printImagePath, count));
                
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
    
            e.PageSettings.Margins = new Margins(0,0,0,0);
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            // 이미지 크기 조정 (옵션)
            e.Graphics.DrawImage(image, e.PageBounds);

            printCurrentPage++;

            

            if (printCurrentPage < count)
            {
                
                e.HasMorePages = true;
            }
            else
            {
                
                e.HasMorePages = false;
            }



/*
            PrintServer printServer = new PrintServer();

            

            printQueue = printServer.GetPrintQueue(printName); // 프린터 이름 설정

            


            Console.WriteLine("상태 : " + printQueue.QueueStatus);
            Console.WriteLine("큐 리스트 : " + printQueue.NumberOfJobs);
            
            

            *//*   // 프린터 상태 확인
               if (printQueue.IsPrinting)
               {
                   Console.WriteLine("프린터가 바쁩니다.");
               }
               else
               {
                   Console.WriteLine("프린터가 준비되었습니다.");
               }*//*


            collection = printQueue.GetPrintJobInfoCollection();*/

           


            

        }

       /* PrintJobInfoCollection collection;
        PrintQueue printQueue;
        PrintQueue localPrintQueue;

        LocalPrintServer localPrintServer;*/

        /*private void CheckPrinterStatus()
        {

            *//*using (PrintServer printServer = new PrintServer())
            {
                PrintQueue printQueue = printServer.GetPrintQueue(printName); // 프린터 이름 설정


                printQueue.Refresh();
                Console.WriteLine("상태 : " + printQueue.QueueStatus);   
                Console.WriteLine("큐 리스트 : "+ printQueue.NumberOfJobs);
              




                collection = printQueue.GetPrintJobInfoCollection();*//*

            printQueue.Refresh();

            localPrintServer = new LocalPrintServer();
            localPrintQueue = localPrintServer.DefaultPrintQueue;

            Console.WriteLine("isBusy : " + localPrintQueue.IsBusy);
            Console.WriteLine("IsPrinting : " + localPrintQueue.IsPrinting);
            Console.WriteLine("QueueStatus : " + localPrintQueue.QueueStatus);
            Console.WriteLine("NumberOfJobs : " + localPrintQueue.NumberOfJobs);
            Console.WriteLine("IsBidiEnabled) : " + printQueue.IsBidiEnabled);
            Console.WriteLine("IsIOActive) : " + printQueue.IsIOActive);
            Console.WriteLine("IsNotAvailable) : " + printQueue.IsNotAvailable);
            Console.WriteLine("IsOffline) : " + printQueue.IsOffline);

            *//*foreach (PrintSystemJobInfo item in collection)
            {
                Console.WriteLine("isCompleted : " + item.IsCompleted);
                Console.WriteLine("IsPrinted : " + item.IsPrinted);
                Console.WriteLine("IsPrinting : " + item.IsPrinting);
                Console.WriteLine("item.JobStatus : " + item.JobStatus);                            
            }*/


            /* }*/


            /*using (PrintSystemJobInfo psjInfo = new PrintSystemJobInfo())
            {

            }
*//*

        }*/


 





        private void timer_Event(object sender, System.EventArgs e)
        {
            if (timer_time == timer_time_limit)    
            {
                timer_time = 0;   
                t.Stop();
                this.Dispose();



                return;
            }

            /*CheckPrinterStatus();*/

            /*Console.WriteLine("timer time : "+timer_time);*/

            timer_time++;

            if (timer_time % 5 == 0)
            {
                preview_text_set = "";
                label1.Text = preview_text_set;
            }
            else
            {
                preview_text_set = preview_text_set + preview_text_origin;
                label1.Text = preview_text_set;
            }

            

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PreViewWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            printCurrentPage = 0;
            preview_text_set = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
