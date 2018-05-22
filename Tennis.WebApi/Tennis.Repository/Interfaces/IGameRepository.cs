using System;
using System.Collections.Generic;
using Tennis.Dto;

namespace Tennis.Repository.Interfaces
{
    public interface IGameRepository
    {
        IList<GameResultDto> GetAllGames();
        GameResultDto GetGame(int id);
        IList<GameResultDto> GetAllGames(DateTime date);
    }
}
