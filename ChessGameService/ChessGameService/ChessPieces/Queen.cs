using ChessGameService.Enums;

namespace ChessGameService.ChessPieces;

public class Queen : Piece
{
    public Queen(Color color) : base(color)
    {
        Type = PieceType.Queen;
    }

    public override bool IsCompleteMovePossible(int[] fromCoordinates, int[] toCoordinates, Piece?[,] board)
    {
        var isHorizontal = IsHorizontalMove(fromCoordinates, toCoordinates);
        var isVertical = IsVerticalMove(fromCoordinates, toCoordinates);

        if (isHorizontal) return IsHorizontalMovePossible(fromCoordinates, toCoordinates, board);

        return isVertical ? 
            IsVerticalMovePossible(fromCoordinates, toCoordinates, board) : 
            IsDiagonalMovePossible(fromCoordinates, toCoordinates, board);
    }
}