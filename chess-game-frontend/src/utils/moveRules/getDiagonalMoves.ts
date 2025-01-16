import { Piece } from "../../interfaces";
import { isValidMove } from "./isValidMove";

export const getDiagonalMoves = (
    x: number,
    y: number,
    piece: Piece,
    board: (Piece | null)[][],
) => {

    // Top-right
    for (let i = 1; x + i < board.length && y + i < board[0].length; i++) {
        if (!isValidMove(x + i, y + i, piece, board)) break;
    }

    // Top-left
    for (let i = 1; x + i < board.length && y - i >= 0; i++) {
        if (!isValidMove(x + i, y - i, piece, board)) break;
    }

    // Bottom-right
    for (let i = 1; x - i >= 0 && y + i < board[0].length; i++) {
        if (!isValidMove(x - i, y + i, piece, board)) break;
    }

    // Bottom-left
    for (let i = 1; x - i >= 0 && y - i >= 0; i++) {
        if (!isValidMove(x - i, y - i, piece, board)) break;
    }
};