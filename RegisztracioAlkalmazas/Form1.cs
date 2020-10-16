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

namespace RegisztracioAlkalmazas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<string> hobbiLista = new List<string>();
        private void button_hozzaAd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBoxUjHobbi.Text))
            {
                MessageBox.Show("Üres beviteli mező");
                return;
            }
            if (listBox1.Items.Contains(textBoxUjHobbi.Text))
            {
                MessageBox.Show("Már szerpel ilyen hobbi");
                return;
            }
            textBoxUjHobbi.Text = textBoxUjHobbi.Text.TrimStart();
            textBoxUjHobbi.Text = textBoxUjHobbi.Text.TrimEnd();
            listBox1.Items.Add(textBoxUjHobbi.Text);
            textBoxUjHobbi.Text = "";
            textBoxUjHobbi.Focus();
        }

        private void buttonMentes_Click(object sender, EventArgs e)
        {
            var result = saveFileDialog1.ShowDialog();
            string file = saveFileDialog1.FileName;
            using (var sw = new StreamWriter(file))
            {

            }
        }
    }
}
