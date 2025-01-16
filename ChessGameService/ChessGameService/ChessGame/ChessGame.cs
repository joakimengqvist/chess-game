using ChessGameService.ChessPieces;
using ChessGameService.Enums;

namespace ChessGameService.ChessGame;

using static Coordinates;
public class ChessGame(Color turnOfColor, Piece?[,]? chessBoard)
{
    private const int Y = (int)YCoordinate;
    private const int X = (int)XCoordinate;

    public readonly GameStatus Status = new(turnOfColor);
    public ChessGameHistory History = new();
    
    public Piece?[,] Board { get; private set; } = chessBoard ?? new Piece?[,]
    {
        { new Tower(Color.Black), new Horse(Color.Black), new Knight(Color.Black), new Queen(Color.Black), new King(Color.Black), new Knight(Color.Black), new Horse(Color.Black), new Tower(Color.Black) },
        { new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black) },
        { null, null, null, null, null, null, null, null },
        { null, null, null, null, null, null, null, null },
        { null, null, null, null, null, null, null, null },
        { null, null, null, null, null, null, null, null },
        { new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White) },
        { new Tower(Color.White), new Horse(Color.White), new Knight(Color.White), new Queen(Color.White), new King(Color.White), new Knight(Color.White), new Horse(Color.White), new Tower(Color.White) }
    };
    
    public void ResetGame()
    {
        Board = new Piece?[,]
        {
            { new Tower(Color.Black), new Horse(Color.Black), new Knight(Color.Black), new Queen(Color.Black), new King(Color.Black), new Knight(Color.Black), new Horse(Color.Black), new Tower(Color.Black) },
            { new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black) },
            { null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null },
            { new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White) },
            { new Tower(Color.White), new Horse(Color.White), new Knight(Color.White), new Queen(Color.White), new King(Color.White), new Knight(Color.White), new Horse(Color.White), new Tower(Color.White) }
        };
        History = new ChessGameHistory();
        Status.ResetGameStatus();
    }

    public void MovePiece(int[] fromCoordinate, int[] toCoordinate)
    {
        var movingPiece = Board[fromCoordinate[Y], fromCoordinate[X]];
        var targetPiece = Board[toCoordinate[Y], toCoordinate[X]];
        
        if (movingPiece == null) return;

        if (Status.IsCheckmate)
        {
            throw new InvalidOperationException("Game is over, " + Status.Winner + " has won.");
        }
        
        if (movingPiece.Color != Status.TurnOfColor)
        {
            throw new InvalidOperationException("Wrong color, it is not that colors turn.");
        }
        
        if (!movingPiece.IsCompleteMovePossible(fromCoordinate, toCoordinate, Board))
        {
            throw new InvalidOperationException("Move is not possible.");
        }

        if (PiecesAreSameColor(movingPiece, targetPiece))
        {
            throw new InvalidOperationException("Target piece is the same color.");
        }
        
        if (Status.IsKingInDangerAfterMove(Board, fromCoordinate, toCoordinate, movingPiece, movingPiece.Color))
        {
            throw new InvalidOperationException("You can't move here since it puts your king in danger");
        }
        
        FinalizeMove(fromCoordinate, toCoordinate, movingPiece, targetPiece);
        
        History.AddSnapshot(Board, fromCoordinate, toCoordinate);
    }
    
    private void FinalizeMove(int[] fromCoordinate, int[] toCoordinate, Piece movingPiece, Piece? targetPiece)
    {
        Board[fromCoordinate[Y], fromCoordinate[X]] = null;
        Board[toCoordinate[Y], toCoordinate[X]] = movingPiece;

        UpdateGameStatus(targetPiece);
    }

    private void UpdateGameStatus(Piece? targetPiece)
    {
        Status.EndGameIfKingIsKilled(targetPiece); 
        Status.SetCheckStatus(Board);
        var turnOfNextColor = Status.SetColorOfNextTurn();
        Status.SetCheckmateStatus(Board, turnOfNextColor);
    }

    private static bool PiecesAreSameColor(Piece? sourcePiece, Piece? targetPiece)
    {
        if (targetPiece == null) return false;
        return sourcePiece != null && sourcePiece.Color == targetPiece.Color;
    }
}