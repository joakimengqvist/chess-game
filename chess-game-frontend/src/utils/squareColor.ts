import { Move } from "../store/chessBoardHistory.store";

export const squareColor = (y: number, x: number) => {
    return (y + x) % 2 === 0 ? 'rgba(50, 50, 50, 0.1)' : 'rgba(35, 20, 35, 0.25)';
};

export const historySquareColor = (y: number, x: number, move: Move) => {
    if (move.fromCoordinates[0] === y && move.fromCoordinates[1] === x) {
        return 'rgba(135, 206, 250, 0.8)';
    }
    if (move.toCoordinates[0] === y && move.toCoordinates[1] === x) {
        return 'rgba(250, 128, 114, 0.8)';
    }
    return (y + x) % 2 === 0 ? 'rgba(50, 50, 50, 0.1)' : 'rgba(35, 20, 35, 0.25)';
};