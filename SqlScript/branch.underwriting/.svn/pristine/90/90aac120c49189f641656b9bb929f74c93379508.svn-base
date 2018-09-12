using RESOURCE.UnderWriting.ConfirmationCall;
using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace WEB.ConfirmationCall.Infrastructure.Providers
{
    public static class ResourcesProvider
    {
        public static string GetString(string key)
        {
            return String.IsNullOrEmpty(key) ? "" : Resources.ResourceManager.GetString(key) ?? key;
        }

        public static string GetResxNameByValue(string value, string language = "en-US")
        {
            try
            {
                System.Resources.ResourceManager rm = Resources.ResourceManager;

                var entry =
                    rm.GetResourceSet(new CultureInfo(language), true, true);

                var key =
                      entry.OfType<DictionaryEntry>()
                      .Where(e => e.Value.ToString() == value);

                return key.Count() > 0 ? key.FirstOrDefault().Key.ToString() : value;
            }
            catch (Exception ex)
            {
            }
            return value;
        }

        public static string GetResxValueByName(string name)
        {
            try
            {
                return Resources.ResourceManager.GetString(name, System.Threading.Thread.CurrentThread.CurrentCulture);
            }
            catch (Exception)
            {

            }
            return null;
        }

        public static string GetResxCurrentValueByValue(string value)
        {
            try
            {
                if (UserDataProvider.Language == "en") return value;
                var name = GetResxNameByValue(value);
                if (!String.IsNullOrEmpty(name))
                    return Resources.ResourceManager.GetString(name, System.Threading.Thread.CurrentThread.CurrentCulture);
            }
            catch (Exception)
            {

            }
            return value;
        }

        public static void ChangeLanguage(string lang = "en-US")
        {
            if (lang == "en") return;
            var culture = new System.Globalization.CultureInfo(GetLanguage(lang));
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }

        public static string GetLanguage(string lang)
        {
            switch (lang)
            {
                case "es":
                    return "es-ES";
                default:
                    return "en-US";
            }
        }
    }
}
