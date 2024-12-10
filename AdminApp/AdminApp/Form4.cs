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

        private List<Produktua> carrito = new List<Produktua>();

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
            // Recorremos todos los elementos del ListBox (productos en el carrito)
            foreach (var item in listBoxCarrito.SelectedItems)
            {
                string itemText = item.ToString();

                // Parseamos la cadena del ListBox
                string[] itemParts = itemText.Split(new string[] { " - ", " x " }, StringSplitOptions.None);

                if (itemParts.Length >= 3)
                {
                    string productName = itemParts[0]; // Nombre del producto
                    float productPrice = Convert.ToSingle(itemParts[1].Replace("€", "").Trim()); // Precio del producto
                    int cantidadEnListBox = Convert.ToInt32(itemParts[2].Split(' ')[0]); // La cantidad actual en el ListBox
                    int erosketaKantitatea = Convert.ToInt32(textBoxErosketaKant.Text); // La cantidad a sumar desde el TextBox

                    // Calcular la nueva cantidad
                    int nuevaCantidad = cantidadEnListBox + erosketaKantitatea;

                    // Realizar la actualización en la base de datos
                    string query = "UPDATE produktua SET kantitatea = @nuevaCantidad WHERE izena = @productName";

                    try
                    {

                        Connection connection = new Connection();
                        // Realizar la conexión a la base de datos y ejecutar la actualización
                        using (MySqlConnection konexioa = connection.GetConnection())
                        {
                            konexioa.Open();
                            using (MySqlCommand cmd = new MySqlCommand(query, konexioa))
                            {
                                // Definir los parámetros para la consulta
                                cmd.Parameters.AddWithValue("@nuevaCantidad", nuevaCantidad);
                                cmd.Parameters.AddWithValue("@productName", productName);

                                // Ejecutar la consulta
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // Actualizar el texto del ListBox con la nueva cantidad
                        int index = listBoxCarrito.Items.IndexOf(item);
                        listBoxCarrito.Items[index] = $"{productName} - {productPrice}€ x {nuevaCantidad} = {productPrice * nuevaCantidad}€";

                        // Opcional: Mostrar un mensaje de éxito
                        MessageBox.Show($"La cantidad de '{productName}' ha sido actualizada a {nuevaCantidad}.");
                    }
                    catch (Exception ex)
                    {
                        // Manejo de errores
                        MessageBox.Show("Error al actualizar la base de datos: " + ex.Message);
                    }
                }
            }
        }
    }
}
