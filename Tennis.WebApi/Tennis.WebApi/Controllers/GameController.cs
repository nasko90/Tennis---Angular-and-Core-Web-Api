using System;
using Microsoft.AspNetCore.Mvc;
using Tennis.Repository.Interfaces;

namespace Tennis.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class GameController : Controller
    {
        private readonly IGameRepository _gameRepository;

        public GameController(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var games = _gameRepository.GetAllGames();
            return Json(games);
        }

        [HttpGet("id/{id}")]
        public JsonResult Get(int id)
        {
            var game = _gameRepository.GetGame(id);
            return Json(game);
        }

        [HttpGet("date/{dateTime}")]
        public JsonResult Get(string dateTime)
        {
            var date = DateTime.Parse(dateTime);
            var games = _gameRepository.GetAllGames(date);
            if (games.Count < 1)
            {
                return Json("No games were played on the seleted date.");
            }
            return Json(games);
        }
    }
}
