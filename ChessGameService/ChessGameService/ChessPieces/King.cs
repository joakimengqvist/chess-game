using ChessGameService.ChessGame;
using ChessGameService.Enums;

namespace ChessGameService.ChessPieces;

public class King : Piece
{
    public King(Color color) : base(color)
    {
        Type = PieceType.King;
    }

    public override bool IsCompleteMovePossible(int[] fromCoordinates, int[] toCoordinates, Piece?[,] board)
    {
        var isOneStepHorizontally = Math.Abs(toCoordinates[X] - fromCoordinates[X]) == 1;
        var isOneStepVertically =  Math.Abs(toCoordinates[Y] - fromCoordinates[Y]) == 1;
        var isOneStepDiagonally = isOneStepHorizontally && isOneStepVertically;
        
        if (IsHorizontalMove(fromCoordinates, toCoordinates))
        {
            if (isOneStepHorizontally)
            {
                return IsToDestinationPossibleToPlace(board[toCoordinates[Y], toCoordinates[X]]);
            }  
        }
        
        if (IsVerticalMove(fromCoordinates, toCoordinates))
        {
            if (isOneStepVertically)
            {
                return IsToDestinationPossibleToPlace(board[toCoordinates[Y], toCoordinates[X]]);
            }
        }
        
        if (IsMoveDiagonal(fromCoordinates, toCoordinates))
        {
            if (isOneStepDiagonally)
            {
                return IsToDestinationPossibleToPlace(board[toCoordinates[Y], toCoordinates[X]]);
            }
        }
        
        return false;
    }
    
}