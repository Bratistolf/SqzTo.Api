using AutoMapper;
using System.Reflection;

namespace SqzTo.Application.Common.Mappings
{
    public class AutoMapperConfig
    {
        public static IMapperConfigurationExpression MapperConfigurationExpression = null;

        public MapperConfiguration Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                MapperConfigurationExpression = cfg;
                cfg.AddMaps(Assembly.GetExecutingAssembly());
            });

            return config;
        }
    }
}
