
using Mapster;
using TeachMeHow.Application.Dtos;
using TeachMeHow.Domain;

namespace TeachMeHow.Infrastructure.Mapping
{
   public class MapsterSettings
    {
        public static void ConfigureMappings()
        {
            TypeAdapterConfig<DummyDto, Dummy>
                .NewConfig()
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.Code, src => src.Code)
                .Map(dest => dest.IsActive, src => src.IsActive);
        }
    }
}
