using AutoMapper;
using CommandsService.Dtos;
using CommandsService.Models;
using PlatformService;

namespace CommandsService.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            // Source -> Target
            CreateMap<Platform, PlatformReadDto>();
            CreateMap<CommandCreateDto, Command>();
            CreateMap<Command, CommandReadDto>();
            CreateMap<PlatformPublishedDto, Platform>()
                .ForMember(destination => destination.ExternalId, opt => opt.MapFrom(source => source.Id));
            CreateMap<GrpcPlatformModel, Platform>()
                .ForMember(destination => destination.ExternalId, source => source.MapFrom(source => source.PlatformId))
                .ForMember(destination => destination.Name, source => source.MapFrom(source => source.Name))
                .ForMember(destination => destination.Commands, opt => opt.Ignore());
        }
    }
}
