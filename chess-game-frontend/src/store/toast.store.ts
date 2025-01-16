import { create } from 'zustand';

interface Toast {
    message: string;
    type: 'success' | 'error';
}

interface ToastState {
    toasts: Toast[];
    showToast: (message: string, type: 'success' | 'error') => void;
}

export const useToastStore = create<ToastState>((set) => ({
    toasts: [],
    showToast: (message: string, type: 'success' | 'error') => {
        set((state) => {
            const newToast = { message, type };
            return { toasts: [...state.toasts, newToast] };
        });
        setTimeout(() => {
            set((state) => {
                return { toasts: state.toasts.slice(1) };
            });
        }, 5000);
    }
}));
