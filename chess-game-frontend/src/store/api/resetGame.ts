import axios from 'axios';
import { ChessGame, initialState } from '../chessBoard.store';

export async function resetGame() : Promise<ChessGame> {
  try {
    const response = await axios.get('http://localhost:5069/api/reset-game');
    return response.data;
  } catch (error) {
    return initialState
  }
}