using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReAssignNCF;
using System.IO;

namespace WinReAssignNCF
{

    public partial class frmDetalle : Form
    {

        Buscar _db = null;
        TipoDoc _tipoDoc = null; 

        Thread _hilo1 = null;

        public frmDetalle()
        {
            InitializeComponent();

            try
            {
                _db = new ReAssignNCF.Buscar();

                _tipoDoc = new TipoDoc(); 

                polizas = _db.ObtenerPolizasConNCF().ToList();

                OrganizaColumnasGrid();

                LlenaTipoDocumento();

                dgvListaDocumentos.DataSource = polizas;

                //btnAsignarNCF.Text = "Asignar \n NCF";

            }
            catch (Exception ex)
            {
               

                string msg = string.Format("{0}\n{1}", ex.Message, ex.InnerException );

                MessageBox.Show(msg);
            }
        }

        IList<InfoNCFPolizas> polizas { get; set; }

        private void btnAsignarNCF_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow reg in dgvListaDocumentos.Rows)
            {
                bool chkCell = bool.Parse((string)reg.Cells["Check"].Value == null ? "false" : reg.Cells["Check"].Value.ToString());

                if (chkCell)
                {
                    reg.Selected = chkCell;

                    lstPolizasSeleccionadas.Add(new SelectDocument { poliza = reg.Cells["Poliza"].Value.ToString(), ncf = reg.Cells["NCF"].Value.ToString() });

                }
            }

            if (lstPolizasSeleccionadas.Count == 0) return;

            AsignarNuevoDocumento();
        }

        private void cbTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvListaDocumentos.DataSource = null;


            TipoMovimiento Selected = (TipoMovimiento)cbTipoDocumento.SelectedItem;

            dgvListaDocumentos.DataSource = FiltrarPolizas((Selected != null) ? Selected.Id : 0);

        }

        IList<ReAssignNCF.InfoNCFPolizas> FiltrarPolizas(int DocTypeId = 0, string DocumentoNo = null, string NcfNo = null)
        {
            string Documento = DocumentoNo == "" ? null : DocumentoNo;
            string NCF = NcfNo == "" ? null : NcfNo;

            if (DocTypeId != 0 & Documento == null & NCF == null) return polizas.Where(p => p.TipoDocumento == DocTypeId).ToList();

            if (DocTypeId != 0 & Documento != null & NCF == null) return polizas.Where(p => p.TipoDocumento == DocTypeId & p.Poliza == DocumentoNo).ToList();

            if (DocTypeId != 0 & Documento != null & NCF != null) return polizas.Where(p => p.TipoDocumento == DocTypeId & p.Poliza == DocumentoNo & p.NCF == NcfNo).ToList();

            if (DocTypeId == 0 & Documento != null & NCF == null) return polizas.Where(p => p.Poliza == DocumentoNo).ToList();

            if (DocTypeId == 0 & Documento != null & NCF != null) return polizas.Where(p => p.Poliza == DocumentoNo & p.NCF == NcfNo).ToList();

            return polizas;
        }

        private void LlenaTipoDocumento()
        {
            List<TipoMovimiento> lstTipoMovimento = _tipoDoc.Obtener;
            TipoMovimiento _tmv = new TipoMovimiento { Id = 0, Nombre = "-" };

            lstTipoMovimento.Insert(0, _tmv);

            cbTipoDocumento.DataSource = lstTipoMovimento;
            cbTipoDocumento.ValueMember = "Id";
            cbTipoDocumento.DisplayMember = "Nombre";

        }

        private void OrganizaColumnasGrid()
        {

            dgvListaDocumentos.AutoGenerateColumns = false;

            dgvListaDocumentos.Columns["Poliza"].DisplayIndex = 0;
            dgvListaDocumentos.Columns["TipoDocumento"].DisplayIndex = 1;
            dgvListaDocumentos.Columns["Factura"].DisplayIndex = 2;
            dgvListaDocumentos.Columns["Valor"].DisplayIndex = 3;
            dgvListaDocumentos.Columns["ValorItbis"].DisplayIndex = 4;
            dgvListaDocumentos.Columns["NCF"].DisplayIndex = 5;
            dgvListaDocumentos.Columns["Check"].DisplayIndex = 6;

        }

        private void txtDocumentNo_Validated(object sender, EventArgs e)
        {
            dgvListaDocumentos.DataSource = null;


            TipoMovimiento Selected = (TipoMovimiento)cbTipoDocumento.SelectedItem;

            dgvListaDocumentos.DataSource = FiltrarPolizas((Selected != null) ? Selected.Id : 0, txtPoliza.Text, txtNCF.Text);
        }

        List<SelectDocument> lstPolizasSeleccionadas = new List<SelectDocument>();

        private void AsignarNuevoDocumento()
        {
            ReAssignNCF.Reassign Reasigna = new Reassign();
            foreach (var item in lstPolizasSeleccionadas)
            {

                Reasigna.Actualiza(item.poliza, item.ncf);

            }

            polizas = _db.ObtenerPolizasConNCF().ToList();

            dgvListaDocumentos.DataSource = polizas;

        }

        private void btnCSV_Click(object sender, EventArgs e)
        {
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

                        SelectDocument doc = new SelectDocument { poliza = registro[0].Trim(), ncf = registro[1].Trim() };

                        var exists = lstPolizasSeleccionadas.Any(s => s.poliza == doc.poliza && s.ncf == doc.ncf);

                        if (!exists) { lstPolizasSeleccionadas.Add(doc); }

                        Progreso.Value = i;
                    }

                    _hilo1 = new Thread(SeleccionaRegistros);

                    _hilo1.Start();

                }
                catch (Exception)
                {
                    throw;
                }

            }

        }

        private void SeleccionaRegistros()
        {
            try
            {

                lblProceso.Invoke(new Action(() => lblProceso.Text = "Buscando coincidencias..."));
                Progreso.Invoke(new Action(() => Progreso.Maximum = lstPolizasSeleccionadas.Count));
                Progreso.Invoke(new Action(() => Progreso.Value = 0));

                int docRowIndex = 0;
                foreach (var document in lstPolizasSeleccionadas)
                {

                    VerificaYMarcaRegistrosComoSelected(document);

                    Progreso.Invoke(new Action(() => Progreso.Value = docRowIndex));
                    docRowIndex++;
                }

                lblProceso.Invoke(new Action(() => lblProceso.Text = "Buscando coincidencias... Completado!"));

                Thread.Sleep(300);

                lblProceso.Invoke(new Action(() => lblProceso.Visible = false));
                Progreso.Invoke(new Action(() => Progreso.Visible = false));
                Progreso.Invoke(new Action(() => Progreso.Value = 0));

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void VerificaYMarcaRegistrosComoSelected(SelectDocument document)
        {
            try
            {

                foreach (DataGridViewRow reg in dgvListaDocumentos.Rows)
                {
                    var _index = reg.Index;
                    //if (reg.Index == dgvListaDocumentos.Rows.Count - 1)
                    //{


                    bool Exists = (((string)reg.Cells["Poliza"].Value == document.poliza & (string)reg.Cells["NCF"].Value == document.ncf) ? true : false);
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)reg.Cells["Check"];

                    if (Exists)
                    {
                        reg.Selected = Exists;
                        chk.Value = chk.TrueValue;
                    }
                    //}
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            Form1 frmCfg = null;

            if (frmCfg == null)
            {
                frmCfg = new Form1();
            }

            frmCfg.ShowDialog();
        }

        private void chkSeleccionados_CheckedChanged(object sender, EventArgs e)
        {
            bool MostrarSoloSeleccionados = chkSeleccionados.Checked;

            _hilo1 = new Thread(() => MuestraSoloSeleccionadas(MostrarSoloSeleccionados));

            _hilo1.Start();

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

                var ncf = from po in lstPolizasSeleccionadas
                          select po.ncf;
                var resultado = polizas.Where(p => ncf.Contains(p.NCF));

                dgvListaDocumentos.Invoke(new Action(() => dgvListaDocumentos.DataSource = null));
                dgvListaDocumentos.Invoke(new Action(() => dgvListaDocumentos.DataSource = resultado.ToList()));

            }
            else
            {
                dgvListaDocumentos.Invoke(new Action(() => dgvListaDocumentos.DataSource = polizas));
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

        private void btnDescargar_Click(object sender, EventArgs e)
        {
            exportGridToCsv();
        }

        private void exportGridToCsv()
        {
            string _nombreArchivo = String.Format("{5}\\ListadoDocumentosNCF_{0}{1}{2}{3:00}{4:00}.csv", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, Environment.CurrentDirectory);
            String _contenido = "";
            StreamWriter _fileStream = new StreamWriter(_nombreArchivo, true, UnicodeEncoding.Default);


            for (int r = -1; r < dgvListaDocumentos.Rows.Count; r++)
            {

                foreach (DataGridViewColumn col in dgvListaDocumentos.Columns)
                {

                    if (r == -1)
                    {
                        if (col.Index == 0)
                        {
                            _contenido = String.Format("\"{0}\",\"", col.HeaderText.ToString());
                        }
                        else if (col.Index > 0 && col.Index <= 5)
                        {
                            _contenido = String.Format("{0}\"{1}\"", _contenido + col.HeaderText, ",");
                        }
                    }
                    else
                    {
                        if (col.Index == 0)
                        {

                            _contenido = String.Format("\"{0}\",\"", col.DataGridView.Rows[r].Cells[col.Index].Value.ToString());
                        }
                        else if (col.Index > 0 && col.Index <= 5)
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

        private void btnSalir_Click(object sender, EventArgs e)
        {

            this.Close();
            this.Dispose();

        }


    }

    public class SelectDocument
    {
        public string poliza { get; set; }
        public string ncf { get; set; }
    }




}
