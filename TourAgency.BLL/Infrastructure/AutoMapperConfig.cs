﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using TourAgency.BLL.DTO;
using TourAgency.DAL.Entities;

namespace TourAgency.BLL.Infrastructure
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
#pragma warning disable CS0618 
            Mapper.Initialize(config =>
            {
                config.CreateMap<Role, RoleDto>();

                config.CreateMap<Image, string>()
                .ConstructUsing(i => i.Picture.Replace("\\\\", "\\"));


                config.CreateMap<Node, CityDto>()
                    .ForMember(c => c.Name,
                        c => c
                            .MapFrom(e => e.City.Name))
                    .ForMember(c => c.CountryName,
                        c => c
                            .MapFrom(e => e.City.Country.Name))
                    .ForMember(c => c.Id,
                        c => c
                            .MapFrom(e => e.CityId));

                config.CreateMap<User, String>()
                    .ConvertUsing(u => u.UserName);

                config.CreateMap<User, UserDto>()
                    .ForMember(u => u.RoleId,
                        u => u
                            .MapFrom(e => e.Roles.First()
                                .RoleId));

                config.CreateMap<City, CityDto>()
                    .ForMember(c => c.CountryName,
                        u => u
                            .MapFrom(e => e.Country.Name));

                config.CreateMap<Country, CountryDto>();

                config.CreateMap<Tour, TourDto>()
                .ForMember(t => t.UserNames, t => t
                .MapFrom(e => Mapper.Map<IEnumerable<User>, IEnumerable<String>>(e.Users)))
                .ForMember(t => t.Cities, t => t
                .MapFrom(e => Mapper.Map<IEnumerable<Node>, IEnumerable<CityDto>>(e.Nodes
                .OrderBy(n => n.OrderNumber))))
                .ForMember(t => t.Images, t => t.MapFrom(e => Mapper.Map<IEnumerable<Image>, IEnumerable<string>>(e.Images)));

            });
#pragma warning restore CS0618 
        }
    }
}