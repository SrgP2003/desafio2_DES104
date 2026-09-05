using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Eventos.Entities.DTO;
using Eventos.Entities.Models;

namespace Eventos.BL.Profiles
{
    public class OrganizadorProfile : Profile
    {
        public OrganizadorProfile()
        {
            CreateMap<Organizador, OrganizadorDto>()
                .ForMember(
                    dest => dest.Codigo,
                    opt => opt.MapFrom(src => src.Id)
                )
                .ForMember(
                    dest => dest.NombreOrganizador,
                    opt => opt.MapFrom(src => src.Nombre)
                )
                .ForMember(
                    dest => dest.CargoOrganizador,
                    opt => opt.MapFrom(src => src.Cargo)
                )
                .ForMember(
                    dest => dest.EventoCodigo,
                    opt => opt.MapFrom(src => src.EventoId)
                );

            CreateMap<OrganizadorDto, Organizador>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Codigo)
                )
                .ForMember(
                    dest => dest.Nombre,
                    opt => opt.MapFrom(
                        src => src.NombreOrganizador
                    )
                )
                .ForMember(
                    dest => dest.Cargo,
                    opt => opt.MapFrom(
                        src => src.CargoOrganizador
                    )
                )
                .ForMember(
                    dest => dest.EventoId,
                    opt => opt.MapFrom(src => src.EventoCodigo)
                );
        }
    }
}
