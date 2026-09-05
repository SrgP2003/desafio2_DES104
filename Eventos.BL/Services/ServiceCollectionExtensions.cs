using System;
using System.Collections.Generic;
using System.Text;
using Eventos.BL.Interfaces;
using Eventos.BL.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace Eventos.BL.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceConnector(
            this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<EventoProfile>();
                cfg.AddProfile<ParticipanteProfile>();
                cfg.AddProfile<OrganizadorProfile>();
            });

            services.AddScoped<
                IEventoService,
                EventoService
            >();

            services.AddScoped<
                IParticipanteService,
                ParticipanteService
            >();

            services.AddScoped<
                IOrganizadorService,
                OrganizadorService
            >();

            return services;
        }
    }
}
