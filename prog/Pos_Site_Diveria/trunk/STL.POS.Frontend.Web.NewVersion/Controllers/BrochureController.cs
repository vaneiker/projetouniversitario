using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using STL.POS.Frontend.Web.NewVersion.CustomCode;
using Newtonsoft.Json;
using System.Globalization;
using System.Text;

namespace STL.POS.Frontend.Web.NewVersion.Controllers
{
    public partial class HomeController : BaseController
    {

        public ActionResult GetProductTypeFamily()
        {

            var result = oDropDownManager.GetDropDown(CommonEnums.DropDownType.PRODUCTTYPEFAMILYBROCHURE.ToString());
            return Json(result.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetBrochureByProduct(int productTypeID)
        {
            var result = oBrochureManager.getProductTypeBrochure(productTypeID);
            return Json(result.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCoverageTypesBrochure(int ProductTypeBrochureId)
        {
            var result = oBrochureManager.getCoverageTypesBrochure(ProductTypeBrochureId);

            return Json(result.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCoverageDetailBrochure(int CoverageBrochureId)
        {
            var result = oBrochureManager.getCoverageDetailBrochure(CoverageBrochureId);

            var ctypoe = string.Join(",", result.Select(x => x.CoverageType).Distinct().ToArray());

            return Json(new { result = result.ToList(), coverageTypesBrochure = ctypoe }, JsonRequestBehavior.AllowGet);
        }
    }

}

