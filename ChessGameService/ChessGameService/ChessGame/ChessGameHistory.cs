using ChessGameService.ChessPieces;

namespace ChessGameService.ChessGame;

public class ChessGameHistory()
{
    public List<History> ChessHistory { get; set; } = [];

    public void AddSnapshot(Piece?[,] board, int[] fromCoordinates, int[] toCoordinates)
    {
        var history = new History(ChessHelpers.CloneBoard(board), fromCoordinates, toCoordinates);
        ChessHistory.Add(history);
    }
}

public class History(Piece?[,] board, int[] fromCoordinates, int[] toCoordinates)
{
    public Piece?[,] Board { get; } = board;
    public Move Move { get; } = new Move(fromCoordinates, toCoordinates);
}

public class Move(int[] fromCoordinates, int[] toCoordinates)
{
    public int[] FromCoordinates = fromCoordinates;
    public int[] ToCoordinates = toCoordinates;
}