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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.stuConnectionString"].ConnectionString.ToString();
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Addmedicine";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@病人编号", SqlDbType.Char, 10, "病人编号").Value = this.textBox1.Text;
            cmd.Parameters.Add("@病人姓名", SqlDbType.Char, 10, "病人姓名").Value = this.textBox2.Text;
            cmd.Parameters.Add("@使用药品", SqlDbType.Char, 10, "使用药品").Value = this.textBox3.Text;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
