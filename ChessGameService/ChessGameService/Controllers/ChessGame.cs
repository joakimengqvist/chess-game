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
                return Content(SerializeChessGameResponse(chessGame), "application/json");
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
                return Content(SerializeHistoryResponse(chessGame), "application/json");
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
                return Content(SerializeChessGameResponse(chessGame), "application/json");
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
                return Content(SerializeChessGameResponse(chessGame), "application/json");
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

        private static string SerializeHistoryResponse(ChessGame.ChessGame chessGame)
        {
            var history = chessGame.History.ChessHistory.Select(snapshot => snapshot).ToList();
            
            return LowercaseJsonSerializer.SerializeObject(new { history });
        }
        private static string SerializeChessGameResponse(ChessGame.ChessGame chessGame)
        {
            var board = chessGame.Board;
            var gameStatus = chessGame.Status;
            var status = new
            {
                turnOfColor = gameStatus.TurnOfColor.ToString(),
                whiteKingCheck = gameStatus.WhiteKingCheck,
                blackKingCheck = gameStatus.BlackKingCheck,
                isCheckmate = gameStatus.IsCheckmate,
                winner = gameStatus.Winner.ToString()
            };
            
            return LowercaseJsonSerializer.SerializeObject(new { board, status });
        }
    }
