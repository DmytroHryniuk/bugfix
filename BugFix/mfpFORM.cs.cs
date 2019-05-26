using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace BugFix
{
    public partial class mfpFORM : Form
    {
        public static List<string> data = new List<string>();
        public mfpFORM()
        {
            InitializeComponent();
        }

        private void проблемаІзНоутбукомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            laptopFORM laptopF = new laptopFORM();
            laptopF.ShowDialog();
        }

        private void проблемаІзМФПToolStripMenuItem_Click(object sender, EventArgs e)
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
            System.IO.File.WriteAllText("mfpFIX.txt", lines);
            MessageBox.Show("Текс збережено", "Увага", 0, MessageBoxIcon.Information);
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
            string query = "SELECT `ID`, `trouble`, `group`, `info`  FROM mfp WHERE `trouble` = " + "'" + comboBox1.Text + "'";


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

        private void mfpFORM_Load(object sender, EventArgs e)
        {
            try
            {
                string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\DB\\bugfix.mdb";
                OleDbConnection myConnection;
                myConnection = new OleDbConnection(connectString);
                myConnection.Open();
                string query = "SELECT `ID`, `trouble`  FROM mfp";
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
    }
}
