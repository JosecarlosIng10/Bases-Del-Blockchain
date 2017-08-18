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
using System.Collections.Specialized;

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


          
            try
            {
                
                using (var client = new WebClient())
                {
                    var responseString = client.DownloadString("http://" + ip + ":5000/conectado");
                    guardarip(ip, responseString, "Activo");
                }

                
            }
            catch
            {
                guardarip(ip, "--", "Inactivo");
            }
           



        }
        public void guardarip(string ip, string carnet,string estado)
        {

            try
            {
                using (var client = new WebClient())
                {
                    var values = new NameValueCollection();
                    values["ip"] = ip;
                    values["carnet"] = carnet;
                    values["estado"] = estado;

                    var response = client.UploadValues("http://192.168.1.5:5000/guardarip", values);

                    var responseString = Encoding.Default.GetString(response);

                    DataRow row = dt.NewRow();

                    row["Nodo"] = "Nodo" + num;
                    row["Ip"] = ip;
                    row["Carnet"] = carnet;
                    row["Estado"] = estado;
                    num++;
                    dt.Rows.Add(row);
                }
            }
            catch
            {
                DataRow row = dt.NewRow();

                row["Nodo"] = "Nodo" + num;
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

