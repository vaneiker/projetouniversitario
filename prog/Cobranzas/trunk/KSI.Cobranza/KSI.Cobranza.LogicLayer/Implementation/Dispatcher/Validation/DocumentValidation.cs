using KSI.Cobranza.LogicLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSI.Cobranza.EntityLayer;

namespace KSI.Cobranza.LogicLayer.Implementation.Dispatcher
{
    public class DocumentValidation : ValidationBusinessModel
    {
        /// <summary>
        /// vbarrera | 8 Feb 2019
        /// Le concede a este controlador acceso a la data
        /// </summary>
        DocumentManager _dataManager = new DocumentManager();

        /// <summary>
        /// vbarrera | 12 Mar 2019
        /// Id del movimiento de generacion y carga de documentos
        /// </summary>
        private const int DOCUMENT_LOAD_MOVEMENT_ID = 1;

        /// <summary>
        /// vbarrera | 12 Mar 2019
        /// Id del movimiento de validación de documentos
        /// </summary>
        private const int DOCUMENT_VALIDATION_MOVEMENT_ID = 3;

        /// <summary>
        /// vbarrera | 12 Mar 2019
        /// Esta validación no tiene tareas que ejecutar
        /// cuando el caso/queue entra en el nuevo status
        /// </summary>
        public override void ExcuteInitialTask()
        { }

        /// <summary>
        /// vbarrera | 12 Mar 2019
        /// Contiene las validaciones sobre los documentos que se cargan
        /// * - Se valida que todos los documentos se hayan cargado
        /// * - Ademas se valida que todos los documentos cargados se hayan validado
        /// </summary>
        public override void PostValidate()
        {
            ResultLogic<Document> documentResult 
                = _dataManager.Get(QueueId);

            if (documentResult.result.HasError)
                throw new Exception(documentResult.result.ErrorDescription);

            List<Document> documents
                = documentResult.dataResult.ToList();

            Response.State 
                = !documents.Any(x => string.IsNullOrWhiteSpace(x.DocumentName) && x.IsUploadedBySystem);

            if (!Response.State)
            {
                Response.Message 
                    = string.Format("Aun hay documentos pendientes de cargar. <a href='#' onclick='Dispatcher.LoadMovement({0}, {1});'><b>Click aqui</b></a> para cargarlos.",
                    QueueId, DOCUMENT_LOAD_MOVEMENT_ID);
            }
            else
            {
                Response.State = !documents.Any(x => !x.Validated && x.IsUploadedBySystem);

                if (!Response.State)
                {
                    Response.Message 
                        = string.Format("Aun hay documentos pendientes de validar. <a href='#' onclick='Dispatcher.LoadMovement({0}, {1});'><b>Click aqui</b></a> para validarlos.",
                        QueueId, DOCUMENT_VALIDATION_MOVEMENT_ID);
                }
            }
        }

        /// <summary>
        /// vbarrera | 12 Mar 2019
        /// Esta regla no posee ninguna validación al momento que el caso/queue entra al nuevo estatus
        /// </summary>
        public override void PreValidate()
        {
            Response.State = true;
        }
    }
}
