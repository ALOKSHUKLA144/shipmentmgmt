using shipmentmgmt_WebapiCore.BusinessLayer.Models;
using System.Collections.Generic;

namespace shipmentmgmt_WebapiCore.BusinessLayer.IRepsitory
{
    public interface Iaddress
    {
        int createaddress(Address address);
        IEnumerable<Address> GetaddressById(int id);
        List<Address> GetAllAddress();
        int updateAddress(Address user);
        int DeleteAddress(int id);
    }
}
