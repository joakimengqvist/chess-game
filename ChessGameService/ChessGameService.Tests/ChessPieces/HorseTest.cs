using System;
using ChessGameService.ChessPieces;
using ChessGameService.Enums;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessGameService.Tests.ChessPieces;

[TestClass]
[TestSubject(typeof(Horse))]
public class HorseTest
{
    
    private readonly Piece[,] _mockedChessGame = new Piece[8, 8]
    {
        { new Tower(Color.Black), new Horse(Color.Black), new Knight(Color.Black), new Queen(Color.Black), new King(Color.Black), new Knight(Color.Black), new Horse(Color.Black), new Tower(Color.Black) },
        { new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black) },
        { null, null, null, null, new Pawn(Color.Black), new Pawn(Color.Black), null, null },
        { null, null, null, new Horse(Color.White), null, null, null, null },
        { null, null, null, new Horse(Color.White), null, null, null, null },
        { null, null, null, null, null, null, null, null },
        { new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White) },
        { new Tower(Color.White), new Horse(Color.White), new Knight(Color.White), new Queen(Color.White), new King(Color.White), new Knight(Color.White), new Horse(Color.White), new Tower(Color.White) }
    };

    [TestMethod]
    public void Horse_piece_should_have_a_color_and_a_correct_type()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGame);
        var board = chessGame.Board;
        
        Assert.AreEqual(Color.White, board[3,3].Color);
        Assert.AreEqual(PieceType.Horse, board[3,3].Type);
    }
    
    [TestMethod]
    public void Horse_piece_should_be_able_to_move_2_steps_negative_horizontally_and_1_step_positive_vertically()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGame);
        var board = chessGame.Board;
        
        chessGame.MovePiece([3,3], [4,1]);
        
        Assert.AreEqual(null, board[3,3]);
        Assert.AreEqual(PieceType.Horse, board[4,1].Type);
    }
    
    [TestMethod]
    public void Horse_piece_should_be_able_to_move_2_steps_negative_horizontally_and_1_step_negative_vertically()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGame);
        var board = chessGame.Board;
        
        chessGame.MovePiece([3,3], [2,1]);
        
        Assert.AreEqual(null, board[3,3]);
        Assert.AreEqual(PieceType.Horse, board[2,1].Type);
    }
    
    [TestMethod]
    public void Horse_piece_should_be_able_to_move_2_steps_positive_horizontally_and_1_step_negative_vertically_and_kill_pawn()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGame);
        var board = chessGame.Board;
        
        Assert.AreEqual(PieceType.Pawn, board[2,5].Type);
        
        chessGame.MovePiece([3,3], [2,5]);
        
        Assert.AreEqual(null, board[3,3]);
        Assert.AreEqual(PieceType.Horse, board[2,5].Type);
    }

    [TestMethod]
    public void Horse_piece_should_be_able_to_move_2_steps_positive_horizontally_and_1_step_positive_vertically()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGame);
        var board = chessGame.Board;
        
        chessGame.MovePiece([3,3], [2,1]);
        
        Assert.AreEqual(null, board[3,3]);
        Assert.AreEqual(PieceType.Horse, board[2,1].Type);
    }
    
    [TestMethod]
    public void Horse_piece_should_be_able_to_move_2_steps_positive_vertically_and_1_step_negative_horizontally()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGame);
        var board = chessGame.Board;
        
        chessGame.MovePiece([3,3], [5,2]);
        
        Assert.AreEqual(null, board[3,3]);
        Assert.AreEqual(PieceType.Horse, board[5,2].Type);
    }
    
    [TestMethod]
    public void Horse_piece_should_be_able_to_move_2_steps_positive_vertically_and_1_step_positive_horizontally()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGame);
        var board = chessGame.Board;
        
        chessGame.MovePiece([3,3], [5,4]);
        
        Assert.AreEqual(null, board[3,3]);
        Assert.AreEqual(PieceType.Horse, board[5,4].Type);
    }
    
    [TestMethod]
    public void Horse_piece_should_be_able_to_move_2_steps_negative_vertically_and_1_step_positive_horizontally_and_kill_pawn()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGame);
        var board = chessGame.Board;
        
        Assert.AreEqual(PieceType.Pawn, board[2,4].Type);
        
        chessGame.MovePiece([4,3], [2,4]);
        
        Assert.AreEqual(null, board[4,3]);
        Assert.AreEqual(PieceType.Horse, board[2,4].Type);
    }
    
    [TestMethod]
    public void Horse_piece_should_be_able_to_move_2_steps_negative_vertically_and_1_step_negative_horizontally()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGame);
        var board = chessGame.Board;
        
        chessGame.MovePiece([4,3], [2,2]);
        
        Assert.AreEqual(null, board[4,3]);
        Assert.AreEqual(PieceType.Horse, board[2,2].Type);
    }
    
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Horse_piece_should_not_be_able_to_move_only_on_step()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGame);
        
        chessGame.MovePiece([3,3], [2,3]);
        
    }
}