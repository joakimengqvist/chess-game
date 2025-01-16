import { Piece } from "../../interfaces";
import { highlightSquare } from "../highlightSquare";
import { isWithinBounds } from "./isWithinBounds";

export const getPawnMoves = (
    x: number,
    y: number,
    piece: Piece,
    board: (Piece | null)[][],
) => {
    const isWhite = piece.color === 1;
    const direction = isWhite ? -1 : 1;
    const startingRow = isWhite ? 6 : 1;

    const oneStepY = y + direction;
    if (isWithinBounds(x, oneStepY) && board[oneStepY][x] === null) {
        highlightSquare(x, oneStepY, "black");

        const twoStepY = y + 2 * direction;
        if (
            y === startingRow &&
            isWithinBounds(x, twoStepY) &&
            board[twoStepY][x] === null
        ) {
            highlightSquare(x, twoStepY, "black");
        }
    }

    const diagLeftX = x - 1;
    if (
        isWithinBounds(diagLeftX, oneStepY) &&
        board[oneStepY][diagLeftX] !== null &&
        board[oneStepY][diagLeftX]?.color !== piece.color
    ) {
        highlightSquare(diagLeftX, oneStepY, "red");
    }

    const diagRightX = x + 1;
    if (
        isWithinBounds(diagRightX, oneStepY) &&
        board[oneStepY][diagRightX] !== null &&
        board[oneStepY][diagRightX]?.color !== piece.color
    ) {
        highlightSquare(diagRightX, oneStepY, "red");
    }
};
