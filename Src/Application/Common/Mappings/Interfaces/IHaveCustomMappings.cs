using AutoMapper;

namespace SqzTo.Application.Common.Mappings.Interfaces
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}
