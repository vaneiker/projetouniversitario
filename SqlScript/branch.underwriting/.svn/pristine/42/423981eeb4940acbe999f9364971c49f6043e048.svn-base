
using System;
namespace WEB.NewBusiness.Common.Illustration.IllustrationVehicle.Models
{
    [Serializable]
    public class DocumentRequired
    {
        public string FileName { get; set; }
        public string Description { get; set; }
        public int TypeId { get; set; }
        public string CodeName { get; set; }
        public bool PerVehicle { get; set; }
        public bool isRequired { get; set; } 
        public string CategoryNameKey { get; set; }
        public int CategoryId { get; set; }
        public string CategoryDescription { get; set; }
        public int? Id { get; set; }
        public int Index { get; set; }
        public int InsuredVehicleId { get; set; }
        public bool Status { get { return !FileName.SIsNullOrEmpty(); } }
        public bool IsVehicle { get; set; }
    }
}