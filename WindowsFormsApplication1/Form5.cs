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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.stuConnectionString"].ConnectionString.ToString();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string ID = this.textBox1.Text;
            SqlDataAdapter da = new SqlDataAdapter("select * from 病历 where 病人编号='"+ID+"' ",con);
            
            DataTable dt = new DataTable("病历");
            da.Fill(dt);
            this.dataGridView1.DataSource = dt.DefaultView;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.stuConnectionString"].ConnectionString.ToString();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string ID = this.textBox2.Text;
            SqlDataAdapter da = new SqlDataAdapter("select * from 病历 where 病人姓名='" + ID + "' ", con);

            DataTable dt = new DataTable("病历");
            da.Fill(dt);
            this.dataGridView1.DataSource = dt.DefaultView;
            con.Close();
        }
    }
}
