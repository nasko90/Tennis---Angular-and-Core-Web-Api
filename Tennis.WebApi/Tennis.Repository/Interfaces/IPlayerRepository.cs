using System.Collections.Generic;
using Tennis.Dto;

namespace Tennis.Repository.Interfaces
{
    public interface IPlayerRepository
    {
        IList<PlayerDto> GetPlayers();
    }
}
