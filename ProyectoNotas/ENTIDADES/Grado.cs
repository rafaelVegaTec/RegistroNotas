using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Grado
    {
        public int IdGrado { get; set; }
        public string NombreGrado { get; set; }
        public string Seccion { get; set; }
        public int IdAlumno { get; set; }
        public int IdMateria { get; set; }
        public bool Estado { get; set; }
    }
}
