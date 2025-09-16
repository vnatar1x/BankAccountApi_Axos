using AutoMapper;

namespace BankAccountApi.Mappers
{
    public class MappingProfile
    {
        public static MapperConfiguration InitializeAutoMapper()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(x =>
            {
                x.AddProfile(new BankMapperProfile());
            });

            return mapperConfiguration;
        }
    }
}