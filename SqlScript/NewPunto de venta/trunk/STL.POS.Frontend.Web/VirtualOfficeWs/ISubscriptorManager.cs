using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace STL.POS.Frontend.Web.VirtualOfficeWs
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISubscriptorManager" in both code and config file together.
    [ServiceContract]
    public interface ISubscriptorManager
    {
        /// <summary>
        /// Método interactivo utilizado por VirtualOffice para actualizar (ABM) un usuario (agente o suscriptor).
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [OperationContract]
        Result CreateOrUpdateUser(User user);

        /// <summary>
        /// Operación "de contingencia", para hacer un chequeo batch de un conjunto de usuarios. Se utiliza para 
        /// asegurar la sincronización entre los sets de usuarios de VO y POS.
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        [OperationContract]
        List<Result> ContingencyOperation(List<User> users);
    }
}
