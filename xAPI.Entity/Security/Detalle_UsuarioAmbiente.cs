using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xAPI.Entity.Security
{
    public class Detalle_UsuarioAmbiente
    {
        public int Id_Detalle_UsuarioTipoUsuario { get; set; }
        public int Id_Usuario { get; set; }
        public int Id_Ambiente { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public int CreadoPor { get; set; }
        public int ActualizadoPor { get; set; }
        
    }
}
