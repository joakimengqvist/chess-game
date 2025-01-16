import { Piece } from "../../interfaces";
import { highlightSquare } from "../highlightSquare";
import { isValidMove } from "./isValidMove";
import { isWithinBounds } from "./isWithinBounds";

export const getHorseMoves = (
    x: number,
    y: number,
    piece: Piece,
    board: (Piece | null)[][],
) => {

    const horseMoves = [
        [x + 2, y + 1],
        [x + 2, y - 1],
        [x - 2, y + 1],
        [x - 2, y - 1],
        [x + 1, y + 2],
        [x + 1, y - 2],
        [x - 1, y + 2],
        [x - 1, y - 2],
    ];

    for (const [newX, newY] of horseMoves) {
        if (isWithinBounds(newX, newY) && isValidMove(newX, newY, piece, board)) {
            highlightSquare(newX, newY, 'black');
        }
    }
};