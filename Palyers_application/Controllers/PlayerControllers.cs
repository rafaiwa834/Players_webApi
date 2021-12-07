using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pilkarze.Entities;
using Pilkarze.Models;
using Pilkarze.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Pilkarze.Controllers
{
    [Route("app")]
    [ApiController]
    public class PlayerControllers : ControllerBase
    {
        private readonly PlayerServices _playerServices;
        private readonly PlayerDBContext _dbContext;

        public PlayerControllers(PlayerServices playerServices, PlayerDBContext dbContext)
        {
            _playerServices = playerServices;
            _dbContext = dbContext;
        }

        [HttpGet("players")]
        public ActionResult<IEnumerable<PlayerDto>> DipslayPlayers()
        {
            var results = _playerServices.DipslayPlayers();

            return Ok(results);
        }
        [HttpGet("players/{id}")]
        public ActionResult<PlayerDto> DisplayPlayerByID([FromRoute] int id)
        {
            var results = _playerServices.DipslayPlayerById(id);

            return Ok(results);
        }
        [HttpPut("players/{id}")]
        public ActionResult<PlayerDto> UpdatePlayer([FromRoute] int id, [FromBody] UpdatePlayerDto updatePlayer)
        {
            var results = _playerServices.UpdatePlayer(id,updatePlayer);
            return Ok(results);
        }
        [HttpDelete("players/{id}")]
        public ActionResult<string> DeletePlayer ([FromRoute] int id)
        {
            _playerServices.DeletePlayer(id);
            return Ok("Poprawnie usunieto pilkarza o id = " + id);
        }

        [HttpPost("players")]
        public ActionResult<string> AddPlayer([FromBody] CreatePlayerDto player)
        {
            var playerId = _playerServices.AddPlayer(player);

            return Ok("Pomyslnie dodano nowego zawodnika \n Adres: ...app/players/" + playerId);
        }
        [HttpGet("clubs")]
        public ActionResult<IEnumerable<string>> DisplayClubs()
        {
            var results = _playerServices.DisplayClubs();

            return Ok(results);
        }

    

    }
}
