using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shipmentmgmt_WebapiCore.BusinessLayer.IRepsitory;
using shipmentmgmt_WebapiCore.BusinessLayer.Models;

namespace shipmentmgmt_WebapiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentController : ControllerBase
    {
        private readonly Ishipment _shipment;
        public ShipmentController(Ishipment shipment)
        {
            _shipment = shipment;
        }
        [HttpPost]
        public IActionResult Createshipment(shipment request)
        {
            if (request.OrderId == 0 && request.ToAddressId == 0)
                return BadRequest("please enter orderid and Toaddress");
                int response = _shipment.CreateShipment(request);
            if(response!=null)
                return Ok("shipment created successfully");
            else
                return BadRequest(response);
        }

        [HttpDelete]
        public IActionResult Deleteshipment(int id)
        {
          int response=  _shipment.DeleteShipment(id);
            if (response != null)
                return Ok("shipment deleted successfully");
            else
                return BadRequest("data Not found ");
        }

        [HttpGet]
        public IActionResult GetAllshipment()
        {
            var reponse = _shipment.GetAllShipments();
            // Check the VARIABLE 'reponse', not the System 'Response'
            if (reponse != null)
            {
                return Ok(reponse); // Send the Data
            }
            else
            {
                return BadRequest("Data Not found");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetshipmentById()
        {
            var reponse = _shipment.GetAllShipments();
            // Check the VARIABLE 'reponse', not the System 'Response'
            if (reponse != null)
            {
                return Ok(reponse); // Send the Data
            }
            else
            {
                return BadRequest("Data Not found");
            }
        }


        [HttpPut]
        public IActionResult updateshipment(shipment Updaterequest)
        {
            var reponse = _shipment.UpdateShipment(Updaterequest);
            // Check the VARIABLE 'reponse', not the System 'Response'
            if (reponse != null)
            {
                return Ok("shipment data updated "); // Send the Data
            }
            else
            {
                return BadRequest("Data Not found");
            }
        }
    }
}
