using System.Windows.Forms;

namespace SnapshotsOfLifeEx02
{
    class DoubleBufferPanel: Panel
    {
        public DoubleBufferPanel()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DoubleBufferPanel
            // 
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DoubleBufferPanel_Paint);
            this.ResumeLayout(false);

        }

        private void DoubleBufferPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
