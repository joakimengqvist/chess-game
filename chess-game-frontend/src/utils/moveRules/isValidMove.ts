import { Piece } from "../../interfaces";
import { highlightSquare } from "../highlightSquare";

export const isValidMove = (
    x: number,
    y: number,
    piece: Piece,
    board: (Piece | null)[][]
): boolean => {

    const pieceAtCoordinate = board[y][x];
    const isAPiece = typeof pieceAtCoordinate?.type === 'number';

    if (isAPiece) {
        const isEnemy = pieceAtCoordinate.color !== piece.color

        if (isEnemy) {
            highlightSquare(x, y, 'red');
        }

    } else {
        highlightSquare(x, y, 'black');
    }

    return !isAPiece
};