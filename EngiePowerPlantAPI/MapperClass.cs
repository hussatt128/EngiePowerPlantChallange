using AutoMapper;

namespace EngiePowerPlantAPI
{
    /// <summary>
    /// Mapper Class used to Map the API layer data Models to the BL models.
    /// </summary>
    public class MapperClass : Profile
    {
        public MapperClass()
        {
            CreateMap<Models.PowerPlant, EngiePowePlantBL.Models.PowerPlant>().ReverseMap();
            CreateMap<Models.PlantType, EngiePowePlantBL.Models.PlantType>().ReverseMap();
            CreateMap<Models.Fuel, EngiePowePlantBL.Models.Fuel>().ReverseMap();
        }
    }
}
