using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawing_point.GUI
{
    class GameGUI : Form
    {
        private GamePanel GP;
        public GameGUI(int WhichPlayer)
        {
            GP = new GamePanel(WhichPlayer);
            GP.Focus();
            InitializeComponent();
            this.Size = GP.Size;
            this.Controls.Add(GP);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // GameGUI
            // 
            this.ClientSize = new System.Drawing.Size(517, 461);
            this.Name = "GameGUI";
            this.Load += new System.EventHandler(this.GameGUI_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameGUI_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameGUI_KeyUp);
            this.ResumeLayout(false);

        }

        private void GameGUI_KeyDown(object sender, KeyEventArgs e)
        {
            KeyMnager.setKey(e.KeyCode, true);
        }

        private void GameGUI_KeyUp(object sender, KeyEventArgs e)
        {
            KeyMnager.setKey(e.KeyCode, false);

        }

        private void GameGUI_Load(object sender, EventArgs e)
        {

        }
    }
}
