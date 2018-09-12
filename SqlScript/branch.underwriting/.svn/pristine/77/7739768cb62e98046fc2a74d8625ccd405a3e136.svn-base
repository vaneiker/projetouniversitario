using Entity.UnderWriting.Entities;
using System.Collections.Generic;

namespace DI.UnderWriting.Interfaces
{
    public interface IVehicle
    {
        IEnumerable<Vehicle.Insured.Detail> GetVehicleInsuredDetail(Vehicle.Policy policy);
        IEnumerable<Vehicle.Insured> GetVehicleInsured(Vehicle.Policy policy);
        IEnumerable<Vehicle.Review> GetVehicleReview(Vehicle vehicle);
        IEnumerable<Vehicle.Review.Pic> GetVehicleReviewPic(Vehicle.Review review);
        IEnumerable<Vehicle.Review.Item.Option> GetVehicleReviewItemOption(Vehicle.Review review);
        Vehicle.Document.Category GetDocumentCategory(string nameKey);
        Vehicle.Review SetVehicleReview(Vehicle.Review review);
        int? DeleteVehicleReviewDetail(Vehicle.Review.Detail detail);
        Vehicle.Review.Detail SetVehicleReviewDetail(Vehicle.Review.Detail detail);
        IEnumerable<Vehicle.Review.Detail> GetVehicleReviewDetail(Vehicle.Review review);
        Vehicle.Document SetDocument(Vehicle.Document document);
        Vehicle.Document SetPolicyDocument(Vehicle.Document document);
        Vehicle.Review.Pic SetVehicleReviewPic(Vehicle.Review.Pic review);
        Vehicle.Agent.AssignedOffice GetAgentAssignedOffice(Vehicle.Agent agent);
        Vehicle.Review.VIG SetVehicleReviewVIG(Vehicle.Review.VIG vig);
        IEnumerable<Vehicle.Review.VIG> GetVehicleReviewVIG(Vehicle.Review.VIG vig);
        IEnumerable<Vehicle.TransmissionType> GetVehicleTransmissionTypes(Vehicle.TransmissionType vehicle_transmission_type);
        IEnumerable<Vehicle.Classes> GetVehicleClasses(Vehicle.Classes vehicle_class);
        IEnumerable<Vehicle.WheelDriveType> GetVehicleWheelDriveTypes(Vehicle.WheelDriveType vehicle_wheel_drive_type);
        IEnumerable<Vehicle.Version> GetVehicleVersions(Vehicle.Version vehicle_version);
        IEnumerable<Vehicle.Document> GetPolicyDocument(Vehicle.Policy policy);
        int? DeletePolicyDocument(Vehicle.Review review);
        IEnumerable<RequestChanges> GetVehicleRequestChange(string PolicyNumber, int? ConditionID, bool IsLastRecord = true);
        RequestChanges SetVehicleRequestChange(RequestChanges.Parameter parameter);

        Vehicle.FuelType GetFuelTypes(Vehicle.FuelType parameter);
    }
}
