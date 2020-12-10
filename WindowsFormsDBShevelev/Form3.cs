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
    public partial class Form3 : Form
    {
        SqlConnection _sqCon = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=usersdb;Integrated Security=True");
        public Form3()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand SQIns = new SqlCommand();
            SQIns.Connection = _sqCon;
            _sqCon.Open();
            SQIns.CommandText = "Select * from Registr";
            SqlDataAdapter _daP = new SqlDataAdapter(SQIns);
            DataSet _dSet = new DataSet();
            _daP.Fill(_dSet);
            for(int i = 0; i < _dSet.Tables[0].Rows.Count; i++)
            {
                if (textBox1.Text == _dSet.Tables[0].Rows[i][1].ToString() && textBox2.Text == _dSet.Tables[0].Rows[i][2].ToString())
                {
                    MessageBox.Show("Здравствуйте, " + textBox1.Text);
                    Form4 fr4 = new Form4(textBox1.Text);
                    this.Hide();
                    fr4.Show();
                    textBox1.Clear();
                    textBox2.Clear();
                }
            }
            _sqCon.Close();
        }
    }
}
