namespace shipmentmgmt_WebapiCore.BusinessLayer.Models
{
    public class orders
    {
        public int? OrderId { get; set; }
        public int UserId { get; set; }
        public int ShippingAddressId { get; set; }
        public string OrderNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentStatus { get; set; }
        public string OrderStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
