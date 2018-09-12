using System;
using Web.SubmittedPolicies.Common.Classes;

namespace Web.SubmittedPolicies.Common.Interfaces
{       
    public interface IUc
    {
        /// <summary>
        /// Traducir los User Controls
        /// </summary>
        /// <param name="lang"></param>
        void Translator(Enums.Languages lang);
        
        /// <summary>
        /// Persitir la Data
        /// </summary>
        void Save();

        /// <summary>
        /// Limipar la data del UserControl
        /// </summary>
        void ClearData();
        
        /// <summary>
        /// Bindear los Controles
        /// </summary>
        void FillData();
    }
}
