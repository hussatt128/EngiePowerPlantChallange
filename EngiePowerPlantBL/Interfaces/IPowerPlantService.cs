using System.Collections.Generic;
using EngiePowePlantBL.Models;

namespace EngiePowePlantBL.Interfaces
{
    public interface IPowerPlantService
    {
        public IEnumerable<PowerOutput> GetProductionPlan(IEnumerable<PowerPlant> powerPlants, float load, Fuel fuel);
    }
}