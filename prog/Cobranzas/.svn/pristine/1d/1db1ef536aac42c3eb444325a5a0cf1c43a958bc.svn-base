using KSI.Cobranza.Web.Models;
using KSI.Cobranza.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KSI.Cobranza.Web.Controllers
{
    public class HomeController : BaseController
    {
        private SearchModel _oSearchModel { get; set; }

        public HomeController()
        {
            _oSearchModel = new Lazy<SearchModel>().Value;
            HideVaribleURL = false;
            bool.TryParse(System.Configuration.ConfigurationManager.AppSettings["HideVaribleURL"], out HideVaribleURL);
            ViewBag.HideVaribleURL = HideVaribleURL.ToString().ToLower();
        }

        public ActionResult Index()
        {
            var model = new SearchViewModels { searchResult = new List<SearchResult>(0) };
            return View(model);
        }

        public PartialViewResult _SearchResult(string clienteName, string identificationNumber, Nullable<long> quotationId, Nullable<long> accountId, string collateralReference, string chassisNumber)
        {
            var model = _oSearchModel.GetLoanInformation(clienteName, identificationNumber, quotationId, accountId, collateralReference, chassisNumber);
            var SearchRes = model
                .searchResult
                .Select(x =>
                {
                    x._dataRequest = HideVaribleURL ? System.Web.HttpUtility.UrlEncode(x._dataRequest) : x._dataRequest;
                    return x;
                });

            model.searchResult = SearchRes;

            return PartialView(model);
        }

    }
}