namespace shipmentmgmt_WebapiCore.BusinessLayer.Models
{
    public class Address
    {
        public int? AddressId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string? Pincode { get; set; }
        public int? UserId { get; set; }
    }
}
