using MySql.Data.MySqlClient;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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

        private NHibernate.Cfg.Configuration myConfiguration;
        private ISessionFactory mySessionFactory;
        private ISession mySession;

        public static void ProduktuakErakutsi(DataGridView dataGridView1)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        string hql = "FROM Produktua p WHERE p.Aktibo = 1";
                        var query = session.CreateQuery(hql);

                        var produktuak = query.List<Produktua>();
                        dataGridView1.DataSource = produktuak;
                        if (dataGridView1.Columns["Aktibo"] != null)
                        {
                            dataGridView1.Columns["Aktibo"].Visible = false;
                        }
                        if (dataGridView1.Columns["ErosketaKantitatea"] != null)
                        {
                            dataGridView1.Columns["ErosketaKantitatea"].Visible = false;
                        }

                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        public static void erosketaEgin(List<Produktua> carrito, ListBox listBoxCarrito)
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
                            foreach (var producto in carrito)
                            {
                                var productoExistente = mySession.QueryOver<Produktua>()
                                    .Where(p => p.Izena == producto.Izena)
                                    .SingleOrDefault();
                                if (productoExistente != null)
                                {
                                    productoExistente.Kantitatea += producto.ErosketaKantitatea;
                                    mySession.SaveOrUpdate(productoExistente);
                                }
                            }
                            transaction.Commit();
                            MessageBox.Show("Erosketa ongi suertatu da. Datuak eguneratuta.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            carrito.Clear();
                            listBoxCarrito.Items.Clear();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback(); 
                            MessageBox.Show("Arazoa eorsketa egitean: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Arazoa NHibernate iniziatzean: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void GehituProduktua(
            ISessionFactory sessionFactory,
            TextBox[] textBoxes,
            int erabiltzaileaId,
            DataGridView dataGridView)
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    var produktua = new Produktua
                    {
                        Izena = textBoxes[0].Text,
                        Deskribapena = textBoxes[1].Text,
                        Prezioa = Convert.ToSingle(textBoxes[2].Text),
                        ErosketaPrezioa = Convert.ToSingle(textBoxes[3].Text),
                        Mota = Convert.ToInt16(textBoxes[4].Text),
                        Kantitatea = Convert.ToInt16(textBoxes[5].Text),
                        KantitateMin = Convert.ToInt16(textBoxes[6].Text)
                    };
                    session.Save(produktua);
                    transaction.Commit();
                    MessageBox.Show("Produktua ongi gehituta.");
                    Produktua.HistorialaGorde(sessionFactory, produktua.Id, "Produktua gehitu", erabiltzaileaId);
                    Produktua.ProduktuakErakutsi(dataGridView);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Errorea: " + ex.Message);
                }
            }
        }
        public static void HistorialaGorde(
            ISessionFactory sessionFactory,
            int produktuaId,
            string ekintza,
            int erabiltzaileaId)
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    var historiala = new ProduktuHistorikoa
                    {
                        ProduktuaId = produktuaId,
                        ErabiltzaileaId = erabiltzaileaId,
                        Data = DateTime.Now,
                        Ekintza = ekintza,
                        Galera = 0
                    };
                    session.Save(historiala);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Errorea historiala gordetzerakoan: " + ex.Message);
                }
            }
        }

        public static void EguneratuProduktua(
            ISessionFactory sessionFactory,
            TextBox[] textBoxes,
            int erabiltzaileaId,
            DataGridView dataGridView)
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    int id = Convert.ToInt32(textBoxes[0].Text);
                    var produktua = session.Query<Produktua>().FirstOrDefault(f => f.Id == id);
                    if (produktua != null)
                    {
                        produktua.Izena = textBoxes[1].Text;
                        produktua.Deskribapena = textBoxes[2].Text;
                        produktua.Prezioa = Convert.ToSingle(textBoxes[3].Text);
                        produktua.ErosketaPrezioa = Convert.ToSingle(textBoxes[4].Text);
                        produktua.Kantitatea = Convert.ToInt16(textBoxes[5].Text);
                        produktua.KantitateMin = Convert.ToInt16(textBoxes[6].Text);
                        produktua.Mota = Convert.ToInt16(textBoxes[7].Text);
                        session.Update(produktua);
                        transaction.Commit();
                        MessageBox.Show("Produktua ondo eguneratu da.");
                        Produktua.HistorialaGorde(sessionFactory, id, "Produktua eguneratu", erabiltzaileaId);
                        Produktua.ProduktuakErakutsi(dataGridView);
                    }
                    else
                    {
                        MessageBox.Show("Produktua ezin izan da bilatu.");
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Errorea: " + ex.Message);
                }
            }
        }

        public static void EzabatuProduktua(
            ISessionFactory sessionFactory,
            int produktuaId,
            int erabiltzaileaId,
            DataGridView dataGridView)
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    var produktua = session.Query<Produktua>().FirstOrDefault(f => f.Id == produktuaId);
                    if (produktua != null)
                    {
                        produktua.Aktibo = 0;
                        session.Update(produktua);
                        transaction.Commit();
                        MessageBox.Show("Produktua ongi desaktibatua izan da.");
                        Produktua.HistorialaGorde(sessionFactory, produktuaId, "Produktua desaktibatu", erabiltzaileaId);
                        Produktua.ProduktuakErakutsi(dataGridView);
                    }
                    else
                    {
                        MessageBox.Show("Produktua ezin izan da bilatu.");
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Errorea: " + ex.Message);
                }
            }
        }
        public static void TaulaKargatu(DataGridView dataGridView)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        try
                        {
                            string hql = "FROM Produktua";
                            var query = session.CreateQuery(hql);

                            var produktuak = query.List<Produktua>();

                            dataGridView.DataSource = produktuak;

                            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                            dataGridView.CellFormatting += (s, e) => CellFormattingHandler(dataGridView, e);

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
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


        public static void CellFormattingHandler(DataGridView dataGridView, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView.Columns["kantitatea"] != null && dataGridView.Columns["kantitateMinimoa"] != null)
            {
                int kantitateaIndex = dataGridView.Columns["kantitatea"].Index;
                int kantitateMinimoaIndex = dataGridView.Columns["kantitateMinimoa"].Index;

                if (e.RowIndex >= 0 && e.ColumnIndex == kantitateaIndex)
                {
                    var row = dataGridView.Rows[e.RowIndex];
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
    }
}
