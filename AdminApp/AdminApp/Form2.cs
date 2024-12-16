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
    public partial class Form2 : Form
    {

        private int langileaId;
        //private string erabiltzaileIzena;

        public Form2(int LangileaId)
        {
            InitializeComponent();
            int langileaId = LangileaId;
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(langileaId);
            form3.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(langileaId);
            form4.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
