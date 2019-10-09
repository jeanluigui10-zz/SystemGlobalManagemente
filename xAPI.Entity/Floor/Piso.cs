using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xAPI.Entity.Floor
{
    public class Piso
    {
        public int Id_Piso { get; set; }
        public string Nombre_Piso { get; set; }
        public string Descripcion_Piso { get; set; }
        public Byte Estado { get; set; }
        public String Index { get; set; }
        private String _estadodesc;
        public String EstadoDes
        {
            get
            {
                if (Estado == 1) _estadodesc = "Activo"; else _estadodesc = "Inactivo";
                return _estadodesc;
            }
        }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public int CreadoPor { get; set; }
        public int ActualizadoPor { get; set; }
    }
}
