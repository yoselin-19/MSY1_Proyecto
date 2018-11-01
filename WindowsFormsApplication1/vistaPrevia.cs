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
        DataTable dt;

        public vistaPrevia(DataTable dt)
        {
            this.dt = dt;
            InitializeComponent();
        }

        private void vistaPrevia_Load(object sender, EventArgs e)
        {
            try
            {                
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
