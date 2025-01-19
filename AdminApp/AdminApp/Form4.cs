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

        private void Form4_Load(object sender, EventArgs e)
        {
            Produktua.TaulaKargatu(dataGridView1);
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
            Produktua.TaulaKargatu(dataGridView1);
        }

        private void listBoxCarrito_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}


