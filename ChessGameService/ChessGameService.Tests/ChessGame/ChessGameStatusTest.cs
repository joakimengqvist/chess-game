using System;
using ChessGameService.ChessGame;
using ChessGameService.ChessPieces;
using ChessGameService.Enums;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessGameService.Tests.ChessGame;

[TestClass]
[TestSubject(typeof(ChessGameService.ChessGame.ChessGame))]
public class ChessGameStatusTest
{
    private readonly Piece[,] _mockedChessGameKingInDanger = new Piece[8, 8]
    {
        { new Tower(Color.Black), new Horse(Color.Black), new Knight(Color.Black), new Queen(Color.Black), null, new Knight(Color.Black), new Horse(Color.Black), new Tower(Color.Black) },
        { new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black) },
        { null, null, null, null, null, null, null, null },
        { null, null, null, new Queen(Color.White), null, null, null, null },
        { null, new King(Color.Black), null, null, null, null, null, null },
        { null, null, null, null, null, null, null, null },
        { new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White) },
        { new Tower(Color.White), new Horse(Color.White), new Knight(Color.White), new Queen(Color.White), new King(Color.White), new Knight(Color.White), new Horse(Color.White), new Tower(Color.White) }
    };
    
    private readonly Piece[,] _mockedChessGameKingGetsKilled = new Piece[8, 8]
    {
        { new Tower(Color.Black), new Horse(Color.Black), new Knight(Color.Black), new Queen(Color.Black), null, new Knight(Color.Black), new Horse(Color.Black), new Tower(Color.Black) },
        { new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black) },
        { null, null, null, null, null, null, null, null },
        { null, new Queen(Color.White), null, null, null, null, null, null },
        { null, new King(Color.Black), null, null, null, null, null, null },
        { null, null, null, null, null, null, null, null },
        { new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White) },
        { new Tower(Color.White), new Horse(Color.White), new Knight(Color.White), new Queen(Color.White), new King(Color.White), new Knight(Color.White), new Horse(Color.White), new Tower(Color.White) }
    };
    
    [TestMethod]
    public void Check_status_should_update_when_king_is_in_danger()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGameKingInDanger);
        
        chessGame.MovePiece([3, 3], [4, 3]);
        
        Assert.AreEqual(true, chessGame.Status.BlackKingCheck);
    }
    
    [TestMethod]
    public void Check_mate_status_should_update_when_king_is_killed()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGameKingGetsKilled);
        
        chessGame.MovePiece([3, 1], [4, 1]);
        
        Assert.AreEqual(true, chessGame.Status.IsCheckmate);
        Assert.AreEqual("White", chessGame.Status.Winner.ToString());
    }
    
    [TestMethod]
    public void Check_mate_status_should_update_when_king_no_moves_can_be_made()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, null);
        
        chessGame.MovePiece([6, 4], [4, 4]);
        chessGame.MovePiece([1, 4], [3, 4]);
        
        chessGame.MovePiece([7, 5], [4, 2]);
        chessGame.MovePiece([0, 1], [2, 2]);
        
        chessGame.MovePiece([7, 3], [3, 7]);
        chessGame.MovePiece([0, 6], [2, 5]);
        
        chessGame.MovePiece([3, 7], [1, 5]);
        
        Assert.AreEqual(true, chessGame.Status.IsCheckmate);
        Assert.AreEqual("White", chessGame.Status.Winner.ToString());
    }
    
    [TestMethod]
    public void Checkmate_status_should_update_when_black_forces_checkmate()
    {
        // Initialize the chess game, White moves first
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, null);
    
        // Move 1: White pawn e2 to e4, Black pawn e7 to e5
        chessGame.MovePiece([6, 5],  [5, 5]);
        chessGame.MovePiece( [1, 4], [3, 4]);
    
        // Move 2: White bishop f1 to c4, Black knight b8 to c6
        chessGame.MovePiece([6, 6], [4, 6]);
        chessGame.MovePiece([0, 3], [4, 7]);
        
        Console.WriteLine("is white king check: " + chessGame.Status.WhiteKingCheck);
        // ChessHelpers.LogBoard(chessGame.Board);
    
        // Assert checkmate and winner
        Assert.AreEqual(true, chessGame.Status.IsCheckmate, "The game should be in a checkmate state.");
        Assert.AreEqual("Black", chessGame.Status.Winner.ToString(), "Black should be the winner.");
    }
}