namespace ChessGameService.Enums;

[Flags]
public enum PieceType : byte
{
    Pawn = 0b_0000_0000,
    Tower = 0b_0000_0001,
    Horse = 0b_0000_0010,
    Knight = 0b_0000_0100,
    King = 0b_0000_1000,
    Queen = 0b_0001_0000
}