using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.UI.WebControls;
using LOGIC.UnderWriting.Common;
using ServicesApi.UnderWriting.Common;
using ServicesApi.UnderWriting.Common.Model;
using Entity.UnderWriting.Entities;

namespace ServicesApi.UnderWriting.BackgroundCheck
{
    public class BackGroundCheckService : CommonService, IBackGroundCheckService
    {
        //#region Private Properties
        //private bool _usingTest = System.Configuration.ConfigurationManager.AppSettings["UsingTest"] == "true";
        //private int _corpId;
        //private int _contactId;
        //#endregion



        /// <summary>
        /// Método para cerrar una linea en Underwriting global.
        /// </summary>
        ///<param name="corp_Id">corp_Id</param>
        ///<param name="region_Id">region_Id</param>
        ///<param name="country_Id">country_Id</param>
        ///<param name="domesticreg_Id">domesticreg_Id</param>
        ///<param name="state_Prov_Id">state_Prov_Id</param>
        ///<param name="city_Id">city_Id</param>
        ///<param name="office_Id">office_Id</param>
        ///<param name="case_Seq_No">case_Seq_No</param>
        ///<param name="hist_Seq_No">hist_Seq_No</param>
        ///<param name="contact_Id">contact_Id</param>
        ///<param name="background_Check_Id">background_Check_Id</param>
        ///<param name="reason">reason</param>
        ///<param name="results">results</param>
        ///<param name="date">date</param>
        ///<param name="comments">comments</param>
        ///<param name="userId">userId</param>
        /// <returns>string</returns>
        #region Services
        public string CloseUnderwritingLineOnlyGlobal(int corp_Id, int region_Id, int country_Id, int domesticreg_Id,
       int state_Prov_Id, int city_Id, int office_Id, int case_Seq_No, int hist_Seq_No, int contact_Id, int background_Check_Id,
       string reason, bool results, DateTime date, string comments, int userId, List<Step.ExtraInfo> urlList, List<BgcDocuments> documentList)
        {
            try
            {
                var backgrounchecker = new Policy.BackgroundCheck
                {
                    CorpId = corp_Id,
                    RegionId = region_Id,
                    CountryId = country_Id,
                    DomesticRegId = domesticreg_Id,
                    StateProvId = state_Prov_Id,
                    CityId = city_Id,
                    OfficeId = office_Id,
                    CaseSeqNo = case_Seq_No,
                    HistSeqNo = hist_Seq_No,
                    ContactId = contact_Id,
                    BackgroundCheckId = background_Check_Id,
                    Reason = reason,
                    Results = results,
                    Date = date,
                    Comments = comments,
                    UserId = userId
                };

                //Insert BGC Documents
                //BGC Docyument = DocTypeId = 1, DocCategoryId = 46
                const int docTypeId = 1;
                const int docCategoryId = 46;

                foreach (var document in documentList)
                    document.DocumentId = (_uManager.PolicyManager.SetDocument(docTypeId, docCategoryId, -1, document.DocumentBinary, document.DocumentName, document.CreationDate, null, userId));

                var stepDocsList = new List<Step.ExtraInfo>();
                foreach (var document in documentList)
                {
                    stepDocsList.Add(new Step.ExtraInfo()
                    {
                        StepExtraInfoTypeId = (int)BGCExtraInfoType.Documento,
                        CorpId = corp_Id,
                        RegionId = region_Id,
                        CountryId = country_Id,
                        DomesticRegId = domesticreg_Id,
                        StateProvId = state_Prov_Id,
                        CityId = city_Id,
                        OfficeId = office_Id,
                        CaseSeqNo = case_Seq_No,
                        HistSeqNo = hist_Seq_No,
                        DocumentId = document.DocumentId,
                        DocTypeId = docTypeId,
                        DocCategoryId = docCategoryId,
                        DocumentName = document.DocumentName,
                        DocumentDesc = document.DocumentName,
                        FileCreationDate = document.CreationDate,
                        UserId = userId,
                    });
                }

                //Add BGC URls (Links)
                foreach (var extraInfo in urlList)
                {
                    extraInfo.StepExtraInfoTypeId = (int)BGCExtraInfoType.URL;
                    extraInfo.CorpId = corp_Id;
                    extraInfo.RegionId = region_Id;
                    extraInfo.CountryId = country_Id;
                    extraInfo.DomesticRegId = domesticreg_Id;
                    extraInfo.StateProvId = state_Prov_Id;
                    extraInfo.CityId = city_Id;
                    extraInfo.OfficeId = office_Id;
                    extraInfo.CaseSeqNo = case_Seq_No;
                    extraInfo.HistSeqNo = hist_Seq_No;
                    extraInfo.UserId = userId;
                }

                //Uno las dos listas (Documentos y URL)
                stepDocsList.AddRange(urlList);

                //Agrego las listas al objeto BGC
                backgrounchecker.ExtraInfoList = stepDocsList;

                //Close BGC Step and Add Comments
                _uManager.PolicyManager.SetBackgroundCheckAndCloseStep(backgrounchecker);

                return "Línea cerrada.";
            }
            catch (Exception ex)
            {
                return "Línea NO cerrada.";
            }
        }



        #endregion
    }
}
