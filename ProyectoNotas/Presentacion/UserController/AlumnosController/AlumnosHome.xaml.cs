using DATOS;
using ENTIDADES;
using MaterialDesignThemes.Wpf;
using NEGOCIO;
using Presentacion.UserController.Alertas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
    /// Lógica de interacción para AlumnosHome.xaml
    /// </summary>
    public partial class AlumnosHome : UserControl
    {
        //Instancias de CapaNegocio
        NAlumnos nAlumnos = new NAlumnos();

        //Instancias de UserControllers
        ucExitoAlerta aExito = new ucExitoAlerta();
        ucExisteAlumno aExiste = new ucExisteAlumno();
        ucCamObli aCamObli = new ucCamObli();
        ucCancelar aCancelar = new ucCancelar();

        //Isntancias Apoyo
        DispatcherTimer timer = new DispatcherTimer();


        int IdAlumno = 0;

        public AlumnosHome()
        {
            InitializeComponent();
            LimpiarCampos();
            CargarGrid();
        }

        #region Eventos
        private void MOD_Click(object sender, RoutedEventArgs e)
        {
            CrearAlumnos.IsEnabled = false;
            ModificarAlumnos.IsEnabled = true;
            ListaAlumnos.IsEnabled = false;
            tbEliminar.IsEnabled = false;
            tbGeneralAlumnos.SelectedIndex = 2;

            DataRowView modAlumnos = (DataRowView)dtAlumnos.SelectedItem;
            IdAlumno = (int)modAlumnos.Row.ItemArray[0];
            txtNom.Text = modAlumnos.Row.ItemArray[1].ToString();
            txtEdad.Text = modAlumnos.Row.ItemArray[2].ToString();
            txtFechaNa.Text = Convert.ToDateTime(modAlumnos.Row.ItemArray[3]).ToString("dd/MM/yyyy");
            txtTelAlum.Text = modAlumnos.Row.ItemArray[4].ToString();
            txtTelEnc.Text = modAlumnos.Row.ItemArray[5].ToString();
            txtCorreo.Text = modAlumnos.Row.ItemArray[6].ToString();

        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            dtAlumnos.DataContext = nAlumnos.FiltrarAlumnos(txtFiltrar.Text);
        }

        private void btnBuscarElim_Click(object sender, RoutedEventArgs e)
        {
            dtAlumnosElim.DataContext = nAlumnos.FiltrarAlumnosDesactivados(txtFiltrarElim.Text);
        }

        private void btnCrearAlum_Click(object sender, RoutedEventArgs e)
        {
            if (txtNomCre.Text.Equals(string.Empty) || txtEdadCre.Text.Equals(string.Empty) || txtFechaNaCre.Text.Equals(string.Empty))
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
                Alumno oAlumno = new Alumno();
                var fecha = Regex.Match(txtFechaNaCre.Text, @"\d{2}\/\d{2}\/\d{4}").Success;
                if (fecha)
                {

                    oAlumno.nombreAlumno = txtNomCre.Text;
                    oAlumno.edad = int.Parse(txtEdadCre.Text);
                    oAlumno.fechaNacimiento = Convert.ToDateTime($"{txtFechaNaCre.Text} {DateTime.Now.TimeOfDay}");
                    oAlumno.telefonoAlumno = txtTelAlumCre.Text;
                    oAlumno.telefonoEncargado = txtTelEncCre.Text;
                    oAlumno.emailAlumno = txtCorreoCre.Text;
                    oAlumno.Estado = true;
                    string resultado = nAlumnos.InsertarAlumno(oAlumno);

                    switch (resultado)
                    {
                        case "Ok":
                            LimpiarCampos();
                            tbGeneralAlumnos.SelectedIndex = 0;
                            CargarGrid();
                            aExito.Height = 50;
                            aExito.Width = 200;
                            if (!aExito.IsVisible)
                            {
                                stAlertasExito.Children.Add(aExito);
                                EjecutarAlerta();
                            }
                            break;
                        case "existe":
                            aExiste.Width = 200;
                            aExiste.Height = 50;

                            if (!aExiste.IsVisible)
                            {
                                stAlertas.Children.Add(aExiste);
                                EjecutarAlerta();
                            }
                            break;
                        default:
                            MessageBox.Show("Error: Contacte al administrador", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            break;
                    }
                }
            }
        }

        private void btnModificarAlum_Click(object sender, RoutedEventArgs e)
        {
            if (txtNom.Text.Equals(string.Empty) || txtEdad.Text.Equals(string.Empty) || txtFechaNa.Text.Equals(string.Empty))
            {
                aCamObli.Width = 405;
                aCamObli.Height = 50;

                if (!aCamObli.IsVisible)
                {
                    stAlertasMod.Children.Add(aCamObli);
                    EjecutarAlerta();
                }
            }
            else
            {
                Alumno oAlumno = new Alumno();
                var fecha = Regex.Match(txtFechaNa.Text, @"\d{2}\/\d{2}\/\d{4}").Success;
                if (fecha)
                {
                    oAlumno.idAlumno = IdAlumno;
                    oAlumno.nombreAlumno = txtNom.Text;
                    oAlumno.edad = int.Parse(txtEdad.Text);
                    oAlumno.fechaNacimiento = Convert.ToDateTime($"{txtFechaNa.Text} {DateTime.Now.TimeOfDay}");
                    oAlumno.telefonoAlumno = txtTelAlum.Text;
                    oAlumno.telefonoEncargado = txtTelEnc.Text;
                    oAlumno.emailAlumno = txtCorreo.Text;
                    oAlumno.Estado = true;
                    string resultado = nAlumnos.ActualizarAlumno(oAlumno);

                    switch (resultado)
                    {
                        case "Ok":
                            LimpiarCampos();
                            tbGeneralAlumnos.SelectedIndex = 0;
                            CrearAlumnos.IsEnabled = true;
                            ModificarAlumnos.IsEnabled = false;
                            ListaAlumnos.IsEnabled = true;
                            tbEliminar.IsEnabled = true;
                            CargarGrid();
                            aExito.Height = 50;
                            aExito.Width = 200;
                            if (!aExito.IsVisible)
                            {
                                stAlertasExito.Children.Add(aExito);
                                EjecutarAlerta();
                            }
                            break;
                        default:
                            MessageBox.Show("Error: Contacte al administrador", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            break;
                    }
                }
            }
        }

        private void BtnCanCreAlum_Click(object sender, RoutedEventArgs e)
        {
            tbGeneralAlumnos.SelectedIndex = 0;
            CrearAlumnos.IsEnabled = true;
            ModificarAlumnos.IsEnabled = false;
            LimpiarCampos();
            aCancelar.Height = 50;
            aCancelar.Width = 200;
            stAlertasExito.Children.Add(aCancelar);
            EjecutarAlerta();
        }

        private void BtnCanModAlum_Click(object sender, RoutedEventArgs e)
        {
            tbGeneralAlumnos.SelectedIndex = 0;
            CrearAlumnos.IsEnabled = true;
            ModificarAlumnos.IsEnabled = false;
            ListaAlumnos.IsEnabled = true;
            tbEliminar.IsEnabled = true;
            LimpiarCampos();
            aCancelar.Height = 50;
            aCancelar.Width = 200;
            stAlertasExito.Children.Add(aCancelar);
            EjecutarAlerta();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Notificacion not = new Notificacion();
            ucEliminar aEliminar = new ucEliminar(not);
            DataRowView row = (DataRowView)dtAlumnos.SelectedItem;
            IdAlumno = (int)row.Row.ItemArray[0];
            aEliminar.ShowDialog();
            var resultado = not.valor_confirmacion;
            if (resultado.Equals("Ok"))
            {
                string respuesta = nAlumnos.DesactivarAlumno(IdAlumno);
                if (respuesta.Equals("Ok"))
                {
                    CargarGrid();
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

        private void txtEdadCre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void btnActivar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = (DataRowView)dtAlumnosElim.SelectedItem;
            IdAlumno = (int)row.Row.ItemArray[0];
            string respuesta = nAlumnos.ActivarAlumno(IdAlumno);
            if (respuesta.Equals("Ok"))
            {
                CargarGrid();
                tbGeneralAlumnos.SelectedIndex = 0;
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
        #endregion

        #region Metodos
        private void CargarGrid()
        {
            dtAlumnos.DataContext = nAlumnos.ListarAlumnos();
            dtAlumnosElim.DataContext = nAlumnos.ListaAlumnosDesactivados();
        }

        private void LimpiarCampos()
        {
            IdAlumno = 0;
            txtNom.Text = "";
            txtEdad.Text = "";
            txtFechaNa.Text = "";
            txtTelAlum.Text = "";
            txtTelEnc.Text = "";
            txtCorreo.Text = "";

            txtNomCre.Text = "";
            txtEdadCre.Text = "";
            txtFechaNaCre.Text = "";
            txtTelAlumCre.Text = "";
            txtTelEncCre.Text = "";
            txtCorreoCre.Text = "";
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
        #endregion        
    }
}
