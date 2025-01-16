using ChessGameService.Enums;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessGameService.Tests.ChessGame;

[TestClass]
[TestSubject(typeof(ChessGameService.ChessGame.ChessGame))]
public class ChessGameTest
{
    [TestMethod]
    public void Chessboard_should_be_64_squares()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, null);
        
        Assert.AreEqual(64, chessGame.Board.Length);
    }
}