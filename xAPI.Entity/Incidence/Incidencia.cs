using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xAPI.Entity.Incidence
{
    public class Incidencia
    {

        public int Id_Incidencia { get; set; }
        public int Id_Usuario { get; set; }
        public int Id_Ambiente { get; set; }
        public string Ambiente { get; set; }
        public string Descripcion { get; set; }
        public int Id_Equipo { get; set; }
        public byte Completo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public int CreadoPor { get; set; }
        public int ActualizadoPor { get; set; }
        public int Estado { get; set; }
        public int Id_UsuarioAsignado { get; set; }
    }
}
