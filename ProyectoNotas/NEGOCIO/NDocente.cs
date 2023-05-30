using DATOS;
using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEGOCIO
{
    public class NDocente
    {
        public DataTable ListarDocentes()
        {
            DDocente dDocente = new DDocente();
            return dDocente.ListarDocentes();
        }

        public DataTable FiltrarDocentes(string valor)
        {
            DDocente dDocente = new DDocente();
            return dDocente.FiltrarDocentes(valor);
        }

        public bool InsertarDocente(Docente obj)
        {
            DDocente dDocente = new DDocente();
            bool existe = dDocente.Existe(obj.NombreDocente);
            bool resultado;
            if (existe)
            {
                resultado = false;
            }
            else
            {
                resultado = dDocente.CrearDocente(obj);
            }
            return resultado;
        }

        public bool DesactivarDocente(int id)
        {
            DDocente dDocente = new DDocente();
            return dDocente.DesactivarDocente(id);
        }

        public string Encriptacion(string valor)
        {
            DDocente dDocente = new DDocente();
            return dDocente.Encriptacion(valor);
        }
    }
}
