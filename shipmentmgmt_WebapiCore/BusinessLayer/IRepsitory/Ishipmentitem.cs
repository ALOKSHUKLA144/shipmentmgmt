using shipmentmgmt_WebapiCore.BusinessLayer.Models;

namespace shipmentmgmt_WebapiCore.BusinessLayer.IRepsitory
{
    public interface Ishipmentitem
    {

        int Createshipmentitem(shipmentitem request);
        int Deleteshipmentitem(int ID);
        int Updateshipmentitem(shipmentitem request);

        IEnumerable<shipmentitem> GetAllshipmentitems();
        IEnumerable<shipmentitem> GetshipmentitemByID(int ID);


        //Test Push 3

    }
}
