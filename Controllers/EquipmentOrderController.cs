using Microsoft.AspNetCore.Mvc;
using ManufacturingEquipmentOrderProject.Models;
using ManufacturingEquipmentOrderProject.Services;

namespace ManufacturingEquipmentOrderProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipmentOrderController : ControllerBase
    {
        private readonly DatabaseService _databaseService;

        public EquipmentOrderController(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        [HttpPost]
        public IActionResult SubmitOrder([FromBody] EquipmentOrder order)
        {
            _databaseService.SaveEquipmentOrder(order);
            return Ok("Order saved successfully");
        }
    }
}