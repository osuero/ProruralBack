using AutoMapper;

namespace ProRualBackEnd.Mappers
{
    public static class MappingConfigurations
    {
        public static void RegisterMappings(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UserProfile());
                mc.AddProfile(new ProjectProfile());
                mc.AddProfile(new BeneficiaryProfile());
                mc.AddProfile(new OrganizationProfile());
                mc.AddProfile(new ProductionCategoryProfile());
                mc.AddProfile(new FundProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
