using ATL.TraspasoCartera.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATL.TraspasoCartera
{
    public partial class frmTraspasoCartera : Form
    {
        Thread _hilo1 = null;

        List<Intermediario> lstIntermediarios = new List<Intermediario>();
        List<SelectDocument> lstPolizasCargadas = new List<SelectDocument>();
        List<SelectDocument> lstPolizasSeleccionadas = new List<SelectDocument>();
        public frmTraspasoCartera()
        {
            try
            {

            InitializeComponent();

            CargaListaIntermediarios();

            dgvTraspaso.AutoGenerateColumns = false;


            }
            catch (Exception)
            {

                throw;
            }
        }
        
        #region Metodos
        private string BuscarIntermediario(int codIntermediario)
        {

            var _intermediario = lstIntermediarios.FirstOrDefault(i => i.Codigo == codIntermediario);

            if (_intermediario != null)
            {
                return _intermediario.Nombre;
            }

            return "No Encontradado";

        }

        private void CargaListaIntermediarios()
        {
            try
            {

            using (model.SysFlexSegurosEntities db = new model.SysFlexSegurosEntities())
            {
                lstIntermediarios = (from inter in db.CXC_Vendedor
                                     select new Intermediario
                                     {
                                         Codigo = inter.Codigo,
                                         Nombre = inter.NombreVendedor
                                     }).ToList();
            }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void CargaRegistrosGrid()
        {
            try
            {

                dgvTraspaso.Invoke(new Action(() => dgvTraspaso.DataSource = lstPolizasCargadas));

                Thread.Sleep(1000);

                lblProceso.Invoke(new Action(() => lblProceso.Visible = false));
                Progreso.Invoke(new Action(() => Progreso.Visible = false));
                Progreso.Invoke(new Action(() => Progreso.Value = 0));

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void exportGridToCsv(object sender, EventArgs e)
        {
            string _nombreArchivo = String.Format("{5}\\ListadoTraspaso_{0}{1}{2}{3:00}{4:00}.csv", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, Environment.CurrentDirectory);
            String _contenido = "";
            StreamWriter _fileStream = new StreamWriter(_nombreArchivo, true, UnicodeEncoding.Default);


            for (int r = -1; r < dgvTraspaso.Rows.Count; r++)
            {

                foreach (DataGridViewColumn col in dgvTraspaso.Columns)
                {

                    if (r == -1)
                    {
                        if (col.Index == 1)
                        {
                            _contenido = String.Format("\"{0}\",\"", col.HeaderText.ToString());
                        }
                        else if (col.Index > 1 && col.Index <= 5)
                        {
                            _contenido = String.Format("{0}\"{1}\"", _contenido + col.HeaderText, ",");
                        }
                    }
                    else
                    {
                        if (col.Index == 1)
                        {

                            _contenido = String.Format("\"{0}\",\"", col.DataGridView.Rows[r].Cells[col.Index].Value.ToString());
                        }
                        else if (col.Index > 1 && col.Index <= 5)
                        {
                            _contenido = String.Format("{0}\"{1}\"", _contenido + col.DataGridView.Rows[r].Cells[col.Index].Value.ToString(), ",");
                        }
                    }

                }

                string Linea = _contenido.Substring(0, _contenido.Length - 1);

                _fileStream.WriteLine(Linea);

            }

            _fileStream.Close();
            MessageBox.Show("Exportación terminada.");

        }

        private void GuardaActividad(string poliza, int _interOrigen, int _interDestino, bool success)
        {
            try
            {

            using (SysFlexSegurosEntities db = new SysFlexSegurosEntities())
            {
                Log_TraspasoCartera log = new Log_TraspasoCartera
                {
                    poliza = poliza,
                    IntermediarioOrigen = _interOrigen,
                    IntermediarioDestino = _interDestino,
                    fechaTraspaso = DateTime.Now,
                    usuario = WindowsIdentity.GetCurrent().User.Value,
                    transferido = success
                };

                db.Log_TraspasoCartera.Add(log);

                db.SaveChanges();
            }

            }
            catch (Exception ex)
            {
                string errEx = string.Format("{0}\n{1}", ex.Message, ex.InnerException);

                throw new Exception(string.Format("{0}\n{1}","Error al Guardar Log.", errEx));
            }
        }

        private void MuestraSoloSeleccionadas(bool MostrarSoloSeleccionados = false)
        {
            try
            {


                if (MostrarSoloSeleccionados)
                {
                    if (lstPolizasSeleccionadas.Count <= 0)
                    {
                        MessageBox.Show("No tiene nada Seleccionado para Mostrar.");
                        return;
                    }

                    dgvTraspaso.Invoke(new Action(() => dgvTraspaso.DataSource = null));
                    dgvTraspaso.Invoke(new Action(() => dgvTraspaso.DataSource = lstPolizasSeleccionadas));

                }
                else
                {
                    dgvTraspaso.Invoke(new Action(() => dgvTraspaso.DataSource = lstPolizasCargadas));
                }


                foreach (var document in lstPolizasSeleccionadas)
                {

                    VerificaYMarcaRegistrosComoSelected(document);

                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        private void TrasladarCartera(string poliza, int _interOrigen, int _interDestino)
        {
            try
            {
                using (SysFlexSegurosEntities db = new SysFlexSegurosEntities())
                {
                    db.ATL_TraspasoCartera(_interOrigen, _interDestino, poliza );
                    GuardaActividad(poliza, _interOrigen, _interDestino, true);

                }
            }
            catch (Exception)
            {
                GuardaActividad(poliza, _interOrigen, _interDestino, false);
                throw;
            }

        }

        private void VerificaYMarcaRegistrosComoSelected(SelectDocument document)
        {
            try
            {

                foreach (DataGridViewRow reg in dgvTraspaso.Rows)
                {
                    var _index = reg.Index;

                    bool Exists = (((string)reg.Cells["Poliza"].Value == document.Poliza) ? true : false);
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)reg.Cells["Select"];

                    if (Exists)
                    {
                        reg.Selected = Exists;
                        chk.Value = chk.TrueValue;
                    }

                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Eventos
        private void btnConfig_Click(object sender, EventArgs e)
        {
            frmConfiguracion frmCfg = null;

            if (frmCfg == null)
            {
                frmCfg = new frmConfiguracion();
            }

            frmCfg.ShowDialog();
        }

        private void btnCSV_Click(object sender, EventArgs e)
        {
            lstPolizasCargadas.Clear();
            lstPolizasSeleccionadas.Clear();

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.DefaultExt = ".csv";
            fileDialog.Filter = "Comma Separated Values (.csv)|*.csv";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    string[] registros = File.ReadAllLines(fileDialog.FileName);
                    Progreso.Maximum = registros.Count();
                    Progreso.Visible = true;
                    lblProceso.Visible = true;
                    lblProceso.Text = "Cargando Archivo CSV...";
                    for (int i = 0; i < registros.Count(); i++)
                    {

                        var registro = registros[i].Split(',');

                        Progreso.Value = i;

                        if (i == 0) continue;

                        if (registro[0].Trim() == string.Empty) continue;

                        SelectDocument doc = new SelectDocument
                        {
                            Poliza = registro[0].Trim(),
                            InterOrigen = int.Parse(registro[1].ToString()),
                            IntermediarioOrigen = BuscarIntermediario(int.Parse(registro[1].ToString())),
                            InterDestino = int.Parse(registro[2].ToString()),
                            IntermediarioDestino = BuscarIntermediario(int.Parse(registro[2].ToString()))
                        };


                        var exists = lstPolizasCargadas.Any(s => s.Poliza == doc.Poliza);

                        if (!exists) { lstPolizasCargadas.Add(doc); }


                    }

                    _hilo1 = new Thread(CargaRegistrosGrid);

                    _hilo1.Start();

                }
                catch (Exception)
                {
                    throw;
                }

            }

        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            try
            {

                foreach (DataGridViewRow reg in dgvTraspaso.Rows)
                {
                    bool chkCell = bool.Parse((string)reg.Cells["Select"].Value == null ? "false" : reg.Cells["Select"].Value.ToString());

                    if (chkCell)
                    {
                        reg.Selected = chkCell;

                        lstPolizasSeleccionadas.Add(new SelectDocument
                        {
                            Poliza = reg.Cells["Poliza"].Value.ToString(),
                            InterOrigen = int.Parse(reg.Cells["InterOrigen"].Value.ToString()),
                            IntermediarioOrigen = reg.Cells["IntermediarioOrigen"].Value.ToString(),
                            InterDestino = int.Parse(reg.Cells["InterDestino"].Value.ToString()),
                            IntermediarioDestino = reg.Cells["IntermediarioDestino"].Value.ToString()
                        });

                    }
                }

                if (lstPolizasSeleccionadas.Count == 0) return;


                lblProceso.Invoke(new Action(() => lblProceso.Text = "Traspasando polizas ..."));
                Progreso.Invoke(new Action(() => Progreso.Maximum = lstPolizasSeleccionadas.Count));
                Progreso.Invoke(new Action(() => Progreso.Value = 0));

                int docRowIndex = 0;
                foreach (SelectDocument doc in lstPolizasSeleccionadas)
                {
                    VerificaYMarcaRegistrosComoSelected(doc);

                    TrasladarCartera(doc.Poliza, doc.InterOrigen, doc.InterDestino);

                    Progreso.Invoke(new Action(() => Progreso.Value = docRowIndex));

                    docRowIndex++;

                }

            }
            catch (Exception ex)
            {
                string errmsg = string.Format("{0}\n{1}", ex.Message, ex.StackTrace);

                MessageBox.Show(errmsg); 
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void chkSeleccionados_CheckedChanged(object sender, EventArgs e)
        {
            bool MostrarSoloSeleccionados = chkSeleccionados.Checked;

            _hilo1 = new Thread(() => MuestraSoloSeleccionadas(MostrarSoloSeleccionados));

            _hilo1.Start();

        }

        private void dgvTraspaso_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {

                SelectDocument document = new SelectDocument
                {
                    Poliza = dgvTraspaso.Rows[e.RowIndex].Cells["Poliza"].Value.ToString(),
                    InterOrigen = int.Parse(dgvTraspaso.Rows[e.RowIndex].Cells["InterOrigen"].Value.ToString()),
                    IntermediarioOrigen = dgvTraspaso.Rows[e.RowIndex].Cells["IntermediarioOrigen"].Value.ToString(),
                    InterDestino = int.Parse(dgvTraspaso.Rows[e.RowIndex].Cells["InterDestino"].Value.ToString()),
                    IntermediarioDestino = dgvTraspaso.Rows[e.RowIndex].Cells["IntermediarioDestino"].Value.ToString()
                };

                DataGridViewCheckBoxCell chkCell = (DataGridViewCheckBoxCell)dgvTraspaso.Rows[e.RowIndex].Cells[0];

                if (chkCell.Value == chkCell.TrueValue)
                {
                    //dgvTraspaso.Rows[e.RowIndex].Selected = true;
                    if (!lstPolizasSeleccionadas.Any(p => p.Poliza == dgvTraspaso[1, e.RowIndex].Value))
                    {
                        lstPolizasSeleccionadas.Add(document);
                    }
                }
                else
                {
                    lstPolizasSeleccionadas.Remove(document);
                }
            }
        }
        
        private void txtPoliza_KeyUp(object sender, KeyEventArgs e)
        {
            IList<SelectDocument> resultado = null;

            if (txtPoliza.Text.Length != 0)
            {
                resultado = lstPolizasCargadas.Where(p => p.Poliza.StartsWith(txtPoliza.Text)).ToList();
            }
            else
            {
                resultado = lstPolizasCargadas;
            }

            dgvTraspaso.DataSource = resultado;
        }
        #endregion

        private void chkMarcarTodos_CheckedChanged(object sender, EventArgs e)
        {

            foreach (DataGridViewRow linea in dgvTraspaso.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)linea.Cells["Select"];

                chk.Value = chkMarcarTodos.Checked;
            }
        }

        private void pnlMenu_Paint(object sender, PaintEventArgs e)
        {

        }

    }

    public class SelectDocument
    {
        public int InterDestino { get; set; }
        public string IntermediarioDestino { get; set; }
        public string IntermediarioOrigen { get; set; }
        public int InterOrigen { get; set; }
        public string Poliza { get; set; }
    }

}
