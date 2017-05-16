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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            //string conString = "Data Source=HONGKE914;Initial Catalog=stu;Integrated Security=True";
            string conString = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.stuConnectionString"].ConnectionString.ToString();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (textBox1.Text.Trim() == string.Empty || textBox2.Text.Trim() == string.Empty || (textBox2.Text.Trim() == string.Empty && textBox1.Text.Trim() == string.Empty))
            {
                MessageBox.Show("输入为空，请重新输入");
            }
            else
            {
                f2.STR1=this.comboBox1.Text.Trim();
                SqlCommand cmd = new SqlCommand("Select * from 医生 where 用户名='" + textBox2.Text + "'and 密码='" + textBox1.Text + "' and 身份='"+comboBox1.Text+"'", con);
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                if (sdr.HasRows)
                {
                    
                    this.Hide();
                    f2.Show();
                    sdr.Close();
                    con.Close();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            comboBox1.Text = string.Empty;
        }

    }
}
