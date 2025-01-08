using System;

public class Class1
{
	public Class1()
	{
        private void produktuakErakutsi()
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
    }
}
