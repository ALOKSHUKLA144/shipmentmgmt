using shipmentmgmt_WebapiCore.BusinessLayer.Models;

namespace shipmentmgmt_WebapiCore.BusinessLayer.IRepsitory
{
    public interface Iaddress
    {
        int createaddress(Address address);
        Address GetaddressById(int id);
        List<Address> GetAllAddress();
        int updateAddress(Address user);
        int DeleteAddress(int id);
    }
}
