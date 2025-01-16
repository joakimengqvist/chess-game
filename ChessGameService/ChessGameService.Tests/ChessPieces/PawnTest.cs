using System;
using ChessGameService.ChessGame;
using ChessGameService.ChessPieces;
using ChessGameService.Enums;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessGameService.Tests.ChessPieces;

[TestClass]
[TestSubject(typeof(Pawn))]
public class PawnTest
{

    [TestMethod]
    public void Pawn_piece_should_have_a_color_and_a_correct_type()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, null);
        var board = chessGame.Board;
        
        Assert.AreEqual(Color.Black, board[1,3].Color);
        Assert.AreEqual(PieceType.Pawn, board[1,3].Type);
    }
    
    [TestMethod]
    public void pawn_piece_should_be_able_to_move_forward_if_destination_is_empty()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, null);

        chessGame.MovePiece([6,2], [4,2]); // white two steps
        chessGame.MovePiece([1,2], [3,2]); // black two steps
        chessGame.MovePiece([6,3], [5,3]); // white one step
        chessGame.MovePiece([1,3], [3,3]); // black one step
        
        // white
        Assert.AreEqual(null, chessGame.Board[6,2]);
        Assert.AreEqual(PieceType.Pawn, chessGame.Board[4,2].Type);
        Assert.AreEqual(null, chessGame.Board[6,3]);
        Assert.AreEqual(PieceType.Pawn, chessGame.Board[5,3].Type);
        
        // black
        Assert.AreEqual(null, chessGame.Board[1,2]);
        Assert.AreEqual(PieceType.Pawn, chessGame.Board[3,2].Type);
        Assert.AreEqual(null, chessGame.Board[2,3]);
        Assert.AreEqual(PieceType.Pawn, chessGame.Board[3,3].Type);
    }
    
    [TestMethod]
    public void White_pawn_piece_should_be_able_to_kill_black_piece_if_diagonal()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, null);

        chessGame.MovePiece([6,2], [5,2]); // white makes first move
        chessGame.MovePiece([1,3], [2,3]); // black makes a move
        
        chessGame.MovePiece([5,2], [4,2]); // white makes a move
        chessGame.MovePiece([2,3], [3,3]); // black makes a move
        
        chessGame.MovePiece([4,2], [3,3]); // white kills black diagonally
        
        Assert.AreEqual(null, chessGame.Board[4,2]);
        Assert.AreEqual(Color.White, chessGame.Board[3,3].Color);
    }
    
    [TestMethod]
    public void Black_pawn_piece_should_be_able_to_kill_white_piece_if_diagonal_horizontal_negative()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, null);

        chessGame.MovePiece([6,2], [4,2]); // white makes first move
        chessGame.MovePiece([1,3], [3,3]); // black makes a move
        
        chessGame.MovePiece([6,6], [5,6]); // white makes a move
        chessGame.MovePiece([3,3], [4,2]); // black makes a move
        
        Assert.AreEqual(Color.Black, chessGame.Board[4,2].Color);
    }
    
    [TestMethod]
    public void Black_pawn_piece_should_be_able_to_kill_white_piece_if_diagonal_horizontal_positive()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, null);

        chessGame.MovePiece([6,7], [4,7]);
        chessGame.MovePiece([1,6], [3,6]);
        
        chessGame.MovePiece([6,1], [5,1]);
        chessGame.MovePiece([3,6], [4,7]);
        
        Assert.AreEqual(Color.Black, chessGame.Board[4,7].Color);
    }
    
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void pawn_piece_should_be_not_be_able_to_move_backwards()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, null);
        
        chessGame.MovePiece([6,2], [5,2]); // white has to move first
        chessGame.MovePiece([5,2], [6,2]); // white can't move cause it is blacks turn
    }
    
    
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void black_pawn_piece_should_not_be_able_to_kill_backwards()
    {
        var chessGame = new ChessGameService.ChessGame.ChessGame(Color.White, null);
        
        chessGame.MovePiece([6,2], [4,2]); 
        chessGame.MovePiece([1,3], [3,3]);
        
        chessGame.MovePiece([4,2], [3,2]); 
        chessGame.MovePiece([3,3], [4,3]);
        
        chessGame.MovePiece([6,0], [4,0]); 
        chessGame.MovePiece([4,3], [3,2]);
        
        Assert.AreEqual(Color.White, chessGame.Board[3,2].Color);
    }
}