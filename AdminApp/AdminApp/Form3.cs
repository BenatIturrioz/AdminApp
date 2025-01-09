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
        }

        private void LoadDataGridView()
        {
            using (var session = mySessionFactory.OpenSession())
            {
                var produktuak = session.Query<Produktua>().ToList();
                dataGridView1.DataSource = produktuak; // Asume que dataGridView1 es el nombre de tu DataGridView
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

        private void historialaGorde(int produktuaId, string ekintza)
        {
            using (var session = mySessionFactory.OpenSession()) 
            {
                using (var transaction = session.BeginTransaction()) 
                {
                    try
                    {
                        
                        var produktua = session.Get<Produktua>(produktuaId); 
                        if (produktua == null) 
                        {
                            MessageBox.Show($"El producto con ID {produktuaId} no existe. Operación cancelada.");
                            return;
                        }

                        ProduktuHistorikoa historiala = new ProduktuHistorikoa
                        {
                            ProduktuaId = produktuaId,
                            ErabiltzaileaId = erabiltzaileaId, 
                            Data = DateTime.Now,
                            Ekintza = ekintza,
                            Galera = 0
                        };

                        session.Save(historiala);

                        transaction.Commit();

                        MessageBox.Show("El historial se ha guardado correctamente.");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error al guardar el historial: " + ex.Message);
                    }
                }
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
                    historialaGorde(produktua.Id, "Produktua gehitu");
                    LoadDataGridView();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();  // Si hay un error, revierte la transacción
                    MessageBox.Show("Errorkaixo: " + ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            myConfiguration = new NHibernate.Cfg.Configuration();
            myConfiguration.Configure();
            mySessionFactory = myConfiguration.BuildSessionFactory();
            mySession = mySessionFactory.OpenSession();

            using (var transaction = mySession.BeginTransaction())
            {
                try
                {
                    // Mostrar cuadro de confirmación
                    DialogResult confirmacion = MessageBox.Show(
                        "Seguru zaude produktua ezabatu nahi duzula?",
                        "Konfirmazioa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    // Verificar la respuesta del usuario
                    if (confirmacion == DialogResult.Yes)
                    {
                        // Cargar el objeto "Produktua" a actualizar
                        int id = Convert.ToInt32(textBoxIdEzabatu.Text); // ID del producto a buscar
                        var produktuaEzabatu = mySession.Query<Produktua>()
                                                        .FirstOrDefault(f => f.Id == id);

                        if (produktuaEzabatu != null)
                        {
                            // Cambiar el valor de la columna "aktibo" a 0
                            produktuaEzabatu.Aktibo = 0;

                            // Guardar el cambio en la base de datos
                            mySession.Update(produktuaEzabatu);

                            transaction.Commit(); // Confirmar la transacción para aplicar el cambio

                            // Registrar el cambio en el historial
                            historialaGorde(id, "Produktua desaktibatu");

                            // Mostrar mensaje de éxito
                            MessageBox.Show("Produktua ongi desaktibatua izan da.");

                            // Recargar el DataGridView
                            LoadDataGridView();
                        }
                        else
                        {
                            // Mostrar mensaje si el producto no existe
                            MessageBox.Show("Produktuaren id-a ezin izan da bilatu.");
                        }
                    }
                    else
                    {
                        // Operación cancelada por el usuario
                        MessageBox.Show("Ezabatzeko operazioa bertan behera utzi da.");
                    }
                }
                catch (Exception ex)
                {
                    // Revertir la transacción en caso de error
                    transaction.Rollback();
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            myConfiguration = new NHibernate.Cfg.Configuration();
            myConfiguration.Configure();
            mySessionFactory = myConfiguration.BuildSessionFactory();
            mySession = mySessionFactory.OpenSession();

            using (var transaction = mySession.BeginTransaction())
            {
                try
                {
                    DialogResult confirmacion = MessageBox.Show(
                       "Seguru zaude produktua ezabatu nahi duzula?",
                       "Konfirmazioa",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Warning
                   );

                    if (confirmacion == DialogResult.Yes)
                    {
                        // Obtener el ID de la fruta a actualizar
                        int id = Convert.ToInt32(textBoxIdEguneratu.Text);  // ID de la fruta a buscar

                        // Buscar el objeto "frutak" en la base de datos
                        var produktuaEgunertau = mySession.Query<Produktua>()
                                                        .FirstOrDefault(f => f.Id == id);

                        if (produktuaEgunertau != null)
                        {
                            // Actualizar los campos del objeto "frutak" con los valores de los TextBox
                            produktuaEgunertau.Izena = textBoxIzenaEguneratu.Text;                // Asignar el valor del TextBox "izena"
                            produktuaEgunertau.Deskribapena = textBoxDeskribapenaEguneratu.Text;  // Convertir y asignar el valor de "stock"
                            produktuaEgunertau.Prezioa = Convert.ToInt32(textBoxPrezioaEguneratu.Text);// Convertir y asignar el valor de "prezioa"
                            produktuaEgunertau.ErosketaPrezioa = Convert.ToInt32(textBoxErosketaPrezioaEguneratu.Text);  // Convertir y asignar el valor de "stock"
                            produktuaEgunertau.Kantitatea = Convert.ToInt32(textBoxKantitateaEguneratu.Text);  // Convertir y asignar el valor de "stock"
                            produktuaEgunertau.KantitateMin = Convert.ToInt32(textBoxKantitateMinEguneratu.Text);  // Convertir y asignar el valor de "stock"
                            produktuaEgunertau.Mota = Convert.ToInt32(textBoxMotaEguneratu.Text);  // Convertir y asignar el valor de "stock"


                            // Guardar los cambios en la base de datos
                            mySession.Update(produktuaEgunertau);
                            mySession.Save(produktuaEgunertau);
                            transaction.Commit();  // Confirmar la transacción

                            MessageBox.Show("Produktua ondo eguneratu da.");
                            historialaGorde(id, "Produktua ezabatu");
                            LoadDataGridView();
                        }
                        else
                        {
                            MessageBox.Show("Produktua ezin izan da bilatu");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Eguneratzeko operazioa bertan behera utzi da.");
                    }

                    
                }
                catch (Exception ex)
                {
                    transaction.Rollback();  // Revertir la transacción en caso de error
                    MessageBox.Show("Error: " + ex.Message);
                }
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
