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
using Newtonsoft.Json;
using System.Net;

namespace Practica1EDD
{

    

    public partial class Dashboard : Form
    {
        private DataTable dt;
        private int num = 0;
        public Dashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            dt.Clear();
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
                            String p1 = JsonConvert.DeserializeObject(File.ReadAllText(direccion)).ToString();

                            StreamReader r = new StreamReader(direccion);
                            string json = r.ReadToEnd();
                           

                            dynamic array = JsonConvert.DeserializeObject(json);
                            label1.Text = "Este Nodo: " + array.nodos.local + " - 201212644";
                            string resultado = "";
                            int i = 0;
                            var ip = array.nodos.nodo[0].ip;
                            while (true) {
                                try
                                {
                                    resultado = array.nodos.nodo[i].ip.ToString();
                                    PostXML(resultado);
                                    i++;
                                }
                                catch (Exception ex)
                                {
                                    break;
                                }
                               
                            }
                           // MessageBox.Show(resultado);
                                
                             
                                        
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: no se puede leer el archivo" + ex.Message);
                }
            }
        

      
            
        }
        public void PostXML(string ip)
        {


            // Create a request using a URL that can receive a post. 

            // Set the Method property of the request to POST.
            try
            {
                System.Net.WebRequest req = System.Net.WebRequest.Create("http://"+ip+":5000/conectado");
                System.Net.WebResponse resp = req.GetResponse();
                System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
                string response = sr.ReadToEnd().Trim();

                guardarip(ip, response,"Activo");
            }
            catch
            {
                guardarip(ip, "--", "Inactivo");
            }
           



        }
        public void guardarip(string ip, string carnet,string estado)
        {
            Dictionary<string, string> myarray =
    new Dictionary<string, string>();

            myarray.Add(ip, carnet+","+ estado);
            string str = string.Join(Environment.NewLine, myarray);
            try
            {
              

                // Create a request using a URL that can receive a post. 
                WebRequest request = WebRequest.Create("http://192.168.1.5:5000/guardarip");
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

                DataRow row = dt.NewRow();

                row["Nodo"] = "Nodo"+ num;
                row["Ip"] = ip;
                row["Carnet"] = carnet;
                row["Estado"] = estado;
                num++;
                dt.Rows.Add(row);

            }
            catch
            {
                DataRow row = dt.NewRow();

                row["Nodo"] = "Nodo"+num;
                row["Ip"] = ip;
                row["Carnet"] = carnet;
                row["Estado"] = estado;
                num++;
                dt.Rows.Add(row);
            }
           




        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt.Columns.Add("Nodo");
            dt.Columns.Add("Ip");
            dt.Columns.Add("Carnet");
            dt.Columns.Add("Estado");
         
            dataGridView1.DataSource = dt;
        }
    }
	
	
    }

