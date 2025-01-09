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
        private int langileaId;

        private List<Produktua> carrito = new List<Produktua>();

        public Form4(int LangileaId)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            langileaId = LangileaId;
        }

        private void taulaKargatu()
        {
            try
            {
                // Configuración de NHibernate
                var myConfiguration = new NHibernate.Cfg.Configuration();
                myConfiguration.Configure(); // Esto lee el archivo de configuración app.config o hibernate.cfg.xml
                var mySessionFactory = myConfiguration.BuildSessionFactory();

                using (var mySession = mySessionFactory.OpenSession())
                {
                    using (var transaction = mySession.BeginTransaction())
                    {
                        try
                        {
                            string hql = "FROM Produktua";
                            var query = mySession.CreateQuery(hql);

                            var produktuak = query.List<Produktua>();

                            dataGridView1.DataSource = produktuak;

                            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                            dataGridView1.CellFormatting += dataGridView1_CellFormatting;

                            transaction.Commit(); // Confirma la transacción
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback(); // Revierte la transacción en caso de error
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
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
                        row.DefaultCellStyle.BackColor = Color.LightCoral; // Fondo rojo
                        row.DefaultCellStyle.ForeColor = Color.White; // Texto blanco
                    }
                    else if (kantitatea >= kantitateMinimoa && kantitatea <= kantitateMinimoa + 3)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightSalmon; // Fondo naranja
                        row.DefaultCellStyle.ForeColor = Color.Black; // Texto negro
                    }
                    else if (kantitatea > kantitateMinimoa + 3 && kantitatea <= kantitateMinimoa + 7)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow; // Fondo amarillo
                        row.DefaultCellStyle.ForeColor = Color.Black; // Texto negro
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen; // Fondo verde
                        row.DefaultCellStyle.ForeColor = Color.Black; // Texto negro
                    }
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(langileaId);
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
                // Configuración de NHibernate
                var myConfiguration = new NHibernate.Cfg.Configuration();
                myConfiguration.Configure(); // Lee la configuración desde app.config o hibernate.cfg.xml
                var mySessionFactory = myConfiguration.BuildSessionFactory();

                using (var mySession = mySessionFactory.OpenSession())
                {
                    using (var transaction = mySession.BeginTransaction())
                    {
                        try
                        {
                            // Actualizar los productos en el carrito
                            foreach (var producto in carrito)
                            {
                                // Buscar el producto en la base de datos por su nombre
                                var productoExistente = mySession.QueryOver<Produktua>()
                                    .Where(p => p.Izena == producto.Izena)
                                    .SingleOrDefault();

                                if (productoExistente != null)
                                {
                                    // Actualizamos la cantidad del producto
                                    productoExistente.Kantitatea += producto.ErosketaKantitatea;

                                    // Guardamos los cambios en la base de datos
                                    mySession.SaveOrUpdate(productoExistente);
                                }
                            }

                            // Confirmar la transacción
                            transaction.Commit();

                            MessageBox.Show("Compra realizada con éxito. Las cantidades han sido actualizadas.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Limpiar el carrito y la lista visual
                            carrito.Clear();
                            listBoxCarrito.Items.Clear();

                            taulaKargatu(); // Recargar la tabla
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback(); // Revierte la transacción en caso de error
                            MessageBox.Show("Error al realizar la compra: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al inicializar NHibernate: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }

}

