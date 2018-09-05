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
using System.Configuration;

namespace DataAdapterDemo
{
    public partial class Form1 : Form
    {
        SqlConnection conn = null;
        SqlDataAdapter da = null;
        DataSet set = null;
        SqlCommandBuilder builder = null;
        string cs = "";
        public Form1()
        {
            InitializeComponent();
            cs = ConfigurationManager.ConnectionStrings["My"].ConnectionString;
            conn = new SqlConnection(cs);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = textBox1.Text;
                da = new SqlDataAdapter(sql, conn);
                dataGridView1.DataSource = null;
                builder = new SqlCommandBuilder(da);
                set = new DataSet();
                da.Fill(set, "MyTable");
                dataGridView1.DataSource = set.Tables["MyTable"];
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            da.Update(set, "MyTable");
        }
    }
}
