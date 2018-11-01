using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATL.EditCoberturas
{
    public partial class frmCobertura : Form
    {

        SysFlexSegurosEntities db = new SysFlexSegurosEntities();

        public frmCobertura()
        {
            InitializeComponent();
        }

        public IQueryable<P_PolizaCoberturasMov> CargaData(decimal cotizacion)
        {

            var resultado = (from f in db.P_PolizaCoberturasMov
                             where f.Cotizacion == cotizacion
                             select f);

            return resultado;

        }



        public void CargaData(decimal cotizacion, int SecuenciaMov, int SecuenciaCot)
        {

            var resultado = CargaData(cotizacion);

            if (SecuenciaMov > 0 && SecuenciaCot > 0) { resultado = resultado.Where(c => c.SecuenciaMov == SecuenciaMov && c.SecuenciaCot == SecuenciaCot); }

            if (SecuenciaMov > 0) { resultado = resultado.Where(c => c.SecuenciaMov == SecuenciaMov); }

            if (SecuenciaCot > 0) { resultado = resultado.Where(c => c.SecuenciaCot == SecuenciaCot); }





            //var resultado = (from f in db.P_PolizaCoberturasMov
            //                 where f.Cotizacion == cotizacion && f.SecuenciaMov == SecuenciaMov && f.SecuenciaCot == SecuenciaCot
            //                 select f);

            dgvCobertura.DataSource = new BindingList<P_PolizaCoberturasMov>(resultado.ToList());

            FormatGridView();

        }

        public void FormatGridView()
        {
            dgvCobertura.Columns["Compania"].Visible = false;
            dgvCobertura.Columns["Endoso"].Visible = false;
            dgvCobertura.Columns["Cotizacion"].Visible = false;

            //Size
            dgvCobertura.Columns["Ramo"].Width = 40;
            dgvCobertura.Columns["SubRamo"].Width = 60;



            dgvCobertura.Columns["SecuenciaCot"].Width = 50;
            dgvCobertura.Columns["SecuenciaCot"].HeaderText = "SecCot";

            dgvCobertura.Columns["Secuencia"].Width = 30;
            dgvCobertura.Columns["Secuencia"].HeaderText = "Sec";

            dgvCobertura.Columns["TieneCobertura"].Width = 60;
            dgvCobertura.Columns["TieneCobertura"].HeaderText = "Tiene\nCobertura";

            dgvCobertura.Columns["SecuenciaMov"].Width = 50;
            dgvCobertura.Columns["SecuenciaMov"].HeaderText = "SecMov";

            dgvCobertura.Columns["ValorServicio"].Width = 70;
            dgvCobertura.Columns["ValorServicio"].HeaderText = "Valor\nServicio";

            dgvCobertura.Columns["PorcDeducible"].Width = 60;
            dgvCobertura.Columns["PorcDeducible"].HeaderText = "%\nDeducible";

            dgvCobertura.Columns["PorcCobertura"].Width = 60;
            dgvCobertura.Columns["PorcCobertura"].HeaderText = "%\nCobertura";

            dgvCobertura.Columns["MontoInformativo"].Width = 80;
            dgvCobertura.Columns["MontoInformativo"].HeaderText = "Monto\nInformativo";

            dgvCobertura.Columns["MinimoDeducible"].Width = 80;
            dgvCobertura.Columns["MinimoDeducible"].HeaderText = "Minimo\nDeducible";

            dgvCobertura.Columns["Porciento"].Width = 80;
            dgvCobertura.Columns["Prima"].Width = 80;


        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtCotizacion_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargaData(decimal.Parse(txtCotizacion.Text), 0, 0);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            db.SaveChanges();
        }

        private void txtSecuenciaMov_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int _secMov = txtSecuenciaMov.Text == "" ? 0 : int.Parse(txtSecuenciaMov.Text);

                CargaData(decimal.Parse(txtCotizacion.Text), _secMov, 0);
            }
        }

        private void txtSecuenciaCot_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                int _secMov = txtSecuenciaMov.Text == "" ? 0 : int.Parse(txtSecuenciaMov.Text);
                int _secCot = txtSecuenciaCot.Text == "" ? 0 : int.Parse(txtSecuenciaCot.Text);

                CargaData(decimal.Parse(txtCotizacion.Text), _secMov, _secCot);

                // CargaData(decimal.Parse(txtCotizacion.Text), int.Parse(txtSecuenciaMov.Text), int.Parse(txtSecuenciaCot.Text));
            }
        }

        private void txtPoliza_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string _poliza = txtPoliza.Text;
                txtCotizacion.Text = GetCotizacionByPoliza(_poliza).ToString();

                txtCotizacion.Focus();


            }
        }

        private Decimal GetCotizacionByPoliza(string poliza)
        {

            if (poliza != "")
            {
                var resultado = db.P_PolizaHeaderMov.FirstOrDefault(p => p.Poliza == poliza);

                if (resultado != null)
                {
                    return resultado.Cotizacion;

                }
                else
                {
                    return 0;
                }
            }

            return 0;

        }

    }
}
