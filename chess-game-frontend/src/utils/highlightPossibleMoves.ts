import { PieceType } from "../enums/pieceType";
import { Board } from "../store/chessBoard.store";
import { highlightSquare } from "./highlightSquare";
import { getDiagonalMoves } from "./moveRules/getDiagonalMoves";
import { getHorseMoves } from "./moveRules/getHorseMoves";
import { getKingMoves } from "./moveRules/getKingMoves";
import { getPawnMoves } from "./moveRules/getPawnRules";
import { getStraightMoves } from "./moveRules/getStraightMoves";

export const highlightPossibleMoves = (
    fromCoordinate: Array<number>,
    board: Board | null
) => {
    if (!board) return;

    const [y, x] = fromCoordinate;
    const piece = board[y][x];

    if (piece === null) return;

    highlightSquare(x, y, 'blue');

    switch (piece.type) {
        case PieceType.Pawn:
            getPawnMoves(x, y, piece, board);
            break;
        case PieceType.Tower:
            getStraightMoves(x, y, piece, board);
            break;
        case PieceType.Horse:
            getHorseMoves(x, y, piece, board);
            break;
        case PieceType.Knight:
            getDiagonalMoves(x, y, piece, board);
            break;
        case PieceType.Queen:
            getDiagonalMoves(x, y, piece, board);
            getStraightMoves(x, y, piece, board);
            break;
        case PieceType.King:
            getKingMoves(x, y, piece, board);
            break;
        default:
            return [];
    }
};