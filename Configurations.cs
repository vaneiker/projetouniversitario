using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Data.Common;

namespace CLR_WS_TH.DLL
{

    public class Configurations
    {

        public string Url()
        {

            return "http://172.16.199.39:8080/thunderhead/services/JobAPIWebWrapped?wsdl";
        }

        public string User()
        {

            return @"atlantica\THServices";
        }
        public int BatchConfigResID()
        {

            return 1335501440;
        }
        public string BatchName()
        {

            return "SysflexIntegrationPROD";
        }

        public int ProjectID()
        {

            return 0;
        }
        public string Pass()
        {

            return "";
        }




        ////desarrollo
        //public string Url()
        //{

        //    return "http://172.16.193.18:8080/thunderhead/services/JobAPIWebWrapped";
        //}

        //public string User()
        //{

        //    return @"dev\THServices";
        //}
        //public int BatchConfigResID()
        //{

        //    return 1335501440;
        //}
        //public string BatchName()
        //{

        //    return "SysflexIntegration";
        //}
        //public int ProjectID()
        //{
        //   return 1335500027;
        //}
        //public string Pass()
        //{

        //    return "";
        //}





    }
}
