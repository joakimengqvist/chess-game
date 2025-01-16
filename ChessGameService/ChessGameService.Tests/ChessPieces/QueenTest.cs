using System;
using ChessGameService.ChessPieces;
using ChessGameService.Enums;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessGameService.Tests.ChessPieces;

[TestClass]
[TestSubject(typeof(Queen))]
public class QueenTest
{
    private readonly Piece[,] _mockedChessGameHorizontalMovements = new Piece[8, 8]
    {
        { new Queen(Color.Black), new Horse(Color.Black), new Queen(Color.Black), new Queen(Color.Black), new King(Color.Black), new Queen(Color.Black), new Horse(Color.Black), new Queen(Color.Black) },
        { new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black) },
        { null, null, null, null, null, null, null, null },
        { null, null, null, new Queen(Color.White), null, null, null, null },
        { null, null, null, null, null, null, null, null },
        { null, null, null, null, null, null, null, null },
        { new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White) },
        { new Queen(Color.White), new Horse(Color.White), new Queen(Color.White), new Queen(Color.White), new King(Color.White), new Queen(Color.White), new Horse(Color.White), new Queen(Color.White) }
    };
    
    private readonly Piece[,] _mockedChessDiagonalMovements = new Piece[8, 8]
    {
        { new Tower(Color.Black), new Horse(Color.Black), new Queen(Color.Black), new Queen(Color.Black), new King(Color.Black), new Queen(Color.Black), new Horse(Color.Black), new Tower(Color.Black) },
        { null, null, null, null, null, null, null, null },
        { null, null, null, null, null, null, null, null },
        { null, null, null, new Queen(Color.White), null, null, null, null },
        { null, null, null, null, null, null, null, null },
        { null, null, null, null, null, null, null, null },
        { new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White) },
        { new Tower(Color.White), new Horse(Color.White), new Queen(Color.White), new Queen(Color.White), new King(Color.White), new Queen(Color.White), new Horse(Color.White), new Tower(Color.White) }
    };

    [TestMethod]
    public void Queen_piece_should_have_a_color_and_a_correct_type()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGameHorizontalMovements);
        var board = chessGame.Board;
        
        Assert.AreEqual(Color.White, board[3,3].Color);
        Assert.AreEqual(PieceType.Queen, board[3,3].Type);
    }
    
    [TestMethod]
    public void Queen_piece_should_be_able_to_move_horizontally_in_positive_direction()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGameHorizontalMovements);
        var board = chessGame.Board;
        
        chessGame.MovePiece([3,3], [3,6]);
        
        Assert.AreEqual(null, board[3,3]);
        Assert.AreEqual(PieceType.Queen, board[3,6].Type);

    }
    
    [TestMethod]
    public void Queen_piece_should_be_able_to_move_horizontally_in_negative_direction()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGameHorizontalMovements);
        var board = chessGame.Board;
        
        chessGame.MovePiece([3,3], [3,1]);
        
        Assert.AreEqual(null, board[3,3]);
        Assert.AreEqual(PieceType.Queen, board[3,1].Type);

    }
    
    [TestMethod]
    public void Queen_piece_should_be_able_to_move_vertically_in_positive_direction()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGameHorizontalMovements);
        var board = chessGame.Board;
        
        chessGame.MovePiece([3,3], [4,3]);
        
        Assert.AreEqual(null, board[3,3]);
        Assert.AreEqual(PieceType.Queen, board[4,3].Type);

    }
    
    [TestMethod]
    public void Queen_piece_should_be_able_to_move_vertically_in_negative_direction()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGameHorizontalMovements);
        var board = chessGame.Board;
        
        chessGame.MovePiece([3,3], [2,3]);
        
        Assert.AreEqual(null, board[3,3]);
        Assert.AreEqual(PieceType.Queen, board[2,3].Type);

    }
    
    [TestMethod]
    public void Queen_piece_should_be_able_to_kill_vertically()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGameHorizontalMovements);
        var board = chessGame.Board;
        
        Assert.AreEqual(PieceType.Pawn, board[1,3].Type);
        
        chessGame.MovePiece([3,3], [1,3]);
        
        Assert.AreEqual(null, board[3,3]);
        Assert.AreEqual(PieceType.Queen, board[1,3].Type);
    }
    
    [TestMethod]
    public void Queen_piece_should_be_able_to_kill_horizontally()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGameHorizontalMovements);
        var board = chessGame.Board;
        
        Assert.AreEqual(PieceType.Pawn, board[1,3].Type);
        
        chessGame.MovePiece([3,3], [3,5]);
        chessGame.MovePiece([1,3], [3,3]);
        
        chessGame.MovePiece([3,5], [3,3]);
        
        Assert.AreEqual(null, board[1,3]);
        Assert.AreEqual(PieceType.Queen, board[3,3].Type);

    }
    
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Queen_piece_should_not_be_able_to_jump_over_other_units()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessGameHorizontalMovements);
        
        chessGame.MovePiece([6,3], [4,3]);
        chessGame.MovePiece([1,2], [2,2]);
        chessGame.MovePiece([3,3], [5,3]); // Queen cant jump over a piece
    }
    
    [TestMethod]
    public void Queen_piece_should_not_be_able_to_walk_diagonally_positive_positive()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessDiagonalMovements);
        var board = chessGame.Board;
        
        chessGame.MovePiece([3,3], [5,5]);
         
        Assert.AreEqual(null, board[3,3]);
        Assert.AreEqual(Color.White, board[5,5].Color);
        Assert.AreEqual(PieceType.Queen, board[5,5].Type);
    }
    
    [TestMethod]
    public void Queen_piece_should_not_be_able_to_walk_diagonally_negative_negative()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessDiagonalMovements);
        var board = chessGame.Board;
        
        chessGame.MovePiece([3,3], [1,1]);
         
        Assert.AreEqual(null, board[3,3]);
        Assert.AreEqual(Color.White, board[1,1].Color);
        Assert.AreEqual(PieceType.Queen, board[1,1].Type);
    }
    
    [TestMethod]
    public void Queen_piece_should_not_be_able_to_walk_diagonally_positive_negative()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessDiagonalMovements);
        var board = chessGame.Board;
        
        chessGame.MovePiece([3,3], [4,2]);
         
        Assert.AreEqual(null, board[3,3]);
        Assert.AreEqual(Color.White, board[4,2].Color);
        Assert.AreEqual(PieceType.Queen, board[4,2].Type);
    }
    
    [TestMethod]
    public void Queen_piece_should_not_be_able_to_walk_diagonally_negative_positive()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessDiagonalMovements);
        var board = chessGame.Board;
        
        chessGame.MovePiece([3,3], [2,4]);
         
        Assert.AreEqual(null, board[3,3]);
        Assert.AreEqual(Color.White, board[2,4].Color);
        Assert.AreEqual(PieceType.Queen, board[2,4].Type);
    }
    
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Queen_piece_should_not_be_able_to_move_off_line_diagonally()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessDiagonalMovements);
        
        chessGame.MovePiece([3,3], [2,1]);
    }
    
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Queen_piece_should_not_be_able_to_move_off_line_diagonally_second()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, _mockedChessDiagonalMovements);
        
        chessGame.MovePiece([3,3], [4,5]);
    }
}