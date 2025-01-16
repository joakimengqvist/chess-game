import { Piece } from "../../interfaces";
import { isValidMove } from "./isValidMove";

export const getStraightMoves = (
    x: number,
    y: number,
    piece: Piece,
    board: (Piece | null)[][],
) => {

    // moving right
    for (let i = x + 1; i < board[0].length; i++) {
        if (!isValidMove(i, y, piece, board)) break;
    }

    // moving left
    for (let i = x - 1; i > -1; i--) {
        if (!isValidMove(i, y, piece, board)) break;
    }

    // moving down
    for (let i = y + 1; i < board[0].length; i++) {
        if (!isValidMove(x, i, piece, board)) break;
    }

    // moving up
    for (let i = y - 1; i > -1; i--) {
        if (!isValidMove(x, i, piece, board)) break;
    }


};
