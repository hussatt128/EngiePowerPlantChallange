using System.Collections.Generic;
using EngiePowePlantBL.Models;
using EngiePowePlantBL.Extensions;
using EngiePowePlantBL.Interfaces;

namespace EngiePowePlantBL.Services
{
    public class PowerPlantService: IPowerPlantService
    {
        public IEnumerable<PowerOutput> GetProductionPlan(IEnumerable<PowerPlant> powerPlants, float load, Fuel fuel)
        { 
            return powerPlants
                .GetActualCostAndPower(fuel)
                .OrderByDescending()
                .GetFinalLoad(load);
        }
    }
}