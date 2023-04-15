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
    public partial class Form3 : Form
    {
        SqlConnection cn;

        SqlDataAdapter data;

        SqlCommand cm;

        DataTable tb;

        public Form3()
        {
            InitializeComponent();
        }

        void showItem()
        {
            string sql = "select distinct itemId from Item";
            data = new SqlDataAdapter(sql, cn);
            tb = new DataTable();
            data.Fill(tb);
            cb.DataSource = tb;
            cb.ValueMember = "itemId";
            cb.DisplayMember = "itemId";
        }

        public void showGRD()

        {

            string s = "select * from Item";

            data = new SqlDataAdapter(s, cn);

            tb = new DataTable();

            data.Fill(tb);

            grd.DataSource = tb;

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string sql = "initial catalog = CreditTask; data source = MSI\\SQLEXPRESS; integrated security = true";

            cn = new SqlConnection(sql);

            cn.Open();
            showGRD();
            showItem();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           


        }

        private void cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text = "Customers purchased this product";

            string s = "select distinct agentName from Agent where agentId in ( select agentId from Order_order where orderID in ( select order_Detail.orderId from order_Detail, Item where '" + cb.Text + "' = order_Detail.itemId))";

            data = new SqlDataAdapter(s, cn);

            tb = new DataTable();

            data.Fill(tb);

            grd.DataSource = tb;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = "select * from Item";

            data = new SqlDataAdapter(s, cn);

            tb = new DataTable();

            data.Fill(tb);

            grd.DataSource = tb;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label2.Text = "Top 3 customers mostly purchased ";

            string s = "select * from Agent where agentId in (SELECT  top 3 agentId FROM Order_order GROUP BY agentId HAVING COUNT(agentId) > 1 ORDER BY COUNT(agentId) desc)";

            data = new SqlDataAdapter(s, cn);

            tb = new DataTable();

            data.Fill(tb);

            grd.DataSource = tb;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label2.Text = "Top 3 item mostly purchased by customers";

            string s = "select * from item where itemid in (SELECT  top 3 itemId FROM order_Detail GROUP BY itemId HAVING COUNT(itemId) > 0 ORDER BY COUNT(itemId) desc)";

            data = new SqlDataAdapter(s, cn);

            tb = new DataTable();

            data.Fill(tb);

            grd.DataSource = tb;
        }
    }
}
