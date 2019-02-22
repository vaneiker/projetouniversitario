using Google.Apis.Services;
using Google.Apis.Urlshortener.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MantModelosyMarcas.Utility
{
    public class ApiGoogle
    {
        public static string shortenIt(string url)
        {

       
            var service = new UrlshortenerService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyC-sNERlNNJZfTUpD0MbXPiH236B7XW1mo",
                ApplicationName = "Daimto URL shortener Sample",
            });

            var m = new Google.Apis.Urlshortener.v1.Data.Url();
            m.LongUrl = url;
            return service.Url.Insert(m).Execute().Id;
        }

        public static string unShortenIt(string url)
        {
            var service = new UrlshortenerService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyC-sNERlNNJZfTUpD0MbXPiH236B7XW1mo",
                ApplicationName = "Daimto URL shortener Sample",
            });

            return service.Url.Get(url).Execute().LongUrl;
        }
    }
}