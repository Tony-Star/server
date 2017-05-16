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
    public partial class Form2 : Form
    {
        private string str1;
        public Form2()
        {
            InitializeComponent();
        }
        public string STR1//为窗体Form2定义的属性
        {
            get //读
            {
                return str1;

            }
            set
            {
                str1 = value;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            System.Environment.Exit(0);   
            return;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.stuConnectionString"].ConnectionString.ToString();
            SqlConnection con = new SqlConnection(conString);
            SqlDataAdapter Dat = new SqlDataAdapter("SELECT * from 病历", con);
            DataTable dt = new DataTable("病历");
            Dat.Fill(dt);
            this.dataGridView1.DataSource = dt.DefaultView;

            try
            {
                con.Open();

                MessageBox.Show("nice work");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form f7=new Form7();
            f7.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (str1 != "管理员")
            {
                MessageBox.Show("你不是管理员");
            }
            else
            {
                Form f9=new Form9();
                f9.Show();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            this.timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
                this.label1.Left += 5;
                if (this.label1.Left > 917)
                {
                    this.label1.Left = 0-this.label1.Width;
                }
        }

    }
}
