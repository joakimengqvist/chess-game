namespace ChessGameService.Enums;
[Flags]
public enum Coordinates : byte
{
    YCoordinate = 0b_0000_0000,
    XCoordinate = 0b_0000_0001
}