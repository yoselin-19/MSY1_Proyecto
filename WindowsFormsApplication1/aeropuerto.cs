using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class aeropuerto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int posicion_x { get; set; }
        public int posicion_y { get; set; }
        public int posicion_z { get; set; }
        public string tipo_falla { get; set; }
        public int cantidad_eventos { get; set; }
        public int tiempo_reparacion { get; set; }
        public int aviones_por_pista { get; set; }
        public int t_llegada_personas { get; set; }
        public int t_abordaje { get; set; }
    }
}
