using DATOS;
using ENTIDADES;
using NEGOCIO;
using Presentacion.UserController.Alertas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Windows.Threading;

namespace Presentacion.UserController.AlumnosController
{
    /// <summary>
    /// Lógica de interacción para DocentesHome.xaml
    /// </summary>
    public partial class DocentesHome : UserControl
    {
        //Instancias de CapaNegocio
        NDocente nDocente = new NDocente();

        //Instancias de UserControllers
        ucExitoAlerta aExito = new ucExitoAlerta();
        ucExisteAlumno aExiste = new ucExisteAlumno("Existe Docente");
        ucCamObli aCamObli = new ucCamObli();
        ucCancelar aCancelar = new ucCancelar();

        //Isntancias Apoyo
        DispatcherTimer timer = new DispatcherTimer();

        private int IdDocente = 0;

        public DocentesHome()
        {
            InitializeComponent();
            CargarGridDocentes();
        }

        private void btnBuscarDocentes_Click(object sender, RoutedEventArgs e)
        {
            dtDocentes.DataContext = nDocente.FiltrarDocentes(txtBuscarDocente.Text);
        }

        private void btnModificarDoc_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEliminarDoc_Click(object sender, RoutedEventArgs e)
        {
            Notificacion not = new Notificacion();
            ucEliminar aEliminar = new ucEliminar(not);
            DataRowView row = (DataRowView)dtDocentes.SelectedItem;
            IdDocente = (int)row.Row.ItemArray[0];
            aEliminar.ShowDialog();
            var resultado = not.valor_confirmacion;
            if (resultado.Equals("Ok"))
            {
                bool respuesta = nDocente.DesactivarDocente(IdDocente);
                if (respuesta)
                {
                    CargarGridDocentes();
                    aExito.Height = 50;
                    aExito.Width = 200;
                    if (!aExito.IsVisible)
                    {
                        stAlertasExito.Children.Add(aExito);
                        EjecutarAlerta();
                    }
                }
                else
                {
                    MessageBox.Show("Error: Contacte al administrador", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnCrearDoc_Click(object sender, RoutedEventArgs e)
        {
            if (txtNomDocCre.Text.Equals(string.Empty) || txtUsuario.Text.Equals(string.Empty) || txtContraDocCre.Password.Equals(string.Empty))
            {
                aCamObli.Width = 405;
                aCamObli.Height = 50;

                if (!aCamObli.IsVisible)
                {
                    stAlertas.Children.Add(aCamObli);
                    EjecutarAlerta();
                }
            }
            else
            {
                Docente oDocente = new Docente();
                oDocente.NombreDocente = txtNomDocCre.Text;
                oDocente.TelefonoDocente = txtTelDocCre.Text;
                oDocente.EmailDocente = txtCorreoDocCre.Text;
                oDocente.UsuarioDocente = txtUsuario.Text;
                oDocente.PasswordDocente = nDocente.Encriptacion(txtContraDocCre.Password);
                bool resultado = nDocente.InsertarDocente(oDocente);
                if (resultado)
                {
                    LimpiarCampos();
                    tbGeneralDocentes.SelectedIndex = 0;
                    CargarGridDocentes();
                    aExito.Height = 50;
                    aExito.Width = 200;
                    if (!aExito.IsVisible)
                    {
                        stAlertasExito.Children.Add(aExito);
                        EjecutarAlerta();
                    }
                }
                else
                {
                    aExiste.Width = 200;
                    aExiste.Height = 50;

                    if (!aExiste.IsVisible)
                    {
                        stAlertas.Children.Add(aExiste);
                        EjecutarAlerta();
                    }
                }
            }
        }

        private void BtnCanCreDoc_Click(object sender, RoutedEventArgs e)
        {
            tbGeneralDocentes.SelectedIndex = 0;
            CrearDocentes.IsEnabled = true;
            ModificarDocentes.IsEnabled = false;
            LimpiarCampos();
            aCancelar.Height = 50;
            aCancelar.Width = 200;
            stAlertasExito.Children.Add(aCancelar);
            EjecutarAlerta();
        }

        private void btnModificarDoc_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCanModDoc_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnActivarDoc_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBuscarElimDoc_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LimpiarCampos()
        {
            txtNomDocCre.Clear();
            txtTelDocCre.Clear();
            txtCorreoDocCre.Clear();
            txtUsuario.Clear();
            txtContraDocCre.Clear();
        }

        private void CargarGridDocentes()
        {
            dtDocentes.DataContext = nDocente.ListarDocentes();
        }

        private void EjecutarAlerta()
        {
            timer.Tick += new EventHandler(OcultarElemento);
            timer.Interval = new TimeSpan(0, 0, 2);
            timer.Start();
        }

        private void OcultarElemento(object? sender, EventArgs e)
        {
            stAlertasExito.Children.Remove(aExito);
            stAlertas.Children.Remove(aCamObli);
            stAlertasExito.Children.Remove(aCancelar);
            stAlertasMod.Children.Remove(aCamObli);
            stAlertas.Children.Remove(aExiste);
            timer.Stop();
        }
    }
}
