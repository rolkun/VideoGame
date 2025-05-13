using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VideoGame.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {
        static private List<VideoGame> videoGames = new List<VideoGame>
        {
            new VideoGame
            {
                Id = 1, Title = "The Legend of Zelda: Breath of the Wild",
                Platform = "Nintendo Switch",
                Developer = "Nintendo",
                Publisher = "Nintendo"
            },
            new VideoGame
            {
                Id = 2,
                Title = "The Witcher 3: Wild Hunt",
                Platform = "PC",
                Developer = "CD Projekt Red",
                Publisher = "CD Projekt"
            },
            new VideoGame
            {
                Id = 3,
                Title = "Dark Souls III",
                Platform = "PC",
                Developer = "FromSoftware",
                Publisher = "Bandai Namco Entertainment"
            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<VideoGame>> GetAllVideoGames()
        {
            return Ok(videoGames);
        }

        [HttpGet("{id}")]
        public ActionResult<VideoGame> GetVideoGameById(int id)
        {
            var videoGame = videoGames.FirstOrDefault(v => v.Id == id);
            if (videoGame == null)
            {
                return NotFound();
            }
            return Ok(videoGame);
        }
    }
}
