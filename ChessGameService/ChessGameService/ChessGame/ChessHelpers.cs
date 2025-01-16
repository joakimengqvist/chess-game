using ChessGameService.ChessPieces;
using ChessGameService.Enums;

namespace ChessGameService.ChessGame;

public static class ChessHelpers
{
    public static Piece ClonePiece(Color color, PieceType type)
    {
        return type switch
        {
            PieceType.Pawn => new Pawn(color),
            PieceType.Tower => new Tower(color),
            PieceType.Horse => new Horse(color),
            PieceType.Knight => new Knight(color),
            PieceType.King => new King(color),
            PieceType.Queen => new Queen(color),
            _ => throw new ArgumentException($"Unknown PieceType: {type}")
        };
    }
    public static Piece?[,] CloneBoard(Piece?[,] board)
    {
        var newBoard = new Piece?[8, 8];
        IterateBoard<object>(board, (y, x, piece) =>
        {
            newBoard[y, x] = piece;
            return null;
        });
        
        return newBoard;
    }
    
    public static TResult? IterateBoard<TResult>(
        Piece?[,] board,
        Func<int, int, Piece?, TResult?> action,
        bool stopOnResult = false
    )
    {
        for (var y = 0; y < 8; y++)
        {
            for (var x = 0; x < 8; x++)
            {
                var result = action(y, x, board[y, x]);
                if (stopOnResult && result != null)
                {
                    return result;
                }
            }
        }
        return default;
    }

    
    public static void LogBoard(Piece?[,] board)
    {
        Console.WriteLine("Start board -------------------");
        for (var y = 0; y < 8; y++)
        {
            for (var x = 0; x < 8; x++)
            {
                Console.Write(board[y, x]?.GetType().Name ?? "null");
                Console.Write("\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine("End board -------------------");
    }

}