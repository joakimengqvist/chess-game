using ChessGameService.ChessPieces;
using ChessGameService.Enums;

using static ChessGameService.Enums.Coordinates;

namespace ChessGameService.ChessGame;

public class GameStatus(Color turnOfColor)
{
    private const int Y = (int)YCoordinate;
    private const int X = (int)XCoordinate;
    
    public Color TurnOfColor = turnOfColor;
    public bool WhiteKingCheck;
    public bool BlackKingCheck;
    public bool IsCheckmate;
    public Color? Winner;

    public void ResetGameStatus()
    {
        TurnOfColor = Color.White;
        Winner = null;     
        IsCheckmate = false;
        IsCheckmate = false;
        WhiteKingCheck = false;
        BlackKingCheck = false;
    }
    
    public Color SetColorOfNextTurn()
    {
        if (!IsCheckmate)
        {
            TurnOfColor = TurnOfColor == Color.White ? Color.Black : Color.White;
            return TurnOfColor == Color.White ? Color.Black : Color.White;
        }

        return TurnOfColor;
    }
    
    public void EndGameIfKingIsKilled(Piece? targetPiece)
    {
        if (targetPiece is not { Type: PieceType.King }) return;
        IsCheckmate = true;
        Winner = TurnOfColor;
    }

    public void SetCheckStatus(Piece?[,] board)
    {
        BlackKingCheck = CanKingBeKilled(board, Color.Black);
        WhiteKingCheck = CanKingBeKilled(board, Color.White);
    }

    public void SetCheckmateStatus(Piece?[,] board, Color colorOfTurn)
    {
        Console.WriteLine("");
        Console.WriteLine("---------------------------");
        Console.WriteLine("");
        var isCheckmate = CheckIsCheckmate(board, colorOfTurn);
        if (!isCheckmate) return;
        IsCheckmate = true;
        Winner = colorOfTurn;
    }
    
    private bool CheckIsCheckmate(Piece?[,] board, Color color)
    {
        var isCheckMate = true;
        ChessHelpers.IterateBoard(board, (y, x, piece) =>
        {
            if (piece != null && piece.Color != color)
            {
                var clonedPiece = ChessHelpers.ClonePiece(piece.Color, piece.Type);
                var clonedBoard = ChessHelpers.CloneBoard(board);

                var fromCoordinates = new[] { y, x };

                var validMoves = clonedPiece.ValidMoves(fromCoordinates, clonedBoard);

                foreach (var validMove in validMoves)
                {
                    var toCoordinates = new[] { validMove[Y], validMove[X] };
                    var isMovePossible = SimulateIsCompleteMovePossible(clonedBoard, clonedPiece, fromCoordinates, toCoordinates);
                    var isKingInDanger = IsKingInDangerAfterMove(clonedBoard, fromCoordinates, toCoordinates, clonedPiece,
                        piece.Color);

                    if (isMovePossible && !isKingInDanger)
                    {
                        isCheckMate = false;
                        return true;
                    }
                }
            }

            return false;
            
        }, stopOnResult: false);

        return isCheckMate;
    }
    
    public bool IsKingInDangerAfterMove(Piece?[,] board, int[] fromCoordinate, int[] toCoordinate, Piece movingPiece, Color colorOfKing)
    {
        var clonedBoard = ChessHelpers.CloneBoard(board);
        
        clonedBoard[fromCoordinate[Y], fromCoordinate[X]] = null;
        clonedBoard[toCoordinate[Y], toCoordinate[X]] = movingPiece;
        
        return CanKingBeKilled(clonedBoard, colorOfKing);
    }
    
    private bool CanKingBeKilled(Piece?[,] board, Color colorOfKing)
    {
        var kingPosition = FindKing(board, colorOfKing);
        var kingIsInDanger = false;
        
        ChessHelpers.IterateBoard(board, (y, x, piece) =>
        {
            if (piece == null || piece.Color == colorOfKing) return false;
            
            if (SimulateIsCompleteMovePossible(board, piece, new[] { y, x }, kingPosition))
            {
                kingIsInDanger = true;
                return true;
            }

            return false;
        });
        
        return kingIsInDanger;
    }

        
    private int[]? FindKing(Piece?[,] board, Color colorOfKing)
    {
        return ChessHelpers.IterateBoard<int[]>(board, (y, x, piece) =>
        {
            if (piece is { Type: PieceType.King } && piece.Color == colorOfKing)
            {
                return [y, x];
            }
            return null;
        }, stopOnResult: true);
    }
      
    private bool SimulateIsCompleteMovePossible( Piece?[,] board, Piece piece, int[] startPosition, int[]? kingPosition)
    {
        if (kingPosition == null)
        {
            return false;
        }
        try
        {
            var clonePiece = ChessHelpers.ClonePiece(piece.Color, piece.Type);
            return clonePiece.IsCompleteMovePossible(startPosition, kingPosition, board);
        }
        catch
        {
            return false;
        }
    }
    
}