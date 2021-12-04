using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MegaDeathMountain;

namespace MegaDeathMountainShared
{
    public partial class Game : Form
    {
        public Game()
        {
            InitializeComponent();
        }

        private void Game_Load(object sender, EventArgs e)
        {
            //Timer CountdownToChangeLook = new Timer();
            //CountdownToChangeLook.Interval = (1000);
            //CountdownToChangeLook.Tick += new EventHandler(ChangeLook_Event);
            //CountdownToChangeLook.Start();
            FormsKeyLogger formsKeyLogger = (FormsKeyLogger)Processor.keyLogger;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(formsKeyLogger.Game_KeyDown);

        }

        public delegate void PanelVisibility(Panel panel, bool isVisible);
        public static PanelVisibility PanelVisibilityDelegate = new PanelVisibility(SetPanelVisibility);
        public static void SetPanelVisibility(Panel panel, bool isVisible)
        {
            panel.Visible = isVisible;
        }

        private void ChangeLook_Event(object sender, EventArgs e)
        {
            MessageBox.Show("waited 5 seconds broskie");
        }


        ////////////////////////////////////////////Selection Indication////////////////////////////////////////////
        /// TODO not happy with implementation using tags without checks. 
        /// probably change this to use a static border imagebox
        private void KnightSelectorImage_Paint(object sender, PaintEventArgs e)
        {
            if (KnightSelectorImage.Tag == null)
                KnightSelectorImage.Tag = ButtonBorderStyle.None;
            ControlPaint.DrawBorder(e.Graphics, KnightSelectorImage.ClientRectangle, Color.Gold, (ButtonBorderStyle)KnightSelectorImage.Tag);
        }

        private void PriestSelectorImage_Paint(object sender, PaintEventArgs e)
        {
            if (PriestSelectorImage.Tag == null)
                PriestSelectorImage.Tag = ButtonBorderStyle.None;
            ControlPaint.DrawBorder(e.Graphics, PriestSelectorImage.ClientRectangle, Color.Gold, (ButtonBorderStyle)PriestSelectorImage.Tag);
        }

        private void BeastSelectorImage_Paint(object sender, PaintEventArgs e)
        {
            if (BeastSelectorImage.Tag == null)
                BeastSelectorImage.Tag = ButtonBorderStyle.None;
            ControlPaint.DrawBorder(e.Graphics, BeastSelectorImage.ClientRectangle, Color.Gold, (ButtonBorderStyle)BeastSelectorImage.Tag);
        }


        private void KnightSelectorImage_Click(object sender, EventArgs e)
        {
            PlayerCreator.SetClass(PlayerClass.Knight);

            KnightSelectorImage.Tag = ButtonBorderStyle.Solid;
            PriestSelectorImage.Tag = ButtonBorderStyle.None;
            BeastSelectorImage.Tag = ButtonBorderStyle.None;
            KnightSelectorImage.Refresh();
            PriestSelectorImage.Refresh();
            BeastSelectorImage.Refresh();
        }

        private void PriestSelectorImage_Click(object sender, EventArgs e)
        {
            PlayerCreator.SetClass(PlayerClass.Priest);

            PriestSelectorImage.Tag = ButtonBorderStyle.Solid;
            KnightSelectorImage.Tag = ButtonBorderStyle.None;
            BeastSelectorImage.Tag = ButtonBorderStyle.None;
            PriestSelectorImage.Refresh();
            KnightSelectorImage.Refresh();
            BeastSelectorImage.Refresh();
        }

        private void BeastSelectorImage_Click(object sender, EventArgs e)
        {
            PlayerCreator.SetClass(PlayerClass.Beast);

            BeastSelectorImage.Tag = ButtonBorderStyle.Solid;
            PriestSelectorImage.Tag = ButtonBorderStyle.None;
            KnightSelectorImage.Tag = ButtonBorderStyle.None;
            BeastSelectorImage.Refresh();
            PriestSelectorImage.Refresh();
            KnightSelectorImage.Refresh();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void CharacterSelectorPanel_Paint(object sender, PaintEventArgs e)
        {

        }
        //////////////////////////////////////////END Selection Indication//////////////////////////////////////////

    }
}
