using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using ATL.TraspasoCartera.model;



//using System.Data.EntityClient;


namespace ATL.TraspasoCartera
{
    public partial class frmConfiguracion : Form
    {
        public frmConfiguracion()
        {
            InitializeComponent();
        }


        private void btnActualizarListaBaseDatos_Click(object sender, EventArgs e)
        {
            CargaListaServidores(chkTrustedConnection.Checked, txtUser.Text, txtPassword.Text);

        }


        private void CargaListadeServidores()
        {

            DataTable dataTable = SmoApplication.EnumAvailableSqlServers(false);

            cbServerList.ValueMember = "Name";
            cbServerList.DataSource = dataTable;

        }

        private void CargaListaServidores(bool TrustedConnection = false, string userId = "", string password = "")
        {
            string serverName = cbServerList.Text;




            ServerConnection SrvConn = new ServerConnection();

            SrvConn.ServerInstance = serverName;
            if (TrustedConnection)
            {
                SrvConn.LoginSecure = TrustedConnection;
            }
            else
            {
                SrvConn.LoginSecure = TrustedConnection;
                if (userId == "")
                {
                    MessageBox.Show("El Usuario no debe estar en blanco.");
                    return;
                }
                else if (password == "")
                {
                    MessageBox.Show("El password no debe estar en blanco.");
                    return;
                }
                else
                {
                    SrvConn.Login = userId;
                    SrvConn.Password = password;
                }

            }

            Server server = new Server(SrvConn);

            try
            {
                foreach (Microsoft.SqlServer.Management.Smo.Database database in server.Databases)
                {
                    cbDatabaseList.Items.Add(database.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void chkTrustedConnection_CheckedChanged(object sender, EventArgs e)
        {
            txtUser.Enabled = !chkTrustedConnection.Checked;
            txtPassword.Enabled = !chkTrustedConnection.Checked;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReadConfig();

        }

        private void ReadConfig()
        {


            SysFlexSegurosEntities _dbSF = new SysFlexSegurosEntities();

            CargaListadeServidores();

            try
            {

                var _conn = _dbSF.Database.Connection;

                SqlConnectionStringBuilder sqlConn = new SqlConnectionStringBuilder(_conn.ConnectionString);

                cbServerList.Text = sqlConn.DataSource;
                cbDatabaseList.Text = sqlConn.InitialCatalog;

                txtUser.Text = sqlConn.UserID;
                txtPassword.Text = sqlConn.Password;

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //var _config = ConfigurationManager.OpenExeConfiguration(userLevel: ConfigurationUserLevel.None);

            //_config.AppSettings.Settings["TipoDocABuscar"].Value = txtTipoDocumentoID.Text;

            //_config.AppSettings.Settings["CompanyId"].Value = txtCompanyId.Text;

            //_config.Save();

            //ConfigurationManager.RefreshSection("AppSettings");

            GuardarConnectionString(cbServerList.Text, cbDatabaseList.Text, chkTrustedConnection.Checked, txtUser.Text, txtPassword.Text);

        }

        private void GuardarConnectionString(string servidor, string basedatos, bool TrustedConnection = false, string userId = "", string passWord = "")
        {

            try
            {
                
                EntityConnectionStringBuilder _connBld = new EntityConnectionStringBuilder(connectionString: ConfigurationManager.ConnectionStrings["SysFlexSegurosEntities"].ConnectionString);

                PrepararSQLConnStr(servidor, basedatos, TrustedConnection, userId, passWord, _connBld);

                var _config = ConfigurationManager.OpenExeConfiguration(userLevel: ConfigurationUserLevel.None);

                _config.ConnectionStrings.ConnectionStrings["SysFlexSegurosEntities"].ConnectionString = _connBld.ToString();

                _config.Save();

                ConfigurationManager.RefreshSection("ConnectionStrings");

                ProtegerConnStr(true);

                MessageBox.Show("Guardado Satisfactoriamente!");

            }
            catch (Exception ex)
            {
                string msg = string.Format("Error al Guardar \n {0}", ex.Message);
                MessageBox.Show(msg);

            }
        }

        private void PrepararSQLConnStr(string servidor, string basedatos, bool TrustedConnection, string userId, string passWord, EntityConnectionStringBuilder _connBld)
        {


            SqlConnectionStringBuilder _conn = new SqlConnectionStringBuilder(_connBld.ProviderConnectionString);

            _conn.UserID = userId;

            _conn.Password = passWord;

            _conn.IntegratedSecurity = TrustedConnection;

            _conn.InitialCatalog = basedatos;

            _conn.DataSource = servidor;

            _connBld.ProviderConnectionString = _conn.ToString();



        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ProtegerConnStr(bool Proteger)
        {
            var _config = ConfigurationManager.OpenExeConfiguration(userLevel: ConfigurationUserLevel.None);

            if (Proteger)
            {
                _config.ConnectionStrings.SectionInformation.ProtectSection(null);
            }
            else
            {
                _config.ConnectionStrings.SectionInformation.UnprotectSection();
            }

            _config.ConnectionStrings.SectionInformation.ForceSave = true;

            _config.Save();

        }
    }
}
