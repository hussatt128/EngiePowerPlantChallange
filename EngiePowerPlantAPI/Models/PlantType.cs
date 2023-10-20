using System.Runtime.Serialization;

namespace EngiePowerPlantAPI.Models
{
    public enum PlantType
    {
        [EnumMember(Value = "gasfired")]
        GasFired = 0,
        [EnumMember(Value = "turbojet")]
        TurboJet = 1,
        [EnumMember(Value = "windturbine")]
        WindTurbine = 2
    }
}
