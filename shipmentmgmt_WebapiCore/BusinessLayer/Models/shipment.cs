namespace shipmentmgmt_WebapiCore.BusinessLayer.Models
{
    public class shipment
    {
        public int? ShipmentId { get; set; }
        public int? OrderId { get; set; }
        public int? FromAddressId { get; set; }
        public int? ToAddressId { get; set; }
        public string CarrierName { get; set; }
        public string TrackingNumber { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }

        // Payment Info
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentTransactionId { get; set; }
        public decimal? AmountPaid { get; set; }
    }
}
