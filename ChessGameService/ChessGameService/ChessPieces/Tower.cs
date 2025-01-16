using ChessGameService.Enums;

namespace ChessGameService.ChessPieces;

public class Tower : Piece
{
    public Tower(Color color) : base(color)
    {
        Type = PieceType.Tower;
    }

    public override bool IsCompleteMovePossible(int[] fromCoordinates, int[] toCoordinates, Piece?[,] board)
    {
        var isHorizontal = IsHorizontalMove(fromCoordinates, toCoordinates);
        var isVertical = IsVerticalMove(fromCoordinates, toCoordinates);

        if (!isHorizontal && !isVertical) return false;

        return isHorizontal
            ? IsHorizontalMovePossible(fromCoordinates, toCoordinates, board)
            : IsVerticalMovePossible(fromCoordinates, toCoordinates, board);
    }
}