﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STL.POS.Data.NewVersion.Repository;
using Entity.Entities;

namespace STL.POS.Logic
{
    public class DocumentRequiredManager : BaseManager
    {
        private readonly DocumentRequiredRepository documentRequiredRepository;

        public DocumentRequiredManager()
        {
            documentRequiredRepository = new DocumentRequiredRepository();
        }

        public IEnumerable<Requeriments> GeQuotationRequeriments(Requeriments.GetRequerimentsParameters parameters)
        {
            return documentRequiredRepository.GeQuotationRequeriments(parameters);
        }

        public IEnumerable<Requeriments.Documents> GeQuotationRequerimentsByDocument(Requeriments.GetRequerimentsParameters parameters)
        {
            return documentRequiredRepository.GeQuotationRequerimentsByDocument(parameters);
        }


        public int SetQuotationRequeriment(Requeriments.SetRequerimentsParameters parameter)
        {
            return
                 documentRequiredRepository.SetQuotationRequeriment(parameter);
        }

        public int DeleteQuotationRequeriment(Requeriments.SetRequerimentsParameters parameter)
        {
            return
                 documentRequiredRepository.DeleteQuotationRequeriment(parameter);
        }

        public int ValidateQuotationRequeriment(Requeriments.SetRequerimentsParameters parameter)
        {
            return
                 documentRequiredRepository.ValidateQuotationRequeriment(parameter);
        }

        public int SendDocumentRequiredToGlobal(Requeriments.SetRequerimentsParameters parameter)
        {
            return
                 documentRequiredRepository.SendDocumentRequiredToGlobal(parameter);
        }

    }
}