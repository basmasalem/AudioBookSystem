using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Core.Data.Repositories;
using Core.Model;

namespace Core.Admin
{
    public static  class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure DbContext with Scoped lifetime   
            services.AddDbContext<AudioKetabDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlCon")).UseLazyLoadingProxies();
            });
            return services;
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }


        //public static IServiceCollection AddRepositories(this IServiceCollection services)
        //{
        //    return services
        //        //.AddScoped<IUserRepository, UserRepository>()
        //        //.AddScoped<IPodcastRepository, PodcastRepository>()
        //        //.AddScoped<IAttachmentRepository, AttachmentRepository>()
        //        //.AddScoped<ICategoryRepository, CategoryRepository>()
        //        //.AddScoped<IAudioTypeRepository, AudioTypeRepository>()
        //        //.AddScoped<IAudioRepository, AudioRepository>()
        //        //.AddScoped<IContactUsRepository, ContactUsRepository>()
        //        //.AddScoped<IClientRepository, ClientRepository>()
        //        //.AddScoped<IPodcastAudioRepository, PodcastAudioRepository>()
        //        //.AddScoped<IPodcastParticipantRepository, PodcastParticipantRepository>()
        //        //.AddScoped<IArticleRepository, ArticleRepository>()
        //        //.AddScoped<ITagRepository, TagRepository>()
        //        //.AddScoped<IAboutUsRepository, AboutUsRepository>()
        //        //.AddScoped<ISettingRepository, SettingRepository>();

        //    ;
        //}
    }
}
