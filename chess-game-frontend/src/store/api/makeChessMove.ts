import { API_URL } from './apiUrl';
import axios from "axios";

export async function makeChessMove(toCoordinates : Array<number>, fromCoordinates : Array<number>) {
    try {
      const response = await axios.post(`${API_URL}/api/move`, {
        toCoordinates: toCoordinates,
        fromCoordinates: fromCoordinates
      });

      return response.data;
    } catch (error) {
      console.error('Error making chess move:', error);
      throw error;
    }
}