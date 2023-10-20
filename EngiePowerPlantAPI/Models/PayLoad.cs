using Newtonsoft.Json;

namespace EngiePowerPlantAPI.Models
{
    public class PayLoad
    {
        /// <summary>
        /// The load is the amount of energy (MWh) that need to be generated during one hour.
        /// </summary>
        [JsonProperty("load")]
        public float Load { get; set; }

        /// <summary>
        /// Based on the cost of the fuels of each powerplant, the merit-order can be determined.
        /// </summary>
        [JsonProperty("fuels")]
        public Fuel Fuels { get; set; }

        /// <summary>
        /// Describes the powerplants at disposal to generate the demanded load.
        /// </summary>
        [JsonProperty("powerplants")]
        public List<PowerPlant> PowerPlants { get; set; }
    }
}
