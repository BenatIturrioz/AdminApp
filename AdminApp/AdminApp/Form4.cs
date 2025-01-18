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
                var myConfiguration = new NHibernate.Cfg.Configuration();
                myConfiguration.Configure(); 
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

            if (dataGridView1.Columns["kantitatea"] != null && dataGridView1.Columns["kantitateMinimoa"] != null)
            {
                int kantitateaIndex = dataGridView1.Columns["kantitatea"].Index;
                int kantitateMinimoaIndex = dataGridView1.Columns["kantitateMinimoa"].Index;

                if (e.RowIndex >= 0 && e.ColumnIndex == kantitateaIndex)
                {
                    var row = dataGridView1.Rows[e.RowIndex];
                    int kantitatea = Convert.ToInt32(row.Cells[kantitateaIndex].Value);
                    int kantitateMinimoa = Convert.ToInt32(row.Cells[kantitateMinimoaIndex].Value);

                    if (kantitatea < kantitateMinimoa)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightCoral; 
                        row.DefaultCellStyle.ForeColor = Color.White; 
                    }
                    else if (kantitatea >= kantitateMinimoa && kantitatea <= kantitateMinimoa + 3)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightSalmon; 
                        row.DefaultCellStyle.ForeColor = Color.Black; 
                    }
                    else if (kantitatea > kantitateMinimoa + 3 && kantitatea <= kantitateMinimoa + 7)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                        row.DefaultCellStyle.ForeColor = Color.Black; 
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen; 
                        row.DefaultCellStyle.ForeColor = Color.Black; 
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
            textBoxErosketaPrezioa.Clear();
            textBoxKantMin.Clear();
            textBoxErosketaKant.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Produktua.erosketaEgin(carrito, listBoxCarrito);
            taulaKargatu();
        }

        private void listBoxCarrito_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}


