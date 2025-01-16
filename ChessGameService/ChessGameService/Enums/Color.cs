namespace ChessGameService.Enums;

[Flags]
public enum Color : byte
{
    Black = 0b_0000_0000,
    White = 0b_0000_0001
}
