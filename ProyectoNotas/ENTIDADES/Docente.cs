using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Docente
    {
        public int IdDocente { get; set; }
        public string NombreDocente { get; set; }
        public string? TelefonoDocente { get; set; }
        public string? EmailDocente { get; set; }
        public string UsuarioDocente { get; set; }
        public string PasswordDocente { get; set; }
    }
}
