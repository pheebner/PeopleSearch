using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PeopleSearch.Business.Interfaces;
using PeopleSearch.Business.Services;
using PeopleSearch.IoC.Configuration.AutoMapperProfiles;
using PeopleSearch.Persistence;
using PeopleSearch.Persistence.Repositories;
using PeopleSearch.Persistence.Repositories.Interfaces;

namespace PeopleSearch.IoC.Configuration.DependencyInjection
{
    public static class DependencyInjectionHelper
    {
        private const string PEOPLE_SEARCH_DATABASE_CONNECTION_STRING_NAME = "PeopleSearchDatabase";

        public static void InjectDependencies(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IPeopleSearchContext, PeopleSearchContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString(PEOPLE_SEARCH_DATABASE_CONNECTION_STRING_NAME)));

            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IPersonService, PersonService>();

            var mappingConfig = new MapperConfiguration(ce => ce.AddProfile(new ServiceMappingProfile()));
            services.AddSingleton(mappingConfig.CreateMapper());
        }
    }
}
