﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Turno
    {
        public int IdTurno { get; set; }
        
        public Disponibilidad Disponibilidad{ get; set; }

        public Medico  Medico{ get; set; }

        public Paciente Paciente { get; set; }

        public string Motivo { get; set; }

        public bool Estado{ get; set; }
    }
}