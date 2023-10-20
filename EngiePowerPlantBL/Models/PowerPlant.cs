namespace EngiePowePlantBL.Models
{
    public class PowerPlant
        {
            public string Name { get; set; }
        
            public PlantType Type { get; set; }

            public float Efficiency { get; set; }

            public float PMin { get; set; }
        
            public float PMax { get; set; }
            
            public float FuelCost { get; set; }

            public float ActualPMax { get; set; }
        
        }
    }
