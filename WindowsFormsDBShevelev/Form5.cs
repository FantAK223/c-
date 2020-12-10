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
    public partial class Form5 : Form
    {
        SqlConnection _sqCon1 = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Database=_703a2_Shevelev_logIn;Integrated Security=True;");
        SqlConnection _sqCon2 = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Database=_703a2_Shevelev_logIn;Integrated Security=True;");
        SqlCommand _sqComm = new SqlCommand();
        SqlDataAdapter _daP = new SqlDataAdapter();
        DataSet _dSet = new DataSet();

        string name, log;
        int count = 0;
        
        public Form5(string str, string login)
        {
            InitializeComponent();
            this.name = str;
            this.log = login;
            label8.Text = login;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            log = "";
            Form3 fr3 = new Form3();
            this.Hide();
            fr3.Show();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            _dSet.Tables.Clear();
            _sqComm.CommandText = "select rol from Rol where (nick ='" + this.log + "')";
            _sqComm.Connection = _sqCon2;
            _sqCon2.Open();
            //_sqComm.ExecuteNonQuery();
            _daP = new SqlDataAdapter(_sqComm);
            _daP.Fill(_dSet);
            if (_dSet.Tables[0].Rows.Count != 0)
            {
                button3.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
            }
            _dSet.Tables.Clear();
            _sqCon2.Close();
            _sqComm.CommandText = "SELECT * From Товары where (Название='" + this.name + "')";
            _sqComm.Connection = _sqCon1;
            _sqCon1.Open();
            _daP = new SqlDataAdapter(_sqComm);
            _daP.Fill(_dSet);
            dataGridView1.DataSource = _dSet.Tables[0];
            _dSet.Tables.Clear();
            _sqComm.CommandText = "SELECT Nickname, Review From review where (Product='" + this.name + "')";
            _daP = new SqlDataAdapter(_sqComm);
            _daP.Fill(_dSet);
            count = _dSet.Tables[0].Rows.Count;
            label1.Text = _dSet.Tables[0].Rows[count - 1][0].ToString();
            label2.Text = _dSet.Tables[0].Rows[count - 1][1].ToString();
            label3.Text = _dSet.Tables[0].Rows[count - 2][0].ToString();
            label4.Text = _dSet.Tables[0].Rows[count - 2][1].ToString();
            label5.Text = _dSet.Tables[0].Rows[count - 3][0].ToString();
            label6.Text = _dSet.Tables[0].Rows[count - 3][1].ToString();
            _dSet.Tables.Clear();
            _sqCon1.Close();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            _dSet.Tables.Clear();
            _sqComm.CommandText = "select rol from Rol where (nick ='" + this.log + "')";
            _sqComm.Connection = _sqCon2;
            _sqCon2.Open();
            _daP = new SqlDataAdapter(_sqComm);
            _daP.Fill(_dSet);
            string rol = _dSet.Tables[0].Rows[0][0].ToString();
            _dSet.Tables.Clear();
            _sqCon2.Close();

            if (rol == "admin")
            {
                _sqComm.CommandText = "delete from review where (Review ='" + label6.Text + "')";
                _sqComm.Connection = _sqCon2;
                _sqCon2.Open();
                _sqComm.ExecuteNonQuery();
                _sqComm.CommandText = "SELECT Nickname, Review From review where (Product='" + this.name + "')";
                _daP = new SqlDataAdapter(_sqComm);
                _daP.Fill(_dSet);
                count = _dSet.Tables[0].Rows.Count;
                label1.Text = _dSet.Tables[0].Rows[count - 1][0].ToString();
                label2.Text = _dSet.Tables[0].Rows[count - 1][1].ToString();
                label3.Text = _dSet.Tables[0].Rows[count - 2][0].ToString();
                label4.Text = _dSet.Tables[0].Rows[count - 2][1].ToString();
                label5.Text = _dSet.Tables[0].Rows[count - 3][0].ToString();
                label6.Text = _dSet.Tables[0].Rows[count - 3][1].ToString();
                _dSet.Tables.Clear();
                _sqCon2.Close();
            }
            if (rol == "moderator")
            {
                _sqComm.CommandText = "delete from review where (Review ='" + label6.Text + "')";
                _sqComm.Connection = _sqCon2;
                _sqCon2.Open();
                if (label5.Text == "Admin")
                {
                    MessageBox.Show("Вы не можете удалять коментарии Администратора. У вас недотаточно прав");
                    _sqCon2.Close();
                }
                else
                {
                    _sqComm.ExecuteNonQuery();
                    _sqComm.CommandText = "SELECT Nickname, Review From review where (Product='" + this.name + "')";
                    _daP = new SqlDataAdapter(_sqComm);
                    _daP.Fill(_dSet);
                    count = _dSet.Tables[0].Rows.Count;
                    label1.Text = _dSet.Tables[0].Rows[count - 1][0].ToString();
                    label2.Text = _dSet.Tables[0].Rows[count - 1][1].ToString();
                    label3.Text = _dSet.Tables[0].Rows[count - 2][0].ToString();
                    label4.Text = _dSet.Tables[0].Rows[count - 2][1].ToString();
                    label5.Text = _dSet.Tables[0].Rows[count - 3][0].ToString();
                    label6.Text = _dSet.Tables[0].Rows[count - 3][1].ToString();
                    _dSet.Tables.Clear();
                    _sqCon2.Close();
                }
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            _dSet.Tables.Clear();
            _sqComm.CommandText = "select rol from Rol where (nick ='" + this.log + "')";
            _sqComm.Connection = _sqCon2;
            _sqCon2.Open();
            _daP = new SqlDataAdapter(_sqComm);
            _daP.Fill(_dSet);
            string rol = _dSet.Tables[0].Rows[0][0].ToString();
            _dSet.Tables.Clear();
            _sqCon2.Close();
            
            if (rol == "admin")
                {
                    _sqComm.CommandText = "delete from review where (Review ='" + label2.Text + "')";
                    _sqComm.Connection = _sqCon2;
                    _sqCon2.Open();
                    _sqComm.ExecuteNonQuery();
                    _sqComm.CommandText = "SELECT Nickname, Review From review where (Product='" + this.name + "')";
                    _daP = new SqlDataAdapter(_sqComm);
                    _daP.Fill(_dSet);
                    count = _dSet.Tables[0].Rows.Count;
                    label1.Text = _dSet.Tables[0].Rows[count - 1][0].ToString();
                    label2.Text = _dSet.Tables[0].Rows[count - 1][1].ToString();
                    label3.Text = _dSet.Tables[0].Rows[count - 2][0].ToString();
                    label4.Text = _dSet.Tables[0].Rows[count - 2][1].ToString();
                    label5.Text = _dSet.Tables[0].Rows[count - 3][0].ToString();
                    label6.Text = _dSet.Tables[0].Rows[count - 3][1].ToString();
                    _dSet.Tables.Clear();
                    _sqCon2.Close();
                }
            if (rol == "moderator")
            {
                _sqComm.CommandText = "delete from review where (Review ='" + label2.Text + "')";
                _sqComm.Connection = _sqCon2;
                _sqCon2.Open();
                if (label1.Text == "Admin")
                {
                    MessageBox.Show("Вы не можете удалять коментарии Администратора. У вас недотаточно прав");
                    _sqCon2.Close();
                }
                else
                {
                    _sqComm.ExecuteNonQuery();
                    _sqComm.CommandText = "SELECT Nickname, Review From review where (Product='" + this.name + "')";
                    _daP = new SqlDataAdapter(_sqComm);
                    _daP.Fill(_dSet);
                    count = _dSet.Tables[0].Rows.Count;
                    label1.Text = _dSet.Tables[0].Rows[count - 1][0].ToString();
                    label2.Text = _dSet.Tables[0].Rows[count - 1][1].ToString();
                    label3.Text = _dSet.Tables[0].Rows[count - 2][0].ToString();
                    label4.Text = _dSet.Tables[0].Rows[count - 2][1].ToString();
                    label5.Text = _dSet.Tables[0].Rows[count - 3][0].ToString();
                    label6.Text = _dSet.Tables[0].Rows[count - 3][1].ToString();
                    _dSet.Tables.Clear();
                    _sqCon2.Close();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _dSet.Tables.Clear();
            _sqComm.CommandText = "select rol from Rol where (nick ='" + this.log + "')";
            _sqComm.Connection = _sqCon2;
            _sqCon2.Open();
            _daP = new SqlDataAdapter(_sqComm);
            _daP.Fill(_dSet);
            string rol = _dSet.Tables[0].Rows[0][0].ToString();
            _dSet.Tables.Clear();
            _sqCon2.Close();

            if (rol == "admin")
            {
                _sqComm.CommandText = "delete from review where (Review ='" + label4.Text + "')";
                _sqComm.Connection = _sqCon2;
                _sqCon2.Open();
                _sqComm.ExecuteNonQuery();
                _sqComm.CommandText = "SELECT Nickname, Review From review where (Product='" + this.name + "')";
                _daP = new SqlDataAdapter(_sqComm);
                _daP.Fill(_dSet);
                count = _dSet.Tables[0].Rows.Count;
                label1.Text = _dSet.Tables[0].Rows[count - 1][0].ToString();
                label2.Text = _dSet.Tables[0].Rows[count - 1][1].ToString();
                label3.Text = _dSet.Tables[0].Rows[count - 2][0].ToString();
                label4.Text = _dSet.Tables[0].Rows[count - 2][1].ToString();
                label5.Text = _dSet.Tables[0].Rows[count - 3][0].ToString();
                label6.Text = _dSet.Tables[0].Rows[count - 3][1].ToString();
                _dSet.Tables.Clear();
                _sqCon2.Close();
            }
            if (rol == "moderator")
            {
                _sqComm.CommandText = "delete from review where (Review ='" + label4.Text + "')";
                _sqComm.Connection = _sqCon2;
                _sqCon2.Open();
                if (label3.Text == "Admin")
                {
                    MessageBox.Show("Вы не можете удалять коментарии Администратора. У вас недотаточно прав");
                    _sqCon2.Close();
                }
                else
                {
                    _sqComm.ExecuteNonQuery();
                    _sqComm.CommandText = "SELECT Nickname, Review From review where (Product='" + this.name + "')";
                    _daP = new SqlDataAdapter(_sqComm);
                    _daP.Fill(_dSet);
                    count = _dSet.Tables[0].Rows.Count;
                    label1.Text = _dSet.Tables[0].Rows[count - 1][0].ToString();
                    label2.Text = _dSet.Tables[0].Rows[count - 1][1].ToString();
                    label3.Text = _dSet.Tables[0].Rows[count - 2][0].ToString();
                    label4.Text = _dSet.Tables[0].Rows[count - 2][1].ToString();
                    label5.Text = _dSet.Tables[0].Rows[count - 3][0].ToString();
                    label6.Text = _dSet.Tables[0].Rows[count - 3][1].ToString();
                    _dSet.Tables.Clear();
                    _sqCon2.Close();
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            _sqComm.CommandText = "insert into review values ('"+this.log+"','"+textBox1.Text+"','"+this.name+"')";
            _sqComm.Connection = _sqCon2;
            _sqCon2.Open();
            _sqComm.ExecuteNonQuery();
            _sqComm.CommandText = "SELECT Nickname, Review From review where (Product='" + this.name + "')";
            _daP = new SqlDataAdapter(_sqComm);
            _daP.Fill(_dSet);
            count = _dSet.Tables[0].Rows.Count;
            label1.Text = _dSet.Tables[0].Rows[count - 1][0].ToString();
            label2.Text = _dSet.Tables[0].Rows[count - 1][1].ToString();
            label3.Text = _dSet.Tables[0].Rows[count - 2][0].ToString();
            label4.Text = _dSet.Tables[0].Rows[count - 2][1].ToString();
            label5.Text = _dSet.Tables[0].Rows[count - 3][0].ToString();
            label6.Text = _dSet.Tables[0].Rows[count - 3][1].ToString();
            _dSet.Tables.Clear();
            _sqCon2.Close();
            textBox1.Clear();
        }
    }
}
