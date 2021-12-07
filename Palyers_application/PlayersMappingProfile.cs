using AutoMapper;
using Pilkarze.Entities;
using Pilkarze.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pilkarze
{
    public class PlayersMappingProfile : Profile
    {
        public PlayersMappingProfile()
        {
            CreateMap<Player, PlayerDto>()
                .ForMember(p => p.CurrentClub, c => c.MapFrom(s => s.Clubs.FirstOrDefault(k => k.Active == true)))
                .ForMember(p => p.FormerClubs, c => c.MapFrom(s => s.Clubs.Where(k => k.Active != true)));

            CreateMap<Club, SoftClubDto>();

            CreateMap<Club, ClubDto>();

            CreateMap<ClubDto, Club>();

            CreateMap<CreatePlayerDto, Player>();

            CreateMap<UpdatePlayerDto, Player>();
        }
    }
}
