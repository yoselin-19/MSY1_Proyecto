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

namespace WindowsFormsApplication1
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void cargar1Button_Click(object sender, EventArgs e)
        {
            string csv = File.ReadAllText(@"Aeropuertos.csv");
            StringBuilder sb = new StringBuilder();
            try
            {
              
                using (var p = ChoETL.ChoCSVReader.LoadText(csv)
                    .WithFirstLineHeader()
                    )
                {
                    using (var w = new ChoETL.ChoJSONWriter(sb))
                        w.Write(p);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            vistaPrevia vp = new vistaPrevia(sb);
            vp.Show();
            vp.Visible = true;
        }

        private void cargar2Button_Click(object sender, EventArgs e)
        {

        }

        private void CalcularButton_Click(object sender, EventArgs e)
        {
            SimioProjectFactory.SetExtensionsPath(System.AppDomain.CurrentDomain.BaseDirectory);
           
            try
            {
                string path = "Modelo1_G1.spfx";
                if (File.Exists(path) == false)
                    throw new ApplicationException($"Proyecto no encontrado:{path}");

                ISimioProject _simioProject = SimioAPI.SimioProjectFactory.LoadProject(path, out string[] warnings);
                IModel model =  _simioProject.Models[0];               
                model.Facility.IntelligentObjects.CreateObject("Server", new FacilityLocation(0, 0, 0));
                model.Facility.IntelligentObjects.CreateObject("Combiner", new FacilityLocation(10, 20, 10));
                SimioProjectFactory.SaveProject(_simioProject, path, out warnings);
                
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }
    }
}
