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
        DataTable dt2;

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
            StreamReader sr = new StreamReader("Rutas.csv");
            string[] headers = sr.ReadLine().Split(',');
            dt2 = new DataTable();
            foreach (string header in headers)
            {
                dt2.Columns.Add(header);
            }

            while (!sr.EndOfStream)
            {
                string[] rows = sr.ReadLine().Split(',');
                DataRow dr = dt2.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }
                dt2.Rows.Add(dr);
            }


            vistaPrevia vp = new vistaPrevia(dt2);
            vp.Show();
            vp.Visible = true;
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

                model.Facility.IntelligentObjects.CreateObject("Source", new FacilityLocation(0,0,0));
                var objetoA = model.Facility.IntelligentObjects["Source1"];
                objetoA.ObjectName = "Personas";
                objetoA.Properties["EntityType"].Value = "ModelEntity1";
                objetoA.Properties["InterarrivalTime"].Value = "Random.Poisson(0.2)";

                model.Facility.IntelligentObjects.CreateObject("Source", new FacilityLocation(-20, 0, 0));
                var objetoB = model.Facility.IntelligentObjects["Source1"];
                objetoB.ObjectName = "Aviones";
                objetoB.Properties["EntityType"].Value = "ModelEntity2";
                objetoB.Properties["InterarrivalTime"].Value = "Random.Poisson(12)";

                foreach (DataRow fila in dt.Rows)
                {
                    //model.Facility.IntelligentObjects.CreateObject("Combiner", new FacilityLocation(Convert.ToDouble(fila[2]), Convert.ToDouble(fila[3]), Convert.ToDouble(fila[4])));
                    model.Facility.IntelligentObjects.CreateObject("Combiner", new FacilityLocation(Convert.ToDouble(fila[2]), Convert.ToDouble(fila[4]), Convert.ToDouble(fila[3])));

                    var objeto = model.Facility.IntelligentObjects["Combiner1"];
                    objeto.ObjectName = "aeropuerto_" + Convert.ToString(fila[0]);

                    model.Facility.IntelligentObjects.CreateObject("Sink", new FacilityLocation((Convert.ToDouble(fila[2]) - 5), Convert.ToDouble(fila[4]), Convert.ToDouble(fila[3])));

                    var entradaAeropuerto = model.Facility.IntelligentObjects["Sink1"];
                    entradaAeropuerto.ObjectName = "AuxAeropuerto_" + Convert.ToString(fila[0]);

                    //FailureType = 61
                    objeto.Properties[61].Value = Convert.ToString(fila[5]);
                    //CountBetweenFailures = 63
                    objeto.Properties[63].Value = Convert.ToString(fila[6]);
                    //TimeToRepair = 65
                    objeto.Properties[65].Value = Convert.ToString((Convert.ToDouble(fila[7]) / 60));
                    //InitialCapacity = 16
                    objeto.Properties[16].Value = Convert.ToString(fila[8]);
                    //ProcessingTime = 39
                    objeto.Properties[39].Value = Convert.ToString(fila[10]);
                    //BatchQuantity = 27
                    objeto.Properties[27].Value = "100";
                    //MemberTransferInTime
                    objeto.Properties["MemberTransferInTime"].Value = Convert.ToString(fila[9]); ;


                    String combi = "aeropuerto_" + Convert.ToString(fila[0]);
                    INodeObject a = ((IFixedObject)model.Facility.IntelligentObjects["Personas"]).Nodes[0];
                    INodeObject b = ((IFixedObject)model.Facility.IntelligentObjects[combi]).Nodes[1];
                    model.Facility.IntelligentObjects.CreateLink("Path", a, b, null);

                    String combi2 = "aeropuerto_" + Convert.ToString(fila[0]);
                    INodeObject a2 = ((IFixedObject)model.Facility.IntelligentObjects["Aviones"]).Nodes[0];
                    INodeObject b2 = ((IFixedObject)model.Facility.IntelligentObjects[combi]).Nodes[0];
                    model.Facility.IntelligentObjects.CreateLink("Path", a2, b2, null);
                }

                //var objeto2 = model.Facility.IntelligentObjects["aeropuerto_1"];
                //objeto2.ObjectName = "nuevo";


                /**************Esto es para los Path**************/
                //Destino posicion 0 
                //Origen posicion 1

                foreach (DataRow fila in dt2.Rows)
                {
                    String aux1 = "aeropuerto_" + fila[0];
                    String aux2 = "aeropuerto_" + fila[1];
                    String aux3 = "AuxAeropuerto_" + fila[0];

                    //Aeropuerto Origen -> Salida
                    INodeObject a = ((IFixedObject)model.Facility.IntelligentObjects[aux2]).Nodes[2];
                    INodeObject b = ((IFixedObject)model.Facility.IntelligentObjects[aux3]).Nodes[0];
                    model.Facility.IntelligentObjects.CreateLink("Path", a, b, null);
                }

                //*************** Esto es para los experimentos **********/
                IExperiment experimento = model.Experiments.Create("Experimento");

                //configurando el experimento
                IRunSetup setup = experimento.RunSetup;
                setup.StartingTime = new DateTime(2018, 10, 1);
                setup.WarmupPeriod = TimeSpan.FromHours(0);
                setup.EndingTime = experimento.RunSetup.StartingTime + TimeSpan.FromDays(1);
                experimento.ConfidenceLevel = ExperimentConfidenceLevelType.Point95;
                experimento.LowerPercentile = 25;
                experimento.UpperPercentile = 75;
                //configuracion variable de control

                //configurando los responses
                //a estos hay que asignarles un valor en el escenario
                IExperimentResponse response1 = experimento.Responses.Create("CantidadAviones");
                response1.Expression = "avion.cantidad"; //valor de ejemplo
                IExperimentResponse response2 = experimento.Responses.Create("CantidadPersonasTranportadas");
                response2.Expression = "personas.cantidad"; //valor de ejemplo

                //creando un escenario
                IScenario escenario1 = experimento.Scenarios.Create("escenario1");
                IScenario escenario2 = experimento.Scenarios.Create("escenario2");
                IScenario escenario3 = experimento.Scenarios.Create("escenario3");

                //escenario creados
                //TODO cambiar la variable de control por escenario
                //como se hace? el metodo de controls de cada escenario solo tiene un get
                //que solo devueleve el valor del control pero no para asignarselo                 

                SimioProjectFactory.SaveProject(_simioProject, path, out warnings);
                MessageBox.Show("Carga realizada");

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
