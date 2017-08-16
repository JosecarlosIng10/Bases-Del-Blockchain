using System;
using System.Collections.Generic;
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
            Dictionary<string, string> myarray =
   new Dictionary<string, string>();
            myarray.Add(ip, texto);
            try
            {
                string url = "http://" + ip.Trim() + ":5000/mensaje";
                string str = string.Join(Environment.NewLine, myarray);
                // Create a request using a URL that can receive a post. 
                WebRequest request = WebRequest.Create(url);
                // Set the Method property of the request to POST.
                request.Method = "POST";

                // Create POST data and convert it to a byte array.

                string postData = str;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/x-www-form-urlencoded";

                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;
                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
                // Get the response.
                WebResponse response = request.GetResponse();
                // Display the status.
                // MessageBox.Show(((HttpWebResponse)response).StatusDescription);
                // Get the stream containing content returned by the server.
                dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Display the content.
                // MessageBox.Show(responseFromServer);
                // Clean up the streams.
                reader.Close();
                dataStream.Close();
                response.Close();
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
        
    

