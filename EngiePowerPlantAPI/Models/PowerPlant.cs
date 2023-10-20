using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace EngiePowerPlantAPI.Models
{
    public class PowerPlant
    {
        public string Name { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public PlantType Type { get; set; }
        public float Efficiency { get; set; }
        public float PMin { get; set; }
        public float PMax { get; set; }
    }
}
