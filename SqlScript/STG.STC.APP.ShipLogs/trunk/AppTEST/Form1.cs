using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShipLogs.Logic.LogicBL;
using ShipLogs.Entity.Entity;

namespace AppTEST
{
    public partial class Form1 : Form
    {
        private ShioLogsManager manager = new ShioLogsManager();
        private ShipmentEntity ShipmentE = new ShipmentEntity();

        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Click on the link below to continue learning how to build a desktop app using WinForms!
            System.Diagnostics.Process.Start("http://aka.ms/dotnet-get-started-desktop");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thanks!");
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            var data = manager.GET_Shimet_Logic(textBox1.Text);
            dataGridView1.DataSource = data;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var shipment = new ShipmentEntity();


            List<ShipmentDetailEntity> shipmentDetail = new List<ShipmentDetailEntity>();

            shipment.ShipUniqueID = 0;
            shipment.CarrierName = "DHL";
            shipment.AccountNumber = "";
            shipment.ShipmentNumber = "12345678910";
            shipment.ShipmentDate = DateTime.Now;
            shipment.ShipmentWeight = 1;
            shipment.ShipmentQTY = 1;
            shipment.ShipPackageType = "Envelope";
            shipment.Operator = "MVAZQUEZ";
            shipment.Sender = "Juaquin Puello2";
            shipment.Receiver = "Juan Perez2";
            shipment.ReceiverAttn = "";
            shipment.ReceiverAddress = "";
            shipment.ReceiverCity = "";
            shipment.ReceiverState = "";
            shipment.ReceiverZipCode = "";
            shipment.ReceiverCountry = "";
            shipment.ReceiverPhoneNumber = "";
            shipment.ShipmentComments = "";
            shipment.Transit = true;
            shipment.Incoming = true;
            shipment.CommissionChecks = false;
            shipment.Materials = false;
            shipment.OtherContents = false;

            var aa = manager.Set_Shimet_Logic(shipment);

            shipmentDetail.Add(new ShipmentDetailEntity());// Implementación para poder agregar los detalles 


            shipmentDetail.Add(new ShipmentDetailEntity { ShipUniqueID = aa.id, AssignedTo = "Pica Pollo de Prueba151", ItemDetail = "Ninguno8",DetailUniqueID = 0 });
            shipmentDetail.Add(new ShipmentDetailEntity { ShipUniqueID = aa.id, AssignedTo = "Pica Pollo de Prueba152", ItemDetail = "Ninguno7", DetailUniqueID = 0 });
            shipmentDetail.Add(new ShipmentDetailEntity { ShipUniqueID = aa.id, AssignedTo = "Pica Pollo de Prueba153", ItemDetail = "Ninguno6",DetailUniqueID = 0 });
            shipmentDetail.Add(new ShipmentDetailEntity { ShipUniqueID = aa.id, AssignedTo = "Pica Pollo de Prueba154", ItemDetail = "Ninguno5", DetailUniqueID = 0 });
            shipmentDetail.Add(new ShipmentDetailEntity { ShipUniqueID = aa.id, AssignedTo = "Pica Pollo de Prueba155", ItemDetail = "Ninguno4",DetailUniqueID = 0 });
            shipmentDetail.Add(new ShipmentDetailEntity { ShipUniqueID = aa.id, AssignedTo = "Pica Pollo de Prueba156", ItemDetail = "Ninguno3", DetailUniqueID = 0 });
            shipmentDetail.Add(new ShipmentDetailEntity { ShipUniqueID = aa.id, AssignedTo = "Pica Pollo de Prueba157", ItemDetail = "Ninguno2",DetailUniqueID = 0 });
            shipmentDetail.Add(new ShipmentDetailEntity { ShipUniqueID = aa.id, AssignedTo = "Pica Pollo de Prueba158", ItemDetail = "Ninguno1", DetailUniqueID = 0 });

            if (shipment.Incoming.GetValueOrDefault())
            {
                foreach (var p in shipmentDetail)
                {
                    var  j= p;
                    var result = manager.Set_ShimetDetailsInsert_Logic(p);
                } 
            }
        }
    }
}
