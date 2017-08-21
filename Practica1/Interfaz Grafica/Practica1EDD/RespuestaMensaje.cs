using System;
using System.Collections.Generic;
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
    public partial class RespuestaMensaje : Form
    {
        private DataTable dt;
        public RespuestaMensaje()
        {
            InitializeComponent();
           
        }

        private void RespuestaMensaje_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt.Columns.Add("Carnet que opero");
            dt.Columns.Add("Ip que opero");
            dt.Columns.Add("InOrden");
            dt.Columns.Add("PostOrden");
            dt.Columns.Add("Resultado");
            

            dataGridView1.DataSource = dt;
        }
        public void MasReciente()
        {
            dt.Clear();


            try
            {

                using (var client = new WebClient())
                {
                    var responseString = client.DownloadString("http://192.168.1.5:5000/ListaRespuestaReciente");
                    String[] nodos = responseString.Split('@');
                    int i = 0;

                    while (i <= nodos.Length - 1)
                    {
                        String[] datos = nodos[i].Split('$');
                        DataRow row = dt.NewRow();

                        row["Carnet que opero"] = datos[1];
                        row["Ip que opero"] = datos[0];
                        row["InOrden"] = datos[2];
                        row["PostOrden"] = datos[3];
                        row["Resultado"] = datos[4];

                        dt.Rows.Add(row);

                        i++;
                    }

                }


            }
            catch
            {
               
            }

        }
        public void MasAntiguo()
        {
            dt.Clear();

            try
            {

                using (var client = new WebClient())
                {
                    var responseString = client.DownloadString("http://192.168.1.5:5000/ListaRespuestaUltimo");
                    String[] nodos = responseString.Split('@');
                    int i = 0;
                    
                    while (i <= nodos.Length-1)
                    {
                        String[] datos = nodos[i].Split('$');
                        DataRow row = dt.NewRow();

                        row["Carnet que opero"] = datos[1];
                        row["Ip que opero"] = datos[0];
                        row["InOrden"] = datos[2];
                        row["PostOrden"] = datos[3];
                        row["Resultado"] = datos[4];

                        dt.Rows.Add(row);
                       
                        i++;
                    }

                    
                }


            }
            catch
            {

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MasAntiguo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MasReciente();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Mensajes nuevo = new Mensajes();
            nuevo.StartPosition = FormStartPosition.CenterScreen;
            nuevo.Show();
            this.Close();
        }
    }
}
