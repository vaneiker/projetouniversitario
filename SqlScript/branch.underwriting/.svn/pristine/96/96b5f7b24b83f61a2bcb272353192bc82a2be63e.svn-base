using DATA.UnderWriting.Data;
using DATA.UnderWriting.Repositories.Base;
using Entity.UnderWriting.Entities;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace DATA.UnderWriting.Repositories.Global
{
    public class AlliedLinesReviewRepository : GlobalRepository
    {
        public AlliedLinesReviewRepository(GlobalEntityDataModel globalModel, GlobalEntities globalModelExtended) : base(globalModel, globalModelExtended) { }

        public virtual IEnumerable<AlliedLines.Review.Result.Get> GetAlliedLineReview(AlliedLines.Review.Parameters.Get alliedLine)
        {
            IEnumerable<AlliedLines.Review.Result.Get> result;
            IEnumerable<SP_GET_PL_PCY_ALLIEDLINES_REVIEW_Result> temp;

            temp = globalModel.SP_GET_PL_PCY_ALLIEDLINES_REVIEW(
                    alliedLine.CorpId,
                    alliedLine.RegionId,
                    alliedLine.CountryId,
                    alliedLine.DomesticregId,
                    alliedLine.StateProvId,
                    alliedLine.CityId,
                    alliedLine.OfficeId,
                    alliedLine.CaseSeqNo,
                    alliedLine.HistSeqNo,
                    alliedLine.AlliedLineId,
                    alliedLine.UniqueAlliedLineId,
                    alliedLine.AlliedLineTypeId,
                    alliedLine.ReviewId,
                    alliedLine.BlTypeId,
                    alliedLine.BlId,
                    alliedLine.ProductId
            );

            result = temp.Select(dk => new AlliedLines.Review.Result.Get
            {
                CorpId = dk.Corp_Id,
                RegionId = dk.Region_Id,
                CountryId = dk.Country_Id,
                DomesticregId = dk.Domesticreg_Id,
                StateProvId = dk.State_Prov_Id,
                CityId = dk.City_Id,
                OfficeId = dk.Office_Id,
                CaseSeqNo = dk.Case_Seq_No,
                HistSeqNo = dk.Hist_Seq_No,
                UniqueAlliedLineId = dk.Unique_AlliedLine_Id,
                AlliedLineTypeId = dk.AlliedLine_Type_Id,
                ReviewId = dk.Review_Id,
                AirplaneId = dk.Airplane_Id,
                BlTypeId = dk.Bl_Type_Id,
                BlId = dk.Bl_Id,
                ProductId = dk.Product_Id,
                Name = dk.Name,
                Brand = dk.Brand,
                Model = dk.Model,
                Type = dk.Type,
                SerialKey = dk.Serial_Key,
                Year = dk.Year,
                Usage = dk.Usage,
                AirplaneBase = dk.Airplane_Base,
                SeatingQty = dk.Seating_Qty,
                CrewQty = dk.Crew_Qty,
                Boundaries = dk.Boundaries,
                OverhullDate = dk.Overhull_Date,
                InsuredDate = dk.Insured_Date,
                InsuredAmount = dk.Insured_Amount,
                Rate = dk.Rate,
                PremiumAmount = dk.Premium_Amount,
                BasePremiumAmount = dk.Base_Premium_Amount,
                DeductiblePercentage = dk.Deductible_Percentage,
                DeductibleAmount = dk.Deductible_Amount,
                MinimumDeductibleAmount = dk.Minimum_Deductible_Amount,
                New = dk.New,
                RequiresInspection = dk.Requires_Inspection,
                Reinsurance = dk.Reinsurance,
                Inspected = dk.Inspected,
                EndorsementClarifying = dk.Endorsement_Clarifying,
                Endorsement = dk.Endorsement,
                EndorsementBeneficiary = dk.Endorsement_Beneficiary,
                EndorsementBeneficiaryRnc = dk.Endorsement_Beneficiary_Rnc,
                EndorsementAmount = dk.Endorsement_Amount,
                EndorsementContactName = dk.Endorsement_Contact_Name,
                EndorsementContactPhone = dk.Endorsement_Contact_Phone,
                EndorsementContactEmail = dk.Endorsement_Contact_Email,
                InspectionAddress = dk.Inspection_Address,
                AirplaneStatusId = dk.Airplane_Status_Id,
                BailId = dk.Bail_Id,
                EquipmentQty = dk.Equipment_Qty,
                BailStatusId = dk.Bail_Status_Id,
                NavyId = dk.Navy_Id,
                Length = dk.Length,
                Manga = dk.Manga,
                Strut = dk.Strut,
                ConstructionMaterial = dk.Construction_Material,
                EngineQty = dk.Engine_Qty,
                Power = dk.Power,
                FuelCapacity = dk.Fuel_Capacity,
                NavigationLimit = dk.Navigation_Limit,
                BasePort = dk.Base_Port,
                PassengersQty = dk.Passengers_Qty,
                CrewTraining = dk.Crew_Training,
                NavyStatusId = dk.Navy_Status_Id,
                PropertyId = dk.Property_Id,
                PropertyInspectedValue = dk.Property_Inspected_Value,
                Inspection = dk.Inspection,
                PolicyPropertyStatusId = dk.Policy_Property_Status_Id,
                TransportId = dk.Transport_Id,
                TransportInsuredId = dk.Transport_Insured_Id,
                MerchandasingType = dk.Merchandasing_Type,
                PortShipment = dk.Port_Shipment,
                PortLanding = dk.Port_Landing,
                OutDate = dk.Out_Date,
                InDate = dk.In_Date,
                PackingForm = dk.Packing_Form,
                PackingUnderCover = dk.Packing_Under_Cover,
                Value = dk.Value,
                TransportStatusId = dk.Transport_Status_Id,
                InspectionDate = dk.Inspection_Date,
                RiskName = dk.Risk_Name,
                InspectedLocation = dk.Inspected_Location,
                RiskType = dk.Risk_Type,
                InspectorId = dk.Inspector_Id,
                DocTypeId = dk.Doc_Type_Id,
                DocCategoryId = dk.Doc_Category_Id
            })
                         .ToArray();

            return
                result;
        }

        public virtual IEnumerable<AlliedLines.Review.Detail.Result.Get> GetAlliedLineReviewDetail(AlliedLines.Review.Detail.Parameters.Get review)
        {
            IEnumerable<AlliedLines.Review.Detail.Result.Get> result;
            IEnumerable<SP_GET_PL_PCY_ALLIEDLINES_REVIEW_DETAILS_Result> temp;

            temp = globalModel.SP_GET_PL_PCY_ALLIEDLINES_REVIEW_DETAILS(
                        review.CorpId,
                        review.RegionId,
                        review.CountryId,
                        review.DomesticregId,
                        review.StateProvId,
                        review.CityId,
                        review.OfficeId,
                        review.CaseSeqNo,
                        review.HistSeqNo,
                        review.AlliedLineId,
                        review.UniqueAlliedLineId,
                        review.AlliedLineTypeId,
                        review.ReviewId,
                        review.ReviewGroupId,
                        review.ReviewGroupEndorsementClarifying,
                        review.ReviewOptionEndorsementClarifying
                   );

            result = temp.Select(dk => new AlliedLines.Review.Detail.Result.Get
            {
                CorpId = dk.Corp_Id,
                RegionId = dk.Region_Id,
                CountryId = dk.Country_Id,
                DomesticregId = dk.Domesticreg_Id,
                StateProvId = dk.State_Prov_Id,
                CityId = dk.City_Id,
                OfficeId = dk.Office_Id,
                CaseSeqNo = dk.Case_Seq_No,
                HistSeqNo = dk.Hist_Seq_No,
                AlliedLineId = dk.AlliedLine_Id,
                UniqueAlliedLineId = dk.Unique_AlliedLine_Id,
                AlliedLineTypeId = dk.AlliedLine_Type_Id,
                AlliedLineTypeDesc = dk.AlliedLine_Type_Desc,
                ReviewDetailId = dk.Review_Detail_Id,
                ReviewGroupId = dk.Review_Group_Id,
                ReviewGroupDesc = dk.Review_Group_Desc,
                ReviewClassId = dk.Review_Class_Id,
                ReviewClassDesc = dk.Review_Class_Desc,
                ReviewItemId = dk.Review_Item_Id,
                ReviewItemDesc = dk.Review_Item_Desc,
                ReviewOptionId = dk.Review_Option_Id,
                ReviewOptionDesc = dk.Review_Option_Desc,
                ReviewOptionEndorsementClarifying = dk.Review_Option_Endorsement_Clarifying,
                ReviewGroupEndorsementClarifying = dk.Review_Group_Endorsement_Clarifying,
                ValueChecked = dk.Value_Checked,
                ValueText = dk.Value_Text,
                ReviewStatus = dk.Review_Status,
                Required = dk.Required,
                UsuarioInspeccion = dk.UsuarioInspeccion 
            });

            return
                result;
        }

        public virtual IEnumerable<AlliedLines.Review.Pic.Result.Get> GetAlliedLineReviewPic(AlliedLines.Review.Pic.Parameters.Get review)
        {
            IEnumerable<AlliedLines.Review.Pic.Result.Get> result;
            IEnumerable<SP_GET_PL_PCY_ALLIEDLINES_REVIEW_PICS_Result> temp;

            temp = globalModel.SP_GET_PL_PCY_ALLIEDLINES_REVIEW_PICS(
                        review.CorpId,
                        review.RegionId,
                        review.CountryId,
                        review.DomesticregId,
                        review.StateProvId,
                        review.CityId,
                        review.OfficeId,
                        review.CaseSeqNo,
                        review.HistSeqNo,
                        review.AlliedLineId,
                        review.UniqueAlliedLineId,
                        review.AlliedLineTypeId,
                        review.ReviewId,
                        review.DocTypeId,
                        review.DocCategoryId,
                        review.DocumentId
                );

            result = temp.Select(dk => new AlliedLines.Review.Pic.Result.Get
            {
                CorpId = dk.Corp_Id,
                RegionId = dk.Region_Id,
                CountryId = dk.Country_Id,
                DomesticregId = dk.Domesticreg_Id,
                StateProvId = dk.State_Prov_Id,
                CityId = dk.City_Id,
                OfficeId = dk.Office_Id,
                CaseSeqNo = dk.Case_Seq_No,
                HistSeqNo = dk.Hist_Seq_No,
                DocTypeId = dk.Doc_Type_Id,
                DocCategoryId = dk.Doc_Category_Id,
                DocumentId = dk.Document_Id,
                AlliedLineId = dk.AlliedLine_Id,
                UniqueAlliedLineId = dk.Unique_AlliedLine_Id,
                AlliedLineTypeId = dk.AlliedLine_Type_Id,
                ReviewId = dk.Review_Id,
                PictureId = dk.Picture_Id,
                DocumentBinary = dk.Document_Binary,
                DocumentDesc = dk.Document_Desc,
                DocumentName = dk.Document_Name
            })
                        .ToArray();

            return
                result;
        }

        public virtual AlliedLines.Agent.AssignedOffice.Result.Get GetAgentAssignedOffice(AlliedLines.Agent.AssignedOffice.Parameters.Get agent)
        {
            AlliedLines.Agent.AssignedOffice.Result.Get result;
            IEnumerable<SP_GET_EN_AGENT_ASSIGNED_OFFICE_Result> temp;

            temp = globalModel.SP_GET_EN_AGENT_ASSIGNED_OFFICE(
                            agent.CorpId,
                            agent.AgentId
                   );

            result = temp.Select(dk => new AlliedLines.Agent.AssignedOffice.Result.Get
            {
                AgentId = dk.Agent_Id,
                OfficeDesc = dk.Office_Desc,
                OfficeId = dk.Office_Id
            })
                        .FirstOrDefault();
            return
                result;
        }

        public virtual IEnumerable<AlliedLines.Document.Policy.Result.Get> GetPolicyDocument(AlliedLines.Document.Policy.Parameters.Get policy)
        {
            IEnumerable<AlliedLines.Document.Policy.Result.Get> result;
            IEnumerable<SP_GET_PL_PCY_DOCUMENTS_Result> temp;

            temp = globalModel.SP_GET_PL_PCY_DOCUMENTS(
                            policy.CorpId,
                            policy.RegionId,
                            policy.CountryId,
                            policy.DomesticregId,
                            policy.StateProvId,
                            policy.CityId,
                            policy.OfficeId,
                            policy.CaseSeqNo,
                            policy.HistSeqNo
                   );

            result = temp.Select(dk => new AlliedLines.Document.Policy.Result.Get
            {
                CorpId = dk.Corp_Id,
                RegionId = dk.Region_Id,
                CountryId = dk.Country_Id,
                DomesticregId = dk.Domesticreg_Id,
                StateProvId = dk.State_Prov_Id,
                CityId = dk.City_Id,
                OfficeId = dk.Office_Id,
                CaseSeqNo = dk.Case_Seq_No,
                HistSeqNo = dk.Hist_Seq_No,
                DocTypeId = dk.Doc_Type_Id,
                DocCategoryId = dk.Doc_Category_Id,
                DocumentId = dk.Document_Id,
                DocumentDesc = dk.Document_Desc,
                DocumentStatusId = dk.Document_Status_Id,
                DocumentName = dk.Document_Name,
                DocumentBinary = dk.Document_Binary
            });

            return
                result;
        }

        public virtual IEnumerable<AlliedLines.Review.Item.Option.Result.Get> GetAlliedLineReviewItemOption(AlliedLines.Review.Item.Option.Parameters.Get review)
        {
            IEnumerable<AlliedLines.Review.Item.Option.Result.Get> result;
            IEnumerable<SP_GET_ST_REVIEW_ITEM_OPTIONS_Result> temp;

            temp = globalModel.SP_GET_ST_REVIEW_ITEM_OPTIONS(
                        review.CorpId,
                        review.LanguageId,
                        review.ReviewGroupId
                   );

            result = temp.Select(dk => new AlliedLines.Review.Item.Option.Result.Get
            {
                GroupId = dk.GroupId,
                GroupDesc = dk.GroupDesc,
                ClassId = dk.ClassId,
                ClassDesc = dk.ClassDesc,
                ItemId = dk.ItemId,
                ItemDesc = dk.ItemDesc,
                OptionId = dk.OptionId,
                OptionDesc = dk.OptionDesc
            })
                        .ToArray();

            return
                result;
        }

        public virtual AlliedLines.Document.Category.Result.Get GetDocumentCategory(AlliedLines.Document.Category.Parameters.Get category)
        {
            AlliedLines.Document.Category.Result.Get result;
            IEnumerable<SP_GET_DOCUMENT_CATEGORY_Result> temp;

            temp = globalModel.SP_GET_DOCUMENT_CATEGORY(
                        category.NameKey
                   );

            result = temp.Select(dk => new AlliedLines.Document.Category.Result.Get
            {
                DocTypeId = dk.Doc_Type_Id,
                DocCategoryId = dk.Doc_Category_Id,
                NameKey = dk.NameKey,
                DocCategoryDesc = dk.Doc_Category_Desc,
                DocCategoryParentId = dk.Doc_Category_Parent_Id
            })
                        .FirstOrDefault();
            return
                result;
        }

        public virtual IEnumerable<AlliedLines.Review.GroupsClassesItemsOptions.Result.Get> GetAlliedLineGroupsClassesItemsOptions(AlliedLines.Review.GroupsClassesItemsOptions.Parameters.Get parameters)
        {
            IEnumerable<AlliedLines.Review.GroupsClassesItemsOptions.Result.Get> result;
            IEnumerable<SP_GET_PL_PCY_ALLIEDLINES_GROUPS_CLASSES_ITEMS_OPTIONS_Result> temp;

            temp = globalModel.SP_GET_PL_PCY_ALLIEDLINES_GROUPS_CLASSES_ITEMS_OPTIONS(
                        parameters.CorpId,
                        parameters.AlliedLineTypeId,
                        parameters.GroupId
                   );

            result = temp.Select(dk => new AlliedLines.Review.GroupsClassesItemsOptions.Result.Get
            {
                CorpId = dk.Corp_Id,
                GroupId = dk.Review_Group_Id,
                GroupDesc = dk.Review_Group_Desc,
                ClassId = dk.Review_Class_Id,
                ClassDesc = dk.Review_Class_Desc,
                ItemId = dk.Review_Item_Id,
                ItemDesc = dk.Review_Item_Desc,
                OptionId = dk.Review_Option_Id,
                OptionDesc = dk.Review_Option_Desc,
            })
                        .ToArray();

            return
                result;
        }

        public virtual IEnumerable<AlliedLines.Review.Sections.Count.Result.Get> GetAlliedLineReviewSectionsCount(AlliedLines.Review.Sections.Count.Parameters.Get parameters)
        {
            IEnumerable<AlliedLines.Review.Sections.Count.Result.Get> result;
            IEnumerable<SP_GET_PL_PCY_ALLIEDLINES_REVIEW_SECTIONS_COUNT_Result> temp;

            temp = globalModel.SP_GET_PL_PCY_ALLIEDLINES_REVIEW_SECTIONS_COUNT(
                        parameters.CorpId,
                        parameters.RegionId,
                        parameters.CountryId,
                        parameters.DomesticregId,
                        parameters.StateProvId,
                        parameters.CityId,
                        parameters.OfficeId,
                        parameters.CaseSeqNo,
                        parameters.HistSeqNo,
                        parameters.AlliedLineId,
                        parameters.UniqueAlliedLineId,
                        parameters.AlliedLineTypeId,
                        parameters.ReviewId,
                        parameters.DocTypeId,
                        parameters.DocCategoryId
                   );

            result = temp.Select(dk => new AlliedLines.Review.Sections.Count.Result.Get
            {
                Section = dk.Section,
                Count = dk.Count
            })
                        .ToArray();

            return
                result;
        }

        public virtual AlliedLines.Review.Result.Set SetAlliedLineReview(AlliedLines.Review.Parameters.Set review)
        {
            AlliedLines.Review.Result.Set result;
            IEnumerable<SP_SET_PL_PCY_ALLIEDLINES_REVIEW_Result> temp;

            temp = globalModel.SP_SET_PL_PCY_ALLIEDLINES_REVIEW(
                        review.CorpId,
                        review.RegionId,
                        review.CountryId,
                        review.DomesticregId,
                        review.StateProvId,
                        review.CityId,
                        review.OfficeId,
                        review.CaseSeqNo,
                        review.HistSeqNo,
                        review.AlliedLineId,
                        review.UniqueAlliedLineId,
                        review.AlliedLineTypeId,
                        review.BlTypeId,
                        review.BlId,
                        review.ProductId,
                        review.ReviewId,
                        review.InspectionDate,
                        review.RiskName,
                        review.InspectedLocation,
                        review.RiskType,
                        review.InspectorId,
                        review.DocTypeId,
                        review.DocCategoryId,
                        review.ReviewStatus,
                        review.UsrId
                   );

            result = temp.Select(dk => new AlliedLines.Review.Result.Set
            {
                CorpId = dk.Corp_Id,
                RegionId = dk.Region_Id,
                CountryId = dk.Country_Id,
                DomesticregId = dk.Domesticreg_Id,
                StateProvId = dk.State_Prov_Id,
                CityId = dk.City_Id,
                OfficeId = dk.Office_Id,
                CaseSeqNo = dk.Case_Seq_No,
                HistSeqNo = dk.Hist_Seq_No,
                AlliedLineId = dk.AlliedLine_Id,
                AlliedLineTypeId = dk.AlliedLine_Type_Id,
                BlTypeId = dk.Bl_Type_Id,
                BlId = dk.Bl_Id,
                ProductId = dk.Product_Id,
                ReviewId = dk.Review_Id,
                DocTypeId = dk.Doc_Type_Id,
                DocCategoryId = dk.Doc_Category_Id
            })
                        .FirstOrDefault();
            return
                result;
        }

        public virtual AlliedLines.Review.Detail.Result.Set SetAlliedLineReviewDetail(AlliedLines.Review.Detail.Parameters.Set review)
        {
            AlliedLines.Review.Detail.Result.Set result = null;
            IEnumerable<SP_SET_PL_PCY_ALLIEDLINES_REVIEW_DETAILS_Result> temp;

            temp = globalModelExtended.SP_SET_PL_PCY_ALLIEDLINES_REVIEW_DETAILS(
                        review.CorpId,
                        review.RegionId,
                        review.CountryId,
                        review.DomesticregId,
                        review.StateProvId,
                        review.CityId,
                        review.OfficeId,
                        review.CaseSeqNo,
                        review.HistSeqNo,
                        review.AlliedLineId,
                        review.UniqueAlliedLineId,
                        review.AlliedLineTypeId,
                        review.ReviewId,
                        review.ReviewDetailId,
                        review.ReviewGroupId,
                        review.ReviewClassId,
                        review.ReviewItemId,
                        review.ReviewOptionId,
                        review.ValueChecked,
                        review.ValueText,
                        review.Reviewtatus,
                        review.Required,
                        review.UserId,
                        review.UsuarioInspeccion
                   );

            result = temp.Select(dk => new AlliedLines.Review.Detail.Result.Set
            {
                CorpId = dk.Corp_Id,
                RegionId = dk.Region_Id,
                CountryId = dk.Country_Id,
                DomesticregId = dk.Domesticreg_Id,
                StateProvId = dk.State_Prov_Id,
                CityId = dk.City_Id,
                OfficeId = dk.Office_Id,
                CaseSeqNo = dk.Case_Seq_No,
                HistSeqNo = dk.Hist_Seq_No,
                AlliedLineId = dk.AlliedLine_Id,
                UniqueAlliedLineId = dk.Unique_AlliedLine_Id,
                AlliedLineTypeId = dk.AlliedLine_Type_Id,
                ReviewId = dk.Review_Id,
                ReviewDetailId = dk.Review_Detail_Id,
                ReviewGroupId = dk.Review_Group_Id,
                ReviewClassId = dk.Review_Class_Id,
                ReviewItemId = dk.Review_Item_Id,
                ReviewOptionId = dk.Review_Option_Id
            })
                        .FirstOrDefault();
            return
                result;
        }

        public virtual AlliedLines.Review.Pic.Result.Set SetVehicleReviewPic(AlliedLines.Review.Pic.Parameters.Set review)
        {
            AlliedLines.Review.Pic.Result.Set result;
            IEnumerable<SP_SET_PL_PCY_ALLIEDLINES_REVIEW_PICS_Result> temp;

            temp = globalModel.SP_SET_PL_PCY_ALLIEDLINES_REVIEW_PICS(
                        review.CorpId,
                        review.RegionId,
                        review.CountryId,
                        review.DomesticregId,
                        review.StateProvId,
                        review.CityId,
                        review.OfficeId,
                        review.CaseSeqNo,
                        review.HistSeqNo,
                        review.AlliedLineId,
                        review.UniqueAlliedLineId,
                        review.AlliedLineTypeId,
                        review.ReviewId,
                        review.PictureId,
                        review.DocTypeId,
                        review.DocCategoryId,
                        review.DocumentId,
                        review.PictureStatus,
                        review.UsrId
                   );

            result = temp.Select(dk => new AlliedLines.Review.Pic.Result.Set
            {
                CorpId = dk.Corp_Id,
                RegionId = dk.Region_Id,
                CountryId = dk.Country_Id,
                DomesticregId = dk.Domesticreg_Id,
                StateProvId = dk.State_Prov_Id,
                CityId = dk.City_Id,
                OfficeId = dk.Office_Id,
                CaseSeqNo = dk.Case_Seq_No,
                HistSeqNo = dk.Hist_Seq_No,
                AlliedLineId = dk.AlliedLine_Id,
                UniqueAlliedLineId = dk.Unique_AlliedLine_Id,
                AlliedLineTypeId = dk.AlliedLine_Type_Id,
                ReviewId = dk.Review_Id,
                PictureId = dk.Picture_Id,
                DocTypeId = dk.Doc_Type_Id,
                DocCategoryId = dk.Doc_Category_Id,
                DocumentId = dk.Document_Id
            })
                        .FirstOrDefault();
            return
                result;
        }

        public virtual AlliedLines.Document.Result.Set SetDocument(AlliedLines.Document.Parameters.Set document)
        {
            AlliedLines.Document.Result.Set result;
            IEnumerable<SP_SET_DOCUMENT2_Result> temp;
            ObjectParameter document_Id;

            document_Id = new ObjectParameter("Document_Id", document.DocumentId);

            temp = globalModel.SP_SET_DOCUMENT2(
                            document.DocTypeId,
                            document.DocCategoryId,
                            document_Id,
                            document.DocumentBinary,
                            document.DocumentName,
                            document.DocumentDesc,
                            document.FileCreationDate,
                            document.FileExpireDate,
                            document.UserId
                   );

            result = temp.Select(dk => new AlliedLines.Document.Result.Set
                                {
                                    DocTypeId = dk.Doc_Type_Id,
                                    DocCategoryId = dk.Doc_Category_Id,
                                    DocumentId = dk.Document_Id
                                })
                        .FirstOrDefault();
            return
                result;
        }

        public virtual AlliedLines.Document.Policy.Result.Set SetPolicyDocument(AlliedLines.Document.Policy.Parameters.Set document)
        {
            AlliedLines.Document.Policy.Result.Set result;
            IEnumerable<SP_SET_PL_PCY_DOCUMENTS_Result> temp;

            temp = globalModel.SP_SET_PL_PCY_DOCUMENTS(
                            document.CorpId,
                            document.RegionId,
                            document.CountryId,
                            document.DomesticregId,
                            document.StateProvId,
                            document.CityId,
                            document.OfficeId,
                            document.CaseSeqNo,
                            document.HistSeqNo,
                            document.DocTypeId,
                            document.DocCategoryId,
                            document.DocumentId,
                            document.DocumentStatusId,
                            document.UserId
                   );

            result = temp.Select(dk => new AlliedLines.Document.Policy.Result.Set
                            {
                                CorpId = dk.Corp_Id,
                                RegionId = dk.Region_Id,
                                CountryId = dk.Country_Id,
                                DomesticregId = dk.Domesticreg_Id,
                                StateProvId = dk.State_Prov_Id,
                                CityId = dk.City_Id,
                                OfficeId = dk.Office_Id,
                                CaseSeqNo = dk.Case_Seq_No,
                                HistSeqNo = dk.Hist_Seq_No,
                                DocTypeId = dk.Doc_Type_Id,
                                DocCategoryId = dk.Doc_Category_Id,
                                DocumentId = dk.Document_Id
                            })
                        .FirstOrDefault();
            return
                result;
        }

        public virtual AlliedLines.Review.Detail.Del.Result.Set DelAlliedLineReviewDetail(AlliedLines.Review.Detail.Del.Parameters.Set review)
        {
            AlliedLines.Review.Detail.Del.Result.Set result;
            IEnumerable<SP_DELETE_PL_PCY_ALLIEDLINES_REVIEW_DETAILS_Result> temp;

            temp = globalModel.SP_DELETE_PL_PCY_ALLIEDLINES_REVIEW_DETAILS(
                        review.CorpId,
                        review.RegionId,
                        review.CountryId,
                        review.DomesticregId,
                        review.StateProvId,
                        review.CityId,
                        review.OfficeId,
                        review.CaseSeqNo,
                        review.HistSeqNo,
                        review.AlliedLineId,
                        review.UniqueAlliedLineId,
                        review.AlliedLineTypeId,
                        review.ReviewId
                   );

            result = temp.Select(dk => new AlliedLines.Review.Detail.Del.Result.Set
            {
                Result = dk.Result
            }).FirstOrDefault();

            return
                result;
        }

        public virtual AlliedLines.Review.Pic.Del.Result.Set DelAlliedLineReviewPhoto(AlliedLines.Review.Pic.Del.Parameters.Set review)
        {
            AlliedLines.Review.Pic.Del.Result.Set result;
            IEnumerable<SP_DELETE_PL_PCY_ALLIEDLINES_REVIEW_PHOTO_Result> temp;

            temp = globalModel.SP_DELETE_PL_PCY_ALLIEDLINES_REVIEW_PHOTO(
                        review.CorpId,
                        review.RegionId,
                        review.CountryId,
                        review.DomesticregId,
                        review.StateProvId,
                        review.CityId,
                        review.OfficeId,
                        review.CaseSeqNo,
                        review.HistSeqNo,
                        review.AlliedLineId,
                        review.UniqueAlliedLineId,
                        review.AlliedLineTypeId,
                        review.ReviewId,
                        review.DocTypeId,
                        review.DocCategoryId,
                        review.DocumentId,
                        review.DocumentDesc,
                        review.DocumentName
                   );

            result = temp.Select(dk => new AlliedLines.Review.Pic.Del.Result.Set
            {
                Result = dk.Result
            }).FirstOrDefault();

            return
                result;
        }
    }
}