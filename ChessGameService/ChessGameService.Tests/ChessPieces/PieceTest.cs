using System;
using ChessGameService.Enums;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessGameService.Tests.ChessPieces;

[TestClass]
[TestSubject(typeof(ChessGameService.ChessGame.ChessGame))]
public class PieceTest
{
    [TestMethod]
    public void First_piece_should_have_be_color_black()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, null);
        
        Assert.AreEqual(Color.Black, chessGame.Board[0, 0].Color);
    }
    
    [TestMethod]
    public void First_piece_should_have_be_of_type_Tower()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, null);
        
        Assert.AreEqual(PieceType.Tower, chessGame.Board[0, 0].Type);
    }
    
    [TestMethod]
    public void Last_row_fourth_piece_should_have_be_color_white()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, null);
        
        Assert.AreEqual(Color.White, chessGame.Board[7, 4].Color);
    }
    
    [TestMethod]
    public void Last_row_fourth_piece_should_have_be_of_type_king()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, null);
        
        Assert.AreEqual(PieceType.King, chessGame.Board[7, 4].Type);
    }
    
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void A_move_cant_be_made_to_the_same_destination()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, null);
        
        chessGame.MovePiece([0, 2], [0, 2]);
        
    }
    
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void A_piece_should_not_be_able_to_be_moved_onto_another_of_same_color()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, null);
        
        chessGame.MovePiece([0, 0], [0, 1]);
        
    }
    
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Black_piece_should_not_be_the_first_to_move()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, null);
        
        chessGame.MovePiece([1, 2], [2, 2]);
        
    }
}