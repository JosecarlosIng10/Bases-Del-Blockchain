using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Practica1EDD
{
    public partial class EnviarMensaje : Form
    {
        public EnviarMensaje()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {

                            String direccion = openFileDialog1.FileName;
                            XmlDocument xDoc = new XmlDocument();
                            xDoc.Load(direccion);
                            XmlNodeList mensajes = xDoc.GetElementsByTagName("mensajes");

                            XmlNodeList lista = ((XmlElement)mensajes[0]).GetElementsByTagName("mensaje");
                            XmlNodeList lista1 = ((XmlElement)lista[0]).GetElementsByTagName("nodos");
                            XmlNodeList lista2 = ((XmlElement)lista1[0]).GetElementsByTagName("IP");

                            foreach (XmlElement nodo in lista)

                            {

                                int i = 0;

                               // XmlNodeList ip = nodo.GetElementsByTagName("IP");

                                XmlNodeList texto = nodo.GetElementsByTagName("texto");

                                int ii = 0;

                                foreach (XmlElement nodo1 in ((XmlElement)lista1[ii]).GetElementsByTagName("IP"))

                                {

                                    


                                    XmlNodeList ip1 = nodo.GetElementsByTagName("IP");
                                    enviarmensaje(ip1[ii].InnerText, texto[i].InnerText);
                                   
                                    ii++;
                                   
                                }


                             

                            }


                        }
                    }

                }
                catch
                {

                }
            }
                
                           
                            
                          



      }

        public void enviarmensaje(string ip, string texto)
        {
            ip = ip.Replace("\r", string.Empty);
            ip = ip.Replace("\t", string.Empty);
            ip = ip.Replace("\n", string.Empty);
            
            try
            {
                string url = "http://" + ip.Trim() + ":5000/mensaje";
                using (var client = new WebClient())
                {
                    var values = new NameValueCollection();
                   
                    values["inorden"] = texto;


                    var response = client.UploadValues(url, values);

                    var responseString = Encoding.Default.GetString(response);
                }
                }
            catch
            {
                MessageBox.Show("El mensaje no llego porque la ip:" + ip + " no esta conectada");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            enviarmensaje(textBox1.Text, textBox2.Text);
        }
    }
 }
        
    

