using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreditTask_Ex1
{
    public partial class Form2 : Form
    {
        SqlConnection cn;

        SqlDataAdapter data;

        SqlCommand cm;

        DataTable tb;
        public Form2()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (txtUser.Text == "" || txtPass.Text == "")
            {
                validateLogin.Visible = false;
                validateLogin.Text = "Please input all the blank";
                validateLogin.Visible = true;
            }
            else 
            {

                String s = "SELECT id, pass FROM username WHERE id='" + txtUser.Text + "' and pass='" + txtPass.Text + "'";

                cm = new SqlCommand(s, cn);

                data = new SqlDataAdapter(cm);

                DataTable dt = new DataTable();

                data.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    validateLogin.Visible = false;
                    validateLogin.Text = "Login successfully";
                    validateLogin.Visible = true;
                    MessageBox.Show("Login Successfully!");
                    this.Close();
                }


                if (dt.Rows.Count == 0)
                {
                    validateLogin.Visible = false;
                    validateLogin.Text = "Invalid username or password";
                    validateLogin.Visible = true;
                }
            }
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string sql = "initial catalog = CreditTask; data source = MSI\\SQLEXPRESS; integrated security = true";

            cn = new SqlConnection(sql);

            cn.Open();
        }

        private void signIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            signIn f = new signIn();
            f.ShowDialog();
            
        }
    }
}
