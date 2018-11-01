using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Simio.SimioEnums;
using SimioAPI.Graphics;
using SimioReplicationRunnerContracts;
using SimioTypes;
using SimioAPI;
using System.IO;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication1
{
    public partial class Inicio : Form
    {

        DataTable dt;

        public Inicio()
        {
            InitializeComponent();
        }
        

        private void cargar1Button_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("Aeropuertos.csv");
            string[] headers = sr.ReadLine().Split(',');
            dt = new DataTable();
            foreach (string header in headers)
            {
                dt.Columns.Add(header);
            }

            while (!sr.EndOfStream)
            {
                string[] rows = sr.ReadLine().Split(',');
                DataRow dr = dt.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }
                dt.Rows.Add(dr);
            }


            vistaPrevia vp = new vistaPrevia(dt);
            vp.Show();
            vp.Visible = true;

            //foreach (DataRow fila in dt.Rows)
            //{
            //    Console.WriteLine(fila[0] + " " + fila[1]);
            //}
        }

        private void cargar2Button_Click(object sender, EventArgs e)
        {
            
        }

        private void CalcularButton_Click(object sender, EventArgs e)
        {
            SimioProjectFactory.SetExtensionsPath(System.AppDomain.CurrentDomain.BaseDirectory);
            string[] warnings;
            try
            {
                string path = "Modelo1_G1.spfx";
                if (File.Exists(path) == false)
                    throw new ApplicationException($"Proyecto no encontrado:{path}");

                ISimioProject _simioProject = SimioAPI.SimioProjectFactory.LoadProject(path, out warnings);
                IModel model =  _simioProject.Models[1];

                //var jsonObj = JsonConvert.DeserializeObject<List<aeropuerto>>(sb.ToString());
                //foreach (var obj in jsonObj)
                //{
                //    model.Facility.IntelligentObjects.CreateObject("Combiner", new FacilityLocation(obj.posicion_x, obj.posicion_z, obj.posicion_y));

                //}

                foreach (DataRow fila in dt.Rows)
                {
                    model.Facility.IntelligentObjects.CreateObject("Combiner", new FacilityLocation(Convert.ToDouble(fila[2]), Convert.ToDouble(fila[3]), Convert.ToDouble(fila[4])));
                }
                SimioProjectFactory.SaveProject(_simioProject, path, out warnings);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
