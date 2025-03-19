
namespace SnapshotsOfLifeEx02
{
    partial class FrameWindow
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
            this.panel1 = new SnapshotsOfLifeEx02.DoubleBufferPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.toggleButton1 = new SnapshotsOfLifeEx02.ToggleButton();
            this.next = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.toggleButton1);
            this.panel1.Controls.Add(this.next);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1080, 1920);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("문체부 제목 바탕체", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(64, 1521);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 40);
            this.label2.TabIndex = 19;
            this.label2.Text = "미러 모드";
            // 
            // toggleButton1
            // 
            this.toggleButton1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.toggleButton1.BackColor = System.Drawing.Color.Transparent;
            this.toggleButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toggleButton1.Checked = true;
            this.toggleButton1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toggleButton1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.toggleButton1.FlatAppearance.BorderSize = 0;
            this.toggleButton1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.toggleButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.toggleButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.toggleButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toggleButton1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toggleButton1.ImageKey = "(없음)";
            this.toggleButton1.Location = new System.Drawing.Point(286, 1521);
            this.toggleButton1.Margin = new System.Windows.Forms.Padding(0);
            this.toggleButton1.MinimumSize = new System.Drawing.Size(45, 22);
            this.toggleButton1.Name = "toggleButton1";
            this.toggleButton1.OffBackColor = System.Drawing.Color.Gray;
            this.toggleButton1.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.toggleButton1.OnBackColor = System.Drawing.Color.MediumSlateBlue;
            this.toggleButton1.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.toggleButton1.Padding = new System.Windows.Forms.Padding(3);
            this.toggleButton1.Size = new System.Drawing.Size(119, 40);
            this.toggleButton1.TabIndex = 18;
            this.toggleButton1.Text = "toggleButton1";
            this.toggleButton1.UseVisualStyleBackColor = false;
            this.toggleButton1.CheckedChanged += new System.EventHandler(this.toggleButton1_CheckedChanged);
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
            this.next.Location = new System.Drawing.Point(454, 1662);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(168, 70);
            this.next.TabIndex = 11;
            this.next.UseVisualStyleBackColor = false;
            this.next.Click += new System.EventHandler(this.next_Click);
            this.next.MouseDown += new System.Windows.Forms.MouseEventHandler(this.next_MouseDown);
            this.next.MouseUp += new System.Windows.Forms.MouseEventHandler(this.next_MouseUp);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(71, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 75);
            this.button1.TabIndex = 17;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
            this.button1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button1_MouseUp);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("문체부 제목 바탕체", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(208, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(695, 40);
            this.label1.TabIndex = 10;
            this.label1.Text = "인쇄할 사진의 테마를 선택해주세요";
            // 
            // FrameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 1920);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrameWindow";
            this.Text = "FrameWindow";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrameWindow_FormClosed);
            this.Load += new System.EventHandler(this.FrameWindow_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrameWindow_Paint);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DoubleBufferPanel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button next;
        private System.Windows.Forms.Button button1;
        private ToggleButton toggleButton1;
        private System.Windows.Forms.Label label2;
    }
}