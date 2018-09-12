using DI.UnderWriting.Interfaces;
using Entity.UnderWriting.Entities;
using LOGIC.UnderWriting.Global;
using System;
using System.Collections.Generic;

namespace DI.UnderWriting.Implementations
{
    public class AlliedLinesReviewBll : IAlliedLinesReview
    {
        private AlliedLinesReviewManager _alliedLinesReviewManager;

        public AlliedLinesReviewBll()
        {
            _alliedLinesReviewManager = new AlliedLinesReviewManager();
        }

        IEnumerable<AlliedLines.Review.Result.Get> IAlliedLinesReview.GetAlliedLineReview(AlliedLines.Review.Parameters.Get alliedLine)
        {
            return
                _alliedLinesReviewManager.GetAlliedLineReview(alliedLine);
        }

        IEnumerable<AlliedLines.Review.Detail.Result.Get> IAlliedLinesReview.GetAlliedLineReviewDetail(AlliedLines.Review.Detail.Parameters.Get review)
        {
            return
                _alliedLinesReviewManager.GetAlliedLineReviewDetail(review);
        }

        IEnumerable<AlliedLines.Review.Pic.Result.Get> IAlliedLinesReview.GetAlliedLineReviewPic(AlliedLines.Review.Pic.Parameters.Get review)
        {
            return
                _alliedLinesReviewManager.GetAlliedLineReviewPic(review);
        }

        AlliedLines.Agent.AssignedOffice.Result.Get IAlliedLinesReview.GetAgentAssignedOffice(AlliedLines.Agent.AssignedOffice.Parameters.Get agent)
        {
            return
                _alliedLinesReviewManager.GetAgentAssignedOffice(agent);
        }

        IEnumerable<AlliedLines.Document.Policy.Result.Get> IAlliedLinesReview.GetPolicyDocument(AlliedLines.Document.Policy.Parameters.Get policy)
        {
            return
                _alliedLinesReviewManager.GetPolicyDocument(policy);
        }

        IEnumerable<AlliedLines.Review.Item.Option.Result.Get> IAlliedLinesReview.GetAlliedLineReviewItemOption(AlliedLines.Review.Item.Option.Parameters.Get review)
        {
            return
                _alliedLinesReviewManager.GetAlliedLineReviewItemOption(review);
        }

        AlliedLines.Document.Category.Result.Get IAlliedLinesReview.GetDocumentCategory(AlliedLines.Document.Category.Parameters.Get category)
        {
            return
                _alliedLinesReviewManager.GetDocumentCategory(category);
        }

        IEnumerable<AlliedLines.Review.GroupsClassesItemsOptions.Result.Get> IAlliedLinesReview.GetAlliedLineGroupsClassesItemsOptions(AlliedLines.Review.GroupsClassesItemsOptions.Parameters.Get parameters)
        {
            return
                _alliedLinesReviewManager.GetAlliedLineGroupsClassesItemsOptions(parameters);
        }

        IEnumerable<AlliedLines.Review.Sections.Count.Result.Get> IAlliedLinesReview.GetAlliedLineReviewSectionsCount(AlliedLines.Review.Sections.Count.Parameters.Get parameters)
        {
            return
                _alliedLinesReviewManager.GetAlliedLineReviewSectionsCount(parameters);
        }

        AlliedLines.Review.Result.Set IAlliedLinesReview.SetAlliedLineReview(AlliedLines.Review.Parameters.Set review)
        {
            return
                _alliedLinesReviewManager.SetAlliedLineReview(review);
        }

        AlliedLines.Review.Detail.Result.Set IAlliedLinesReview.SetAlliedLineReviewDetail(AlliedLines.Review.Detail.Parameters.Set review)
        {
            return
                _alliedLinesReviewManager.SetAlliedLineReviewDetail(review);
        }

        AlliedLines.Review.Pic.Result.Set IAlliedLinesReview.SetVehicleReviewPic(AlliedLines.Review.Pic.Parameters.Set review)
        {
            return
                _alliedLinesReviewManager.SetVehicleReviewPic(review);
        }

        AlliedLines.Document.Result.Set IAlliedLinesReview.SetDocument(AlliedLines.Document.Parameters.Set document)
        {
            return
                _alliedLinesReviewManager.SetDocument(document);
        }

        AlliedLines.Document.Policy.Result.Set IAlliedLinesReview.SetPolicyDocument(AlliedLines.Document.Policy.Parameters.Set document)
        {
            return
                _alliedLinesReviewManager.SetPolicyDocument(document);
        }

        AlliedLines.Review.Detail.Del.Result.Set IAlliedLinesReview.DelAlliedLineReviewDetail(AlliedLines.Review.Detail.Del.Parameters.Set review) 
        {
            return
                _alliedLinesReviewManager.DelAlliedLineReviewDetail(review);
        }

        AlliedLines.Review.Pic.Del.Result.Set IAlliedLinesReview.DelAlliedLineReviewPhoto(AlliedLines.Review.Pic.Del.Parameters.Set review)
        {
            return
                _alliedLinesReviewManager.DelAlliedLineReviewPhoto(review);
        }
    }



    public class AlliedLinesReviewWS : IAlliedLinesReview
    {
        IEnumerable<AlliedLines.Review.Result.Get> IAlliedLinesReview.GetAlliedLineReview(AlliedLines.Review.Parameters.Get alliedLine)
        {
            throw new NotImplementedException();
        }

        IEnumerable<AlliedLines.Review.Detail.Result.Get> IAlliedLinesReview.GetAlliedLineReviewDetail(AlliedLines.Review.Detail.Parameters.Get review)
        {
            throw new NotImplementedException();
        }

        IEnumerable<AlliedLines.Review.Pic.Result.Get> IAlliedLinesReview.GetAlliedLineReviewPic(AlliedLines.Review.Pic.Parameters.Get review)
        {
            throw new NotImplementedException();
        }

        AlliedLines.Agent.AssignedOffice.Result.Get IAlliedLinesReview.GetAgentAssignedOffice(AlliedLines.Agent.AssignedOffice.Parameters.Get agent)
        {
            throw new NotImplementedException();
        }

        IEnumerable<AlliedLines.Document.Policy.Result.Get> IAlliedLinesReview.GetPolicyDocument(AlliedLines.Document.Policy.Parameters.Get policy)
        {
            throw new NotImplementedException();
        }

        IEnumerable<AlliedLines.Review.Item.Option.Result.Get> IAlliedLinesReview.GetAlliedLineReviewItemOption(AlliedLines.Review.Item.Option.Parameters.Get review)
        {
            throw new NotImplementedException();
        }

        AlliedLines.Document.Category.Result.Get IAlliedLinesReview.GetDocumentCategory(AlliedLines.Document.Category.Parameters.Get category)
        {
            throw new NotImplementedException();
        }

        IEnumerable<AlliedLines.Review.GroupsClassesItemsOptions.Result.Get> IAlliedLinesReview.GetAlliedLineGroupsClassesItemsOptions(AlliedLines.Review.GroupsClassesItemsOptions.Parameters.Get parameters)
        {
            throw new NotImplementedException();
        }

        IEnumerable<AlliedLines.Review.Sections.Count.Result.Get> IAlliedLinesReview.GetAlliedLineReviewSectionsCount(AlliedLines.Review.Sections.Count.Parameters.Get parameters)
        {
            throw new NotImplementedException();
        }

        AlliedLines.Review.Result.Set IAlliedLinesReview.SetAlliedLineReview(AlliedLines.Review.Parameters.Set review)
        {
            throw new NotImplementedException();
        }

        AlliedLines.Review.Detail.Result.Set IAlliedLinesReview.SetAlliedLineReviewDetail(AlliedLines.Review.Detail.Parameters.Set review)
        {
            throw new NotImplementedException();
        }

        AlliedLines.Review.Pic.Result.Set IAlliedLinesReview.SetVehicleReviewPic(AlliedLines.Review.Pic.Parameters.Set review)
        {
            throw new NotImplementedException();
        }

        AlliedLines.Document.Result.Set IAlliedLinesReview.SetDocument(AlliedLines.Document.Parameters.Set document)
        {
            throw new NotImplementedException();
        }

        AlliedLines.Document.Policy.Result.Set IAlliedLinesReview.SetPolicyDocument(AlliedLines.Document.Policy.Parameters.Set document)
        {
            throw new NotImplementedException();
        }

        AlliedLines.Review.Detail.Del.Result.Set IAlliedLinesReview.DelAlliedLineReviewDetail(AlliedLines.Review.Detail.Del.Parameters.Set review)
        {
            throw new NotImplementedException();
        }

        AlliedLines.Review.Pic.Del.Result.Set IAlliedLinesReview.DelAlliedLineReviewPhoto(AlliedLines.Review.Pic.Del.Parameters.Set review)
        {
            throw new NotImplementedException();
        }
    }
}
