namespace shipmentmgmt_WebapiCore.BusinessLayer.Models
{
    public class shipmentitem
    {

        public int? ItemId { get; set; }
        public int? ShipmentId { get; set; }
        public string SKU { get; set; }
        public int? Quantity { get; set; }
        public decimal? TotalPrice { get; set; }
    }
}
