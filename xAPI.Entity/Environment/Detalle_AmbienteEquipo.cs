using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xAPI.Entity.Environment
{
    public class Detalle_AmbienteEquipo
    {
        public int Id_Detalle_AmbienteEquipo { get; set; }
        public int Id_Equipo { get; set; }
        public int Id_Ambiente { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public int CreadoPor { get; set; }
        public int ActualizadoPor { get; set; }
    }
}
