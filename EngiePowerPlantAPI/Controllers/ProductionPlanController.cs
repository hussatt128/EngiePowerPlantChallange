using AutoMapper;
using EngiePowePlantBL.Interfaces;
using EngiePowerPlantAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EngiePowerPlantAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductionPlanController : ControllerBase
    {
        private readonly IPowerPlantService _iPowerPlantService;
        private readonly IMapper _mapper;

        public ProductionPlanController(IPowerPlantService iPowerPlantService, IMapper mapper)
        {
            _iPowerPlantService = iPowerPlantService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult GetPowerOutputs([FromBody] PayLoad payload)
        {
            var _powerPlants = payload.PowerPlants.Select(pp => _mapper.Map<EngiePowePlantBL.Models.PowerPlant>(pp));
            var _fuel = _mapper.Map<EngiePowePlantBL.Models.Fuel>(payload.Fuels);
            return Ok(_iPowerPlantService.GetProductionPlan(_powerPlants, payload.Load, _fuel));
        }
    }
}
