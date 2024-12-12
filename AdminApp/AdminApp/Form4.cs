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
        private NHibernate.Cfg.Configuration myConfiguration;
        private ISessionFactory mySessionFactory;
        private ISession mySession;

        private List<Produktua> carrito = new List<Produktua>();

        public Form4()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void taulaKargatu()
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

        private void Form4_Load(object sender, EventArgs e)
        {
            taulaKargatu();
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

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxIzena.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBoxPrezioa.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBoxErosketaPrezioa.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBoxKantMin.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBoxKantitatea.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string izena = textBoxIzena.Text;
            float erosPrezioa = Convert.ToSingle(textBoxErosketaPrezioa.Text);
            int kantitatea = Convert.ToInt32(textBoxKantitatea.Text);
            int cantidadMinima = Convert.ToInt32(textBoxKantMin.Text);
            int erosketaKantitatea = Convert.ToInt32(textBoxErosketaKant.Text);

            Produktua producto = new Produktua
            {
                Izena = izena,
                ErosketaPrezioa = erosPrezioa,
                Kantitatea = kantitatea,
                KantitateMin = cantidadMinima,
                ErosketaKantitatea = erosketaKantitatea
            };

            carrito.Add(producto);

            listBoxCarrito.Items.Add($"{producto.Izena} - {producto.ErosketaPrezioa}€ x {producto.ErosketaKantitatea} = {producto.ErosketaPrezioa * producto.ErosketaKantitatea}€");

            textBoxIzena.Clear();
            textBoxPrezioa.Clear();
            textBoxKantitatea.Clear();
            textBoxErosketaPrezioa .Clear();
            textBoxKantMin.Clear();
            textBoxErosketaKant.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Connection connection = new Connection();

                using (MySqlConnection konexioa = connection.GetConnection())
                {
                    konexioa.Open();
                    foreach (var producto in carrito)
                    {
                        string query = "UPDATE produktua SET kantitatea = kantitatea + @erosketaKantitatea WHERE izena = @izena";
                        using (MySqlCommand cmd = new MySqlCommand(query, konexioa))
                        {
                            cmd.Parameters.AddWithValue("@erosketaKantitatea", producto.ErosketaKantitatea);
                            cmd.Parameters.AddWithValue("@izena", producto.Izena);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Compra realizada con éxito. Las cantidades han sido actualizadas.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar el carrito y la lista visual
                    carrito.Clear();
                    listBoxCarrito.Items.Clear();

                    taulaKargatu();



                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar la compra: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
