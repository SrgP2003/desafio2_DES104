using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Eventos.Entities.DTO;
using Eventos.Entities.Models;

namespace Eventos.BL.Profiles
{
    public class ParticipanteProfile : Profile
    {
        public ParticipanteProfile()
        {
            CreateMap<Participante, ParticipanteDto>()
                .ForMember(
                    dest => dest.Codigo,
                    opt => opt.MapFrom(src => src.Id)
                )
                .ForMember(
                    dest => dest.NombreParticipante,
                    opt => opt.MapFrom(src => src.Nombre)
                )
                .ForMember(
                    dest => dest.CorreoElectronico,
                    opt => opt.MapFrom(src => src.Email)
                )
                .ForMember(
                    dest => dest.EventoCodigo,
                    opt => opt.MapFrom(src => src.EventoId)
                );

            CreateMap<ParticipanteDto, Participante>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Codigo)
                )
                .ForMember(
                    dest => dest.Nombre,
                    opt => opt.MapFrom(
                        src => src.NombreParticipante
                    )
                )
                .ForMember(
                    dest => dest.Email,
                    opt => opt.MapFrom(
                        src => src.CorreoElectronico
                    )
                )
                .ForMember(
                    dest => dest.EventoId,
                    opt => opt.MapFrom(src => src.EventoCodigo)
                );
        }
    }
}