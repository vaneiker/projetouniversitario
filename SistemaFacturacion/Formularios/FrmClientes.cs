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

        LogicaDbVentas _metodos = new LogicaDbVentas();
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
           
            GridViewEmpleado.DataSource = lista;
            }

        public void BuscarCliente(string NombreCompleto, string cedula, string codigo, string telefono)
            {
            var lista = _metodos.BuscarCliente(NombreCompleto,cedula,codigo,telefono);

            GridViewEmpleado.DataSource = lista;
            }

        private void Salir_Click(object sender, EventArgs e)
            {
            MenuPrincipal mp = new MenuPrincipal();
            mp.BtnCategoria.Enabled = true;
            mp.Show();
            this.Close();
            }

        private void BuscarD_Click(object sender, EventArgs e)
            {
            
            var NomC = txtSearchFullName.Text.Trim();
            var cod = txtBuscarCodigo.Text.Trim();
            var tel = txtTelefono.Text.Trim();
            var ced = txtBuscarCedula.Text.Trim();
            
            BuscarCliente(NomC,cod,tel,ced);
            }

        private void Aceptar_Click(object sender, EventArgs e)
            {
            Registrar_Clientes();
            }

        public void Registrar_Clientes()
            {
            ClienteEntitis cliente = new ClienteEntitis();
            cliente.idcliente = 0;
            cliente.apellidos = txtApellidos.Text.Trim();
            cliente.nombre=txtNombres.Text.Trim();
            cliente.sexo = CboSex.Text;
            cliente.fecha_nacimiento =Convert.ToDateTime(DateNacimiento.Text);
           // cliente.tipo_documento = cboTipo.Text;
            cliente.num_documento = MaskCedula.Text;
            cliente.direccion = txtDire.Text;
            cliente.telefono = MascTel.Text;
            cliente.email= txtemail.Text;
            //cliente.FechaModifica =;
            _metodos.Registrar_Clientes(cliente);
            ListaCliente();
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

        private void GridViewEmpleado_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
            if (GridViewEmpleado.CurrentRow != null)
                {

                FrmClientes f = new FrmClientes();
                f.BackColor = Color.NavajoWhite;
                f.Text = "Modo Actualizar";
                txtcodigo.Text = GridViewEmpleado.CurrentRow.Cells[0].Value.ToString();
                //txtNombre.Text = GridViewEmpleado.CurrentRow.Cells[2].Value.ToString();
                //txtApellido.Text = GridViewEmpleado.CurrentRow.Cells[3].Value.ToString();
                //txtTelefono.Text = GridViewEmpleado.CurrentRow.Cells[4].Value.ToString();
                //txtDni.Text = GridViewEmpleado.CurrentRow.Cells[5].Value.ToString();
                //txtDireccion.Text = GridViewEmpleado.CurrentRow.Cells[6].Value.ToString();
                }
            }

        private void Eliminar_Click(object sender, EventArgs e)
            {
            ClienteEntitis c = new ClienteEntitis();
            if (MessageBox.Show("¿Realmente desea eliminar los clientes seleccionados?", "Eliminacion de cliente",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                c.idcliente = int.Parse(txtcodigo.Text);
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
            var Rnc = d.IsValidModulo11(maskedTexRnc.Text);
           
            maskedTexRnc.Visible = true;
            lblced.Text = "RNC";
            lblced.Visible = true;
            MaskCedula.Visible = false;
            }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
            {
            var Rnc = d.IsValidModulo10(MaskCedula.Text);
            maskedTexRnc.Visible = false;
            lblced.Text = "Cedula";
            lblced.Visible = true;
            MaskCedula.Visible = true;
            
            }
        }
    }
//string tipo;
//tipo = cboTipo.Text;

//            switch (tipo)
//                {
//                case "RNC":

//                    var Rnc = d.IsValidModulo11(maskedTexRnc.Text);
//maskedTexRnc.Visible = true;
//                    if (Rnc == true)
//                        {
//                        MessageBox.Show("El RNC Es Correcta");
//                        }
//                    else
//                        {
//                        MessageBox.Show("El RNC Es InCorrecta");
//                        }

//                    break;

//                case "Cedula":
//                    MaskCedula.Visible = true;
//                    var Cedula = d.IsValidModulo10(MaskCedula.Text);
//                    if (Cedula == true)
//                        {
//                        MessageBox.Show("La Cedula Es Correcta");
//                        }
//                    else
//                        {
//                        MessageBox.Show("La Cedula Es InCorrecta");
//                        }
//                    break;

//                }