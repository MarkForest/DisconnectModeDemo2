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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private SqlDataReader reader;
        DataTable table;
        SqlConnection conn;
        string cs = "";
        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection();
            string cs = ConfigurationManager.ConnectionStrings["My"].ConnectionString;
            conn.ConnectionString = cs;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.CommandText = textBox1.Text;
                comm.Connection = conn;
                dataGridView1.DataSource = null;
                table = new DataTable();
                reader = comm.ExecuteReader();
                int line = 0;
                while (reader.Read())
                {
                    if(line == 0)
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            table.Columns.Add(reader.GetName(i));
                        }
                        line++;
                    }

                    DataRow row = table.NewRow();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row[i] = reader[i];
                    }
                    table.Rows.Add(row);

                }
                dataGridView1.DataSource = table;
            }
            catch
            {

            }
        }
    }
}
