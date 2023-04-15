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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CreditTask_Ex1
{
    public partial class Form1 : Form
    {
        SqlConnection cn;

        SqlDataAdapter data;

        SqlCommand cm;

        DataTable tb;

        int dk = 0;
        public Form1()
        {
            InitializeComponent();
        }

        public void enable(GroupBox grp, bool b)

        {

            grp.Enabled = b;

        }

        public void showGRD1()

        {

            string s = "select * from Item";

            data = new SqlDataAdapter(s, cn);

            tb = new DataTable();

            data.Fill(tb);

            grd1.DataSource = tb;

        }
        public void showGRD2()

        {

            string s = "select * from Agent";

            data = new SqlDataAdapter(s, cn);

            tb = new DataTable();

            data.Fill(tb);

            grd2.DataSource = tb;

        }
        public void showGRD3()

        {

            string s = "select * from Order_order";

            data = new SqlDataAdapter(s, cn);

            tb = new DataTable();

            data.Fill(tb);

            grd3.DataSource = tb;

        }
        public void showGRD4()

        {

            string s = "select * from order_Detail";

            data = new SqlDataAdapter(s, cn);

            tb = new DataTable();

            data.Fill(tb);

            grd4.DataSource = tb;

        }

        void formload()

        {

            showGRD1();
            showGRD2();
            showGRD3();
            showGRD4();

            btnPdelete.Enabled = false;
            btnPupdate.Enabled = false;
            btnPsave.Enabled = false;

            btnAdelete.Enabled = false;
            btnAupdate.Enabled = false;
            btnAsave.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string sql = "initial catalog = CreditTask; data source = MSI\\SQLEXPRESS; integrated security = true";

            cn = new SqlConnection(sql);

            cn.Open();

            showAgent();
            showOrder();
            showItem();

            formload();

            Form2 f = new Form2();
            f.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtProduct.Text = grd1.CurrentRow.Cells[0].Value.ToString();
            txtPname.Text = grd1.CurrentRow.Cells[1].Value.ToString();
            txtSize.Text = grd1.CurrentRow.Cells[2].Value.ToString();
            txtPquantity.Text = grd1.CurrentRow.Cells[3].Value.ToString();

            btnPdelete.Enabled = true;

            btnPupdate.Enabled = true;
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = grd4.CurrentRow.Cells[0].Value.ToString();
            cbod.Text = grd4.CurrentRow.Cells[1].Value.ToString();
            cbit.Text = grd4.CurrentRow.Cells[2].Value.ToString();
            txtDquantity.Text = grd4.CurrentRow.Cells[3].Value.ToString();
            txtDunit.Text = grd4.CurrentRow.Cells[3].Value.ToString();

            btnDdelete.Enabled = true;

            btnDupdate.Enabled = true;
        }

        private void grd2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtAid.Text = grd2.CurrentRow.Cells[0].Value.ToString();
            txtAname.Text = grd2.CurrentRow.Cells[1].Value.ToString();
            txtAaddress.Text = grd2.CurrentRow.Cells[2].Value.ToString();
            

            btnAdelete.Enabled = true;

            btnAupdate.Enabled = true;
        }

        private void grd3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtOrder.Text = grd3.CurrentRow.Cells[0].Value.ToString();
            txtOrderdate.Text = grd3.CurrentRow.Cells[1].Value.ToString();
            cb.Text = grd3.CurrentRow.Cells[2].Value.ToString();
            

            btnOdelete.Enabled = true;

            btnOupdate.Enabled = true;
        }

        private void btnPadd_Click(object sender, EventArgs e)
        {            
            int count = 0;
            count = grd1.Rows.Count;
            if (count + 1 < 10)
            {
                txtProduct.Text = "I000" + count.ToString();
            }
            else if (count + 1 < 100)
            {
                txtProduct.Text = "I00" + count.ToString();
            }
            else
            {
                txtProduct.Text = "I0" + count.ToString();
            }

            txtProduct.Enabled= false;

            enable(grp2, false);
            enable(grp3, false);
            enable(grp4, false);

            dk = 1;

            btnPsave.Enabled = true;


            txtSize.Clear();
            txtPname.Clear();
            txtPquantity.Clear();

            txtPname.Focus();
        }

        private void btnPupdate_Click(object sender, EventArgs e)
        {
            dk = 2;

            enable(grp2, false);
            enable(grp3, false);
            enable(grp4, false);

            btnPsave.Enabled = true;
            
        }

        private void btnPsave_Click(object sender, EventArgs e)
        {
            if (dk == 1)

            {

                //check primary key

                string s = "select * from Item where itemName = '" + txtPname.Text + "'";

                data = new SqlDataAdapter(s, cn);

                tb = new DataTable();

                data.Fill(tb);

                if (tb.Rows.Count > 0)

                {

                    MessageBox.Show("Product exists");

                    return;

                }

                s = "insert into Item values ('" + txtProduct.Text + "', N'" + txtPname.Text + "', N'" + txtSize.Text + "', '" + txtPquantity.Text + "')";

                cm = new SqlCommand(s, cn);

                cm.ExecuteNonQuery();

                enable(grp2, true);
                enable(grp3, true);
                enable(grp4, true);

                formload();

            }
            else
            {
                //Update
                string sql = "update Item set itemName = N'" + txtPname.Text + "', size = N'" + txtSize.Text + "', quantity = '" + txtPquantity.Text + "' where itemId = '" + txtProduct.Text + "'";
                cm = new SqlCommand(sql, cn);
                cm.ExecuteNonQuery();

                enable(grp2, true);
                enable(grp3, true);
                enable(grp4, true);

                formload();
            }

        }

    

    private void btnPdelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)

            {

                string sql = "delete from Item where itemID ='" + txtProduct.Text + "'";

                cm = new SqlCommand(sql, cn);

                cm.ExecuteNonQuery();

                txtProduct.Clear();
                txtPname.Clear();
                txtSize.Clear();
                txtPquantity.Clear();

                formload();

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void grp2_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)

            {

                string sql = "delete from Agent where agentId ='" + txtAid.Text + "'";

                cm = new SqlCommand(sql, cn);

                cm.ExecuteNonQuery();

                txtAid.Clear();
                txtAname.Clear();
                txtAaddress.Clear();
                

                formload();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            count = grd2.Rows.Count;
            if (count + 1 < 10)
            {
                txtAid.Text = "A000" + count.ToString();
            }
            else if (count + 1 < 100)
            {
                txtAid.Text = "A00" + count.ToString();
            }
            else
            {
                txtAid.Text = "A0" + count.ToString();
            }

            txtAid.Enabled = false;

            enable(grp1, false);
            enable(grp3, false);
            enable(grp4, false);

            dk = 1;

            btnAsave.Enabled = true;


            
            txtAname.Clear();
            txtAaddress.Clear();

            txtPname.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dk == 1)

            {

                //check primary key

                string s = "select * from Agent where agentName = '" + txtAname.Text + "'";

                data = new SqlDataAdapter(s, cn);

                tb = new DataTable();

                data.Fill(tb);

                if (tb.Rows.Count > 0)

                {

                    MessageBox.Show("Agent exists");

                    return;

                }

                s = "insert into Agent values ('" + txtAid.Text + "', N'" + txtAname.Text + "', N'" + txtAaddress.Text + "')";

                cm = new SqlCommand(s, cn);

                cm.ExecuteNonQuery();

                enable(grp1, true);
                enable(grp3, true);
                enable(grp4, true);

                formload();
            }
            else
            {
                //Update
                string sql = "update Agent set agentName = N'" + txtAname.Text + "', address = N'" + txtAaddress.Text + "' where agentId = '" + txtAid.Text + "'";
                cm = new SqlCommand(sql, cn);
                cm.ExecuteNonQuery();

                enable(grp1, true);
                enable(grp3, true);
                enable(grp4, true);

                formload();
            }
        }

        private void btnAupdate_Click(object sender, EventArgs e)
        {
            dk = 2;

            enable(grp1, false);
            enable(grp3, false);
            enable(grp4, false);
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void grp3_Enter(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dk = 2;

            enable(grp1, false);
            enable(grp2, false);
            enable(grp4, false);
        }

        void showAgent()
        {
            string sql = "select distinct agentId from Agent";
            data = new SqlDataAdapter(sql, cn);
            tb = new DataTable();
            data.Fill(tb);
            cb.DataSource = tb;
            cb.ValueMember = "agentId";
            cb.DisplayMember = "AgentId";
        }

        void showOrder()
        {
            string sql = "select distinct orderId from Order_order";
            data = new SqlDataAdapter(sql, cn);
            tb = new DataTable();
            data.Fill(tb);
            cbod.DataSource = tb;
            cbod.ValueMember = "orderId";
            cbod.DisplayMember = "orderId";
        }

        void showItem()
        {
            string sql = "select distinct itemId from Item";
            data = new SqlDataAdapter(sql, cn);
            tb = new DataTable();
            data.Fill(tb);
            cbit.DataSource = tb;
            cbit.ValueMember = "itemId";
            cbit.DisplayMember = "itemId";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int count = 0;
            count = grd3.Rows.Count;
            if (count + 1 < 10)
            {
                txtOrder.Text = "OD000" + count.ToString();
            }
            else if (count + 1 < 100)
            {
                txtOrder.Text = "OD00" + count.ToString();
            }
            else
            {
                txtOrder.Text = "OD0" + count.ToString();
            }

            txtOrder.Enabled = false;

            enable(grp1, false);
            enable(grp2, false);
            enable(grp4, false);

            dk = 1;

            btnOsave.Enabled = true;



            
           

            
        }

        private void btnOdelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)

            {

                string sql = "delete from Order_order where orderId ='" + txtOrder.Text + "'";

                cm = new SqlCommand(sql, cn);

                cm.ExecuteNonQuery();

                txtOrder.Clear();
                

                formload();

            }
        }

        private void btnOsave_Click(object sender, EventArgs e)
        {
            if (dk == 1)

            {

                //check primary key

                

                string s = "insert into Order_order values ('" + txtOrder.Text + "', N'" + txtOrderdate.Text + "', N'" + cb.Text + "')";

                cm = new SqlCommand(s, cn);

                cm.ExecuteNonQuery();

                enable(grp1, true);
                enable(grp2, true);
                enable(grp4, true);

                formload();
            }
            else
            {
                //Update
                string sql = "update Order_order set orderDate = N'" + txtOrderdate.Text + "', agentId = N'" + cb.Text + "' where orderId = '" + txtOrder.Text + "'";
                cm = new SqlCommand(sql, cn);
                cm.ExecuteNonQuery();

                enable(grp1, true);
                enable(grp2, true);
                enable(grp4, true);

                formload();
            }
        }

        private void grp4_Enter(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void btnDadd_Click(object sender, EventArgs e)
        {
            int count = 0;
            count = grd4.Rows.Count;
            if (count + 1 < 10)
            {
                txtID.Text = "DETAIL000" + count.ToString();
            }
            else if (count + 1 < 100)
            {
                txtID.Text = "DETAIL00" + count.ToString();
            }
            else
            {
                txtID.Text = "DETAIL0" + count.ToString();
            }

            txtID.Enabled = false;

            enable(grp1, false);
            enable(grp2, false);
            enable(grp3, false);

            dk = 1;

            btnDsave.Enabled = true;
        }

        private void btnDupdate_Click(object sender, EventArgs e)
        {
            dk = 2;

            enable(grp1, false);
            enable(grp2, false);
            enable(grp3, false);
        }

        private void btnDdelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)

            {

                string sql = "delete from order_Detail where id ='" + txtID.Text + "'";

                cm = new SqlCommand(sql, cn);

                cm.ExecuteNonQuery();

                txtID.Clear();
                txtDquantity.Clear();
                txtDunit.Clear();

                formload();

            }
        }

        private void btnDsave_Click(object sender, EventArgs e)
        {
            if (dk == 1)

            {

                //check primary key

                

                string s = "insert into  order_Detail values ('" + txtID.Text + "', N'" + cbod.Text + "', N'" + cbit.Text + "', '" + txtDquantity.Text + "', '" + txtDunit.Text + "')";

                cm = new SqlCommand(s, cn);

                cm.ExecuteNonQuery();

                enable(grp1, true);
                enable(grp2, true);
                enable(grp3, true);

                formload();

            }
            else
            {
                //Update
                string sql = "update  order_Detail set orderId = N'" + cbod.Text + "', itemId = N'" + cbit.Text + "', quantity = '" + txtDquantity.Text + "',unitAmount = '" + txtDunit.Text + "' where id = '" + txtID.Text + "'";
                cm = new SqlCommand(sql, cn);
                cm.ExecuteNonQuery();

                enable(grp1, true);
                enable(grp3, true);
                enable(grp2, true);

                formload();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            
            f.ShowDialog();

            this.Close();
        }
    }
}
