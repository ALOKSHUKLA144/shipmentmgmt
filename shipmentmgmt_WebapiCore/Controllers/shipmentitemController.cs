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
    public class shipmentitemController : ControllerBase
    {
        private readonly Ishipmentitem _ishipmentitem;
        public shipmentitemController(Ishipmentitem ishipmentitem)
        {
            _ishipmentitem = ishipmentitem;
        }

        [HttpPost]
        public IActionResult createshipmentitem(shipmentitem request)
        {
           int response= _ishipmentitem.Createshipmentitem(request);
            if (response != null)
                return Ok("shipmentItem created successfully");
            else
                return BadRequest();

        }

        [HttpDelete("{ID}")]
        public IActionResult Deleteshipmentitem(int ID)
        {
          int response=  _ishipmentitem.Deleteshipmentitem(ID);
            if (response != null)
                return Ok("shipmentitem deleted successfully");
            else
                return BadRequest();
        }

        [HttpGet]
        public IActionResult Getallshipmentitem()
        {
           var dt=  _ishipmentitem.GetAllshipmentitems();
            if (dt != null)
                return Ok(dt);
            else
                return Ok("Data Not Found");
        }

        [HttpGet("{id}")]
        public IActionResult Getshipmentbyid(int id)
        {
            var dt = _ishipmentitem.GetshipmentitemByID(id);
            if (dt != null)
                return Ok(dt);
            else
                return Ok("Data Not Found");
        }
    }
}
