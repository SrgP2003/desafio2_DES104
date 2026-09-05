using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Eventos.Entities.DTO;
using Eventos.Entities.Models;
using Microsoft.Extensions.Logging;

namespace Eventos.BL.Profiles
{
    public class EventoProfile : Profile
    {
        public EventoProfile()
        {
            CreateMap<Evento, EventoDto>()
                .ForMember(
                    dest => dest.Codigo,
                    opt => opt.MapFrom(src => src.Id)
                )
                .ForMember(
                    dest => dest.NombreEvento,
                    opt => opt.MapFrom(src => src.Nombre)
                )
                .ForMember(
                    dest => dest.FechaEvento,
                    opt => opt.MapFrom(src => src.Fecha)
                )
                .ForMember(
                    dest => dest.LugarEvento,
                    opt => opt.MapFrom(src => src.Lugar)
                );

            CreateMap<EventoDto, Evento>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Codigo)
                )
                .ForMember(
                    dest => dest.Nombre,
                    opt => opt.MapFrom(src => src.NombreEvento)
                )
                .ForMember(
                    dest => dest.Fecha,
                    opt => opt.MapFrom(
                        src => src.FechaEvento!.Value
                    )
                )
                .ForMember(
                    dest => dest.Lugar,
                    opt => opt.MapFrom(src => src.LugarEvento)
                );
        }
    }
}