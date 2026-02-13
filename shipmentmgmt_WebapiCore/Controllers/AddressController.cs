using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shipmentmgmt_WebapiCore.BusinessLayer.IRepsitory;
using shipmentmgmt_WebapiCore.BusinessLayer.Models;

namespace shipmentmgmt_WebapiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AddressController : ControllerBase
    {
        private readonly Iaddress _iaddress;
        public AddressController(Iaddress iaddress)
        {
            _iaddress = iaddress;
        }
        [HttpGet("{id}")]
        public IActionResult Getaddressbyid(int id)
        {
          var response =  _iaddress.GetaddressById(id);
            if (response != null)
                return Ok(response);
            else
                return BadRequest("Data Not found");
        }

        [HttpGet]
        public IActionResult GetAlldata()
        {
           var dt=  _iaddress.GetAllAddress();
            return Ok(dt);
        }

        [HttpPost]
        public IActionResult createAddress(Address address)
        {
          var response=  _iaddress.createaddress(address);
            if (response == 0)
                return Ok("Address Created Successfully");
            else
            return BadRequest(response);
        }

        [HttpPut]
        public IActionResult updateaddress(Address address)
        {
          int res=  _iaddress.updateAddress(address);
            if (res != null)
                return Ok("Address updated successfully");
            else
                return BadRequest();
        }

        [HttpDelete]
        public IActionResult Deleteaddress(int id)
        {
           int response=  _iaddress.DeleteAddress(id);
            if (response != null)
                return Ok("Address Deleted successfully");
            else
                return BadRequest("deletion failed");
        }
    }
}
