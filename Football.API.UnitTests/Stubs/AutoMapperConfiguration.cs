using AutoMapper;
using System;

namespace Football.API.UnitTests.Stubs
{
    public static class AutoMapper
    {
        public static IMapper GenerateAutoMapper()
        {
            var configuration = new MapperConfiguration(cfg => {
                cfg.AddProfile(new AutoMapperConfiguration());
            });
            configuration.CompileMappings();
            var mapper = configuration.CreateMapper() ?? throw new Exception("Couldn't create mapper!");
            return mapper;
        }
    }
}
