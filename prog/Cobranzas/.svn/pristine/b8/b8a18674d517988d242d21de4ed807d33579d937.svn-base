using KSI.Cobranza.EntityLayer;
using KSI.Cobranza.LogicLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSI.Cobranza.LogicLayer.Implementation.DocumentsXmlProvider
{
    public abstract class XmlProvider: IDocumentsXmlProvider
    {
        #region Fields

        /// <summary>
        /// vbarrera | 8 Feb 2019
        /// proveedor de datos que le permite a esta clase 
        /// obtener los valores necesarios para contruir 
        /// el respectivo documento XML
        /// </summary>
        protected LoanManager _DataManager;

        /// <summary>
        /// vbarrera | 26 Mar 2019
        /// Algunas propiedades de datos que son requeridas por los documetos generados desde thunderhead
        /// se almacenan en este listado
        /// </summary>
        protected List<DataField> _dataFields;

        #endregion

        #region Properties
        /// <summary>
        /// vbarrera | 08 Feb 2019
        /// Identificador de la plantilla de ThunderHead
        /// </summary>
        public string DocumentId { get; set; }

        /// <summary>
        /// vbarrera | 14 Feb 2019
        /// LLave primaria del prestamo.
        /// [Propiedad de negocio]
        /// </summary>
        public long QueueId { get; set; }
        #endregion

        #region Function
        /// <summary>
        /// vbarrera | 8 Feb 2019
        /// La finalidad de este metodo es establecer un proveedor de datos
        /// que le permite a esta clase obtener los valores necesarios para 
        /// contruir el respectivo documento XML
        /// </summary>
        /// <param name="DataManager"></param>
        public void SetDataManager(IBaseLogic<Loan> DataManager)
        {
            _DataManager = (DataManager as LoanManager);
        }

        /// <summary>
        /// vbarrera | 8 Feb 2019
        /// La finalidad de este metodo es establecer un proveedor de datos
        /// que le permite a esta clase obtener los valores necesarios para 
        /// contruir el respectivo documento XML
        /// </summary>
        /// <param name="DataManager"></param>
        public void SetDataManager(List<DataFieldGroup> dataFieldsGroups)
        {
            if (dataFieldsGroups == null || dataFieldsGroups.Count() == 0)
                return;

            _dataFields = dataFieldsGroups.Select(x => x.DataFields)
                .Aggregate((Accumulated, Next) => {
                    Accumulated.AddRange(Next);
                    return Accumulated;
                });
        }

        /// <summary>
        /// vbarrera |08 Feb 2019
        /// Invoque este metodo para obtener el binario del documetno xml respectivo
        /// </summary>
        /// <returns></returns>
        public abstract byte[] GetXml();
        #endregion
    }
}
