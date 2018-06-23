using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad.DbVentas;
using CapaLogicaNegocio.NegocioDbVentas;


namespace SistemaFacturacion.Formularios
{
    public partial class FrmTrabajador : Form
    {
        public FrmTrabajador()
        {
            InitializeComponent();
        }

        #region CbezeraMetodo
        LogicaDbVentas _metodos = new LogicaDbVentas();
        Alertas.AlertError error = new Alertas.AlertError();
        Alertas.AlertSuccess success = new Alertas.AlertSuccess();
        Alertas.Alerwarning warnig = new Alertas.Alerwarning();
        Seccion seccion = Seccion.Instance;

        private int codigo { get; set; }
        #endregion

        private void Aceptar_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrWhiteSpace(txtNombre.Text) || String.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Favor de Digitar su Nombre y Apellidos");
                return;
            }
            else if (String.IsNullOrWhiteSpace(MascCedula.Text) || String.IsNullOrWhiteSpace(dateFechaNacimiento.Text))
            {
                MessageBox.Show("Favor de Digitar su Cedula y Fecha Nacimiento");
                return;
            }
            else if (String.IsNullOrWhiteSpace(cboSexo.Text) || String.IsNullOrWhiteSpace(txtTel.Text))
            {
                MessageBox.Show("Favor de Digitar el Telefono");
                return;
            }

            else
            {
                Add_Employee(
                                this.codigo
                               ,txtNombre.Text
                               ,txtApellido.Text
                               ,cboSexo.Text
                               ,DateTime.Parse(dateFechaNacimiento.Text)
                               ,MascCedula.Text
                               ,txtDireccion.Text.Trim()
                               ,txtTel.Text
                               ,txtCorreo.Text
                               ,true
                               ,seccion.Usuario
                               ,seccion.Usuario
                            
                             );
            }
        }            
    

        private void Add_Employee(
                                   int idtrabajador
                                 , string nombre
                                 , string apellidos
                                 , string sexo
                                 , DateTime Fecha_nac
                                 , string num_documento
                                 , string direccion
                                 , string telefono
                                 , string email
                                 , bool StatusE
                                 , string UsuarioAdiciona
                                 , string UsuarioModifica
                                  )

        {

            var repuest = _metodos.Add_employee(
                 idtrabajador
                 , nombre
                 , apellidos
                 , sexo
                 , Fecha_nac
                 , num_documento
                 , direccion
                 , telefono
                 , email
                 , StatusE
                 , UsuarioAdiciona
                 , UsuarioModifica);
            if(repuest==true)
            {
                success.ShowDialog();
            }
            else
            {
                error.ShowDialog();
            }
        }

        private void BuscarD_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "" || txtBuscar.Text == null)
            {
                error.ShowDialog();
            }
            else
            {
                string a, b, c, d;
                a = txtBuscar.Text.Trim();
                b = txtBuscar.Text.Trim();
                c = txtBuscar.Text.Trim();
                d = txtBuscar.Text.Trim();

                var trabajador = _metodos.ListaTrabajador(a, b, c, d);
                if (trabajador.Count > 0)
                {
                    GridViewTra.DataSource = trabajador;

                }
            }

            }

        }

       
    }


       

       

   