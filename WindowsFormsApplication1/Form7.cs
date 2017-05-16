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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.stuConnectionString"].ConnectionString.ToString();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string cmdrt = "select distinct s.病人编号,s.病人姓名,sum(h.价格) as 价格 from 药品使用清单 s join 药品 h on h.药品=s.使用药品 group by s.病人编号,s.病人姓名";
            SqlCommand cmd=new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = cmdrt;
            SqlDataAdapter Dat = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            Dat.Fill(dt);
            this.dataGridView1.DataSource = dt.DefaultView;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.stuConnectionString"].ConnectionString.ToString();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string cmdrt = "select * from 药品";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = cmdrt;
            SqlDataAdapter Dat = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            Dat.Fill(dt);
            this.dataGridView1.DataSource = dt.DefaultView;
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.stuConnectionString"].ConnectionString.ToString();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string cmdrt = "select * from 药品使用清单";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = cmdrt;
            SqlDataAdapter Dat = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            Dat.Fill(dt);
            this.dataGridView1.DataSource = dt.DefaultView;
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form f8 = new Form8();
            f8.Show();
        }
    }
}
