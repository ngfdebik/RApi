using Microsoft.AspNetCore.Mvc;
using RestApiTicTacToe;
using RestApiTicTacToe.Models;
using System.Net;

namespace RApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly ILogger<GameController> _logger;

        public GameController(ILogger<GameController> logger)
        {
            _logger = logger;
        }
        public static List<GameField> GameField = new List<GameField>();

        private GameField Create(int GameId)
        {
            GameField.Add(new GameField(GameId));
            return GameField[GameField.Count - 1];
        }

        [HttpGet("{id}")]
        public GameField Get(int id)
        {
            return GameField.FirstOrDefault(gf => gf.GameId == id);
        }

        [HttpPost("{id}")]
        public ActionResult Post(int id)
        {
            if(GameField.Any(gf => gf.GameId == id))
            {
                return this.StatusCode((int)HttpStatusCode.Conflict);
            }
            else
            {
                Create(id);
                return this.Ok();
            }
        }

        [HttpPatch("{id}, {type}, {cellid}")]
        public ActionResult Patch(int id, int type, int cellid)
        {
            int index = GameField.FindIndex(gf => gf.GameId == id);
            if(index < 0)
            {
                return this.StatusCode((int)HttpStatusCode.NotFound);
            }
            else
            {
                if (type >= 0 && type < 3)
                {
                    GameField[index].Update(cellid, (CellsTypes)type);
                    GameField[index].Winner = new Wins().IsWin(GameField[index].Cells);
                    return this.Ok();
                }
                else
                {
                    return this.StatusCode((int)HttpStatusCode.Conflict);
                }
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            int index = GameField.FindIndex(gf => gf.GameId == id);
            if (index < 0)
            {
                return this.StatusCode((int)HttpStatusCode.NotFound);
            }
            else
            {
                GameField.RemoveAt(index);

                return this.Ok();
            }
        }
    }
}