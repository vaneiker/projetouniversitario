﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSI.Cobranza.Web.Common
{
    public class Enums
    {
        public enum SexDesc { Masculino, Femenino };
        public enum CommunicationType { Phone, Email };
        public enum SearchType { None, Client, Promoter, Executive }
        public enum DropDownType { countries, phonetype, emailtype, transactionreason, cardtype, LoanTransType, EmisorBank, ReceptorBank }
        /// <summary>
        ///   1	Pendiente Procesar
        ///   2	Pendiente Easybank Cardnet
        ///   3	Pendiente Easybank
        ///   4	Rechazada
        ///   5	Error
        ///   6	Declinada
        ///   7	Completada 
        /// </summary>
        public enum DirectPaymentStatus { PendienteProcesar = 1, PendienteEasybankCardnet, PendienteEasybank, Rechazada, Error, Declinada, Completada }
    }       
}