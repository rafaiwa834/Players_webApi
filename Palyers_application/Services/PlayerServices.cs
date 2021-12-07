using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pilkarze.Entities;
using Pilkarze.Exceptions;
using Pilkarze.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Pilkarze.Services
{
    public interface IPlayerServices
    {

    }
    public class PlayerServices : IPlayerServices
    {
        private List<Player> _players;
        private PlayerDBContext _dbContext;
        private IMapper _mapper;

        public PlayerServices(PlayerDBContext dBContext, IMapper mapper)
        {
            _players = new List<Player>();
            _dbContext = dBContext;
            _mapper = mapper;
        }

        public IEnumerable<PlayerDto> DipslayPlayers()
        {
            var results = _dbContext
                .Players
                .Include(r => r.Clubs)
                .ToList();

            

            var playersDto = _mapper.Map<List<PlayerDto>>(results);

            return playersDto;
        }

        public IEnumerable<string> DisplayClubs()
        {
            var results = _dbContext
                .Clubs
                .Select(m=> "Name: " + m.Name + " Nation: " + m.Nation).Distinct()
                .ToList();

            return results;
        }

        public PlayerDto DipslayPlayerById(int id)
        {
            var results = _dbContext
                .Players
                .Include(p=>p.Clubs)
                .FirstOrDefault(p => p.PlayerId == id);

            if (results is null)
            {
                Console.WriteLine("Jestem w ErrorMiddleware");
                throw new NotFound("Nie ma pilakrzy w BD");
            }

            var player = _mapper.Map<PlayerDto>(results);

            return player;
        }

        public void DeletePlayer(int id)
        {
            var resultsClubs = _dbContext
                .Clubs
                .Where(p => p.PlayerId == id)
                .ToList();

            _dbContext.Clubs.RemoveRange(resultsClubs);
            
            var resultsPlayer = _dbContext
                .Players
                .FirstOrDefault(p => p.PlayerId == id);

            _dbContext.Players.Remove((Player)resultsPlayer);
            _dbContext.SaveChanges();
        }

        public int AddPlayer(CreatePlayerDto playerDto)
        {
            var player = _mapper.Map<Player>(playerDto);
            _dbContext.Players.Add(player);
            _dbContext.SaveChanges();
             return player.PlayerId;
        }

        public PlayerDto UpdatePlayer(int id, UpdatePlayerDto updatePlayer)
        {
            var player = _dbContext
                .Players
                .Include(p=>p.Clubs)
                .FirstOrDefault(p => p.PlayerId == id);

            if(player is null)
            {

            }

            var currentclub = _dbContext
                 .Clubs
                 .FirstOrDefault(p => p.PlayerId == id && p.Active == true);

            
            currentclub.Active = false;
            var newclub = _mapper.Map<Club>(updatePlayer.currentClub);
            newclub.Active = true;

            player.Clubs.Add(newclub);

            player.Goals = updatePlayer.Goals;
            player.Position = updatePlayer.Position;
            player.TotalMatches = updatePlayer.TotalMatches;
            player.Nationality = updatePlayer.Nationality;

            _dbContext.SaveChanges();

            var results = _mapper.Map<PlayerDto>(player);

            //return currentclub.Name;
            return results;
        }
    }
}
