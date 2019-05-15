using STL.POS.PlexysProxy.PlexisService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.PlexysProxy
{
    public class ProxyClient : IProxyClient
    {

        IPlexisServices client;

        public ProxyClient(IPlexisServices plexisClient)
        {
            client = plexisClient;
        }

        public int GetZoneFromPosCountryId(int countryId)
        {
            var value = client.GetZoneFromPosCountryId(countryId);
            return value;
        }

        public int GetDeducibleIdFromAmount(int amount)
        {
            return client.GetDeducibleIdFromAmount(amount);
        }

        public Rates GetRates(GetRatesParameters parameter)
        {
            return client.GetRates(parameter);
        }
    }
}
