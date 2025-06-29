using Microsoft.AspNetCore.Mvc;
using DanMotor.Business;
using DanMotor.Common;
using DanMotor.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DanMotorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanMotorController : Controller
    {
        private readonly MotorService motorService;

        public DanMotorController()
        {
            
            IDataStore dataStore = new DbMotoDataStore();
            motorService = new MotorService(dataStore);
        }

        [HttpGet("brands")]
        public ActionResult<List<string>> GetBrands()
        {
            return Ok(motorService.GetBrands());
        }

        [HttpGet("models")]
        public ActionResult<List<string>> GetModels([FromQuery] string brand)
        {
            return Ok(motorService.GetModels(brand));
        }

        [HttpGet("concepts")]
        public ActionResult<List<string>> GetConcepts([FromQuery] string brand, [FromQuery] string model)
        {
            return Ok(motorService.GetConcepts(brand, model));
        }

        [HttpGet("parts")]
        public ActionResult<List<string>> GetParts([FromQuery] string brand, [FromQuery] string model, [FromQuery] string concept)
        {
            return Ok(motorService.GetParts(brand, model, concept));
        }

        [HttpPost("add")]
        public ActionResult<bool> AddPart([FromQuery] string brand, [FromQuery] string model, [FromQuery] string concept, [FromQuery] string part)
        {
            var result = motorService.AddPart(brand, model, concept, part);
            return Ok(result);
        }

        [HttpPatch("edit")]
        public ActionResult<bool> EditPart([FromQuery] string brand, [FromQuery] string model, [FromQuery] string concept, [FromQuery] string oldPart, [FromQuery] string newPart)
        {
            var result = motorService.EditPart(brand, model, concept, oldPart, newPart);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public ActionResult<bool> DeletePart([FromQuery] string brand, [FromQuery] string model, [FromQuery] string concept, [FromQuery] string part)
        {
            var result = motorService.DeletePart(brand, model, concept, part);
            return Ok(result);
        }

        [HttpGet("search")]
        public ActionResult<List<string>> SearchParts([FromQuery] string brand, [FromQuery] string model, [FromQuery] string concept, [FromQuery] string keyword)
        {
            return Ok(motorService.SearchParts(brand, model, concept, keyword));
        }
    }
}
