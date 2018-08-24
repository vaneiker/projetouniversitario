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
    public partial class FrmClientes : Form
        {
        private int codigo { get; set; }
        Seccion seccion = Seccion.Instance;
        LogicaDbVentas _metodos = new LogicaDbVentas();
        Alertas.AlertError error = new Alertas.AlertError();
        Alertas.AlertSuccess succes = new Alertas.AlertSuccess();
        public FrmClientes()
            {
            InitializeComponent();
            }

        private void FrmClientes_Load(object sender, EventArgs e)
            {
            ListaCliente();
            }
        DocumentValidator d = new DocumentValidator();
        private void ListaCliente()
            {
            var lista = _metodos.ListaClientes();

            GridViewClientes.DataSource = lista;
            }

        public void BuscarCliente(string NombreCompleto, string cedula, string codigo, string telefono)
            {
            var lista = _metodos.BuscarCliente(NombreCompleto,cedula,codigo,telefono);

            GridViewClientes.DataSource = lista;
            }

        private void Salir_Click(object sender, EventArgs e)
            {
            DialogResult resul = MessageBox.Show("Seguro que desea salir de este formulario?", "Mensage de Confirmacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (resul == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
            }
        }

        private void BuscarD_Click(object sender, EventArgs e)
            {
            
            var NomC = txtSearchCategoria.Text.Trim();
            var cod = txtSearchCategoria.Text.Trim();
            var tel = txtSearchCategoria.Text.Trim();
            var ced = txtSearchCategoria.Text.Trim();
            
            BuscarCliente(NomC,cod,tel,ced);
            }

        private void Aceptar_Click(object sender, EventArgs e)
            {
              Registrar_Clientes();
            }

        public void Registrar_Clientes()
            {
            ClienteEntitis cliente = new ClienteEntitis();
            cliente.idcliente = this.codigo;
            cliente.apellidos = txtApellidos.Text.Trim();
            cliente.nombre=txtNom.Text.Trim();
            cliente.sexo = cboSex.Text;
            cliente.fecha_nacimiento =Convert.ToDateTime(dateFechaNacimiento.Text);
            cliente.tipo_documento = cboTipoDoc.Text;
            cliente.num_documento = txtNumDoc.Text;
            cliente.direccion = txtDirecion.Text;
            cliente.telefono = txtTel.Text;
            cliente.email= txtcorreo.Text;
            cliente.UsuarioAdiciona=seccion.Usuario;
            cliente.UsuarioModifica = seccion.Usuario;

           var r= _metodos.Registrar_Clientes(cliente);
            if (r == true)
            {
                ClearData();
                succes.ShowDialog();
                ListaCliente();
            }
            else
            {
                error.ShowDialog();

            }
           
            }

        private void Eliminar_Click(object sender, DataGridViewCellEventArgs e)
            {
           
            //if (e.ColumnIndex == GridViewEmpleado.Columns["Eliminar"].Index)
            //    {
            //    DataGridViewCheckBoxCell chkEliminar =
            //        (DataGridViewCheckBoxCell)GridViewEmpleado.Rows[e.RowIndex].Cells["Eliminar"];
            //    chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);

            //    }
            }

        private void DeleteClinte()
            {

            }

        private void GridViewClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
            if (GridViewClientes.CurrentRow != null)
                {

               this.codigo=int.Parse(GridViewClientes.CurrentRow.Cells[0].Value.ToString());
                txtApellidos.Text = GridViewClientes.CurrentRow.Cells[2].Value.ToString();
                txtNom.Text = GridViewClientes.CurrentRow.Cells[3].Value.ToString();
                cboSex.Text = GridViewClientes.CurrentRow.Cells[4].Value.ToString();
                txtTel.Text = GridViewClientes.CurrentRow.Cells[5].Value.ToString();
                txtDirecion.Text = GridViewClientes.CurrentRow.Cells[6].Value.ToString();
                }
            }

        private void Eliminar_Click(object sender, EventArgs e)
            {
            ClienteEntitis c = new ClienteEntitis();
            if (MessageBox.Show("¿Realmente desea eliminar los clientes seleccionados?", "Eliminacion de cliente",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                c.idcliente = this.codigo;
                _metodos.Borrar_Clientes(c);
                ListaCliente();
                MessageBox.Show("Cliente Borrado Satifactoriamente!!!");

                }
            else
                {
                MessageBox.Show("El Client no pudo ser Borrado");
                }
            }

        private void toolStripButton1_Click(object sender, EventArgs e)
            {
              ListaCliente();
            }

        private void label14_Click(object sender, EventArgs e)
            {

            }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
            {

            }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
            {

           
            }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
            {
            //var Rnc = d.IsValidModulo11(maskedTexRnc.Text);
           
            //maskedTexRnc.Visible = true;
            //lblced.Text = "RNC";
            //lblced.Visible = true;
            //MaskCedula.Visible = false;
            }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
            {
            //var Rnc = d.IsValidModulo10(MaskCedula.Text);
            //maskedTexRnc.Visible = false;
            //lblced.Text = "Cedula";
            //lblced.Visible = true;
            //MaskCedula.Visible = true;
            
            }

        private void GridViewClientes_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (GridViewClientes.CurrentRow != null)
            {
                TabEmpleado.SelectedTab = TabEmpleado.TabPages[1];


                this.codigo = int.Parse(GridViewClientes.CurrentRow.Cells[0].Value.ToString());
                txtNom.Text = GridViewClientes.CurrentRow.Cells[1].Value.ToString();
                txtApellidos.Text = GridViewClientes.CurrentRow.Cells[2].Value.ToString();
                cboSex.Text = GridViewClientes.CurrentRow.Cells[3].Value.ToString();
                cboTipoDoc.SelectedItem = GridViewClientes.CurrentRow.Cells[5].Value.ToString();
                txtNumDoc.Text = GridViewClientes.CurrentRow.Cells[6].Value.ToString();
                txtDirecion.Text = GridViewClientes.CurrentRow.Cells[7].Value.ToString();
                txtTel.Text = GridViewClientes.CurrentRow.Cells[8].Value.ToString();
                txtcorreo.Text = GridViewClientes.CurrentRow.Cells[9].Value.ToString();


                //blbStado.Visible = true;
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;


            }
        }

        private void ClearData()
        {
            txtNom.Text = string.Empty;
            txtApellidos.Text = string.Empty;
            cboSex.Text = "Seleccionar Sexo";
            cboTipoDoc.Text= "Seleccionar Tipo Documento";
            txtNumDoc.Text = string.Empty;
            txtDirecion.Text = string.Empty;
            txtTel.Text = string.Empty;
            txtcorreo.Text = string.Empty;
            //TabEmpleado.SelectedTab = TabEmpleado.TabPages[0];
        }
        }
    }
    
 