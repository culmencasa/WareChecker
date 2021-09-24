using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace TestApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            lblProcessName.Text = Process.GetCurrentProcess().ProcessName;
            this.lblVersion.Text = Application.ProductVersion;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
