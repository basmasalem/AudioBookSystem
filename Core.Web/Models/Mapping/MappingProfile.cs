using AutoMapper;
using Core.Model;
using Core.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Web.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Audio, AudioModel>();
            CreateMap<AudioModel, Audio>();
            CreateMap<RegisterVM, Client>();
            CreateMap<Client, RegisterVM>();
            CreateMap<Podcast, PodcastModel>();
            CreateMap<PodcastModel, Podcast>();
            CreateMap<PrintBook, PrintBookModel>();
            CreateMap<PrintBookModel, PrintBook>();
            CreateMap<Client, EditProfileModel>();
            CreateMap<EditProfileModel, Client>();
    
        }
    }
}
