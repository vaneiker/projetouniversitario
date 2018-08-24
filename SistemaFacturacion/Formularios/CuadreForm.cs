using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogicaNegocio.NegocioDbVentas;
using CapaLogicaNegocio.ModeloVista;

namespace SistemaFacturacion.Formularios
{
    public partial class CuadreForm : Form
    {
        LogicaDbVentas db = new LogicaDbVentas();
        public CuadreForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lbTotal.Visible = false;
            List<CuadreViewModel> ventas = (List<CuadreViewModel>) db.MostrarVentasDelDia();
            if(ventas != null)
            {
                gridDatos.DataSource = ventas;
                gridDatos.Columns["idventa"].Visible = false;
                gridDatos.Columns["idtrabajador"].Visible = false;

                decimal total = ventas.Sum(venta => venta.Total);
                lbTotal.Text = "Ventas del Dia: " + total.ToString("N2");
                lbTotal.Visible = true;
                lblm.Visible = true;
            }
            else
            {
                Alertas.Alerwarning noVentas = new Alertas.Alerwarning("No Existen Ventas Para Hoy: " + DateTime.UtcNow.ToShortDateString());
                noVentas.ShowDialog();
                lbTotal.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lbTotal.Visible = false;
            if(datePickerHasta.Value < datePickerDesde.Value)
            {
                Alertas.AlertError mayor = new Alertas.AlertError("Fecha hasta No Puede ser Mayor");
                mayor.ShowDialog();
                return;
            }
            if(datePickerDesde.Value.Day != 1 && (datePickerHasta.Value.Day != 30 || datePickerHasta.Value.Day != 31))
            {
                Alertas.Alerwarning noMes = new Alertas.Alerwarning("Informacion no Representa un Mes.");
                noMes.ShowDialog();
            }
            List<CuadreViewModel> ventas = (List<CuadreViewModel>)db.MostrarVentasDelDia();

            if(ventas != null)
            {
                gridDatos.DataSource = ventas;
                gridDatos.Columns["idventa"].Visible = false;
                gridDatos.Columns["idtrabajador"].Visible = false;

                decimal total = ventas.Sum(venta => venta.Total);
                lbTotal.Text = "Ventas del Mes: " + total.ToString("N2");
                lbTotal.Visible = true;
            }else
            {
                Alertas.Alerwarning noVentas = new Alertas.Alerwarning("No Hay Ventas Generada Desde: " + datePickerDesde.Value.ToShortDateString() + " a " + datePickerHasta.Value.ToShortDateString());
                noVentas.ShowDialog();
            }
            
        }

        private void CuadreForm_Load(object sender, EventArgs e)
        {
            lbNombreTrabajador.Text = Seccion.Instance.nombreCompleto;
        }
    }
}
