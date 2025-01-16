import { PieceType } from "../../enums/pieceType";

export const pieceName = (pieceType : number) => {
    switch(pieceType) {
        case PieceType.Pawn:
            return "pawn";
        case PieceType.Tower:
            return "tower";
        case PieceType.Horse:
            return "horse";
        case PieceType.Knight:
            return "knight";
        case PieceType.Queen:
            return "queen";
        case PieceType.King:
            return "king"
        default:
            return "unknown"
    }
}