using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnapshotsOfLifeEx02
{
    public partial class CountWindow : Form
    {

        private Image bg = Image.FromFile("./ui/background.png");
        private Image uncomplete_btn_down_img = Image.FromFile("./ui/uncompletebutton_down.png");
        private Image uncomplete_btn_up_img = Image.FromFile("./ui/uncompletebutton_up.png");
        private Image complete_btn_down_img = Image.FromFile("./ui/completebutton_down.png");
        private Image complete_btn_up_img = Image.FromFile("./ui/completebutton_up.png");

        private Image print_count_2_img = Image.FromFile("./ui/print_count_2.png");
        private Image print_count_4_img = Image.FromFile("./ui/print_count_4.png");
        private Image print_count_6_img = Image.FromFile("./ui/print_count_6.png");
        private Image print_count_8_img = Image.FromFile("./ui/print_count_8.png");

        private Color selectedColor = Color.FromArgb(255, 205, 18); // 선택될시 테두리 색
        private int penWidth = 6;   // 테두리 두께

        public int selected_picture_count { get; set; }         // 리턴값



        public CountWindow()
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            doubleBufferPanel1.BackgroundImage = bg;
            selected_picture_count = 0;
            next.BackgroundImage = uncomplete_btn_up_img;

            pictureBox1.Parent = doubleBufferPanel1;
            pictureBox1.Image = print_count_2_img;

            pictureBox2.Parent = doubleBufferPanel1;
            pictureBox2.Image = print_count_4_img;

            pictureBox3.Parent = doubleBufferPanel1;
            pictureBox3.Image = print_count_6_img;

            pictureBox4.Parent = doubleBufferPanel1;
            pictureBox4.Image = print_count_8_img;

            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void PictureBoxSelected_First(PictureBox selectedPB)
        {  

            next.BackgroundImage = complete_btn_up_img;

            Pen pen = new Pen(selectedColor);
            pen.Width = penWidth;

            using (Graphics g = (selectedPB).CreateGraphics())
            {
                // 이미지의 원래 크기
                int originalWidth = (selectedPB).Image.Width;
                int originalHeight = (selectedPB).Image.Height;

                // 이미지 비율 계산
                float originalAspectRatio = (float)originalWidth / originalHeight;
                float pictureBoxAspectRatio = (float)(selectedPB).Width / (selectedPB).Height;

                int zoomedWidth, zoomedHeight;
                int startx, starty;

                if (originalAspectRatio > pictureBoxAspectRatio)
                {
                    // 너비가 더 긴 경우
                    zoomedWidth = (selectedPB).Width;
                    zoomedHeight = (int)((selectedPB).Width / originalAspectRatio);
                    startx = 0;
                    starty = ((selectedPB).Height - zoomedHeight) / 2;
                }
                else
                {
                    // 높이가 더 긴 경우
                    zoomedHeight = (selectedPB).Height;
                    zoomedWidth = (int)((selectedPB).Height * originalAspectRatio);
                    startx = ((selectedPB).Width - zoomedWidth) / 2;
                    starty = 0;
                }


                g.DrawRectangle(pen, startx, starty, zoomedWidth, zoomedHeight);

            }

        }

        private void CountWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            bg = null;
            uncomplete_btn_down_img = null;
            uncomplete_btn_up_img = null;
            complete_btn_down_img = null;
            complete_btn_up_img = null;
        }

        private void next_MouseClick(object sender, MouseEventArgs e)
        {
            if ( selected_picture_count != 0)
            {
                /*this.Visible = false;*/
                this.Dispose();
            }
        }

        private void next_MouseDown(object sender, MouseEventArgs e)
        {
            if (selected_picture_count == 0)
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
            if (selected_picture_count == 0)
            {
                next.BackgroundImage = uncomplete_btn_up_img;
            }
            else
            {
                next.BackgroundImage = complete_btn_up_img;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(selected_picture_count == 1)
            {
                selected_picture_count = 0;
                next.BackgroundImage = uncomplete_btn_up_img;
                pictureBox1.Image = print_count_2_img;
            }
            else
            {
                selected_picture_count = 1;
                PictureBoxSelected_First(pictureBox1);
                pictureBox2.Image = print_count_4_img;
                pictureBox3.Image = print_count_6_img;
                pictureBox4.Image = print_count_8_img;
                next.BackgroundImage = complete_btn_up_img;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (selected_picture_count == 2)
            {
                selected_picture_count = 0;
                next.BackgroundImage = uncomplete_btn_up_img;
                pictureBox2.Image = print_count_4_img;
            }
            else
            {
                selected_picture_count = 2;
                PictureBoxSelected_First(pictureBox2);
                pictureBox1.Image = print_count_2_img;
                pictureBox3.Image = print_count_6_img;
                pictureBox4.Image = print_count_8_img;
                next.BackgroundImage = complete_btn_up_img;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (selected_picture_count == 3)
            {
                selected_picture_count = 0;
                next.BackgroundImage = uncomplete_btn_up_img;
                pictureBox3.Image = print_count_6_img;
            }
            else
            {
                selected_picture_count = 3;
                PictureBoxSelected_First(pictureBox3);
                pictureBox2.Image = print_count_4_img;
                pictureBox1.Image = print_count_2_img;
                pictureBox4.Image = print_count_8_img;
                next.BackgroundImage = complete_btn_up_img;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (selected_picture_count == 4)
            {
                selected_picture_count = 0;
                next.BackgroundImage = uncomplete_btn_up_img;
                pictureBox4.Image = print_count_8_img;
            }
            else
            {
                selected_picture_count = 4;
                PictureBoxSelected_First(pictureBox4);
                pictureBox2.Image = print_count_4_img;
                pictureBox3.Image = print_count_6_img;
                pictureBox1.Image = print_count_2_img;
                next.BackgroundImage = complete_btn_up_img;
            }
        }
    }
}
