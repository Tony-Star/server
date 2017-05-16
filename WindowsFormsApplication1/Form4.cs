using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace WindowsFormsApplication1
{
    public partial class Form4 : Form
    {
        public static string ID = "";
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.stuConnectionString"].ConnectionString.ToString();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            ID = this.textBox1.Text;
            SqlCommand cmd = new SqlCommand("delete from 病历 where 病人编号='" + ID + "'",con);
            
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Good job");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.stuConnectionString"].ConnectionString.ToString();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            ID = this.textBox2.Text;
            SqlCommand cmd = new SqlCommand("delete from 病历 where 病人姓名='" + ID + "'", con);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Good job");
        }
    }
}
