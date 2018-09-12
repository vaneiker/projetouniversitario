
namespace WEB.NewBusiness.Common.Illustration.IllustrationVehicle.Models
{
    //public class ActionIllustrationPayment
    //{
    //    public int Corp_Id { get; set; }
    //    public int Region_Id { get; set; }
    //    public int Country_Id { get; set; }
    //    public int Domesticreg_Id { get; set; }
    //    public int State_Prov_Id { get; set; }
    //    public int City_Id { get; set; }
    //    public int Office_Id { get; set; }
    //    public int Case_Seq_No { get; set; }
    //    public int Hist_Seq_No { get; set; }
    //    public int? ContactEntityID { get; set; }
    //    public string ProductLine { get; set; }
    //    public bool CanEdit { get; set; }
    //    public string Sessions { get; set; }
    //}

    //public class ActionsModel
    //{
    //    public ActionTypes ActionType { get; set; }
    //    public string ActionJson { get; set; }
    //}

    //public enum ActionTypes
    //{
    //    Payments,
    //    Inspection
    //}

    public class ActionsModel
    {
        public ActionTypes ActionType { get; set; }
        public string ActionJson { get; set; }
    }

    public class ActionIllustrationPayment
    {
        public int Corp_Id { get; set; }
        public int Region_Id { get; set; }
        public int Country_Id { get; set; }
        public int Domesticreg_Id { get; set; }
        public int State_Prov_Id { get; set; }
        public int City_Id { get; set; }
        public int Office_Id { get; set; }
        public int Case_Seq_No { get; set; }
        public int Hist_Seq_No { get; set; }
        public int? ContactEntityID { get; set; }
        public string ProductLine { get; set; }
        public bool CanEdit { get; set; }
        public string Sessions { get; set; }
    }

    public enum ActionTypes
    {
        Payments,
        Inspection
    }

}