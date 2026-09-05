using System;
using System.Collections.Generic;
using System.Text;
using Eventos.DAL.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Eventos.DAL.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositoryConnector(
            this IServiceCollection services)
        {
            services.AddScoped<
                IDatabaseRepository,
                DatabaseRepository
            >();

            services.AddScoped<
                IEventoRepository,
                EventoRepository
            >();

            services.AddScoped<
                IParticipanteRepository,
                ParticipanteRepository
            >();

            services.AddScoped<
                IOrganizadorRepository,
                OrganizadorRepository
            >();

            return services;
        }
    }
}