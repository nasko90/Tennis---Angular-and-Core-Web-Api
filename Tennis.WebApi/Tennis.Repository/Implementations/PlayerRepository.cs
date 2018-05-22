using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tennis.DataAcces;
using Tennis.Dto;
using Tennis.Repository.Interfaces;

namespace Tennis.Repository.Implementations
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly Tennis_DbContext _dbContext;

        public PlayerRepository()
        {
            _dbContext = new Tennis_DbContext();
        }
        public IList<PlayerDto> GetPlayers()
        {
            List<PlayerDto> players = _dbContext.Player.Select(x => new PlayerDto{Name = x.Name}).ToList();
            return players;

        }
    }
}
