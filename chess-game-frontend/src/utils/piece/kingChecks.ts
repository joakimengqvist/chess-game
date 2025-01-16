import { PieceType } from "../../enums/pieceType";
import { Piece } from "../../interfaces";
import { GameStatus } from "../../store/chessBoard.store";

export const isPieceKing = (piece : Piece | null) => piece?.type === PieceType.King;
export const isKingInDanger =  (piece : Piece | null, status : GameStatus) => piece?.color === 1 && isPieceKing(piece) ? status.whiteKingCheck : isPieceKing(piece) ? status.blackKingCheck : false;