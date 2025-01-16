namespace ChessGameService.Controllers.DTO;

public class MakeMovePayload
{
    public int[] ToCoordinates { get; set; }
    public int[] FromCoordinates { get; set; }
}