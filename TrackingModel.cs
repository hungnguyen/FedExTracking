using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tracking_api
{
    public class TrackingModel
    {
        public string transactionId { get; set; }
        public Output output { get; set; }
    }

    public class AdditionalTrackingInfo
    {
        public string nickname { get; set; }
        public List<PackageIdentifier> packageIdentifiers { get; set; }
        public bool hasAssociatedShipments { get; set; }
    }

    public class Address
    {
        public string city { get; set; }
        public string countryCode { get; set; }
        public bool residential { get; set; }
        public string countryName { get; set; }
        public string stateOrProvinceCode { get; set; }
    }

    public class Alert
    {
        public string code { get; set; }
        public string message { get; set; }
        public string alertType { get; set; }
    }

    public class AncillaryDetail
    {
        public string reason { get; set; }
        public string reasonDescription { get; set; }
        public string action { get; set; }
        public string actionDescription { get; set; }
    }

    public class CompleteTrackResult
    {
        public string trackingNumber { get; set; }
        public List<TrackResult> trackResults { get; set; }
    }

    public class Contact
    {
    }

    public class DateAndTime
    {
        public string type { get; set; }
        public DateTime dateTime { get; set; }
    }

    public class DeliveryDetails
    {
        public string deliveryAttempts { get; set; }
        public List<DeliveryOptionEligibilityDetail> deliveryOptionEligibilityDetails { get; set; }
        public string destinationServiceArea { get; set; }
    }

    public class DeliveryOptionEligibilityDetail
    {
        public string option { get; set; }
        public string eligibility { get; set; }
    }

    public class DestinationLocation
    {
        public LocationContactAndAddress locationContactAndAddress { get; set; }
        public string locationType { get; set; }
    }

    public class Dimension
    {
        public int length { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string units { get; set; }
    }

    public class EstimatedDeliveryTimeWindow
    {
        public Window window { get; set; }
    }

    public class LastUpdatedDestinationAddress
    {
        public string city { get; set; }
        public string stateOrProvinceCode { get; set; }
        public string countryCode { get; set; }
        public bool residential { get; set; }
        public string countryName { get; set; }
    }

    public class LatestStatusDetail
    {
        public string code { get; set; }
        public string derivedCode { get; set; }
        public string statusByLocale { get; set; }
        public string description { get; set; }
        public ScanLocation scanLocation { get; set; }
        public List<AncillaryDetail> ancillaryDetails { get; set; }
    }

    public class LocationContactAndAddress
    {
        public Address address { get; set; }
    }

    public class OriginLocation
    {
        public LocationContactAndAddress locationContactAndAddress { get; set; }
        public string locationId { get; set; }
    }

    public class Output
    {
        public List<Alert> alerts { get; set; }
        public List<CompleteTrackResult> completeTrackResults { get; set; }
    }

    public class PackageDetails
    {
        public PackagingDescription packagingDescription { get; set; }
        public string sequenceNumber { get; set; }
        public string count { get; set; }
        public WeightAndDimensions weightAndDimensions { get; set; }
        public List<object> packageContent { get; set; }
    }

    public class PackageIdentifier
    {
        public string type { get; set; }
        public List<string> values { get; set; }
        public string trackingNumberUniqueId { get; set; }
        public string carrierCode { get; set; }
    }

    public class PackagingDescription
    {
        public string type { get; set; }
        public string description { get; set; }
    }

    public class RecipientInformation
    {
        public Contact contact { get; set; }
        public Address address { get; set; }
    }

    public class ReturnDetail
    {
    }

    

    public class ScanEvent
    {
        public DateTime date { get; set; }
        public string eventType { get; set; }
        public string eventDescription { get; set; }
        public string exceptionCode { get; set; }
        public string exceptionDescription { get; set; }
        public ScanLocation scanLocation { get; set; }
        public string locationId { get; set; }
        public string locationType { get; set; }
        public string derivedStatusCode { get; set; }
        public string derivedStatus { get; set; }
    }

    public class ScanLocation
    {
        public string city { get; set; }
        public string stateOrProvinceCode { get; set; }
        public string countryCode { get; set; }
        public bool residential { get; set; }
        public string countryName { get; set; }
        public List<string> streetLines { get; set; }
        public string postalCode { get; set; }
    }

    public class ServiceCommitMessage
    {
        public string message { get; set; }
        public string type { get; set; }
    }

    public class ServiceDetail
    {
        public string type { get; set; }
        public string description { get; set; }
        public string shortDescription { get; set; }
    }

    public class ShipmentDetails
    {
        public bool possessionStatus { get; set; }
        public List<Weight> weight { get; set; }
    }

    public class ShipperInformation
    {
        public Contact contact { get; set; }
        public Address address { get; set; }
    }

    public class SpecialHandling
    {
        public string type { get; set; }
        public string description { get; set; }
        public string paymentType { get; set; }
    }

    public class StandardTransitTimeWindow
    {
        public Window window { get; set; }
    }

    public class TrackingNumberInfo
    {
        public string trackingNumber { get; set; }
        public string trackingNumberUniqueId { get; set; }
        public string carrierCode { get; set; }
    }

    public class TrackResult
    {
        public TrackingNumberInfo trackingNumberInfo { get; set; }
        public AdditionalTrackingInfo additionalTrackingInfo { get; set; }
        public ShipperInformation shipperInformation { get; set; }
        public RecipientInformation recipientInformation { get; set; }
        public LatestStatusDetail latestStatusDetail { get; set; }
        public List<DateAndTime> dateAndTimes { get; set; }
        public List<object> availableImages { get; set; }
        public List<SpecialHandling> specialHandlings { get; set; }
        public PackageDetails packageDetails { get; set; }
        public ShipmentDetails shipmentDetails { get; set; }
        public List<ScanEvent> scanEvents { get; set; }
        public List<string> availableNotifications { get; set; }
        public DeliveryDetails deliveryDetails { get; set; }
        public OriginLocation originLocation { get; set; }
        public DestinationLocation destinationLocation { get; set; }
        public LastUpdatedDestinationAddress lastUpdatedDestinationAddress { get; set; }
        public ServiceCommitMessage serviceCommitMessage { get; set; }
        public ServiceDetail serviceDetail { get; set; }
        public StandardTransitTimeWindow standardTransitTimeWindow { get; set; }
        public EstimatedDeliveryTimeWindow estimatedDeliveryTimeWindow { get; set; }
        public string goodsClassificationCode { get; set; }
        public ReturnDetail returnDetail { get; set; }
    }

    public class Weight
    {
        public string value { get; set; }
        public string unit { get; set; }
    }

    public class WeightAndDimensions
    {
        public List<Weight> weight { get; set; }
        public List<Dimension> dimensions { get; set; }
    }

    public class Window
    {
        public DateTime ends { get; set; }
    }
}
