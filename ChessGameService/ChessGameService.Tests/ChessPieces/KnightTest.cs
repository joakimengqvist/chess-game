using System;
using ChessGameService.ChessPieces;
using ChessGameService.Enums;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessGameService.Tests.ChessPieces;

[TestClass]
[TestSubject(typeof(Knight))]
public class KnightTest
{
    
    private readonly Piece[,] _mockedChessGame = new Piece[8, 8]
    {
        { new Tower(Color.Black), new Horse(Color.Black), new Knight(Color.Black), new Queen(Color.Black), new King(Color.Black), new Knight(Color.Black), new Horse(Color.Black), new Tower(Color.Black) },
        { null, null, null, null, null, null, null, null },
        { null, null, null, null, null, null, null, null },
        { null, null, null, new Knight(Color.White), null, null, null, null },
        { null, null, null, null, null, null, null, null },
        { null, null, null, null, null, null, null, null },
        { new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White) },
        { new Tower(Color.White), new Horse(Color.White), new Knight(Color.White), new Queen(Color.White), new King(Color.White), new Knight(Color.White), new Horse(Color.White), new Tower(Color.White) }
    };
    
    [TestMethod]
    public void Knight_piece_should_have_a_color_and_a_correct_type()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGame);
        var board = chessGame.Board;
        
        Assert.AreEqual(Color.White, board[3,3].Color);
        Assert.AreEqual(PieceType.Knight, board[3,3].Type);
    }
    
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Knight_piece_should_not_be_able_to_walk_straight_horizontally()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGame);
        
        chessGame.MovePiece([3,3], [3,4]);
    }
    
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Knight_piece_should_not_be_able_to_walk_straight_vertically()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGame);
        
        chessGame.MovePiece([3,3], [4,3]);
    }
    
    [TestMethod]
    public void Knight_piece_should_not_be_able_to_walk_diagonally_positive_positive()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGame);
        var board = chessGame.Board;
        
        chessGame.MovePiece([3,3], [5,5]);
         
        Assert.AreEqual(null, board[3,3]);
        Assert.AreEqual(Color.White, board[5,5].Color);
        Assert.AreEqual(PieceType.Knight, board[5,5].Type);
    }
    
    [TestMethod]
    public void Knight_piece_should_not_be_able_to_walk_diagonally_negative_negative()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGame);
        var board = chessGame.Board;
        
        chessGame.MovePiece([3,3], [1,1]);
         
        Assert.AreEqual(null, board[3,3]);
        Assert.AreEqual(Color.White, board[1,1].Color);
        Assert.AreEqual(PieceType.Knight, board[1,1].Type);
    }
    
    [TestMethod]
    public void Knight_piece_should_not_be_able_to_walk_diagonally_positive_negative()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGame);
        var board = chessGame.Board;
        
        chessGame.MovePiece([3,3], [4,2]);
         
        Assert.AreEqual(null, board[3,3]);
        Assert.AreEqual(Color.White, board[4,2].Color);
        Assert.AreEqual(PieceType.Knight, board[4,2].Type);
    }
    
    [TestMethod]
    public void Knight_piece_should_not_be_able_to_walk_diagonally_negative_positive()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGame);
        var board = chessGame.Board;
        
        chessGame.MovePiece([3,3], [2,4]);
         
        Assert.AreEqual(null, board[3,3]);
        Assert.AreEqual(Color.White, board[2,4].Color);
        Assert.AreEqual(PieceType.Knight, board[2,4].Type);
    }
    
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Knight_piece_should_not_be_able_to_move_off_line_diagonally()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGame);
        
        chessGame.MovePiece([3,3], [2,1]);
    }
    
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Knight_piece_should_not_be_able_to_move_off_line_diagonally_second()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGame);
        
        chessGame.MovePiece([3,3], [4,5]);
    }
}