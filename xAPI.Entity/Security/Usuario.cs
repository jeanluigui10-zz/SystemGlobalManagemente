using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xAPI.Entity.Security
{
    public class Usuario
    {
        public int Id_Usuario { get; set; }
        public string Nombre_Usuario { get; set; }
        public string APaterno_Usuario { get; set; }
        public string AMaterno_Usuario { get; set; }
        public string Dni_Usuario { get; set; }
        public string Contrasena { get; set; }
        public Byte Estado { get; set; }
        public int Id_TipoUsuario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public int CreadoPor { get; set; }
        public int ActualizadoPor { get; set; }
    }
}
