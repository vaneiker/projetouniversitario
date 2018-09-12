using Entity.UnderWriting.Entities;
using System.Collections.Generic;

namespace DI.UnderWriting.Interfaces
{
    public interface IAlliedLinesReview
    {
        IEnumerable<AlliedLines.Review.Result.Get> GetAlliedLineReview(AlliedLines.Review.Parameters.Get alliedLine);
        IEnumerable<AlliedLines.Review.Detail.Result.Get> GetAlliedLineReviewDetail(AlliedLines.Review.Detail.Parameters.Get review);
        IEnumerable<AlliedLines.Review.Pic.Result.Get> GetAlliedLineReviewPic(AlliedLines.Review.Pic.Parameters.Get review);
        AlliedLines.Agent.AssignedOffice.Result.Get GetAgentAssignedOffice(AlliedLines.Agent.AssignedOffice.Parameters.Get agent);
        IEnumerable<AlliedLines.Document.Policy.Result.Get> GetPolicyDocument(AlliedLines.Document.Policy.Parameters.Get policy);
        IEnumerable<AlliedLines.Review.Item.Option.Result.Get> GetAlliedLineReviewItemOption(AlliedLines.Review.Item.Option.Parameters.Get review);
        AlliedLines.Document.Category.Result.Get GetDocumentCategory(AlliedLines.Document.Category.Parameters.Get category);
        IEnumerable<AlliedLines.Review.GroupsClassesItemsOptions.Result.Get> GetAlliedLineGroupsClassesItemsOptions(AlliedLines.Review.GroupsClassesItemsOptions.Parameters.Get parameters);
        IEnumerable<AlliedLines.Review.Sections.Count.Result.Get> GetAlliedLineReviewSectionsCount(AlliedLines.Review.Sections.Count.Parameters.Get parameters);
        AlliedLines.Review.Result.Set SetAlliedLineReview(AlliedLines.Review.Parameters.Set review);
        AlliedLines.Review.Detail.Result.Set SetAlliedLineReviewDetail(AlliedLines.Review.Detail.Parameters.Set review);
        AlliedLines.Review.Pic.Result.Set SetVehicleReviewPic(AlliedLines.Review.Pic.Parameters.Set review);
        AlliedLines.Document.Result.Set SetDocument(AlliedLines.Document.Parameters.Set document);
        AlliedLines.Document.Policy.Result.Set SetPolicyDocument(AlliedLines.Document.Policy.Parameters.Set document);
        AlliedLines.Review.Detail.Del.Result.Set DelAlliedLineReviewDetail(AlliedLines.Review.Detail.Del.Parameters.Set review);
        AlliedLines.Review.Pic.Del.Result.Set DelAlliedLineReviewPhoto(AlliedLines.Review.Pic.Del.Parameters.Set review);
    }
}
