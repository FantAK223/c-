using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WindowsFormsDBShevelev
{
    public partial class Form1 : Form
    {
        SqlConnection _sqCon = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=usersdb;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void Button_reg_Click(object sender, EventArgs e)
        {
            SqlCommand SQIns = new SqlCommand();
            SQIns.Connection = _sqCon;
            _sqCon.Open();
            SQIns.CommandText = "Insert Registr values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
            SQIns.ExecuteNonQuery();
            _sqCon.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            Form4 fr4 = new Form4(textBox1.Text);
            this.Hide();
            fr4.Show();
        }
    }
}
