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
    public partial class signIn : Form
    {
        SqlConnection cn;

        SqlDataAdapter data;

        SqlCommand cm;

        DataTable tb;
        public signIn()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtUser.Clear();
            txtName.Clear();
            txtPass.Clear();
            txtRepass.Clear();
        }

        private void btnSignin_Click(object sender, EventArgs e)
        {
            string s = "select * from username where id = '" + txtUser.Text + "'";
            data = new SqlDataAdapter(s, cn);
            tb = new DataTable();
            data.Fill(tb);

            if (txtPass.Text != txtRepass.Text)
            {
                validate.Text = "Re-password does not match";
                validate.Visible = true;
            }else if(tb.Rows.Count > 0)
            {
                validate.Visible = false;
                validate.Text = "User exists";
                validate.Visible = true;
            }
            else
            {               
                String sql = "insert into username VALUES('" + txtUser.Text + "','" + txtName.Text + "',N'" + txtPass.Text + "')";
                cm = new SqlCommand(sql, cn);

                int row = cm.ExecuteNonQuery();

                if (row == 1)
                {
                    validate.Visible = false;
                    validate.Text = "Sign in successfully";
                    validate.Visible = true;
                    MessageBox.Show("Sign in Successfully!");
                    this.Close();
                }
            }
        }

        private void signIn_Load(object sender, EventArgs e)
        {
            string sql = "initial catalog = CreditTask; data source = MSI\\SQLEXPRESS; integrated security = true";

            cn = new SqlConnection(sql);

            cn.Open();
        }
    }
}
