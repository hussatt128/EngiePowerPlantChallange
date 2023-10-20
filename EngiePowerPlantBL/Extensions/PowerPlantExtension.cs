using EngiePowePlantBL.Models;

namespace EngiePowePlantBL.Extensions
{
    public static class PowerPlantExtension
    {
        public static IEnumerable<PowerPlant> GetActualCostAndPower(this IEnumerable<PowerPlant> powerPlants,
            Fuel fuel)
        {
            List<PowerPlant> plants = new List<PowerPlant>();
            foreach (var plant in powerPlants)
            {
                plant.ActualPMax = CalculatePMax(plant, fuel);
                plant.FuelCost = CalculateFuelCost(plant, fuel);
                plants.Add(plant);
            }
            return plants;
        }

        private static float CalculateFuelCost(this PowerPlant powerPlant, Fuel fuel)
        {
            switch (powerPlant.Type)
            {
                case PlantType.WindTurbine:
                    return 0.0f;

                case PlantType.GasFired: // Gas emits extra 0.3 ton Co2 per MWh
                    return (fuel.Gas * 0.3f * fuel.CO2)/ powerPlant.Efficiency;

                default:
                    return fuel.Kerosine / powerPlant.Efficiency;
            }
        }
        
        private static float CalculatePMax(this PowerPlant powerPlant, Fuel fuel)
        {
            if (powerPlant.Type != PlantType.WindTurbine)
            {
                return powerPlant.PMax;
            }

            return powerPlant.PMax / 100.0f * fuel.Wind;
        }
        
        public static IEnumerable<PowerPlant> OrderByDescending (this IEnumerable<PowerPlant> powerPlants)
        {
            return powerPlants.OrderByDescending(i => i.Efficiency)
                .ThenBy(i => i.FuelCost)
                .ThenByDescending(i => i.ActualPMax);
        }
        
        public static IEnumerable<PowerOutput> GetFinalLoad(this IEnumerable<PowerPlant> powerPlants, float load)
         {
             var finalPPList = new List<PowerOutput>();
             var plantLoad = load;

            foreach ( var pp in powerPlants) 
            {
                // if Pmax is 0 or the load is less than the PMin
                if (pp.ActualPMax == 0 || pp.PMin > plantLoad)
                {
                    finalPPList.Add(new PowerOutput()
                    {
                        Name = pp.Name,
                        P = 0.0f,
                    });
                    continue;
                }
                // if the load is between PMin and PMax
                if (plantLoad <= pp.ActualPMax && plantLoad >= pp.PMin)
                {
                    finalPPList.Add(new PowerOutput()
                    {
                        Name = pp.Name,
                        P = (float)Math.Round(plantLoad, 1),
                    });
                    plantLoad = 0.0f;
                    continue;
                }

                // if load is greater than PMax, then PMax is the maximum power generated.
                finalPPList.Add(new PowerOutput()
                {
                    Name = pp.Name,
                    P = (float)Math.Round(pp.ActualPMax, 1),
                });
                plantLoad -= pp.ActualPMax;
            }

             return finalPPList;
         }
    }
}