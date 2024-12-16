using AdminApp.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void saioaHasiButton_Click_1(object sender, EventArgs e)
        {
            string erabiltzaile = erabiltzaileaTextbox.Text.Trim(); ;
            string pasahitza = pasahitzaTextbox.Text.Trim();

            if (string.IsNullOrEmpty(erabiltzaile) || string.IsNullOrEmpty(pasahitza))
            {
                MessageBox.Show("Sartzeko erabiltzailea eta pasahitza sartu behar da", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Erabiltzailea erabiltzailea = new Erabiltzailea
                {
                    ErabiltzaileIzena = erabiltzaile,
                    Pasahitza = pasahitza
                };

                

                if (erabiltzailea.ValidarErabiltzailea())
                {
                    MessageBox.Show("Saioa hasita.", "Ongi etorri", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    erregistroakGorde(erabiltzailea.ErabiltzaileIzena, "Onartua");

                    int erabiltzaileaId = erabiltzailea.ErabiltzaileaId;
                    string langileaMota = erabiltzailea.LangileaMota;

                    Console.WriteLine("LangileaId: " + erabiltzaileaId);
                    Console.WriteLine("LangileaMota: " + langileaMota);

                    Form2 form2 = new Form2(erabiltzaileaId);
                    form2.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Ez duzu baimenik sartzeko.", "Arazoa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    erregistroakGorde(erabiltzailea.ErabiltzaileIzena, "Ezeztatua");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Saioa hasterakoan arazoa: " + ex.Message, "Arazoa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void erregistroakGorde(string ErabiltzaileIzena, string mensaje)
        {
            string carpeta = "C:/Users/benat/Desktop/AdminApp/AdminApp/Registroak";


            string rutaArchivo = Path.Combine(carpeta, "erregistroak.txt");

            string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}: {mensaje} - Izena: {ErabiltzaileIzena}";

            try
            {
                File.AppendAllText(rutaArchivo, logMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
