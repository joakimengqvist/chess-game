using ChessGameService.ChessGame;
using ChessGameService.Enums;

namespace ChessGameService.ChessPieces;

using static Coordinates;

public abstract class Piece(Color color)
{
    protected readonly int Y = (int)YCoordinate;
    protected readonly int X = (int)XCoordinate;
    public Color Color { get; } = color;
    public PieceType Type { get; protected init; }
    public abstract bool IsCompleteMovePossible(int[] fromCoordinates, int[] toCoordinates, Piece?[,] board);
    
    public List<int[]> ValidMoves(int[] fromCoordinates, Piece?[,] board)
    {
        var moves = new List<int[]>();
        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                var toCoordinates = new[] { y, x };
                if (SimulateCheckIsCompleteMovePossible(fromCoordinates, toCoordinates, board))
                {
                    moves.Add(toCoordinates); 
                }
            }
        }
        
        return moves;
    }

    private protected bool SimulateCheckIsCompleteMovePossible(int[] fromCoordinates, int[] toCoordinates, Piece?[,] board)
    {
        try
        {
            return IsCompleteMovePossible(fromCoordinates, toCoordinates, board);
        }
        catch
        {
            return false;
        }
    }

    protected bool IsToDestinationPossibleToPlace(Piece? piece)
    {
        return piece?.Color != Color;
    }

    protected bool IsToDestinationEmpty(Piece? piece)
    {
        return piece == null;
    }
    protected bool IsHorizontalMove(int[] fromCoordinates, int[] toCoordinates)
    {
        return fromCoordinates[Y] == toCoordinates[Y];
    }

    protected bool IsVerticalMove(int[] fromCoordinates, int[] toCoordinates)
    {
        return fromCoordinates[X] == toCoordinates[X];
    }

    protected bool IsMoveDiagonal(int[] fromCoordinates, int[] toCoordinates)
    {
        return fromCoordinates[X] != toCoordinates[X];
    }
    
    protected bool IsHorizontalMovePossible(int[] fromCoordinates, int[] toCoordinates, Piece?[,] board)
    {
        var isNegativeIndexDirection = fromCoordinates[X] > toCoordinates[X];
        return isNegativeIndexDirection
            ? IsNegativeHorizontalMovePossible(fromCoordinates, toCoordinates, board)
            : IsPositiveHorizontalMovePossible(fromCoordinates, toCoordinates, board);
    }

    protected bool IsVerticalMovePossible(int[] fromCoordinates, int[] toCoordinates, Piece?[,] board)
    {
        var isNegativeIndexDirection = fromCoordinates[Y] > toCoordinates[Y];
        return isNegativeIndexDirection
            ? IsNegativeVerticalMovePossible(fromCoordinates, toCoordinates, board)
            : IsPositiveVerticalMovePossible(fromCoordinates, toCoordinates, board);
    }

    private bool IsNegativeHorizontalMovePossible(int[] fromCoordinates, int[] toCoordinates, Piece?[,] board)
    {
        var numberOfMoves = fromCoordinates[X] - toCoordinates[X];
        var isPossible = false;

        for (var i = 1; i <= numberOfMoves; i++)
        {
            if (i != numberOfMoves && !IsToDestinationEmpty(board[fromCoordinates[Y], fromCoordinates[X] - i]))
            {
                throw new InvalidOperationException("Cant jump over another piece");
            }

            if (i != numberOfMoves) continue;
            isPossible = IsToDestinationPossibleToPlace(board[fromCoordinates[Y], fromCoordinates[X] - i]);
        }

        return isPossible;
    }

    private bool IsPositiveHorizontalMovePossible(int[] fromCoordinates, int[] toCoordinates, Piece?[,] board)
    {
        var numberOfMoves = toCoordinates[X] - fromCoordinates[X];
        var isPossible = false;

        for (var i = 1; i <= numberOfMoves; i++)
        {

            if (i != numberOfMoves && !IsToDestinationEmpty(board[fromCoordinates[Y], fromCoordinates[X] + i]))
            {
                throw new InvalidOperationException("Cant jump over another piece");
            }

            if (i != numberOfMoves) continue;
            isPossible = IsToDestinationPossibleToPlace(board[fromCoordinates[Y], fromCoordinates[X] + i]);
        }

        return isPossible;
    }

    private bool IsNegativeVerticalMovePossible(int[] fromCoordinates, int[] toCoordinates, Piece?[,] board)
    {

        var numberOfMoves = Math.Abs(fromCoordinates[Y] - toCoordinates[Y]);
        var isPossible = false;

        for (var i = 1; i <= numberOfMoves; i++)
        {
            if (i != numberOfMoves && !IsToDestinationEmpty(board[fromCoordinates[Y] - i, toCoordinates[X]]))
            {
                throw new InvalidOperationException("Cant jump over another piece");
            }

            if (i != numberOfMoves) continue;
            isPossible = IsToDestinationPossibleToPlace(board[fromCoordinates[Y] - i, toCoordinates[X]]);
        }

        return isPossible;
    }

    private bool IsPositiveVerticalMovePossible(int[] fromCoordinates, int[] toCoordinates, Piece?[,] board)
    {
        var numberOfMoves = Math.Abs(toCoordinates[Y] - fromCoordinates[Y]);
        var isPossible = false;

        for (var i = 1; i <= numberOfMoves; i++)
        {
            if (i != numberOfMoves && !IsToDestinationEmpty(board[fromCoordinates[Y] + i, toCoordinates[X]]))
            {
                throw new InvalidOperationException("Cant jump over another piece");
            }

            if (i != numberOfMoves) continue;
            isPossible = IsToDestinationPossibleToPlace(board[fromCoordinates[Y] + i, toCoordinates[X]]);
        }

        return isPossible;
    }
    
    protected bool IsDiagonalMovePossible(int[] fromCoordinates, int[] toCoordinates, Piece?[,] board)
    {
        var rowDiff = fromCoordinates[Y] - toCoordinates[Y];
        var lineDiff = fromCoordinates[X] - toCoordinates[X];
        var isLineDirectionPositive = lineDiff < 0;
        var isRowDirectionPositive = rowDiff < 0;
        
        if (isRowDirectionPositive)
        {
            return isLineDirectionPositive ? 
                IsRowPositiveLinePositivePossible(fromCoordinates, toCoordinates, board) : 
                IsRowPositiveLineNegativePossible(fromCoordinates, toCoordinates, board);
        }
        
        return isLineDirectionPositive ? 
            IsRowNegativeLinePositivePossible(fromCoordinates, toCoordinates, board) : 
            IsRowNegativeLineNegativePossible(fromCoordinates, toCoordinates, board);
    }
    
    private bool IsRowPositiveLineNegativePossible(int[] fromCoordinates, int[] toCoordinates, Piece?[,] board)
    {
        var rowDiff = Math.Abs(fromCoordinates[Y] - toCoordinates[Y]);
        var lineDiff = fromCoordinates[X] - toCoordinates[X];
        
        if (rowDiff != lineDiff) return false;
        
        var isPossible = false;

        for (var i = 1; i <= lineDiff; i++)
        {
            if (i < rowDiff)
            {
                if (!IsToDestinationEmpty(board[fromCoordinates[Y] + i, fromCoordinates[X] - i]))
                {
                    throw new InvalidOperationException("Cant jump over another piece");
                }
            }
            else
            {
                isPossible = IsToDestinationPossibleToPlace(board[toCoordinates[Y], toCoordinates[X]]);
            }
        }
        
        return isPossible;

    }

    private bool IsRowPositiveLinePositivePossible(int[] fromCoordinates, int[] toCoordinates, Piece?[,] board)
    {
        var rowDiff = Math.Abs(fromCoordinates[Y] - toCoordinates[Y]);
        var lineDiff = Math.Abs(fromCoordinates[X] - toCoordinates[X]);
        if (rowDiff != lineDiff) return false;
        
        var isPossible = false;

        for (var i = 1; i <= rowDiff; i++)
        {
            if (i < rowDiff)
            {
                if (!IsToDestinationEmpty(board[fromCoordinates[Y] + i, fromCoordinates[X] + i]))
                {
                    throw new InvalidOperationException("Cant jump over another piece");
                }
            }
            else
            {
                isPossible = IsToDestinationPossibleToPlace(board[toCoordinates[Y], toCoordinates[X]]);
            }
        }

        return isPossible;
    }

    private bool IsRowNegativeLineNegativePossible(int[] fromCoordinates, int[] toCoordinates, Piece?[,] board)
    {
        var rowDiff = fromCoordinates[Y] - toCoordinates[Y];
        var lineDiff = fromCoordinates[X] - toCoordinates[X];
        if (rowDiff != lineDiff) return false;
        
        var isPossible = false;

        for (var i = 1; i <= rowDiff; i++)
        {
            if (i < rowDiff)
            {
                if (!IsToDestinationEmpty(board[fromCoordinates[Y] - i, fromCoordinates[X] - i]))
                {
                    throw new InvalidOperationException("Cant jump over another piece");
                }
            }
            else
            {
                isPossible = IsToDestinationPossibleToPlace(board[toCoordinates[Y], toCoordinates[X]]);
            }
        }

        return isPossible;
    }

    private bool IsRowNegativeLinePositivePossible(int[] fromCoordinates, int[] toCoordinates, Piece?[,] board)
    {
        var rowDiff = fromCoordinates[Y] - toCoordinates[Y];
        var lineDiff = Math.Abs(fromCoordinates[X] - toCoordinates[X]);

        if (rowDiff != lineDiff) return false;

        var isPossible = false;

        for (var i = 1; i <= rowDiff; i++)
        {
            if (i < rowDiff)
            {
                if (!IsToDestinationEmpty(board[fromCoordinates[Y] - i, fromCoordinates[X] + i]))
                {
                    throw new InvalidOperationException("Cant jump over another piece");
                }
            }
            else
            {
                isPossible = IsToDestinationPossibleToPlace(board[toCoordinates[Y], toCoordinates[X]]);
            }
        }

        return isPossible;
    }
}