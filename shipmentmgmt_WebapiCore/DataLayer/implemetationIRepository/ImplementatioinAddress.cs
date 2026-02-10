using Microsoft.Data.SqlClient;
using shipmentmgmt_WebapiCore.BusinessLayer.IRepsitory;
using shipmentmgmt_WebapiCore.BusinessLayer.Models;
using System.Data;
using System.Net;

namespace shipmentmgmt_WebapiCore.DataLayer.implemetationIRepository
{
    public class ImplementatioinAddress : Iaddress
    {
        private readonly dataaccess _db;
        public ImplementatioinAddress(dataaccess dataaccess)
        {
            _db = dataaccess;

        }
        public int createaddress(Address address)
        {
            int res = _db.Executescaler("sp_crud_address", new SqlParameter[]
            {
                new SqlParameter("@name", address.Name),
                new SqlParameter("@phone", address.Phone),
                new SqlParameter("@Line1", address.Line1),
                new SqlParameter("@Line2", address.Line2),
                new SqlParameter("@city", address.City),
                new SqlParameter("@state", address.State),
                new SqlParameter("@pincode", address.Pincode),
                new SqlParameter("@UserId", address.UserId),
                new SqlParameter("@action", 1)
            });
            return res;
        }

        public int DeleteAddress(int  id)
        {
          int res=  _db.ExecuteNOnquery("sp_crud_address", new SqlParameter[]
            {
              new SqlParameter("@AddressId",id),
              new SqlParameter("@action",2),
            });
            return res;
        }

        public IEnumerable<Address> GetaddressById(int id)
        {
            List<Address> addressList = new List<Address>();
            DataTable dt = _db.select("sp_crud_address", new SqlParameter[]
            {
                       new SqlParameter("@AddressId",id),
                       new SqlParameter("@action",4)
                // If you need to filter by User, only pass UserId. Keep it simple.
            });
            // 2. Convert DataTable to List<Address> manually
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    addressList.Add(new Address
                    {
                        AddressId = Convert.ToInt32(row["AddressId"]),
                        Name = row["Name"] != DBNull.Value ? row["Name"].ToString() : "",
                        Phone = row["Phone"] != DBNull.Value ? row["Phone"].ToString() : "",
                        Line1 = row["Line1"] != DBNull.Value ? row["Line1"].ToString() : "",
                        Line2 = row["Line2"] != DBNull.Value ? row["Line2"].ToString() : "",
                        City = row["City"] != DBNull.Value ? row["City"].ToString() : "",
                        State = row["State"] != DBNull.Value ? row["State"].ToString() : "",
                        Pincode = row["Pincode"] != DBNull.Value ? row["Pincode"].ToString() : "",
                        UserId = row["UserId"] != DBNull.Value ? (int?)Convert.ToInt32(row["UserId"]) : null
                    });
                }
            }
            return addressList;
        }

        public List<Address> GetAllAddress()
        {
            List<Address> addressList = new List<Address>();
            DataTable dt = _db.select("sp_crud_address", new SqlParameter[]
            {
                       new SqlParameter("@action",5)
                // If you need to filter by User, only pass UserId. Keep it simple.
            });
            // 2. Convert DataTable to List<Address> manually
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    addressList.Add(new Address
                    {
                        AddressId = Convert.ToInt32(row["AddressId"]),
                        Name = row["Name"] != DBNull.Value ? row["Name"].ToString() : "",
                        Phone = row["Phone"] != DBNull.Value ? row["Phone"].ToString() : "",
                        Line1 = row["Line1"] != DBNull.Value ? row["Line1"].ToString() : "",
                        Line2 = row["Line2"] != DBNull.Value ? row["Line2"].ToString() : "",
                        City = row["City"] != DBNull.Value ? row["City"].ToString() : "",
                        State = row["State"] != DBNull.Value ? row["State"].ToString() : "",
                        Pincode = row["Pincode"] != DBNull.Value ? row["Pincode"].ToString() : "",
                        UserId = row["UserId"] != DBNull.Value ? (int?)Convert.ToInt32(row["UserId"]) : null
                    });
                }
            }
            return addressList;
        }

        public int updateAddress(Address address)
        {
            int res = _db.Executescaler("sp_crud_address", new SqlParameter[]
                {
                new SqlParameter("@name", address.Name),
                new SqlParameter("@AddressId", address.AddressId),
                new SqlParameter("@phone", address.Phone),
                new SqlParameter("@Line1", address.Line1),
                new SqlParameter("@Line2", address.Line2),
                new SqlParameter("@city", address.City),
                new SqlParameter("@state", address.State),
                new SqlParameter("@pincode", address.Pincode),
                new SqlParameter("@UserId", address.UserId),
                new SqlParameter("@action", 3)
               });
            return res;
        }
    }
}
