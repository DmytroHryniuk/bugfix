using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BugFix
{
    public partial class laptopFORM : Form
    {
        public static List<string> data = new List<string>();
        public laptopFORM()
        {
            InitializeComponent();
        }

        private void проблемаІзМФПToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mfpFORM mfpF = new mfpFORM();

            mfpF.ShowDialog();
        }

        private void проблемаІзНоутбукомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pcFORM pcF = new pcFORM();
            pcF.ShowDialog();
        }

        private void вийтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string lines = "Проблема: " + comboBox1.Text + "\nГрупа помилки: " + text1.Text + "\nДодаткова інформація: " + text2.Text;
            System.IO.File.WriteAllText("laptopFIX.txt", lines);
            MessageBox.Show("Текс збережено", "Увага", 0, MessageBoxIcon.Information);
        }

        private void laptopFORM_Load(object sender, EventArgs e)
        {
            try
            {
                string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\DB\\bugfix.mdb";
                OleDbConnection myConnection;
                myConnection = new OleDbConnection(connectString);
                myConnection.Open();
                string query = "SELECT `ID`, `trouble`  FROM laptop";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    data.Add(reader[1].ToString());
                    Console.WriteLine(reader[1].ToString());
                }
                reader.Close();
                myConnection.Close();
                comboBox1.DataSource = data;
            }
            catch
            {
                MessageBox.Show("Не знайдено базу.\nПокладіть базу в директорію C:/DB/", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string group = "";
            string info = "";
            //  Console.WriteLine(comboBox1.Text);
            string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\DB\\bugfix.mdb";
            OleDbConnection myConnection;
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            string query = "SELECT `ID`, `trouble`, `group`, `info`  FROM laptop WHERE `trouble` = " + "'" + comboBox1.Text + "'";


            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                group = reader[2].ToString();
                info = reader[3].ToString();

            }
            reader.Close();
            myConnection.Close();



            text1.Text = group;
            text2.Text = info;

        }
    }
}
