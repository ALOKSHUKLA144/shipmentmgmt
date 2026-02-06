using Azure.Core;
using Microsoft.Data.SqlClient;
using shipmentmgmt_WebapiCore.BusinessLayer.IRepsitory;
using shipmentmgmt_WebapiCore.BusinessLayer.Models;
using System.Data;

namespace shipmentmgmt_WebapiCore.DataLayer.implemetationIRepository
{
    public class implementaionShipmentitem : Ishipmentitem
    {
        private readonly dataaccess _db;
        public implementaionShipmentitem(dataaccess dataaccess)
        {
            _db=dataaccess;
        }
        public int Createshipmentitem(shipmentitem request)
        {
          int res=  _db.ExecuteNOnquery("sp_crud_shipmentitem", new SqlParameter[]
            {
                new SqlParameter("@action", 1),
                new SqlParameter("@ShipmentId", request.ShipmentId ?? (object)DBNull.Value),
                new SqlParameter("@SKU", request.SKU ?? (object)DBNull.Value),
                new SqlParameter("@Quantity", request.Quantity ?? (object)DBNull.Value),
                new SqlParameter("@TotalPrice", request.TotalPrice ?? (object)DBNull.Value)
            });
            return res;
        }

        public int Deleteshipmentitem(int ID)
        {
            int res = _db.ExecuteNOnquery("sp_crud_shipmentitem", new SqlParameter[]
               {
                new SqlParameter("@action", 2),
                new SqlParameter("@ItemId",ID)
                });
              return res;
        }

        public IEnumerable<shipmentitem> GetAllshipmentitems()
        {
           DataTable dt= _db.select("sp_crud_shipmentitem", new SqlParameter[]
            {
                new SqlParameter("@action",4)

            });

            List<shipmentitem> list = new List<shipmentitem>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    // Optional: Client-side filtering if SP doesn't support it yet
                    // if (shipmentId.HasValue && ...) 
                    list.Add(new shipmentitem
                    {
                        ItemId = Convert.ToInt32(row["ItemId"]),
                        ShipmentId = row["ShipmentId"] != DBNull.Value ? (int?)row["ShipmentId"] : null,
                        SKU = row["SKU"]?.ToString(),
                        Quantity = row["Quantity"] != DBNull.Value ? (int?)row["Quantity"] : null,
                        TotalPrice = row["TotalPrice"] != DBNull.Value ? (decimal?)row["TotalPrice"] : null
                    });
                }
            }
            return list;
        }

        public IEnumerable<shipmentitem> GetshipmentitemByID(int ID)
        {
           DataTable dt= _db.select("sp_crud_shipmentitem", new SqlParameter[]
            {
                new SqlParameter("@action",3),
                new SqlParameter("@ItemId",ID)
            });

            List<shipmentitem> list = new List<shipmentitem>();
            if(dt!=null && dt.Rows.Count>0)
            {
                foreach(DataRow row in dt.Rows)
                {
                    list.Add(new shipmentitem
                    {
                        ItemId = Convert.ToInt32(row["ItemId"]),
                        ShipmentId = row["ShipmentId"] != DBNull.Value ? (int?)row["ShipmentId"] : null,
                        SKU = row["SKU"]?.ToString(),
                        Quantity = row["Quantity"] != DBNull.Value ? (int?)row["Quantity"] : null,
                        TotalPrice = row["TotalPrice"] != DBNull.Value ? (decimal?)row["TotalPrice"] : null
                    });
                }
            }
            return list;
        }

        public int Updateshipmentitem(shipmentitem request)
        {
            throw new NotImplementedException();
        }
    }
}
