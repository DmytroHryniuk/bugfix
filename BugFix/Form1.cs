using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BugFix
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string userName = Environment.UserName;
            UserNamLab.Text= "Вітаю, "+userName;

            DateTime now = DateTime.Now;
            timeLab.Text = now.ToString("D");
        }

        private void інфоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            info infoF = new info();
            infoF.ShowDialog();
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pcFORM pcF = new pcFORM();
            pcF.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            laptopFORM laptopF = new laptopFORM();
            laptopF.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mfpFORM mfpF = new mfpFORM();
            mfpF.ShowDialog();
        }
    }
}
