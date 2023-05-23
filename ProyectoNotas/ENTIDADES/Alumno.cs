using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Alumno
    {
        public int idAlumno { get; set; }
        public string nombreAlumno { get; set; }
        public int edad { set; get; }
        public DateTime fechaNacimiento { get; set; }
        public string? telefonoAlumno { get; set; }
        public string? telefonoEncargado { get; set; }
        public string? emailAlumno { get; set; }
        public bool Estado { get; set; }
    }
}
