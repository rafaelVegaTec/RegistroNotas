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
    public class NGrado
    {
        public DataTable ListarGrados()
        {
            DGrado dGrado = new DGrado();
            return dGrado.ListarGrados();
        }

        public DataTable ListarGradosEliminados()
        {
            DGrado dGrado = new DGrado();
            return dGrado.ListarGradosEliminados();
        }

        public DataTable FiltrarGrados(string valor)
        {
            DGrado dGrado = new DGrado();
            return dGrado.FiltrarGrados(valor);
        }

        public DataTable FiltrarGradosEliminados(string valor)
        {
            DGrado dGrado = new DGrado();
            return dGrado.FiltrarGradosEliminados(valor);
        }

        public DataTable MostrarAlumnos()
        {
            DGrado dGrado = new DGrado();
            return dGrado.MostrarAlumnos();
        }

        public DataTable MostrarMateriaDocente()
        {
            DGrado dGrado = new DGrado();
            return dGrado.MostrarMateriaDocente();
        }

        public bool CrearGrado(Grado obj)
        {
            DGrado dGrado = new DGrado();
            return dGrado.CrearGrado(obj);
        }

        public bool ModificarGrado(Grado obj)
        {
            DGrado dGrado = new DGrado();
            return dGrado.ModificarGrado(obj);
        }

        public bool EliminarGrado(int idGrado)
        {
            DGrado dGrado = new DGrado();
            return dGrado.EliminarGrado(idGrado);
        }

        public bool ActivarGrado(int idGrado)
        {
            DGrado dGrado = new DGrado();
            return dGrado.ActivarGrado(idGrado);
        }        
    }
}
