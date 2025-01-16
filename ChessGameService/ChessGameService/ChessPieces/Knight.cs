using ChessGameService.Enums;

namespace ChessGameService.ChessPieces;

public class Knight : Piece
{
    public Knight(Color color) : base(color)
    {
        Type = PieceType.Knight;
    }
    
    public override bool IsCompleteMovePossible(int[] fromCoordinates, int[] toCoordinates, Piece?[,] board)
    {
        var isHorizontal = IsHorizontalMove(fromCoordinates, toCoordinates);
        var isVertical = IsVerticalMove(fromCoordinates, toCoordinates);

        if (isHorizontal || isVertical) return false;
        
        return IsDiagonalMovePossible(fromCoordinates, toCoordinates, board);
    }
}