using shipmentmgmt_WebapiCore.BusinessLayer.Models;

namespace shipmentmgmt_WebapiCore.BusinessLayer.IRepsitory
{
    public interface Ishipment
    {
        int CreateShipment(shipment request);
        IEnumerable<shipment> GetShipmentById(int id);
        List<shipment> GetAllShipments(); 
        int UpdateShipment(shipment request);
        int DeleteShipment(int id);
    }
}
