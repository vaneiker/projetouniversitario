using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace STL.POS.Frontend.Web.VirtualOfficeWs
{

    public enum Operacion
    {
        Alta,
        Modificacion,
        Baja
    }
    /// <summary>
    /// Clase de intercambio de datos de usuarios VO
    /// </summary>
    [DataContract]
    [Serializable]
    public class User
    {

        /// <summary>
        /// Id del usuario de Virtual Office
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public Operacion Operacion { get; set; }

        /// <summary>
        /// Nombre de usuario: es el que se utiliza para loguearse en VirtualOffice y se muestra en POS
        /// </summary>
        [DataMember]
        public string Username { get; set; }

        /// <summary>
        /// Nombre del usuario
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Apellido del usuario
        /// </summary>
        [DataMember]
        public string Surname { get; set; }

        /// <summary>
        /// E-Mail del usuario
        /// </summary>
        [DataMember]
        public string Email { get; set; }

        /// <summary>
        /// Opcional: el id del suscriptor al cual pertenece el usuario (en caso de ser agente).
        /// Es nulo si el usuario es agente.
        /// </summary>
        [DataMember]
        public int? SubscriptorId { get; set; }

        public STL.POS.Data.User GetPosUser()
        {
            var posUser = new STL.POS.Data.User();
            posUser.DateCreated = DateTime.Now;
            SetUserData(posUser);

            return posUser;
        }

        public void SetUserData(STL.POS.Data.User destinationUser)
        {
            destinationUser.Email = this.Email;
            destinationUser.Name = this.Name;
            destinationUser.Surname = this.Surname;
            destinationUser.Username = this.Username;
            destinationUser.UserOrigin = Data.UserOrigins.VO;
            destinationUser.UserStatus = Data.UserStatus.Active;
            destinationUser.UserType = this.SubscriptorId.HasValue ? Data.UserType.Agent : Data.UserType.Subscriptor;
            destinationUser.VirtualOfficeId = this.Id;
        }

        public override string ToString()
        {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(User));
            string xml = string.Empty;
            using (StringWriter sww = new StringWriter())
            using (XmlWriter writer = XmlWriter.Create(sww))
            {
                xsSubmit.Serialize(writer, this);
                xml = sww.ToString();
            }

            return xml;
        }


    }
}
