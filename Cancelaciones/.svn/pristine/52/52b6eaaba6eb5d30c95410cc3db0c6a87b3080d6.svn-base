using ATL.SVC.Services.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Text;
using System.Web;

namespace ATL.SVC.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Cancelaciones" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Cancelaciones.svc or Cancelaciones.svc.cs at the Solution Explorer and start debugging.
    public class Cancelaciones : ICancelaciones
    {
        
        ATLServicesEntities db = new ATLServicesEntities();

        public System.Net.HttpStatusCode Atl_2_Kco(string poliza, Guid clientId)
        {
           // HttpContext _context = HttpContext.Current;
                      
            var _access = GetAccess();

            RequestLog _newRequest = new RequestLog()
            {
                clientId = clientId,
                policy = poliza,
                RequestDate = DateTime.Now,
                RequestURL = _access.Link,
                Services = "Atl_2_Kco",
                Usuario = _access.UserName ,
                Ip = _access.IpAddress
            };

            db.RequestLogs.Add(_newRequest);
            db.SaveChanges();

            WebOperationContext.Current.OutgoingResponse.StatusDescription = "Entidad Creada";
            return WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.OK;
                        
        }
                

        private AccessProp GetAccess()
        {
            OperationContext _OpContext = OperationContext.Current;

            MessageProperties _MsgProp = _OpContext.IncomingMessageProperties;

            RemoteEndpointMessageProperty _endPoint= _MsgProp[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;

            AccessProp _accessProp = new AccessProp()
            {
                Link = _MsgProp.Via.ToString(),
                IpAddress = _endPoint.Address.ToString(),
                UserName = _OpContext.ServiceSecurityContext.PrimaryIdentity.Name

            };
            return _accessProp;
        }


         class AccessProp
        {
            public string Link { get; set; }
            public string IpAddress { get; set; }
            public string UserName { get; set; }
        }
    }
}
