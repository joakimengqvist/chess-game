using ChessGameService.Controllers.DTO;
using ChessGameService.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ChessGameService.Controllers;

    [ApiController]
    [Route("api/")]
    public class ChessController(ChessGame.ChessGame chessGame) : ControllerBase
    {
        [HttpGet("game")]
        public IActionResult GetChessBoard()
        {
            try
            {
                return Content(ChessGameSerializer.SerializeChessGameResponse(chessGame), "application/json");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, new { Error = "An unexpected error occurred while fetching the game board." });
            }
        }
        
        [HttpGet("history")]
        public IActionResult GetGameHistory()
        {
            try
            {
                return Content(ChessGameSerializer.SerializeHistoryResponse(chessGame), "application/json");
            }
            catch (Exception)
            {
                return StatusCode(500, new { Error = "An unexpected error occurred while fetching the game board." });
            }
        }

        [HttpPost("move")]
        public IActionResult MakeMove([FromBody] MakeMovePayload payload)
        {
            try
            {
                chessGame.MovePiece(payload.FromCoordinates, payload.ToCoordinates);
                return Content(ChessGameSerializer.SerializeChessGameResponse(chessGame), "application/json");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { Error = "An unexpected error occurred while processing the move." });
            }
        }
        
        [HttpGet("reset-game")]
        public IActionResult ResetGame()
        {
            try
            {
                chessGame.ResetGame();
                return Content(ChessGameSerializer.SerializeChessGameResponse(chessGame), "application/json");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { Error = "An unexpected error occurred while processing the move." });
            }
        }
    }
