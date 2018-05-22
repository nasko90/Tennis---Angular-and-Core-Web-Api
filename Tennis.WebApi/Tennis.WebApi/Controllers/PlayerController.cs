using Microsoft.AspNetCore.Mvc;
using Tennis.Repository.Interfaces;


namespace Tennis.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PlayerController : Controller
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var players = _playerRepository.GetPlayers();
            return Json(players);
        }
    }
}
