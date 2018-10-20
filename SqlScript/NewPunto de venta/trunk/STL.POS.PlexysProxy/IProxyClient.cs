using STL.POS.PlexysProxy.PlexisService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.PlexysProxy
{
   public interface IProxyClient
    {
        Rates GetRates(GetRatesParameters parameter);

        int GetDeducibleIdFromAmount(int amount);

        int GetZoneFromPosCountryId(int countryId);
    }
}
