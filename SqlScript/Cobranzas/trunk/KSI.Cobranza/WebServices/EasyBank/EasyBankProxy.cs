using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServices.EasyBank
{
    public class EasyBankProxy
    {
        private WsKSIServices.WsKCOClient EasybankServiceClient { get { return new Lazy<WsKSIServices.WsKCOClient>().Value; } }
        public EasyBankProxy() { }

        public string ApplyPayToEasyBank(string Account,decimal MontoAplicadoEasybank)
        {
           string result = "Pago no aplicado en easy bank.";
           try
           {
               var resultApply = EasybankServiceClient.RecibirPago(Account, MontoAplicadoEasybank, 10);
               if (resultApply.Success && resultApply.NoRecibo > 0)
               {

               }

           }
           catch (Exception ex)
           {    
               throw;
           }             

           return
               result;
        }


        //public void ApplyPaymentToEasybank(int PagoID)
        //{
        //    string res = "Pago no aplicado en easy bank.";
        //    var pagos = _oCardNetModel.GetVW_PagoPendienteAplicarEasybanks(PagoID).ToList();

        //    foreach (var item in pagos)
        //    {
        //        try
        //        {
        //            if (item.MontoPagado.HasValue && item.MontoPagado > 0)
        //            {
        //                WsKCO.WsKCOClient callWsKCO = new WsKCO.WsKCOClient();
        //                decimal MontoAplicadoEasybank = item.MontoPagado.Value;
        //                var recibDetail = callWsKCO.RecibirPago(item.cuecta_formateado, MontoAplicadoEasybank, 10);

        //                CardNet.LogPago lp = new CardNet.LogPago();
        //                lp.PagoID = item.PagoID;
        //                lp.TieneError = !recibDetail.Success;
        //                lp.Mensaje = recibDetail.ErrorMessage;
        //                lp.Source = item.FuentePago;
        //                lp.NombreCliente = item.cuecta_nombre;
        //                lp.NumeroReferencia = item.cuecta_formateado;
        //                lp.FechaCreacion = DateTime.Now;
        //                lp.UsuarioCreoId = UserData != null ? UserData.UserID : 1;
        //                _oCardNetModel.SetLogPago(lp);
        //                //db.GetInstance.SubmitChanges();  

        //                if (recibDetail.Success && recibDetail.NoRecibo > 0)
        //                {
        //                    _oCardNetModel.SetPago(MontoAplicadoEasybank, recibDetail.NoRecibo.ToString(), PagoID);


        //                    if (item.FuentePago == "RECAUDO BHD")
        //                    {
        //                        _oLoanModel.SetRecaudoReferenciado(10, item.IDReferencia);

        //                    }
        //                    if (item.FuentePago == "CARNET DOMICILIACION")
        //                    {
        //                        _oCardNetModel.SetCardNetBatchDetail(10, item.IDReferencia);
        //                    }
        //                    if (item.FuentePago == "PAG.DIRECTO EASYBANK")//PAG.DIRECTO EASYBANK
        //                    {

        //                    }
        //                    res = "Pago aplicado en easy bank";
        //                }

        //                else
        //                {
        //                    res = "Pago no aplicado en easy bank";
        //                }
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            /*guardo en log que error esta dando, los principales son caja cerra o la cuenta no tiene balance pendiente o el monto a pagar es mayor que el pendiente*/

        //            CardNet.LogPago lp = new CardNet.LogPago();
        //            lp.PagoID = item.PagoID;
        //            lp.TieneError = true;
        //            lp.Mensaje = ex.Message + "----" + ex.StackTrace;
        //            lp.Source = item.FuentePago;
        //            lp.NombreCliente = item.cuecta_nombre;
        //            lp.NumeroReferencia = item.cuecta_formateado;
        //            lp.FechaCreacion = DateTime.Now;
        //            lp.UsuarioCreoId = UserData != null ? UserData.UserID : 1;
        //            _oCardNetModel.SetLogPago(lp);
        //        }


        //    }

        //    //return Content(res);
        //}
    }
}
