using System.Drawing;
using System.Windows.Forms;

namespace MegaDeathMountainShared
{
    partial class Game
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.TitleScreenInitialPanel = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.CharacterSelectorPanel = new System.Windows.Forms.Panel();
            this.CC_NameBoxLabel = new System.Windows.Forms.Label();
            this.CC_NameBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BeastSelectorImage = new System.Windows.Forms.PictureBox();
            this.PriestSelectorImage = new System.Windows.Forms.PictureBox();
            this.KnightSelectorImage = new System.Windows.Forms.PictureBox();
            this.BattleFieldPanel = new System.Windows.Forms.Panel();
            this.BattleFieldCanvas = new System.Windows.Forms.Panel();
            this.IntroPanel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.IntroPanel2 = new System.Windows.Forms.Panel();
            this.IntroPanel2Label = new System.Windows.Forms.Label();
            this.IntroPanel3 = new System.Windows.Forms.Panel();
            this.IntroPanel3Label = new System.Windows.Forms.Label();
            this.TitleScreenInitialPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.CharacterSelectorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BeastSelectorImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriestSelectorImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KnightSelectorImage)).BeginInit();
            this.BattleFieldPanel.SuspendLayout();
            this.IntroPanel1.SuspendLayout();
            this.IntroPanel2.SuspendLayout();
            this.IntroPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleScreenInitialPanel
            // 
            this.TitleScreenInitialPanel.AccessibleName = "Title Screen";
            this.TitleScreenInitialPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TitleScreenInitialPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TitleScreenInitialPanel.BackgroundImage")));
            this.TitleScreenInitialPanel.Controls.Add(this.pictureBox3);
            this.TitleScreenInitialPanel.Controls.Add(this.pictureBox1);
            this.TitleScreenInitialPanel.Controls.Add(this.pictureBox2);
            this.TitleScreenInitialPanel.Location = new System.Drawing.Point(1, 1);
            this.TitleScreenInitialPanel.Name = "TitleScreenInitialPanel";
            this.TitleScreenInitialPanel.Size = new System.Drawing.Size(803, 600);
            this.TitleScreenInitialPanel.TabIndex = 3;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(216, 249);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(371, 102);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(92, 527);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(685, 364);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(50, 62);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(101, 99);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // CharacterSelectorPanel
            // 
            this.CharacterSelectorPanel.AccessibleName = "Character Selector";
            this.CharacterSelectorPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CharacterSelectorPanel.BackColor = System.Drawing.Color.Black;
            this.CharacterSelectorPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CharacterSelectorPanel.BackgroundImage")));
            this.CharacterSelectorPanel.Controls.Add(this.CC_NameBoxLabel);
            this.CharacterSelectorPanel.Controls.Add(this.CC_NameBox);
            this.CharacterSelectorPanel.Controls.Add(this.label4);
            this.CharacterSelectorPanel.Controls.Add(this.label3);
            this.CharacterSelectorPanel.Controls.Add(this.label2);
            this.CharacterSelectorPanel.Controls.Add(this.label1);
            this.CharacterSelectorPanel.Controls.Add(this.BeastSelectorImage);
            this.CharacterSelectorPanel.Controls.Add(this.PriestSelectorImage);
            this.CharacterSelectorPanel.Controls.Add(this.KnightSelectorImage);
            this.CharacterSelectorPanel.Location = new System.Drawing.Point(0, 0);
            this.CharacterSelectorPanel.Name = "CharacterSelectorPanel";
            this.CharacterSelectorPanel.Size = new System.Drawing.Size(800, 600);
            this.CharacterSelectorPanel.TabIndex = 4;
            this.CharacterSelectorPanel.Visible = false;
            // 
            // CC_NameBoxLabel
            // 
            this.CC_NameBoxLabel.AutoSize = true;
            this.CC_NameBoxLabel.BackColor = System.Drawing.Color.Transparent;
            this.CC_NameBoxLabel.Font = new System.Drawing.Font("Showcard Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CC_NameBoxLabel.Location = new System.Drawing.Point(336, 485);
            this.CC_NameBoxLabel.Name = "CC_NameBoxLabel";
            this.CC_NameBoxLabel.Size = new System.Drawing.Size(103, 40);
            this.CC_NameBoxLabel.TabIndex = 8;
            this.CC_NameBoxLabel.Text = "Name";
            // 
            // CC_NameBox
            // 
            this.CC_NameBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CC_NameBox.Location = new System.Drawing.Point(261, 528);
            this.CC_NameBox.Name = "CC_NameBox";
            this.CC_NameBox.Size = new System.Drawing.Size(253, 39);
            this.CC_NameBox.TabIndex = 7;
            this.CC_NameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Showcard Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(591, 427);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 44);
            this.label4.TabIndex = 6;
            this.label4.Text = "Beast";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Showcard Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(318, 427);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 44);
            this.label3.TabIndex = 5;
            this.label3.Text = "Priest";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Showcard Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(68, 427);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 44);
            this.label2.TabIndex = 4;
            this.label2.Text = "Knight";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(77, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(641, 60);
            this.label1.TabIndex = 3;
            this.label1.Text = "CHOOSE YOUR CHARACTER";
            // 
            // BeastSelectorImage
            // 
            this.BeastSelectorImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BeastSelectorImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BeastSelectorImage.BackgroundImage")));
            this.BeastSelectorImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BeastSelectorImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BeastSelectorImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BeastSelectorImage.Image = ((System.Drawing.Image)(resources.GetObject("BeastSelectorImage.Image")));
            this.BeastSelectorImage.Location = new System.Drawing.Point(551, 116);
            this.BeastSelectorImage.Name = "BeastSelectorImage";
            this.BeastSelectorImage.Size = new System.Drawing.Size(200, 300);
            this.BeastSelectorImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BeastSelectorImage.TabIndex = 2;
            this.BeastSelectorImage.TabStop = false;
            this.BeastSelectorImage.Click += new System.EventHandler(this.BeastSelectorImage_Click);
            this.BeastSelectorImage.Paint += new System.Windows.Forms.PaintEventHandler(this.BeastSelectorImage_Paint);
            // 
            // PriestSelectorImage
            // 
            this.PriestSelectorImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PriestSelectorImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PriestSelectorImage.BackgroundImage")));
            this.PriestSelectorImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PriestSelectorImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PriestSelectorImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PriestSelectorImage.Image = ((System.Drawing.Image)(resources.GetObject("PriestSelectorImage.Image")));
            this.PriestSelectorImage.Location = new System.Drawing.Point(289, 116);
            this.PriestSelectorImage.Name = "PriestSelectorImage";
            this.PriestSelectorImage.Size = new System.Drawing.Size(200, 300);
            this.PriestSelectorImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PriestSelectorImage.TabIndex = 1;
            this.PriestSelectorImage.TabStop = false;
            this.PriestSelectorImage.Click += new System.EventHandler(this.PriestSelectorImage_Click);
            this.PriestSelectorImage.Paint += new System.Windows.Forms.PaintEventHandler(this.PriestSelectorImage_Paint);
            // 
            // KnightSelectorImage
            // 
            this.KnightSelectorImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KnightSelectorImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("KnightSelectorImage.BackgroundImage")));
            this.KnightSelectorImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.KnightSelectorImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.KnightSelectorImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.KnightSelectorImage.Image = ((System.Drawing.Image)(resources.GetObject("KnightSelectorImage.Image")));
            this.KnightSelectorImage.Location = new System.Drawing.Point(39, 116);
            this.KnightSelectorImage.Name = "KnightSelectorImage";
            this.KnightSelectorImage.Size = new System.Drawing.Size(200, 300);
            this.KnightSelectorImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.KnightSelectorImage.TabIndex = 0;
            this.KnightSelectorImage.TabStop = false;
            this.KnightSelectorImage.Click += new System.EventHandler(this.KnightSelectorImage_Click);
            this.KnightSelectorImage.Paint += new System.Windows.Forms.PaintEventHandler(this.KnightSelectorImage_Paint);
            // 
            // BattleFieldPanel
            // 
            this.BattleFieldPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BattleFieldPanel.BackgroundImage")));
            this.BattleFieldPanel.Controls.Add(this.BattleFieldCanvas);
            this.BattleFieldPanel.Location = new System.Drawing.Point(0, 0);
            this.BattleFieldPanel.Name = "BattleFieldPanel";
            this.BattleFieldPanel.Size = new System.Drawing.Size(800, 600);
            this.BattleFieldPanel.TabIndex = 9;
            this.BattleFieldPanel.Visible = false;
            // 
            // BattleFieldCanvas
            // 
            this.BattleFieldCanvas.Location = new System.Drawing.Point(39, 32);
            this.BattleFieldCanvas.Name = "BattleFieldCanvas";
            this.BattleFieldCanvas.Size = new System.Drawing.Size(712, 349);
            this.BattleFieldCanvas.TabIndex = 0;
            // 
            // IntroPanel1
            // 
            this.IntroPanel1.BackColor = System.Drawing.Color.Black;
            this.IntroPanel1.Controls.Add(this.label7);
            this.IntroPanel1.Controls.Add(this.label6);
            this.IntroPanel1.Controls.Add(this.label5);
            this.IntroPanel1.Location = new System.Drawing.Point(0, 0);
            this.IntroPanel1.Name = "IntroPanel1";
            this.IntroPanel1.Size = new System.Drawing.Size(800, 600);
            this.IntroPanel1.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Showcard Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(151, 331);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(481, 50);
            this.label7.TabIndex = 2;
            this.label7.Text = "MEGA DEATH MOUNTAIN";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Showcard Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(261, 256);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(257, 44);
            this.label6.TabIndex = 1;
            this.label6.Text = "Unforgiving";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Showcard Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(121, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(540, 44);
            this.label5.TabIndex = 0;
            this.label5.Text = "You arrive at the desolate";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // IntroPanel2
            // 
            this.IntroPanel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.IntroPanel2.Controls.Add(this.IntroPanel2Label);
            this.IntroPanel2.Location = new System.Drawing.Point(0, 0);
            this.IntroPanel2.Name = "IntroPanel2";
            this.IntroPanel2.Size = new System.Drawing.Size(800, 600);
            this.IntroPanel2.TabIndex = 10;
            this.IntroPanel2.Visible = false;
            // 
            // IntroPanel2Label
            // 
            this.IntroPanel2Label.AutoSize = true;
            this.IntroPanel2Label.Font = new System.Drawing.Font("Showcard Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.IntroPanel2Label.ForeColor = System.Drawing.Color.White;
            this.IntroPanel2Label.Location = new System.Drawing.Point(91, 300);
            this.IntroPanel2Label.Name = "IntroPanel2Label";
            this.IntroPanel2Label.Size = new System.Drawing.Size(627, 44);
            this.IntroPanel2Label.TabIndex = 1;
            this.IntroPanel2Label.Text = "Where Only The Strong Survive";
            // 
            // IntroPanel3
            // 
            this.IntroPanel3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.IntroPanel3.Controls.Add(this.IntroPanel3Label);
            this.IntroPanel3.Location = new System.Drawing.Point(0, 0);
            this.IntroPanel3.Name = "IntroPanel3";
            this.IntroPanel3.Size = new System.Drawing.Size(800, 600);
            this.IntroPanel3.TabIndex = 11;
            this.IntroPanel3.Visible = false;
            // 
            // IntroPanel3Label
            // 
            this.IntroPanel3Label.AutoSize = true;
            this.IntroPanel3Label.Font = new System.Drawing.Font("Showcard Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.IntroPanel3Label.ForeColor = System.Drawing.Color.White;
            this.IntroPanel3Label.Location = new System.Drawing.Point(268, 300);
            this.IntroPanel3Label.Name = "IntroPanel3Label";
            this.IntroPanel3Label.Size = new System.Drawing.Size(250, 44);
            this.IntroPanel3Label.TabIndex = 1;
            this.IntroPanel3Label.Text = "Good Luck...";
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.BattleFieldPanel);
            this.Controls.Add(this.CharacterSelectorPanel);
            this.Controls.Add(this.TitleScreenInitialPanel);
            this.Controls.Add(this.IntroPanel1);
            this.Controls.Add(this.IntroPanel2);
            this.Controls.Add(this.IntroPanel3);
            this.KeyPreview = true;
            this.Name = "Game";
            this.Text = "MEGA DEATH MOUNTAIN";
            this.Load += new System.EventHandler(this.Game_Load);
            this.TitleScreenInitialPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.CharacterSelectorPanel.ResumeLayout(false);
            this.CharacterSelectorPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BeastSelectorImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriestSelectorImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KnightSelectorImage)).EndInit();
            this.BattleFieldPanel.ResumeLayout(false);
            this.IntroPanel1.ResumeLayout(false);
            this.IntroPanel1.PerformLayout();
            this.IntroPanel2.ResumeLayout(false);
            this.IntroPanel2.PerformLayout();
            this.IntroPanel3.ResumeLayout(false);
            this.IntroPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel TitleScreenInitialPanel;
        public System.Windows.Forms.Panel CharacterSelectorPanel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private PictureBox BeastSelectorImage;
        private PictureBox PriestSelectorImage;
        private PictureBox KnightSelectorImage;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label CC_NameBoxLabel;
        public TextBox CC_NameBox;
        public Panel IntroPanel1;
        private Label label5;
        private Label label7;
        private Label label6;
        public Panel IntroPanel2;
        private Label IntroPanel2Label;
        public Panel IntroPanel3;
        private Label IntroPanel3Label;
        public Panel BattleFieldPanel;
        public Panel BattleFieldCanvas;
    }

}

