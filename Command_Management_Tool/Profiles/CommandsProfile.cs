using AutoMapper;
using Command_Management_Tool.Dtos;
using Command_Management_Tool.Models;

namespace Command_Management_Tool.Profiles
{
    public class CommandsProfile : Profile // by this inherance, we use AutoMapper registered in Startup.cs->ConfigureServices()
    {
        public CommandsProfile()
        {
            // Create a map from source to destinatioin
            CreateMap<Command, CommandReadDto>();
            // Source is DBContext containing Model info in DbSet<ModelClass>;
            // Destination is Dto that would be sent back to API Client. Dto just contains minimal content that API user needs to know.
        }
    }
}