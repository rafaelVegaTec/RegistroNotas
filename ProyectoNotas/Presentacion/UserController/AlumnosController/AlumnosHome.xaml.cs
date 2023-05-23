using DATOS;
using ENTIDADES;
using NEGOCIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Presentacion.UserController.AlumnosController
{
    /// <summary>
    /// Lógica de interacción para AlumnosHome.xaml
    /// </summary>
    public partial class AlumnosHome : UserControl
    {
        NAlumnos alumnos1 = new NAlumnos();
        int IdAlumno = 0;

        public AlumnosHome()
        {
            InitializeComponent();
            LimpiarCampos();
            dtAlumnos.DataContext = alumnos1.ListarAlumnos();
        }

        private void MOD_Click(object sender, RoutedEventArgs e)
        {
            CrearAlumnos.IsEnabled = false;
            ActualizarAlumnos.IsEnabled = true;
            tbGeneralAlumnos.SelectedIndex = 2;

            foreach (DataRowView drv in dtAlumnos.Items)
            {
                IdAlumno = (int)drv.Row.ItemArray[0];
                txtNombre.Text = drv.Row.ItemArray[1].ToString();
                txtEdad.Text = drv.Row.ItemArray[2].ToString();
                txtFechaNa.Text = Convert.ToDateTime(drv.Row.ItemArray[3]).ToString("dd/MM/yyyy");
                txtTelAlum.Text = drv.Row.ItemArray[4].ToString();
                txtTelEnc.Text = drv.Row.ItemArray[5].ToString();
                txtCorreo.Text = drv.Row.ItemArray[6].ToString();
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCrearAlum_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCanCreAlum_Click(object sender, RoutedEventArgs e)
        {
            tbGeneralAlumnos.SelectedIndex = 0;
            CrearAlumnos.IsEnabled = true;
            ActualizarAlumnos.IsEnabled = false;
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            IdAlumno = 0;
            txtFechaNa.Text = "";
            txtEdad.Text = "";
            txtFechaNa.Text = "";
            txtTelAlum.Text = "";
            txtTelEnc.Text = "";
            txtCorreo.Text = "";
        }
    }
}
