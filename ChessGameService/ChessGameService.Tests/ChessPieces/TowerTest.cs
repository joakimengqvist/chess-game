using System;
using ChessGameService.ChessPieces;
using ChessGameService.Enums;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessGameService.Tests.ChessPieces;

[TestClass]
[TestSubject(typeof(Tower))]
public class TowerTest
{
    private readonly Piece[,] _mockedChessGame = new Piece[8, 8]
    {
        { new Tower(Color.Black), new Horse(Color.Black), new Knight(Color.Black), new Queen(Color.Black), new King(Color.Black), new Knight(Color.Black), new Horse(Color.Black), new Tower(Color.Black) },
        { new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black) },
        { null, null, null, null, null, null, null, null },
        { null, null, null, new Tower(Color.White), null, null, null, null },
        { null, null, null, null, null, null, null, null },
        { null, null, null, null, null, null, null, null },
        { new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White) },
        { new Tower(Color.White), new Horse(Color.White), new Knight(Color.White), new Queen(Color.White), new King(Color.White), new Knight(Color.White), new Horse(Color.White), new Tower(Color.White) }
    };

    [TestMethod]
    public void Tower_piece_should_have_a_color_and_a_correct_type()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGame);
        var board = chessGame.Board;
        
        Assert.AreEqual(Color.White, board[3,3].Color);
        Assert.AreEqual(PieceType.Tower, board[3,3].Type);
    }
    
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Tower_piece_should_not_be_able_to_move_diagonally()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGame);
        
        chessGame.MovePiece([3,3], [4,4]);

    }
    
    [TestMethod]
    public void Tower_piece_should_be_able_to_move_horizontally_in_positive_direction()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGame);
        var board = chessGame.Board;
        
        chessGame.MovePiece([3,3], [3,6]);
        
        Assert.AreEqual(null, board[3,3]);
        Assert.AreEqual(PieceType.Tower, board[3,6].Type);

    }
    
    [TestMethod]
    public void Tower_piece_should_be_able_to_move_horizontally_in_negative_direction()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGame);
        var board = chessGame.Board;
        
        chessGame.MovePiece([3,3], [3,1]);
        
        Assert.AreEqual(null, board[3,3]);
        Assert.AreEqual(PieceType.Tower, board[3,1].Type);

    }
    
    [TestMethod]
    public void Tower_piece_should_be_able_to_move_vertically_in_positive_direction()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGame);
        var board = chessGame.Board;
        
        chessGame.MovePiece([3,3], [4,3]);
        
        Assert.AreEqual(null, board[3,3]);
        Assert.AreEqual(PieceType.Tower, board[4,3].Type);

    }
    
    [TestMethod]
    public void Tower_piece_should_be_able_to_move_vertically_in_negative_direction()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGame);
        var board = chessGame.Board;
        
        chessGame.MovePiece([3,3], [2,3]);
        
        Assert.AreEqual(null, board[3,3]);
        Assert.AreEqual(PieceType.Tower, board[2,3].Type);

    }
    
    [TestMethod]
    public void Tower_piece_should_be_able_to_kill_vertically()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGame);
        var board = chessGame.Board;
        
        Assert.AreEqual(PieceType.Pawn, board[1,3].Type);
        
        chessGame.MovePiece([3,3], [1,3]);
        
        Assert.AreEqual(null, board[3,3]);
        Assert.AreEqual(PieceType.Tower, board[1,3].Type);
    }
    
    [TestMethod]
    public void Tower_piece_should_be_able_to_kill_horizontally()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGame);
        var board = chessGame.Board;
        
        Assert.AreEqual(PieceType.Pawn, board[1,3].Type);
        
        chessGame.MovePiece([3,3], [3,5]); // move white tower
        chessGame.MovePiece([1,3], [3,3]); // move black pawn
        
        chessGame.MovePiece([3,5], [3,3]); // kill black pawn
        
        Assert.AreEqual(null, board[1,3]);
        Assert.AreEqual(PieceType.Tower, board[3,3].Type);

    }
    
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Tower_piece_should_not_be_able_to_jump_over_other_units()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGame);
        
        chessGame.MovePiece([6,3], [4,3]);
        chessGame.MovePiece([1,2], [2,2]);
        chessGame.MovePiece([3,3], [5,3]); // Tower cant jump over a piece
    }
}