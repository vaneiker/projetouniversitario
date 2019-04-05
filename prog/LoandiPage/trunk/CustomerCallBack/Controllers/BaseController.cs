using CustomerCallBack.CustomCode;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.Mvc;

using Entity.Entities;
using STL.CALLBACK.Logic;


namespace CustomerCallBack.Controllers
{
    public class BaseController : Controller //: STFMainController
    {
        public CultureInfo culturelanguaje = CultureInfo.CreateSpecificCulture("es-DO");
        
        public BaseController()
        {
        }
              
       
        #region Managers
        protected DropDownManager oDropDownManager
        {
            get
            {
                return new DropDownManager();
            }
        }

        protected CallBackManager oCallBackManager
        {
            get
            {
                return new CallBackManager();
            }
        }
        
        #endregion
    }
}