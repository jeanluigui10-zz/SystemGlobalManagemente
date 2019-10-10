using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xAPI.Entity.Environment
{
    public class Ambientes
    {
        public int Id_Ambiente { get; set; }
        public int Id_Piso { get; set; }
        public string Nombre_Ambiente { get; set; }
        public string Piso_Ambiente { get; set; }
        public string Index { get; set; }
        public string Descripcion_Ambiente { get; set; }
        public byte Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public int CreadoPor { get; set; }
        public int ActualizadoPor { get; set; }
        private String _estadodesc;
        public String EstadoDes
        {
            get
            {
                if (Estado == 1) _estadodesc = "Activo"; else _estadodesc = "Inactivo";
                return _estadodesc;
            }
        }
    }
}
