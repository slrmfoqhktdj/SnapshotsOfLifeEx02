
namespace SnapshotsOfLifeEx02
{
    partial class MainWindow
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.panel1 = new SnapshotsOfLifeEx02.DoubleBufferPanel();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.actionButton5 = new SnapshotsOfLifeEx02.ActionButton();
            this.takePictureButton = new SnapshotsOfLifeEx02.ActionButton();
            this.evfPictureBox1 = new SnapshotsOfLifeEx02.EvfPictureBox();
            this.take_picture_count_box = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evfPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.take_picture_count_box)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.axWindowsMediaPlayer1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.actionButton5);
            this.panel1.Controls.Add(this.takePictureButton);
            this.panel1.Controls.Add(this.evfPictureBox1);
            this.panel1.Controls.Add(this.take_picture_count_box);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1080, 1920);
            this.panel1.TabIndex = 16;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(0, 0);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(1080, 1920);
            this.axWindowsMediaPlayer1.TabIndex = 18;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(33, 535);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1015, 695);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Location = new System.Drawing.Point(390, 1350);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(300, 300);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(56, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 75);
            this.button1.TabIndex = 16;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
            this.button1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button1_MouseUp);
            // 
            // actionButton5
            // 
            this.actionButton5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.actionButton5.BackColor = System.Drawing.Color.Transparent;
            this.actionButton5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.actionButton5.Command = SnapshotsOfLifeEx02.ActionEvent.Command.NONE;
            this.actionButton5.Enabled = false;
            this.actionButton5.FlatAppearance.BorderSize = 0;
            this.actionButton5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.actionButton5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.actionButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.actionButton5.ForeColor = System.Drawing.Color.Transparent;
            this.actionButton5.Location = new System.Drawing.Point(449, 1686);
            this.actionButton5.Name = "actionButton5";
            this.actionButton5.Size = new System.Drawing.Size(168, 70);
            this.actionButton5.TabIndex = 8;
            this.actionButton5.UseVisualStyleBackColor = false;
            this.actionButton5.Visible = false;
            // 
            // takePictureButton
            // 
            this.takePictureButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.takePictureButton.BackColor = System.Drawing.Color.Transparent;
            this.takePictureButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.takePictureButton.Command = SnapshotsOfLifeEx02.ActionEvent.Command.NONE;
            this.takePictureButton.Enabled = false;
            this.takePictureButton.FlatAppearance.BorderSize = 0;
            this.takePictureButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.takePictureButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.takePictureButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.takePictureButton.Location = new System.Drawing.Point(449, 1686);
            this.takePictureButton.Name = "takePictureButton";
            this.takePictureButton.Size = new System.Drawing.Size(168, 70);
            this.takePictureButton.TabIndex = 7;
            this.takePictureButton.UseVisualStyleBackColor = false;
            this.takePictureButton.Visible = false;
            // 
            // evfPictureBox1
            // 
            this.evfPictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.evfPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.evfPictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.evfPictureBox1.backimg = null;
            this.evfPictureBox1.Location = new System.Drawing.Point(33, 535);
            this.evfPictureBox1.Mirror_mode = false;
            this.evfPictureBox1.Name = "evfPictureBox1";
            this.evfPictureBox1.selected_ThemaType = false;
            this.evfPictureBox1.Size = new System.Drawing.Size(1015, 695);
            this.evfPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.evfPictureBox1.TabIndex = 10;
            this.evfPictureBox1.TabStop = false;
            this.evfPictureBox1.Click += new System.EventHandler(this.evfPictureBox1_Click);
            // 
            // take_picture_count_box
            // 
            this.take_picture_count_box.BackColor = System.Drawing.Color.Transparent;
            this.take_picture_count_box.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.take_picture_count_box.Dock = System.Windows.Forms.DockStyle.Fill;
            this.take_picture_count_box.Location = new System.Drawing.Point(0, 0);
            this.take_picture_count_box.Name = "take_picture_count_box";
            this.take_picture_count_box.Size = new System.Drawing.Size(1080, 1920);
            this.take_picture_count_box.TabIndex = 9;
            this.take_picture_count_box.TabStop = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 1920);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evfPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.take_picture_count_box)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EvfPictureBox evfPictureBox1;
        private ActionButton actionButton5;
        private ActionButton takePictureButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DoubleBufferPanel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.PictureBox take_picture_count_box;
    }
}

