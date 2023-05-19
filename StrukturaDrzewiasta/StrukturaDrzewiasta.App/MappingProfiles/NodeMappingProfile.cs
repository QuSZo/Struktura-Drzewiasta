using AutoMapper;
using StrukturaDrzewiasta.App.Models.DbModels;
using StrukturaDrzewiasta.Shared;

namespace StrukturaDrzewiasta.App.MappingProfiles;

public class NodeMappingProfile : Profile
{
    public NodeMappingProfile()
    {
        CreateMap<CreateNodeDto, Node>();
        CreateMap<EditNodeDto, Node>();
        CreateMap<Node, ReadNodeTreeDto>();
    }
}