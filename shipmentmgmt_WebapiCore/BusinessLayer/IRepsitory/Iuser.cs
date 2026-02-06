using shipmentmgmt_WebapiCore.BusinessLayer.Models;

namespace shipmentmgmt_WebapiCore.BusinessLayer.IRepsitory
{
    public interface Iuser
    {
        int AddUser(user user);
        user GetUserById(int id);
        List<user> GetAllUsers();
        void UpdateUser(user user);
        int DeleteUser(int id);
    }
}
