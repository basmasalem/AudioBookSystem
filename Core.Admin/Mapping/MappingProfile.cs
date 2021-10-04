using AutoMapper;
using Core.Admin.Models.ViewModels;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Admin.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Podcast, PodcastVM>();
            CreateMap<PodcastVM, Podcast>();
        }
    }
}
