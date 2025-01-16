using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ChessGameService.Utils;

public class ChessGameSerializer : DefaultContractResolver
{
    private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
    {
        ContractResolver = new LowercaseContractResolver()
    };

    public static string SerializeObject(object o)
    {
        return JsonConvert.SerializeObject(o, Formatting.Indented, Settings);
    }
    
    private static string SerializeHistoryResponse(ChessGame.ChessGame chessGame)
    {
        var history = chessGame.History.ChessHistory.Select(snapshot => snapshot).ToList();
            
        return SerializeObject(new { history });
    }
    
    private static string SerializeChessGameResponse(ChessGame.ChessGame chessGame)
    {
        var board = chessGame.Board;
        var gameStatus = chessGame.Status;
        var status = new
        {
            turnOfColor = gameStatus.TurnOfColor.ToString(),
            whiteKingCheck = gameStatus.WhiteKingCheck,
            blackKingCheck = gameStatus.BlackKingCheck,
            isCheckmate = gameStatus.IsCheckmate,
            winner = gameStatus.Winner.ToString()
        };
            
        return SerializeObject(new { board, status });
    }
    
    private class LowercaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName) || char.IsLower(propertyName[0]))
            {
                return propertyName;
            }
            
            return char.ToLower(propertyName[0]) + propertyName.Substring(1);
        }
    }
}