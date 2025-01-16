import { Piece } from "../../interfaces";
import { highlightSquare } from "../highlightSquare";
import { isValidMove } from "./isValidMove";
import { isWithinBounds } from "./isWithinBounds";

export const getKingMoves = (
    x: number,
    y: number,
    piece: Piece,
    board: (Piece | null)[][],
) => {

    const kingMoves = [
        [x + 1, y],
        [x - 1, y],
        [x, y + 1],
        [x, y - 1],
        [x + 1, y + 1],
        [x - 1, y - 1],
        [x + 1, y - 1],
        [x - 1, y + 1],
    ];

    for (const [newX, newY] of kingMoves) {
        if (isWithinBounds(newX, newY) && isValidMove(newX, newY, piece, board)) {
            highlightSquare(newX, newY, 'black');
        }
    }
};
