using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class vistaPrevia : Form
    {
        public StringBuilder sb;
        public vistaPrevia(StringBuilder sb )
        {
            this.sb = sb;
            InitializeComponent();
        }

        private void vistaPrevia_Load(object sender, EventArgs e)
        {
            try
            {                
                var result = JsonConvert.DeserializeObject<List<aeropuerto>>(sb.ToString());
                dataGridView1.DataSource = result;
                Console.WriteLine(sb.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
