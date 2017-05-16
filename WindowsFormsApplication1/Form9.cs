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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        private int id;
        private int rowindex;
       
        private void button1_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.stuConnectionString"].ConnectionString.ToString();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter Dat = new SqlDataAdapter("SELECT * from 医生", con);
            DataTable dt = new DataTable("医生");
            Dat.Fill(dt);
            this.dataGridView1.DataSource = dt.DefaultView;
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.stuConnectionString"].ConnectionString.ToString();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            DialogResult RSS = MessageBox.Show(this, "确定要删除选中行数据码？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            switch (RSS)
            {
                case DialogResult.Yes:
                    for (int i = this.dataGridView1.SelectedRows.Count; i > 0; i--)
                    {
                        string ID = Convert.ToString(dataGridView1.SelectedRows[i - 1].Cells[0].Value);
                        dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[i - 1].Index);
                        //使用获得的ID删除数据库的数据
                        //string SQL = "delete from 医生 where UserId='" + ID.ToString() + "'";
                        SqlCommand cmd = new SqlCommand("delete from 医生 where 用户名='" + ID.ToString() + "'", con);
                        cmd.ExecuteNonQuery();
                    }
                    break;
                    case DialogResult.No:
                    break;
            }
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView1.ReadOnly = false;
            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;
             id = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
             rowindex = e.RowIndex;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form f10=new Form10();
            f10.Show();
        }
    }
}
