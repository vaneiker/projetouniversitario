using System;
using System.Data;
using System.Windows.Forms;
using CapaEntidad.DbVentas;
using CapaLogicaNegocio.NegocioDbVentas;


namespace SistemaFacturacion.Formularios
{
    public partial class FrmTrabajador : Form
    {
        private trabajadorEntitis SelectedEmpleado = null;
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
                string msg = "Favor de Digitar su Nombre y Apellidos";
                Alertas.AlertError emptyError = new Alertas.AlertError(msg);
                emptyError.ShowDialog();
                return;
            }
            else if (String.IsNullOrWhiteSpace(MascCedula.Text) || String.IsNullOrWhiteSpace(dateFechaNacimiento.Text))
            {
                string msg = "Favor de Digitar su Cedula y Fecha Nacimiento";
                Alertas.AlertError cedulaError = new Alertas.AlertError(msg);
                cedulaError.ShowDialog();
                return;
            }
            else if (String.IsNullOrWhiteSpace(cboSexo.Text) || String.IsNullOrWhiteSpace(txtTel.Text))
            {
                string msg = "Favor de Digitar el Telefono";
                Alertas.AlertError sexoError = new Alertas.AlertError(msg);
                sexoError.ShowDialog();
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
            if (repuest)
            {
                Alertas.AlertSuccess insertado = new Alertas.AlertSuccess("Datos Ingresados Correctamente!");
                insertado.ShowDialog();
                LimpiarFormulario();
            }
            else
            {
                Alertas.AlertError insertError = new Alertas.AlertError("Error al Insertar los Datos");
                insertError.ShowDialog();
                LimpiarFormulario();
            }
        }

        private void LimpiarFormulario()
        {
            txtApellido.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            cboSexo.Text = string.Empty;
            txtTel.Text = string.Empty;
            dateFechaNacimiento.Value = DateTime.Now;
            MascCedula.Text = string.Empty;
            txtApellido.Focus();
        }

        private void BuscarD_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                Alertas.Alerwarning warning = new Alertas.Alerwarning("No Se encontraron Datos a Buscar.");
                warning.ShowDialog();
                txtBuscar.Focus();
                return;
            }
            trabajadorEntitis trabajador = new trabajadorEntitis();
            var a = txtBuscar.Text.Trim().ToUpper();
            var b = txtBuscar.Text.Trim().ToUpper();
            var c = txtBuscar.Text.Trim().ToUpper();

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
                string sexo = GetSexo(trabajador.sexo);
                
                DataRow fila = dt.NewRow();
                fila["ID"] = trabajador.idtrabajador.ToString();
                fila["Nombre Completo"] = trabajador.NombreCompleto;
                fila["sexo"] = sexo; 
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
                Alertas.AlertError notFound = new Alertas.AlertError("No Se Encontro Ningun Empleado Por: " + txtBuscar.Text);
                txtBuscar.Text = string.Empty;
                txtBuscar.Focus();
                return;
            }
        }

        private void GridViewTra_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(MessageBox.Show("Desea Modificar el Empleado?", "Modificar Empleado", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                int id = Convert.ToInt32(GridViewTra.CurrentRow.Cells[0].Value.ToString());
                SelectedEmpleado = new trabajadorEntitis();
                SelectedEmpleado = SelectedEmpleado.GetEmployeeById(id);
                txtApellido.Text = SelectedEmpleado.apellidos;
                txtCorreo.Text = SelectedEmpleado.email;
                MascCedula.Text = SelectedEmpleado.num_documento;
                txtDireccion.Text = SelectedEmpleado.direccion;
                txtNombre.Text = SelectedEmpleado.nombre;
                cboSexo.Text = GetSexo(SelectedEmpleado.sexo);
                txtTel.Text = SelectedEmpleado.telefono;
                dateFechaNacimiento.Value = SelectedEmpleado.Fecha_nac;
                TabTrabajador.SelectedTab = TabTrabajador.TabPages[1];

            }
        }

        private string GetSexo(string sexo)
        {
            string s;
            switch (sexo[0].ToString())
            {
                case "M":
                    s= "Masculino";
                    break;
                case "F":
                    s= "Femenino";
                    break;
                default:
                    s= "Otros";
                    break;
            }

            return s;
        }

        private void Nuevo_Click(object sender, EventArgs e)
        {
            if (TabTrabajador.SelectedIndex == 0)
                TabTrabajador.SelectedTab = TabTrabajador.TabPages[1];

            LimpiarFormulario();
        }

        private void TabTrabajador_TabIndexChanged(object sender, EventArgs e)
        {
            if (TabTrabajador.SelectedIndex == 1)
                Limpia.Enabled = true;
            else
                Limpia.Enabled = false;
        }

        private void Limpia_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void TabTrabajador_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabTrabajador.SelectedIndex == 1)
                Limpia.Enabled = true;
            else
                Limpia.Enabled = false;
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            DialogResult resul = MessageBox.Show("Seguro que desea salir de este formulario?", "Mensage de Confirmacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (resul == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}

       
    

       

       

   