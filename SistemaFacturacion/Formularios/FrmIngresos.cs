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
    public partial class FrmIngresos : Form
        {
        LogicaDbVentas _metodos = new LogicaDbVentas();
        public FrmIngresos()
            {
            InitializeComponent();
            }
        DocumentValidator d = new DocumentValidator();
        private void FrmIngresos_Load(object sender, EventArgs e)
            {

            //this.reportViewer1.RefreshReport();
            }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            var Cedula = d.IsValidModulo10(MackCedula.Text);
            MackCedula.Visible = true;
            lblTpD.Text = "Cedula";
            lblTpD.Visible = true;
            MaskRnc.Text = string.Empty;
            MaskRnc.Visible = false;
           
        }

        private void RadioButtRnc_CheckedChanged(object sender, EventArgs e)
        {
            var Rnc = d.IsValidModulo10(MaskRnc.Text);
            MaskRnc.Visible = true;
            lblTpD.Text ="RNC";
            lblTpD.Visible = true;
            MackCedula.Text = string.Empty;
            MackCedula.Visible = false;
        }
    }
    }
