using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminApp.Dominio
{
    internal class Produktua
    {
        public virtual int Id { get; set; }
        public virtual string Izena { get; set; }
        public virtual string Deskribapena { get; set; }
        public virtual float Prezioa { get; set; }
        public virtual float ErosketaPrezioa { get; set; }
        public virtual int Kantitatea { get; set; }
        public virtual int KantitateMin { get; set; }
        public virtual int Mota { get; set; }
        public virtual int ErosketaKantitatea { get; set; }
        public virtual byte Aktibo { get; set; }

        public static void ProduktuakErakutsi(DataGridView dataGridView1)
        {
            // Crear una instancia de la conexión
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

                // Ajustar las columnas y filas del DataGridView
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
        }

    }
}
