using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tennis.DataAcces;
using Tennis.Dto;

namespace Tennis.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly Tennis_DbContext _dbContext;

        public GameRepository()
        {
            _dbContext = new Tennis_DbContext();
        }

        public IList<GameResultDto> GetAllGames()
        {
            var games = _dbContext.Game
                        .Include(x => x.PlayerOneResult).ThenInclude(x => x.Player)
                        .Include(x => x.PlayerTwoResult).ThenInclude(x => x.Player);

            var gamesDto = new List<GameResultDto>();
            foreach (var game in games)
            {
                gamesDto.Add(MapGameToGameDto(game));
            }

            return gamesDto;
        }

        public GameResultDto GetGame(int id)
        {
            try
            {
                var game = _dbContext.Game.Include(x => x.PlayerOneResult).ThenInclude(x => x.Player)
                            .Include(x => x.PlayerTwoResult).ThenInclude(x => x.Player).Single(x=>x.Id == id);
               
                return MapGameToGameDto(game);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IList<GameResultDto> GetAllGames(DateTime date)
        {
            var games = _dbContext.Game.Where(x=> x.DatePlayed == date)
                .Include(x => x.PlayerOneResult).ThenInclude(x => x.Player)
                .Include(x => x.PlayerTwoResult).ThenInclude(x => x.Player);

            var gamesDto = new List<GameResultDto>();
            foreach (var game in games)
            {
                gamesDto.Add(MapGameToGameDto(game));
            }

            return gamesDto;
        }


        private GameResultDto MapGameToGameDto(Game game)
        {
            var ground = _dbContext.Ground.Single(x => x.Id == game.GroundId);
            ground.Surface = _dbContext.Surface.Single(x => x.Id == ground.SurfaceId);
            game.Ground = ground;
            var playerOne = new PlayerDto
            {
                Name = game.PlayerOneResult.Player.Name,
                Set1 = game.PlayerOneResult.Set1,
                Set2 = game.PlayerOneResult.Set2,
                Set3 = game.PlayerOneResult.Set3,
                Set4 = game.PlayerOneResult.Set4,
                Set5 = game.PlayerOneResult.Set5,
            };

            var playerTwo = new PlayerDto
            {
                Name = game.PlayerTwoResult.Player.Name,
                Set1 = game.PlayerTwoResult.Set1,
                Set2 = game.PlayerTwoResult.Set2,
                Set3 = game.PlayerTwoResult.Set3,
                Set4 = game.PlayerTwoResult.Set4,
                Set5 = game.PlayerTwoResult.Set5,
            };
            var gameResultDto = new GameResultDto
            {
                Date = game.DatePlayed.ToShortDateString(),
                Surface = game.Ground.Surface.Type,
                Venue = game.Ground.Name,
                PlayerOne = playerOne,
                PlayerTwo = playerTwo
            };

            return gameResultDto;
        }
    }
}
