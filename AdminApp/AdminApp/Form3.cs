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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using AdminApp;

namespace AdminApp
{
    public partial class Form3 : Form
    {

        private NHibernate.Cfg.Configuration myConfiguration;
        private ISessionFactory mySessionFactory;
        private ISession mySession;
        private int erabiltzaileaId;

        public Form3(int ErabiltzaileaId)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            erabiltzaileaId = ErabiltzaileaId;

            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    var produktuak = session.Query<Produktua>().ToList();
                    dataGridView1.DataSource = produktuak;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                Produktua.ProduktuakErakutsi(dataGridView1);
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
            textBoxIdEguneratu.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBoxIdEzabatu.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox[] textBoxes = { textBoxIzenaGehitu, textBoxDeskribapenaGehitu, 
            textBoxPrezioaGehitu, textBoxErosketaPrezioaGehitu, textBoxMotaGehitu, 
            textBoxKantitateaGehitu, textBoxKantitateMinGehitu };
            try
            {
                Produktua.GehituProduktua(NHibernateHelper.SessionFactory, textBoxes, erabiltzaileaId, dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Produktua ezin izan da gehitu: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int produktuaId = Convert.ToInt32(textBoxIdEzabatu.Text);
            try
            {
                Produktua.EzabatuProduktua(NHibernateHelper.SessionFactory, produktuaId, erabiltzaileaId, dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ezin izan da produktua ezabatu: " + ex.Message);
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox[] textBoxes = { textBoxIdEguneratu, textBoxIzenaEguneratu, 
            textBoxDeskribapenaEguneratu, textBoxPrezioaEguneratu, textBoxErosketaPrezioaEguneratu, 
            textBoxKantitateaEguneratu, textBoxKantitateMinEguneratu, textBoxMotaEguneratu };
            try
            {
                Produktua.EguneratuProduktua(NHibernateHelper.SessionFactory, textBoxes, erabiltzaileaId, dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Produktua ezin izan da eguneratu: " + ex.Message);
            }
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(erabiltzaileaId);
            form2.Show();
            this.Close();
        }
    }
}
