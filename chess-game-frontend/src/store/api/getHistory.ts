// history

import axios from 'axios';
import { historyInitialState, HistoryItem } from '../chessBoardHistory.store';

interface HistoryResponse {
    history: Array<HistoryItem>
}

export async function getHistory() : Promise<HistoryResponse> {
  try {
    const response = await axios.get('http://localhost:5069/api/history');
    return response.data;
  } catch (error) {
    return {
        history: historyInitialState
    };
  }
}