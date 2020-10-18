using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Permissions;
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

            string kedvenchobbi = listBox1.SelectedItem.ToString();
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
            string kedvenchobbi = "";
            using (var sw = new StreamWriter(file))
            {

                if (String.IsNullOrWhiteSpace(txtbox_Nev.Text) || dateTimePicker1.Value <= DateTime.Now || !radioF.Checked || !radioN.Checked && listBox1.SelectedIndex != -1)
                {             
                    kedvenchobbi = listBox1.SelectedItem.ToString();
                    sw.Write(txtbox_Nev.Text + ";");
                    sw.Write(dateTimePicker1.Value + ";") ;
                    if (radioF.Checked)
                    {
                        sw.Write("Férfi;");
                    }
                    else if (radioN.Checked)
                    {
                        sw.Write("Nő;");
                    }
                    sw.Write(kedvenchobbi);
                }
                else {
                    MessageBox.Show("Beviteli hiba történt");
                    return;
                }
            }
        }

        private void buttonBetoltes_Click(object sender, EventArgs e)
        {
            List<string> lista = new List<string>();
            var result = openFileDialog1.ShowDialog(); //MEGNYITJA A FILET
            listBox1.Items.Clear();
            txtbox_Nev.Text = "";
            radioF.Checked = false;
            radioN.Checked = false;


            if (result != DialogResult.OK) //ELLENORZES
            {
                return;
            }
            string fileName = openFileDialog1.FileName;
            string [] hobbiLista = new string [4];
            using (var sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    string sor = sr.ReadLine();
                    hobbiLista = sor.Split(';');
                    txtbox_Nev.Text=hobbiLista[0];
                    dateTimePicker1.Value = Convert.ToDateTime(hobbiLista[1]);              
                    if (hobbiLista[2] == "Férfi")
                    {
                        radioF.Checked = true;
                    }
                    if (hobbiLista[2] == "Nő") {
                        radioN.Checked = true;
                    }
                    listBox1.Items.Add(hobbiLista[3]);

                }
            }

        }
    }
}
