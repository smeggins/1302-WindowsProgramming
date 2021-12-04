using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDeathMountainShared
{
    public partial class Alert : Form
    {
        public Alert(string message)
        {
            InitializeComponent();

            // createus a continue wqindow, asks yes or no, then returns the result
            
            MessageBox.Show(message);
        }

        //private void Form1_Load_1(object sender, EventArgs e)
        //{
        //    MessageBox.Show("Form1 is Loaded!");
        //    this.Text = "form1 loaded";
        //}
    }
}
