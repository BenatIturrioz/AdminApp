using AdminApp.Dominio;
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxIzenaEguneratu.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBoxIzenaEzabatu.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBoxErosketaPrezioaEguneratu.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBoxErosketaPrezioaEzabatu.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBoxPrezioaEguneratu.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBoxPrezioaEzabatu.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBoxMotaEguneratu.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBoxMotaEzabatu.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBoxKantitateaEguneratu.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBoxKantitateaEzabatu.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBoxKantitateMinEguneratu.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBoxKantitateMinEzabatu.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBoxDeskribapenaEguneratu.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBoxDeskribapenaEzabatu.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Konfigurazioa sortzen da BD-arekin konektatzeko app.config-en definitzen dena.
            myConfiguration = new NHibernate.Cfg.Configuration();
            myConfiguration.Configure();
            mySessionFactory = myConfiguration.BuildSessionFactory();
            mySession = mySessionFactory.OpenSession();
            using (var transaction = mySession.BeginTransaction())
            {
                try
                {
                    Produktua produktua = new Produktua
                    {
                        Izena = Convert.ToString(textBoxIzenaGehitu.Text),
                        Deskribapena = Convert.ToString(textBoxDeskribapenaGehitu.Text),
                        Prezioa = Convert.ToSingle(textBoxPrezioaGehitu.Text),
                        ErosketaPrezioa = Convert.ToSingle(textBoxErosketaPrezioaGehitu.Text),
                        Mota = Convert.ToInt16(textBoxMotaGehitu.Text),
                        Kantitatea = Convert.ToInt16(textBoxKantitateaGehitu.Text),
                        KantitateMin = Convert.ToInt16(textBoxKantitateMinGehitu.Text)
                    };
                    mySession.Save(produktua);
                    transaction.Commit();  // Asegúrate de confirmar la transacción
                    MessageBox.Show("Produktua ongi gehituta.");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();  // Si hay un error, revierte la transacción
                    MessageBox.Show("Errorkaixo: " + ex.Message);
                }
            }
        }
    }
}
