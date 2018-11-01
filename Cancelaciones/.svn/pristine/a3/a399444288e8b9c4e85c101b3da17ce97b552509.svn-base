using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WCF_test.CancelacionesSvc;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Net;

namespace WCF_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            textBox2.Text = Guid.NewGuid().ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CancelacionesClient CancelSvc = new CancelacionesClient();

            CancelSvc.ClientCredentials.UserName.UserName = "atlkco";
            CancelSvc.ClientCredentials.UserName.Password = "atl123kco";

            //CancelSvc.ClientCredentials.ClientCertificate.Certificate = UserNamePasswordValidationMode.Custom; 

            HttpStatusCode Resultado = CancelSvc.Atl_2_Kco(textBox1.Text, Guid.Parse(textBox2.Text));

            MessageBox.Show(Resultado.ToString());
            
        }
    }
}
