using AdminApp.Dominio;
using MySql.Data.MySqlClient;
using NHibernate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminApp
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private NHibernate.Cfg.Configuration myConfiguration;
        private ISessionFactory mySessionFactory;
        private ISession mySession;

        private void Form4_Load(object sender, EventArgs e)
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

                    dataGridView1.CellFormatting += dataGridView1_CellFormatting;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadDataGridView()
        {
            using (var session = mySessionFactory.OpenSession())
            {
                var produktuak = session.Query<Produktua>().ToList();
                dataGridView1.DataSource = produktuak;
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Asegúrate de que las columnas "Kantitatea" y "KantitateMinimoa" estén disponibles
            if (dataGridView1.Columns["kantitatea"] != null && dataGridView1.Columns["kantitateMinimoa"] != null)
            {
                int kantitateaIndex = dataGridView1.Columns["kantitatea"].Index;
                int kantitateMinimoaIndex = dataGridView1.Columns["kantitateMinimoa"].Index;

                // Verificar si estamos formateando una fila completa (o una columna específica)
                if (e.RowIndex >= 0 && e.ColumnIndex == kantitateaIndex)
                {
                    var row = dataGridView1.Rows[e.RowIndex];

                    // Obtener los valores de las columnas Kantitatea y KantitateMinimoa
                    int kantitatea = Convert.ToInt32(row.Cells[kantitateaIndex].Value);
                    int kantitateMinimoa = Convert.ToInt32(row.Cells[kantitateMinimoaIndex].Value);

                    // Aplicar el color según las condiciones
                    if (kantitatea < kantitateMinimoa)
                    {
                        row.DefaultCellStyle.BackColor = Color.Red; // Fondo rojo
                        row.DefaultCellStyle.ForeColor = Color.White; // Texto blanco
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.Green; // Fondo verde
                        row.DefaultCellStyle.ForeColor = Color.Black; // Texto negro
                    }
                }
            }
        }
    }
}
