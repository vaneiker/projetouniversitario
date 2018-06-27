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
    public partial class FrmProveedor : Form
        {
        public FrmProveedor()
            {
            InitializeComponent();
            }
        #region cabecera
        private string codigo { get; set; }
        private string tipo { get; set; }
        ProveedorEntity selectProveedor;
        LogicaDbVentas _log = new LogicaDbVentas();

        ComboxBosxTools cbo = new ComboxBosxTools();
        Seccion seccion = Seccion.Instance;
        LogicaDbVentas _metodos = new LogicaDbVentas();
        Alertas.AlertError error = new Alertas.AlertError();
        Alertas.AlertSuccess succes = new Alertas.AlertSuccess();

        #endregion
        
        
        private void GridViewEmpleado_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {

            }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProveedor.Text) || string.IsNullOrWhiteSpace(cboR.Text) || cboR.Text== "---Seleccione---")
            {
                MessageBox.Show("Digite un Nombre de Proveedor y su Razón Social");
                return;
            }
            else
                    if (string.IsNullOrWhiteSpace(RNCradio.Text) || string.IsNullOrWhiteSpace(Cedularadio.Text))
            {
                MessageBox.Show("Elija un Tipo de Documento");
                return;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(CedulaMask.Text.Replace("-","")) && string.IsNullOrWhiteSpace(RncMasck.Text.Replace("-", "")))
                {
                    MessageBox.Show("Asegurese de Digitar la cedula o Rnc según el tipo Seleccionado");
                    return;
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(CedulaMask.Text) || string.IsNullOrWhiteSpace(RncMasck.Text))
                    {
                        MessageBox.Show("Asegurese de Digitar la cedula o Rnc según el tipo Seleccionado");
                        return;
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(txtDireccion.Text) || string.IsNullOrWhiteSpace(txtTel.Text))
                        {
                            MessageBox.Show("Digite la Dirección del Proveedor y su Numero Telefonico");
                            return;
                        }
                        else
                        {
                            Registrar_Proveedor();
                        }
                    }

                }
            }
        }
       private void CleanData()
        {
            this.codigo = string.Empty;
            cboR.Text = string.Empty;
            txtProveedor.Text= string.Empty;
            this.tipo=string.Empty; ;
            CedulaMask.Text = string.Empty;
            RncMasck.Text=string.Empty;
            txtDireccion.Text= string.Empty;
            txtTel.Text= string.Empty;
            tctcorreo.Text= string.Empty;
            lblataipo.Visible = false;
            RncMasck.Visible = false;
            CedulaMask.Visible = false;
            dateFechaNacimiento.Text = string.Empty;
            txtProveedor.Focus();                                        
           
        }                 
            
        private void cargarTipoF()
        {
            var c = cbo.TipoDeFactura();
            cboR.DataSource = c;
            cboR.DisplayMember = "Tipo_Comprovante_Fiscal";
            cboR.ValueMember = "id";
        }
        private void Registrar_Proveedor()
        {

            ProveedorEntity proveedor = new ProveedorEntity();
            proveedor.idproveedor = int.Parse(this.codigo == "" || this.codigo ==null ?this.codigo="0":this.codigo);
            proveedor.razon_social = cboR.Text;
            proveedor.NombreProveedor = txtProveedor.Text;
            proveedor.tipo_documento = this.tipo;
            proveedor.num_documento = RNCradio.Text == "" ? CedulaMask.Text : RncMasck.Text;
            proveedor.direccion = txtDireccion.Text.Trim();
            proveedor.telefono = txtTel.Text;
            proveedor.email = tctcorreo.Text;
            proveedor.url = "";
            proveedor.statu = true;
            proveedor.UsuarioAdiciona = seccion.Usuario;
            proveedor.UsuarioModifica =seccion.Usuario;

            var r = _metodos.Registrar_Proveedor(proveedor);
            if (r == true)
            {
                succes.ShowDialog();
                CleanData();

                //ListaCliente();
            }
            else
            {
                error.ShowDialog();

            }

        }

        private void BuscarD_Click(object sender, EventArgs e)
        {


            CriterioBusquedaProveedor(txtBuscarProveedor.Text.Trim(), txtBuscarProveedor.Text.Trim(), txtBuscarProveedor.Text.Trim());
           
        }

        private void RNCradio_CheckedChanged(object sender, EventArgs e)
        {
            this.tipo = "RNC";
            //var Rnc = d.IsValidModulo11(maskedTexRnc.Text);
            dateFechaNacimiento.Enabled = false;
            CedulaMask.Text = string.Empty;
            RncMasck.Visible = true;
            lblataipo.Text = "RNC";
            lblataipo.Visible = true;
            CedulaMask.Visible = false;
        }

        private void Cedularadio_CheckedChanged(object sender, EventArgs e)
        {
            this.tipo = "Cedula";
            dateFechaNacimiento.Enabled =true;
            RncMasck.Text = string.Empty;
            CedulaMask.Visible = true;
            lblataipo.Text = "Cedula";
            lblataipo.Visible = true;
            RncMasck.Visible = false;
        }

        private void FrmProveedor_Load(object sender, EventArgs e)
        {
            var dato = _metodos.Listap();
            GrivProveedor.DataSource = dato;
            cargarTipoF();
        }

        private void GrivProveedor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ProveedorEntity prov = new ProveedorEntity();
            this.codigo = GrivProveedor.Rows[e.RowIndex].Cells["idProveedor"].Value.ToString();
            selectProveedor = prov.ListaProveedores(int.Parse(this.codigo));
            this.codigo =Convert.ToString(selectProveedor.idproveedor);
            txtProveedor.Text = selectProveedor.NombreProveedor;


            
            cboR.Text = selectProveedor.razon_social;
            this.tipo = selectProveedor.tipo_documento;           
            txtDireccion.Text = selectProveedor.direccion;
            txtTel.Text = selectProveedor.telefono;
            tctcorreo.Text = selectProveedor.email;

            var a= selectProveedor.tipo_documento;
          
            if (a == "RNC")
            {
                RNCradio.Checked=true;
                RncMasck.Text = selectProveedor.num_documento;
                RncMasck.Visible = true;
                lblataipo.Visible = true;
            }
            else if (a == "Cedula")
            {
                Cedularadio.Checked = true;
                Cedularadio.Text = selectProveedor.num_documento;
                CedulaMask.Visible = true;
                lblataipo.Visible = true;
            }

            TabTrabajador.SelectedTab = TabTrabajador.TabPages[1];
        }

        private void CriterioBusquedaProveedor(string nom,string documento,string telefono)
        {
            var dato = _metodos.CriterioBusquedaProveedor(documento,telefono,nom);

           
            GrivProveedor.DataSource = dato;

        }
    }
    }
