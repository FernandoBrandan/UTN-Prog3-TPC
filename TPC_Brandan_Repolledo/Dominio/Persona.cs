﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Persona
    {
        public long DNI { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Domicilio { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Genero { get; set; }

        public bool Estado { get; set; } 
    }   
}
