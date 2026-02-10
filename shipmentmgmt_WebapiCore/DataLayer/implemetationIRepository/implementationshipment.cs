using Microsoft.Data.SqlClient;
using shipmentmgmt_WebapiCore.BusinessLayer.IRepsitory;
using shipmentmgmt_WebapiCore.BusinessLayer.Models;
using System.Collections.Generic;
using System.Data;
namespace shipmentmgmt_WebapiCore.DataLayer.implemetationIRepository
{
    public class implementationshipment : Ishipment
    {
        private readonly dataaccess _db;
        public implementationshipment(dataaccess dataaccess)
        {
            _db = dataaccess;
        }
        public int CreateShipment(shipment request)
        {
          int res=  _db.ExecuteNOnquery("sp_crud_shipment", new SqlParameter[]
            {
                new SqlParameter("@OrderId",request.OrderId),
                new SqlParameter("@FromAddressId",request.FromAddressId),
                new SqlParameter("@ToAddressId",request.ToAddressId),
                new SqlParameter("@CarrierName",request.CarrierName),
                new SqlParameter("@TrackingNumber",request.TrackingNumber),
                new SqlParameter("@Status",request.Status),
               // new SqlParameter("@CreatedDate",request.CreatedDate),
                new SqlParameter("@PaymentMethod",request.PaymentMethod),
                new SqlParameter("@PaymentStatus",request.PaymentStatus),
                new SqlParameter("@PaymentTransactionId",request.PaymentTransactionId),
                new SqlParameter("@AmountPaid",request.AmountPaid),
                new SqlParameter("@action",1)
            });
            return res;
        }

        public int DeleteShipment(int id)
        {
           int res=  _db.Executescaler("sp_crud_shipment", new SqlParameter[]
            {
                new SqlParameter("@ShipmentId",id),
                new SqlParameter("@action",4)
            });
            return res;
        }

        public List<shipment> GetAllShipments()
        {
            DataTable dt = _db.select("sp_crud_shipment", new SqlParameter[]
            {
                new SqlParameter("@action",5)
            });

            List<shipment> list = new List<shipment>();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new shipment
                    {
                        // Use "as int?" for safe nullable casting
                        ShipmentId = row["ShipmentId"] as int?,
                        OrderId = row["OrderId"] as int?,
                        FromAddressId = row["FromAddressId"] as int?,
                        ToAddressId = row["ToAddressId"] as int?,
                        // Handle DBNull for strings safely
                        CarrierName = row["CarrierName"]?.ToString(),
                        TrackingNumber = row["TrackingNumber"]?.ToString(),
                        Status = row["Status"]?.ToString(),
                        PaymentMethod = row["PaymentMethod"]?.ToString(),
                        PaymentStatus = row["PaymentStatus"]?.ToString(),
                        PaymentTransactionId = row["PaymentTransactionId"]?.ToString(),
                        CreatedDate= Convert.ToDateTime(row["CreatedDate"]),
                        // Handle Money/Decimal safely
                        AmountPaid = row["AmountPaid"] != DBNull.Value ? Convert.ToDecimal(row["AmountPaid"]) : (decimal?)null
                    });
                }
            }
            return list;
        }

        public IEnumerable<shipment>  GetShipmentById(int id)
        {
                DataTable dt = _db.select("sp_crud_shipment", new SqlParameter[]
                  {
                new SqlParameter("@action",5),
                new SqlParameter("@@ShipmentId",id),
                  });

            List<shipment> list = new List<shipment>();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new shipment
                    {
                        // Use "as int?" for safe nullable casting
                        ShipmentId = row["ShipmentId"] as int?,
                        OrderId = row["OrderId"] as int?,
                        FromAddressId = row["FromAddressId"] as int?,
                        ToAddressId = row["ToAddressId"] as int?,
                        // Handle DBNull for strings safely
                        CarrierName = row["CarrierName"]?.ToString(),
                        TrackingNumber = row["TrackingNumber"]?.ToString(),
                        Status = row["Status"]?.ToString(),
                        PaymentMethod = row["PaymentMethod"]?.ToString(),
                        PaymentStatus = row["PaymentStatus"]?.ToString(),
                        PaymentTransactionId = row["PaymentTransactionId"]?.ToString(),
                        // Handle Money/Decimal safely
                        AmountPaid = row["AmountPaid"] != DBNull.Value ? Convert.ToDecimal(row["AmountPaid"]) : (decimal?)null
                    });
                }
            }
            return list;
        }

        public int UpdateShipment(shipment request)
        {
            int res = _db.ExecuteNOnquery("sp_crud_shipment", new SqlParameter[]
              {
                new SqlParameter("@ToAddressId",request.ToAddressId),
                new SqlParameter("@CarrierName",request.CarrierName),
                new SqlParameter("@TrackingNumber",request.TrackingNumber),
                new SqlParameter("@Status",request.Status),
               // new SqlParameter("@CreatedDate",request.CreatedDate),
                new SqlParameter("@PaymentStatus",request.PaymentStatus),
                new SqlParameter("@PaymentTransactionId",request.PaymentTransactionId),
                new SqlParameter("@AmountPaid",request.AmountPaid),
                new SqlParameter("@ShipmentId",request.ShipmentId),
                new SqlParameter("@PaymentMethod",request.PaymentMethod),
                new SqlParameter("@action",3)
              });
            return res;
        }
    }
}
