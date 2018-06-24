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
                               , txtNombre.Text
                               , txtApellido.Text
                               , cboSexo.Text
                               , DateTime.Parse(dateFechaNacimiento.Text)
                               , MascCedula.Text
                               , txtDireccion.Text.Trim()
                               , txtTel.Text
                               , txtCorreo.Text
                               , true
                               , seccion.Usuario
                               , seccion.Usuario

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
            if (repuest == true)
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
            trabajadorEntitis trabajador = new trabajadorEntitis();
            var a = txtBuscar.Text.Trim();
            var b = txtBuscar.Text.Trim();
            var c = txtBuscar.Text.Trim();

            trabajador = trabajador.ListaTrabajador(a,b,c);
            if(trabajador !=null)
            {
                DataTable dt = new DataTable();
                dt.Clear();
                dt.Columns.Add("ID");
                dt.Columns.Add("Nombre Completo");
                dt.Columns.Add("sexo");
                dt.Columns.Add("Cedula");
                dt.Columns.Add("direccion");
                dt.Columns.Add("telefono");
                dt.Columns.Add("email");
                dt.Columns.Add("Estado");

                DataRow fila = dt.NewRow();
                fila["ID"] = trabajador.idtrabajador.ToString();
                fila["Nombre Completo"] = trabajador.NombreCompleto;
                fila["sexo"] = trabajador.sexo.ToString();
                fila["Cedula"] = trabajador.num_documento.ToString();
                fila["direccion"] = trabajador.direccion.ToString();
                fila["telefono"] = trabajador.telefono.ToString();
                fila["email"] = trabajador.email.ToString();
                fila["Estado"] = trabajador.estatus.ToString();
                dt.Rows.Add(fila);
                GridViewTra.DataSource = dt;
                GridViewTra.Columns["ID"].Visible = false;


            }
            else
            {
                MessageBox.Show("No se a encontrado ningún Resultado!");
                txtBuscar.Text = string.Empty;
                txtBuscar.Focus();
                return;
            }
        }
    }
}

       
    

       

       

   