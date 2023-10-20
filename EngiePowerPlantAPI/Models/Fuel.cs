using Newtonsoft.Json;

namespace EngiePowerPlantAPI.Models
{
    public class Fuel
    {
        /// <summary>
        /// the price of gas per MWh
        /// </summary>
        [JsonProperty(PropertyName = "gas(euro/MWh)")]
        public float Gas { get; set; }

        /// <summary>
        /// The price of kerosine per MWh
        /// </summary>
        [JsonProperty(PropertyName = "kerosine(euro/MWh)")]
        public float Kerosine { get; set; }

        /// <summary>
        /// The price of emission allowances (optionally to be taken into account)
        /// </summary>
        [JsonProperty(PropertyName = "co2(euro/ton)")]  
        public float CO2 { get; set; }

        /// <summary>
        /// Percentage of wind
        /// </summary>
        [JsonProperty(PropertyName = "wind(%)")]
        public float Wind { get; set; }

    }
}
