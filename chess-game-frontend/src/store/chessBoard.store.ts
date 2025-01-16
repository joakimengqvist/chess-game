import { create } from 'zustand';
import { Piece } from '../interfaces';
import { getChessBoard } from './api/getChessBoard';
import { makeChessMove } from './api/makeChessMove';
import { useToastStore } from './toast.store';
import clickSound from '../assets/sounds/click.wav';
import errorSound from '../assets/sounds/error.wav';
import { resetGame } from './api/resetGame';

export interface ChessGame {
    loading: boolean,
    board: Board | null,
    status: GameStatus
}

export interface GameStatus {
    turnOfColor: 'White' | 'Black',
    blackKingCheck: boolean,
    whiteKingCheck: boolean,
    isCheckmate: boolean,
    winner: 'White' | 'Black' | '',

}

export type Board = (Piece | null)[][];

interface ChessBoardState {
    loading: boolean,
    chessGame: ChessGame | null;

    fetchGameState: () => Promise<void>;
    resetGameState: () => Promise<void>;
    movePiece: (toCoordinates: Array<number>, fromCoordinates: Array<number>) => Promise<void>;
}

export const initialState : ChessGame = {
        loading: true,
        board: null,
        status: {
            turnOfColor: 'White',
            whiteKingCheck: false,
            blackKingCheck: false,
            isCheckmate: false,
            winner: '',
    }

}

export const useChessBoardStore = create<ChessBoardState>((set) => ({
    loading: true,
    chessGame: initialState,
    error: null,

    fetchGameState: () => {
        set({loading: true})
        return getChessBoard()
            .then((response) => {
                set({ chessGame: response, loading: false });
            })
            .catch((error) => {
                set({ chessGame: null, loading: false });
                useToastStore.getState().showToast(error.response.data.error, 'error');
            });
    },

    resetGameState: () => {
        set({ loading: true });
        return resetGame()
            .then((response) => {
                    set({ chessGame: response, loading: false });
            })
            .catch((error) => {
                set({ chessGame: null, loading: false });
                useToastStore.getState().showToast(error.response.data.error, 'error');
            });
    },

    movePiece: (toCoordinates, fromCoordinates) => {
        set({ loading: true });
        return makeChessMove(toCoordinates, fromCoordinates)
            .then((response) => {
                set({ chessGame: response, loading: false });
                new Audio(clickSound).play();
                useToastStore.getState().showToast("Successfully made the move!", 'success');
            })
            .catch((error) => {
                set({ loading: false });
                new Audio(errorSound).play();
                useToastStore.getState().showToast(error.response.data.error, 'error');
            });
    },
}));
