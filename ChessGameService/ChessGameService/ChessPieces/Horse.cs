using ChessGameService.Enums;

namespace ChessGameService.ChessPieces;

public class Horse : Piece
{
    public Horse(Color color) : base(color)
    {
        Type = PieceType.Horse;
    }

    public override bool IsCompleteMovePossible(int[] fromCoordinates, int[] toCoordinates, Piece?[,] board)
    {
        var fromRow = fromCoordinates[Y];
        var fromLine = fromCoordinates[X];
        var toRow = toCoordinates[Y];
        var toLine = toCoordinates[X];

        var isVerticalNegative = fromRow - toRow == 2;
        var isVerticalPositive = toRow - fromRow == 2;
        var isHorizontalNegative = fromLine - toLine == 2;
        var isHorizontalPositive = toLine - fromLine == 2;
        
        if (isVerticalNegative)
        {
            return IsVerticalNegativeMovePossible(fromCoordinates, toCoordinates, board);
        }
        
        if (isVerticalPositive)
        {
            return IsVerticalPositiveMovePossible(fromCoordinates, toCoordinates, board);
        }
        
        if (isHorizontalNegative)
        {
            return IsHorizontalNegativeMovePossible(fromCoordinates, toCoordinates, board);
        }

        return isHorizontalPositive && IsHorizontalPositiveMovePossible(fromCoordinates, toCoordinates, board);
    }

    private bool IsVerticalNegativeMovePossible(int[] fromCoordinates, int[] toCoordinates, Piece?[,] board)
    {
        
        var fromLine = fromCoordinates[X];
        var toLine = toCoordinates[X];

        var isNegativeHorizontalMove = fromLine >= toLine;
        
        if (isNegativeHorizontalMove)
        {
            return fromLine - toLine == 1 && IsToDestinationPossibleToPlace(board[toCoordinates[Y], toCoordinates[1]]);
        }

        return toLine - fromLine == 1 && IsToDestinationPossibleToPlace(board[toCoordinates[Y], toCoordinates[1]]);
    }
    
    private bool IsVerticalPositiveMovePossible(int[] fromCoordinates, int[] toCoordinates, Piece?[,] board)
    {
        var fromLine = fromCoordinates[X];
        var toLine = toCoordinates[X];

        var isPositiveHorizontalMove = toLine >= fromLine;

        if (isPositiveHorizontalMove)
        {
            return toLine - fromLine == 1 && IsToDestinationPossibleToPlace(board[toCoordinates[Y], toCoordinates[1]]);
        }

        return fromLine - toLine == 1 && IsToDestinationPossibleToPlace(board[toCoordinates[Y], toCoordinates[1]]);
    }
    
    private bool IsHorizontalNegativeMovePossible(int[] fromCoordinates, int[] toCoordinates, Piece?[,] board)
    {
        var fromRow = fromCoordinates[Y];
        var toRow = toCoordinates[Y];

        var isPositiveVerticalMove = toRow >= fromRow;
        
        if (isPositiveVerticalMove)
        {
            return toRow - fromRow == 1 && IsToDestinationPossibleToPlace(board[toCoordinates[Y], toCoordinates[1]]);
        }

        return fromRow - toRow == 1 && IsToDestinationPossibleToPlace(board[toCoordinates[Y], toCoordinates[1]]);
    }
    
    private bool IsHorizontalPositiveMovePossible(int[] fromCoordinates, int[] toCoordinates, Piece?[,] board)
    {
        var fromRow = fromCoordinates[Y];
        var toRow = toCoordinates[Y];
        
        var isNegativeVerticalMove = fromRow >= toRow;

        if (isNegativeVerticalMove)
        {
            return fromRow - toRow == 1 && IsToDestinationPossibleToPlace(board[toCoordinates[Y], toCoordinates[1]]);
        }

        return toRow - fromRow == 1 && IsToDestinationPossibleToPlace(board[toCoordinates[Y], toCoordinates[1]]);
    }
}