using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSI.Cobranza.EntityLayer
{
    public class Response
    {
        /// <summary>
        /// 
        /// </summary>
        public Response()
        {
            State = false;
            Message = string.Empty;
            MessageType = MessageTypes.danger;
        }

        /// <summary>
        /// 
        /// </summary>
        public Response(bool State, string Message)
        {
            this.State = State;
            this.Message = Message;
            MessageType = MessageTypes.danger;
        }

        /// <summary>
        /// 
        /// </summary>
        public enum MessageTypes
        {
            empty = 0,
            success = 1,
            info = 2,
            warning = 3,
            danger = 4
        }

        /// <summary>
        /// vbarrera | 06 Mar 2019
        /// Define el color de la alerta que se presentara al usuario
        /// </summary>
        public MessageTypes MessageType { get; set; }

        /// <summary>
        /// vbarrera | 17/Abr/2018
        /// Indica que todas las validaciones fueron superadas, ó, que el proceso ha sido finalizado satisfactoriamente
        /// Depende de la propiedad [Executed], ya que si el valor de la propiedad [Executed] es [false] 
        /// entonces la propiedad [State] no debe ser evaluada o su valor no tiene validez
        /// </summary>
        public bool State { get; set; }

        /// <summary>
        /// vbarrera | 17/Abr/2018
        /// Utilice para enviar mensajes al usuario, normalmente mensajes de incumplimiento de validaciones
        /// </summary>
        public string Message { get; set; }
    }
}
