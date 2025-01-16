import { create } from 'zustand';
import { useToastStore } from './toast.store';
import { getHistory } from './api/getHistory';
import { Board } from './chessBoard.store';

export interface HistoryItem {
    board: Board | null;
    move: Move
}

export interface Move {
        fromCoordinates: Array<number>
        toCoordinates: Array<number>
}

interface ChessHistoryState {
    loading: boolean,
    history: Array<HistoryItem>
    fetchGameHistory: () => Promise<void>;
}

export const historyInitialState = [{
    board: [],
    move: {
        fromCoordinates: [],
        toCoordinates: []
    }
}];

export const useChessBoardHistoryStore = create<ChessHistoryState>((set) => ({
    loading: false,
    history: historyInitialState,

    fetchGameHistory: () => {
        set({loading: true})
        return getHistory()
            .then((response) => {
                set({ history: response.history, loading: false });
            })
            .catch((error) => {
                set({ history: historyInitialState, loading: false });
                useToastStore.getState().showToast(error.response.data.error, 'error');
            });
    },
}));
