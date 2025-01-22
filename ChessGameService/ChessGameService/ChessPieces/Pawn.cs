using ChessGameService.Enums;

namespace ChessGameService.ChessPieces;

public class Pawn : Piece
{
    public Pawn(Color color) : base(color)
    {
        Type = PieceType.Pawn;
    }

    private bool IsFirstMove { get; set; } = true;

    public override bool IsCompleteMovePossible(int[] fromCoordinates, int[] toCoordinates, Piece?[,] board)
    {
        var toPiece = board[toCoordinates[Y], toCoordinates[X]];
        var isDiagonalMove = IsMoveDiagonal(fromCoordinates, toCoordinates);
        
        if (!isDiagonalMove)
        {
            if (!IsToDestinationEmpty(toPiece)) return false;
            
            var okDiff = IsFirstMove ? 2 : 1;
            
            return Color == Color.White
                ? IsWhiteStraightMovePossible(fromCoordinates[Y], toCoordinates[Y], okDiff)
                : IsBlackStraightMovePossible(fromCoordinates[Y], toCoordinates[Y], okDiff);
        }

        if (toPiece == null) return false;
        
        return Color == Color.White ? 
            IsWhiteDiagonalMovePossible(fromCoordinates, toCoordinates, toPiece) : 
            IsBlackDiagonalMovePossible(fromCoordinates, toCoordinates, toPiece);
    }

    private bool IsBlackStraightMovePossible(int fromRow, int toRow, int okDiff)
    {
        var diff = toRow - fromRow;
        var isPossible = fromRow <= toRow && diff <= okDiff;
        
        if (isPossible)
        {
            IsFirstMove = false;
        }

        return isPossible;
    }
    
    private bool IsWhiteStraightMovePossible(int fromRow, int toRow, int okDiff)
    {
        var diff = fromRow - toRow;
        var isPossible = fromRow >= toRow && diff <= okDiff;
        if (isPossible)
        {
            IsFirstMove = false;
        }
        return isPossible;
    }
    
    private bool IsBlackDiagonalMovePossible(int[] fromCoordinates, int[] toCoordinates, Piece targetPiece)
    {
  
        if (targetPiece.Color == Color) return false;
        var verticalDiff = Math.Abs(fromCoordinates[Y] - toCoordinates[Y]);
        var verticalDiffDirection = fromCoordinates[Y] < toCoordinates[Y];
        var horizontalDiff = Math.Abs(fromCoordinates[X] - toCoordinates[X]);

        var isPossible = verticalDiff == 1 && horizontalDiff == 1 && verticalDiffDirection;

        if (isPossible)
        {
            IsFirstMove = false;
        }
        
        return isPossible;
    }
    
    private bool IsWhiteDiagonalMovePossible(int[] fromCoordinates, int[] toCoordinates, Piece targetPiece)
    {
        if (targetPiece.Color == Color) return false;
        var verticalDiff = Math.Abs(fromCoordinates[Y] - toCoordinates[Y]);
        var verticalDiffDirection = fromCoordinates[Y] > toCoordinates[Y];
        var horizontalDiff = Math.Abs(toCoordinates[X] - fromCoordinates[X]);
        
        var isPossible = verticalDiff == 1 && horizontalDiff == 1 && verticalDiffDirection;
        
        if (isPossible)
        {
            IsFirstMove = false;
        }
        
        return isPossible;
    }
}