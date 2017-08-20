using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica1EDD
{
    public partial class ColaMensaje : Form
    {
        public int operaciones = -1;
        public ColaMensaje()
        {
            InitializeComponent();
            actualizar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }
        public void actualizar()
        {
            if  (operaciones != 0)
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
                    label1.Text = "Operaciones en Cola: " + substring[3];
                    operaciones = Convert.ToInt32(substring[3]);
                    textBox2.Text = substring[1];

                    textBox5.Text = substring[0];
                    textBox1.Text = substring[4];
                    substring[2] = substring[2].Replace("@", string.Empty);
                    textBox4.Text = substring[2];
                    textBox3.Text = substring[6];
                    string[] cons = substring[5].Split('_');
                    int i = 0;
                    string cadenacons = "";
                    while (i <= cons.Length - 1)
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
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                richTextBox1.Text = "";
                MessageBox.Show("Ya no hay operaciones en Cola");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string url = "http://" + textBox2.Text + ":5000/respuesta";
                using (var client = new WebClient())
                {
                    var values = new NameValueCollection();

                    values["inorden"] = textBox5.Text;
                    values["postorden"] = textBox4.Text;
                    values["respuesta"] = textBox3.Text;


                    var response = client.UploadValues(url, values);

                    var responseString = Encoding.Default.GetString(response);
                }
            }
            catch
            {
                MessageBox.Show("El mensaje no llego porque la ip:" + textBox2.Text + " no esta conectada");
            }
            actualizar();
        }
    }
}
