using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xAPI.Entity.Category
{
    public class Categoria
    {
        public int Id_Categoria { get; set; }
        public string Nombre_Categoria { get; set; }
        public string Descripcion_Categoria { get; set; }
        public byte Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int CreadoPor { get; set; }
        public int ActualizadoPor { get; set; }
    }
}
