using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xAPI.Entity.Security
{
    public class TipoUsuario
    {
        public int Id_TipoUsuario { get; set; }
        public string Nombre_TipUsuario { get; set; }
        public byte Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public int CreadoPor { get; set; }
        public int ActualizadoPor { get; set; }
    }
}
