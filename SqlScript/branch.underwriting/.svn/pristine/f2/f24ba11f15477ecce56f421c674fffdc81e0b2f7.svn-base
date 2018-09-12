using DATA.UnderWriting.Repositories.Global;
using DATA.UnderWriting.UnitOfWork;
using Entity.UnderWriting.Entities;
using System.Collections.Generic;

namespace LOGIC.UnderWriting.Global
{
    public class AlliedLinesReviewManager
    {
        private AlliedLinesReviewRepository _alliedLinesReviewRepository;

        public AlliedLinesReviewManager()
        {
            _alliedLinesReviewRepository = SingletonUnitOfWork.Instance.AlliedLinesReviewRepository;
        }
        public virtual IEnumerable<AlliedLines.Review.Result.Get> GetAlliedLineReview(AlliedLines.Review.Parameters.Get alliedLine)
        {
            return
                _alliedLinesReviewRepository.GetAlliedLineReview(alliedLine);
        }
        public virtual IEnumerable<AlliedLines.Review.Detail.Result.Get> GetAlliedLineReviewDetail(AlliedLines.Review.Detail.Parameters.Get review)
        {
            return
                _alliedLinesReviewRepository.GetAlliedLineReviewDetail(review);
        }
        public virtual IEnumerable<AlliedLines.Review.Pic.Result.Get> GetAlliedLineReviewPic(AlliedLines.Review.Pic.Parameters.Get review)
        {
            return
                _alliedLinesReviewRepository.GetAlliedLineReviewPic(review);
        }
        public virtual AlliedLines.Agent.AssignedOffice.Result.Get GetAgentAssignedOffice(AlliedLines.Agent.AssignedOffice.Parameters.Get agent)
        {
            return
                _alliedLinesReviewRepository.GetAgentAssignedOffice(agent);
        }
        public virtual IEnumerable<AlliedLines.Document.Policy.Result.Get> GetPolicyDocument(AlliedLines.Document.Policy.Parameters.Get policy)
        {
            return
                _alliedLinesReviewRepository.GetPolicyDocument(policy);
        }
        public virtual IEnumerable<AlliedLines.Review.Item.Option.Result.Get> GetAlliedLineReviewItemOption(AlliedLines.Review.Item.Option.Parameters.Get review)
        {
            return
                _alliedLinesReviewRepository.GetAlliedLineReviewItemOption(review);
        }
        public virtual AlliedLines.Document.Category.Result.Get GetDocumentCategory(AlliedLines.Document.Category.Parameters.Get category)
        {
            return
                _alliedLinesReviewRepository.GetDocumentCategory(category);
        }
        public virtual IEnumerable<AlliedLines.Review.GroupsClassesItemsOptions.Result.Get> GetAlliedLineGroupsClassesItemsOptions(AlliedLines.Review.GroupsClassesItemsOptions.Parameters.Get parameters)
        {
            return
                _alliedLinesReviewRepository.GetAlliedLineGroupsClassesItemsOptions(parameters);
        }
        public virtual IEnumerable<AlliedLines.Review.Sections.Count.Result.Get> GetAlliedLineReviewSectionsCount(AlliedLines.Review.Sections.Count.Parameters.Get parameters)
        {
            return
                _alliedLinesReviewRepository.GetAlliedLineReviewSectionsCount(parameters);
        }
        public virtual AlliedLines.Review.Result.Set SetAlliedLineReview(AlliedLines.Review.Parameters.Set review)
        {
            return
                _alliedLinesReviewRepository.SetAlliedLineReview(review);
        }
        public virtual AlliedLines.Review.Detail.Result.Set SetAlliedLineReviewDetail(AlliedLines.Review.Detail.Parameters.Set review)
        {
            return
                _alliedLinesReviewRepository.SetAlliedLineReviewDetail(review);
        }
        public virtual AlliedLines.Review.Pic.Result.Set SetVehicleReviewPic(AlliedLines.Review.Pic.Parameters.Set review)
        {
            return
                _alliedLinesReviewRepository.SetVehicleReviewPic(review);
        }
        public virtual AlliedLines.Document.Result.Set SetDocument(AlliedLines.Document.Parameters.Set document)
        {
            return
                _alliedLinesReviewRepository.SetDocument(document);
        }
        public virtual AlliedLines.Document.Policy.Result.Set SetPolicyDocument(AlliedLines.Document.Policy.Parameters.Set document)
        {
            return
                _alliedLinesReviewRepository.SetPolicyDocument(document);
        }
        public virtual AlliedLines.Review.Detail.Del.Result.Set DelAlliedLineReviewDetail(AlliedLines.Review.Detail.Del.Parameters.Set review)
        {
            return
                _alliedLinesReviewRepository.DelAlliedLineReviewDetail(review);
        }
        public virtual AlliedLines.Review.Pic.Del.Result.Set DelAlliedLineReviewPhoto(AlliedLines.Review.Pic.Del.Parameters.Set review)
        {
            return
                _alliedLinesReviewRepository.DelAlliedLineReviewPhoto(review);
        }
    }
}
