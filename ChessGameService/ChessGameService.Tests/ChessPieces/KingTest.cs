using System;
using ChessGameService.ChessPieces;
using ChessGameService.Enums;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessGameService.Tests.ChessPieces;

[TestClass]
[TestSubject(typeof(King))]
public class KingTest
{
    private readonly Piece[,] _mockedChessGame = new Piece?[8, 8]
    {
        { new King(Color.Black), new Horse(Color.Black), new Knight(Color.Black), new Queen(Color.Black), new King(Color.Black), new Knight(Color.Black), new Horse(Color.Black), new King(Color.Black) },
        { new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black) },
        { null, null, null, null, null, null, null, null },
        { null, null, null, null, null, null, null, null },
        { null, null, null, new King(Color.White), null, null, null, null },
        { null, null, null, null, null, null, null, null },
        { new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White) },
        { new King(Color.White), new Horse(Color.White), new Knight(Color.White), new Queen(Color.White), new King(Color.White), new Knight(Color.White), new Horse(Color.White), new King(Color.White) }
    };
    
    private readonly Piece[,] _mockedChessGameKingKills = new Piece?[8, 8]
    {
        { new King(Color.Black), new Pawn(Color.Black), new Knight(Color.Black), new Queen(Color.Black), new King(Color.Black), new Knight(Color.Black), new Horse(Color.Black), new King(Color.Black) },
        { null, null, null, null, null, null, null, null },
        { null, null, new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), null, null, null },
        { null, null, new Pawn(Color.Black), new King(Color.White), new Pawn(Color.Black), null, null, null },
        { null, null, new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), null, null, null },
        { null, null, null, null, null, null, null, null },
        { new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White) },
        { new King(Color.White), new Horse(Color.White), new Knight(Color.White), new Queen(Color.White), new King(Color.White), new Knight(Color.White), new Horse(Color.White), new King(Color.White) }
    };

    [TestMethod]
    public void King_piece_should_have_a_color_and_a_correct_type()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGame);
        var board = chessGame.Board;
        
        Assert.AreEqual(Color.White, board[4,3].Color);
        Assert.AreEqual(PieceType.King, board[4,3].Type);
    }
    
    [TestMethod]
    public void King_piece_should_be_able_to_move_one_step_horizontally_positive()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGame);
        var board = chessGame.Board;
        
        chessGame.MovePiece([4,3], [4,4]);
        
        Assert.AreEqual(null, board[4,3]);
        Assert.AreEqual(PieceType.King, board[4,4].Type);
    }
    
    [TestMethod]
    public void King_piece_should_be_able_to_move_one_step_horizontally_negative()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGame);
        var board = chessGame.Board;
        
        chessGame.MovePiece([4,3], [5,2]);
        
        Assert.AreEqual(null, board[4,3]);
        Assert.AreEqual(PieceType.King, board[5,2].Type);
    }
    
    [TestMethod]
    public void King_piece_should_be_able_to_move_one_step_vertically_positive()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGame);
        var board = chessGame.Board;
        
        chessGame.MovePiece([3,3], [4,3]);
        
        Assert.AreEqual(null, board[3,3]);
        Assert.AreEqual(PieceType.King, board[4,3].Type);
    }
    
    [TestMethod]
    public void King_piece_should_be_able_to_move_one_step_vertically_negative()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGame);
        var board = chessGame.Board;
        
        chessGame.MovePiece([5,3], [4,3]);
        
        Assert.AreEqual(null, board[5,3]);
        Assert.AreEqual(PieceType.King, board[4,3].Type);
    }
    
    [TestMethod]
    public void King_piece_should_be_able_to_move_one_step_diagonally_negative_negative()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGame);
        var board = chessGame.Board;
        
        chessGame.MovePiece([4,3], [3,2]);
        
        Assert.AreEqual(null, board[4,3]);
        Assert.AreEqual(PieceType.King, board[3,2].Type);
    }
    
    [TestMethod]
    public void King_piece_should_be_able_to_move_one_step_diagonally_negative_positive()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGame);
        var board = chessGame.Board;
        
        chessGame.MovePiece([4,3], [3,4]);
        
        Assert.AreEqual(null, board[4,3]);
        Assert.AreEqual(PieceType.King, board[3,4].Type);
    }
    
    [TestMethod]
    public void King_piece_should_be_able_to_move_one_step_diagonally_positive_positive()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGame);
        var board = chessGame.Board;
        
        chessGame.MovePiece([4,3], [5,4]);
        
        Assert.AreEqual(null, board[4,3]);
        Assert.AreEqual(PieceType.King, board[5,4].Type);
    }
    
    [TestMethod]
    public void King_piece_should_be_able_to_move_one_step_diagonally_positive_negative()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGame);
        var board = chessGame.Board;
        
        chessGame.MovePiece([4,3], [4,2]);
        
        Assert.AreEqual(null, board[4,3]);
        Assert.AreEqual(PieceType.King, board[4,2].Type);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void King_piece_should_not_be_able_to_move_two_step_vertically_positive()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGame);
        
        chessGame.MovePiece([4,3], [6,3]);
    }
    
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void King_piece_should_not_be_able_to_move_two_step_vertically_negative()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGame);
        
        chessGame.MovePiece([4,3], [1,3]);
    }
    
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void King_piece_should_be_able_to_move_two_step_diagonally_negative_negative()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGame);
        
        chessGame.MovePiece([4,3], [1,1]);
    }
    
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void King_piece_should_be_able_to_move_two_step_diagonally_positive_positive()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGame);
        
        chessGame.MovePiece([4,3], [5,5]);
    }
    
    [TestMethod]
    public void King_piece_should_be_able_to_kill_by_one_step_diagonally_positive()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGameKingKills);
        var board = chessGame.Board;
        
        Assert.AreEqual(Color.Black, board[4,4].Color);
        
        chessGame.MovePiece([3,3], [4,4]);
        
        Assert.AreEqual(null, board[3,3]);
        Assert.AreEqual(PieceType.King, board[4,4].Type);
    }
    
    [TestMethod]
    public void King_piece_should_be_able_to_kill_by_one_step_diagonally_negative()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGameKingKills);
        var board = chessGame.Board;
        
        Assert.AreEqual(Color.Black, board[2,2].Color);
        
        chessGame.MovePiece([3,3], [2,2]);
        
        Assert.AreEqual(null, board[3,3]);
        Assert.AreEqual(PieceType.King, board[2,2].Type);
    }
}