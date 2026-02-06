using shipmentmgmt_WebapiCore.BusinessLayer.Models;

namespace shipmentmgmt_WebapiCore.BusinessLayer.Models
{
    public class user
    {
        public int? Id { get; set; }
        public string? UserId { get; set; }
        public string? Password { get; set; }
        public string? Roles { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
