﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xAPI.Entity.Tool
{
    public class Equipo
    {
        public int Id_Equipo { get; set; }
        public int Id_Categoria { get; set; }
        public string Nombre_Equipo { get; set; }
        public string Nombre_Categoria { get; set; }
        public string Descripcion_Equipo { get; set; }
        public string Condicion_Equipo { get; set; }
        public byte Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public int CreadoPor { get; set; }
        public int ActualizadoPor { get; set; }
        public string Index { get; set; }
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
