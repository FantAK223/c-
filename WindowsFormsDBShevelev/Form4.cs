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
    public partial class Form4 : Form
    {
        string str, log;
        
        SqlConnection _sqCon = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=usersdb;Integrated Security=True");
        SqlCommand _sqComm = new SqlCommand();
        SqlDataAdapter _daP = new SqlDataAdapter();
        DataSet _dSet = new DataSet();
        public Form4(string login)
        {
    
            InitializeComponent();
            this.log = login;
            label1.Text = this.log;
        }

        private void ComboBox1_TextChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text.Length >=3)
            {
                _sqComm.CommandText = "SELECT * From odd WHERE (Название like '%" + comboBox1.Text + "%')";
                _sqComm.Connection = _sqCon;

                _sqCon.Close();
                _sqCon.Open();
                _daP = new SqlDataAdapter(_sqComm);
                _dSet.Tables.Clear();
                _daP.Fill(_dSet);
                comboBox1.DataSource = _dSet.Tables[0];
                comboBox1.DisplayMember = "Название";
                comboBox1.ValueMember = "Название";
                _sqCon.Close();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            str = "";
            log = "";
            Form3 fr3 = new Form3();
            this.Hide();
            fr3.Show();
        }

        private void ComboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            str = comboBox1.Text;
            Form5 fr5 = new Form5(str, log);
            this.Hide();
            fr5.Show();
        }
    }
}
