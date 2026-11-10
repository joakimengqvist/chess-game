import { API_URL } from './apiUrl';
import axios from 'axios';
import { ChessGame, initialState } from '../chessBoard.store';

export async function resetGame() : Promise<ChessGame> {
  try {
    const response = await axios.get(`${API_URL}/api/reset-game`);
    return response.data;
  } catch (error) {
    return initialState
  }
}