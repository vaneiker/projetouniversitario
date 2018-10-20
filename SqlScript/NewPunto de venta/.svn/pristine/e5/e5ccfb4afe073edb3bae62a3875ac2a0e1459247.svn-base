using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;

namespace STL.POS.Frontend.Web.NewVersion.CustomCode
{
    public static class Helperes
    {
        #region Constans
        public const string PRODUCT_NUMBER_AUTO = "01";
        public const string PRODUCT_NUMBER_SALUD = "02";

        public const int BUSINESSLINE_ID_AUTO = 1;
        public const int BUSINESSLINE_ID_SALUD = 2;

        public const int ID_COUNTRY_REPUBLICA_DOMINCANA = 129;

        public const string ID_LANGUAGE_SPANISH = "es-DO";
        public const string ID_LANGUAGE_ENGLISH = "en-US";
        #endregion
        public static MvcHtmlString RawActionLink(this AjaxHelper ajaxHelper, string linkText, string actionName, string controllerName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            var repID = Guid.NewGuid().ToString();
            var lnk = ajaxHelper.ActionLink(repID, actionName, controllerName, routeValues, ajaxOptions, htmlAttributes);
            return MvcHtmlString.Create(lnk.ToString().Replace(repID, linkText));
        }

        public static MvcHtmlString MyDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> html,
                                                                         Expression<Func<TModel, TProperty>> expression,
                                                                         IEnumerable<SelectListItem> selectList,
                                                                         string optionText,
                                                                         object htmlAttributes,
                                                                         bool canEdit
     
            )
        {

            MvcHtmlString result = null;

            if (canEdit)
                result = html.DropDownListFor(expression, selectList, optionText, htmlAttributes);
            else
            {
                PropertyInfo[] Props = htmlAttributes.GetType().GetProperties();

                Dictionary<string, object> NewHtmlAttributes = new Dictionary<string, object>();
                foreach (var item in Props)
                {
                    var propertyName = item.Name;
                    var dataValue = item.GetValue(htmlAttributes);
                    var propertyValue = dataValue;
                    NewHtmlAttributes.Add(propertyName, propertyValue);
                }

                NewHtmlAttributes.Add("disabled", "disabled");

               result = html.DropDownListFor(expression, selectList, optionText, NewHtmlAttributes);
            }

            return
                result;

        }

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string MyRemoveInvalidCharacters(this string value)
        {
            return value.Replace("\\", "").Replace("/", "").Replace("?", "").Replace("*", "").Replace(":", "").Replace("\"", "").Replace("<", "").Replace(">", "").Replace("í", "i")
                         .Replace("á", "a").Replace("é", "e").Replace("ó", "o").Replace("ú", "u");
        }
    }
}