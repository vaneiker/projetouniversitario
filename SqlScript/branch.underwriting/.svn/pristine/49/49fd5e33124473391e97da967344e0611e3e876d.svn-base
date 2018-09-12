using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.NewBusiness.Common
{
    public interface IUC
    {
        /// <summary>
        /// Traducir los User Controls
        /// </summary>
        /// <param name="Lang"></param>
        void Translator(String Lang);

        void ReadOnlyControls(bool isReadOnly);

        /// <summary>
        /// Persitir la Data
        /// </summary>
        void save();
      
        /// <summary>
        /// Modo Edicion
        /// </summary>
        void edit();

        /// <summary>
        /// Bindear los Controles
        /// </summary>
        void FillData();

        /// <summary>
        /// Inicializar el control:
        /// En este metodo se pueden agregar FillData,FillDrop,ClearControls o cualquier otro metodo para inicializar el componente
        /// </summary>
        void Initialize();

        void ViewStateModeControl(bool Mode);

        void ClearData();
    }
}