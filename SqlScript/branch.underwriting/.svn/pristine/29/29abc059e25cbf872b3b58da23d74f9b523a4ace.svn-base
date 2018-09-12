using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Entity.UnderWriting.Entities;
using ServicesApi.UnderWriting.Common;
using ServicesApi.UnderWriting.Common.Model;

namespace ServicesApi.UnderWriting.BackgroundCheck
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IBackGroundCheckService
    {
        [OperationContract]
        string CloseUnderwritingLineOnlyGlobal(int corp_Id, int region_Id, int country_Id, int domesticreg_Id,
       int state_Prov_Id, int city_Id, int office_Id, int case_Seq_No, int hist_Seq_No, int contact_Id, int background_Check_Id,
       string reason, bool results, DateTime date, string comments, int userId, List<Step.ExtraInfo> urlList, List<CommonService.BgcDocuments> documentList);

    }
}
