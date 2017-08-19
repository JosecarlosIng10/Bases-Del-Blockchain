using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica1EDD
{
    public partial class ColaMensaje : Form
    {
        public ColaMensaje()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            actualizar();
        }
        public void actualizar()
        {
            try
            {
                System.Net.WebRequest req = System.Net.WebRequest.Create("http://192.168.1.5:5000/ActualizarCola");
                System.Net.WebResponse resp = req.GetResponse();
                System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
                string response = sr.ReadToEnd().Trim();
                response = response.Replace("\r", string.Empty);
                response = response.Replace("\t", string.Empty);
                response = response.Replace("\n", string.Empty);
                string[] substring = response.Split('$');
                label1.Text = "Operaciones en Cola: "+substring[3];
                textBox2.Text = substring[1];
               
                textBox5.Text = substring[0];
                textBox1.Text = substring[4];
                textBox4.Text = substring[2];
                textBox3.Text = substring[6];
                string[] cons = substring[5].Split('_');
                int i = 0;
                string cadenacons = "";
                while (i <= cons.Length-1)
                {
                    cadenacons = cadenacons + cons[i] + "\n";
                    i++;
                }
                richTextBox1.Text = cadenacons;

            }
            catch
            {
               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
