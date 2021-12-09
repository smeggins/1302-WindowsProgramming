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
        public static PictureBox[][] BattleFieldZones;

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

        public delegate void d_SetLabelValue(Label label, string Value);
        public static d_SetLabelValue SetLabelValueDelegate = new d_SetLabelValue(SetLabelValue);
        public static void SetLabelValue(Label label, string Value)
        {
            label.Text = Value;
        }

        public delegate void d_SetLabelVisibility(Label label, bool isVisible);
        public static d_SetLabelVisibility SetLabelVisibilityDelegate = new d_SetLabelVisibility(SetLabelVisibility);
        public static void SetLabelVisibility(Label label, bool isVisible)
        {
            label.Visible = isVisible;
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

        public static (Color color, string imageLocation) ConvertConsoleSymbolToFormsGraphic(char symbol)
        {
            //NOTE Was Originally going to keep the colored backgrounds but now I'm thinking i might leave them all transparent
            // If i decide to keep it i will remove the Color part of this tuple in the future
            switch (symbol)
            {
                case 'V':
                    return (Color.Transparent, "../../../Resources/Vampire.gif");
                case 'I':
                    return (Color.Transparent, "../../../Resources/Imp.gif");
                case 'C':
                    return (Color.Transparent, "../../../Resources/CryptLord.gif");
                case 'D':
                    return (Color.Transparent, "../../../Resources/Demon.gif");
                case '@':
                    return (Color.Transparent, "../../../Resources/NPC.gif");
                case 'O':
                    return (Color.Transparent, "../../../Resources/Player.gif");
                default:
                    throw new ArgumentException("ConvertConsoleSymbolToFormsGraphic: Trying to Convert entity symbol to form graphic");
            }
        }

        private static int IndexInverter(int indexToInvert, int arrayLength)
        {
            return (arrayLength - 1) - indexToInvert;
        }
       
        public delegate void GridSquare(Panel battleFieldCanvas, IActor[][] layout, (int x, int y) position);
        public static GridSquare GridSquareDelegate = new GridSquare(CreateGridSquare);
        public static void CreateGridSquare(Panel battleFieldCanvas, IActor[][] layout, (int x, int y) position)
        {
            int XLength = layout.Length;
            int YLength = layout[0].Length;
            var Height = (battleFieldCanvas.Height / XLength);
            var Width = (battleFieldCanvas.Width / YLength);

            PictureBox newPB = new PictureBox();
            battleFieldCanvas.Controls.Add(newPB);
            newPB.BackColor = Color.Transparent;
            newPB.Location = new Point(Width*(position.x), Height * IndexInverter(position.y, YLength));
            newPB.Size = new Size(Width, Height);
            newPB.BorderStyle = BorderStyle.FixedSingle;
            newPB.SizeMode = PictureBoxSizeMode.StretchImage;
            if (layout[position.x][position.y] is not null)
            {
                (Color color, string imageLocation) FormGraphic = ConvertConsoleSymbolToFormsGraphic(layout[position.x][position.y].LayoutGraphic().symbol);
                newPB.BackColor = FormGraphic.color;
                newPB.ImageLocation = FormGraphic.imageLocation;
            }
            BattleFieldZones[position.x][position.y] = (newPB);
        }

        public delegate void GridSquareUpdate();
        public static GridSquareUpdate GridSquareUpdateDelegate = new GridSquareUpdate(updateGridSquare);
        public static void updateGridSquare()
        {
            for (int y = 0; y < Processor.Position.Layout.Length; y++)
            {
                for (int x = 0; x < Processor.Position.Layout.Length; x++)
                {
                    if (Processor.Position.Layout[x][y] is not null)
                    {
                        (Color color, string imageLocation) FormGraphic = ConvertConsoleSymbolToFormsGraphic(Processor.Position.Layout[x][y].LayoutGraphic().symbol);
                        BattleFieldZones[x][y].BackColor = FormGraphic.color;
                        BattleFieldZones[x][y].ImageLocation = FormGraphic.imageLocation;
                    }
                    else
                    {
                        BattleFieldZones[x][y].ImageLocation = "";
                    }
                }
            }
        }

        private void BattleAttackButton_Click(object sender, EventArgs e)
        {
            FormBattle.UserSelection = FormBattle.BattleOptions.Attack;
        }

        private void BattleDefendButton_Click(object sender, EventArgs e)
        {
            FormBattle.UserSelection = FormBattle.BattleOptions.Defend;
        }

        private void BattleSpecialButton_Click(object sender, EventArgs e)
        {
            if (Processor.Player.CurrentEnergy >= 10)
            {
                FormBattle.UserSelection = FormBattle.BattleOptions.Special;
            }
            else
            {
                MessageBox.Show("You must have 10 energy to use your special!");
            }
        }

        private void HideEndLevelStatLabels()
        {
            EndOfLevelDefenceIncreaseAmount.Visible = false;
            EndOfLevelDefencePlus.Visible = false;
            EndOfLevelHealthPlus.Visible = false;
            EndOfLevelHealthIncreaseAmount.Visible = false;
        }

        private void EndOfLevelMakeCampYesButton_Click(object sender, EventArgs e)
        {
            int HPGain = Randomizer.Instance.RandomNumber(((int)(Processor.Player.CurrentHealth * 0.1f)), (Processor.Player.TotalHealth - Processor.Player.CurrentHealth));
            int EnergyLoss = Randomizer.Instance.RandomNumber((int)Processor.Player.CurrentEnergy);


            Processor.Player.CurrentHealth += HPGain;
            Processor.Player.CurrentEnergy -= EnergyLoss;
            MessageBox.Show($"Gained {HPGain} Health!\n" +
                            $"Lost {EnergyLoss} Energy...\n" +
                            $"New Total Health {Processor.Player.CurrentHealth}\n" +
                            $"New Total Energy {Processor.Player.CurrentEnergy}");
            HideEndLevelStatLabels();
            EndOfLevelPane.Visible = false;
            GameController.waiting = false;
        }

        private void EndOfLevelMakeCampNoButton_Click(object sender, EventArgs e)
        {
            EndOfLevelPane.Visible = false;
            HideEndLevelStatLabels();
            GameController.waiting = false;
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
        

        private void EndOfLevelHealth_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        

        
    }
}
