﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Materia
    {
        public int IdMateria { get; set; }
        public string NombreMateria { get; set; }
        public int IdDocente { get; set; }
        public bool Estado { get; set; }
    }
}
