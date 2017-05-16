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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.stuConnectionString"].ConnectionString.ToString();
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "AddStudent";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@病人编号", SqlDbType.Char, 10, "病人编号").Value = this.textBox1.Text;
            cmd.Parameters.Add("@病人姓名", SqlDbType.Char, 10, "病人姓名").Value = this.textBox2.Text;
            cmd.Parameters.Add("@病人年龄", SqlDbType.Char, 10, "病人年龄").Value = this.textBox3.Text;
            cmd.Parameters.Add("@伤病情况", SqlDbType.Char, 10, "伤病情况").Value = this.textBox4.Text;
            cmd.Parameters.Add("@归档时间", SqlDbType.Char, 20, "归档时间").Value = this.dateTimePicker1.Text;
            cmd.Parameters.Add("@主任医生", SqlDbType.Char, 10, "主任医生").Value = this.textBox5.Text;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
