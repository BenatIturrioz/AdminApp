using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using NHibernate;

namespace AdminApp
{
    public partial class Form3 : Form
    {

        private NHibernate.Cfg.Configuration myConfiguration;
        private ISessionFactory mySessionFactory;
        private ISession mySession;

        public Form3()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                Connection connection = new Connection();
                string query = "SELECT * FROM produktua";

                using (MySqlConnection konexioa = connection.GetConnection())
                {
                    konexioa.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, konexioa))
                    {
                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                        DataTable tabla1 = new DataTable();
                        dataAdapter.Fill(tabla1);
                        dataGridView1.DataSource = tabla1;
                    }

                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: "+ex.Message);
            }
        }
    }
}
