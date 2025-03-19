
namespace SnapshotsOfLifeEx02
{
    partial class CountWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.doubleBufferPanel1 = new SnapshotsOfLifeEx02.DoubleBufferPanel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.next = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.doubleBufferPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // doubleBufferPanel1
            // 
            this.doubleBufferPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.doubleBufferPanel1.Controls.Add(this.pictureBox4);
            this.doubleBufferPanel1.Controls.Add(this.label1);
            this.doubleBufferPanel1.Controls.Add(this.pictureBox3);
            this.doubleBufferPanel1.Controls.Add(this.next);
            this.doubleBufferPanel1.Controls.Add(this.pictureBox2);
            this.doubleBufferPanel1.Controls.Add(this.pictureBox1);
            this.doubleBufferPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.doubleBufferPanel1.Location = new System.Drawing.Point(0, 0);
            this.doubleBufferPanel1.Name = "doubleBufferPanel1";
            this.doubleBufferPanel1.Size = new System.Drawing.Size(1080, 1920);
            this.doubleBufferPanel1.TabIndex = 0;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Location = new System.Drawing.Point(360, 1150);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(360, 132);
            this.pictureBox4.TabIndex = 16;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("문체부 제목 바탕체", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(194, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(695, 40);
            this.label1.TabIndex = 11;
            this.label1.Text = "인쇄할 사진의 갯수를 선택해주세요";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Location = new System.Drawing.Point(360, 900);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(360, 132);
            this.pictureBox3.TabIndex = 15;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // next
            // 
            this.next.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.next.BackColor = System.Drawing.Color.Transparent;
            this.next.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.next.FlatAppearance.BorderSize = 0;
            this.next.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.next.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.next.ForeColor = System.Drawing.Color.Transparent;
            this.next.Location = new System.Drawing.Point(456, 1662);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(168, 70);
            this.next.TabIndex = 12;
            this.next.UseVisualStyleBackColor = false;
            this.next.MouseClick += new System.Windows.Forms.MouseEventHandler(this.next_MouseClick);
            this.next.MouseDown += new System.Windows.Forms.MouseEventHandler(this.next_MouseDown);
            this.next.MouseUp += new System.Windows.Forms.MouseEventHandler(this.next_MouseUp);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Location = new System.Drawing.Point(360, 650);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(360, 132);
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(360, 400);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(360, 132);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // CountWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 1920);
            this.Controls.Add(this.doubleBufferPanel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CountWindow";
            this.Text = "CountWindow";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CountWindow_FormClosed);
            this.doubleBufferPanel1.ResumeLayout(false);
            this.doubleBufferPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button next;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private DoubleBufferPanel doubleBufferPanel1;
    }
}