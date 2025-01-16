import React from 'react';
import { useChessBoardStore } from '../../store/chessBoard.store';
import { buttonStyle } from '../../utils/styles/buttonStyle';

const GameOverDialog: React.FC = () => {
  const {chessGame, resetGameState} = useChessBoardStore();
  if (!chessGame) return;

  const { winner, isCheckmate } = chessGame.status;
  if (!isCheckmate) return;

  return (
    <>
      <div
        style={{
          zIndex: 10,
          position: 'absolute',
          backgroundColor: 'rgba(128, 128, 128, 0.4)',
          width: '100%',
          height: '100%',
          top: 0,
          left: 0,
        }}
      ></div>
      <dialog
        open={isCheckmate}
        style={{
          zIndex: 11,
          margin: '60px auto',
          padding: '30px',
          width: '400px',
          borderRadius: '8px',
          boxShadow: '0px 8px 16px rgba(0, 0, 0, 0.3)',
          textAlign: 'center',
          backgroundColor: '#fff',
        }}
      >
        <h2 style={{ marginBottom: '20px', fontSize: '24px' }}>Game Over!</h2>
        <p style={{ marginBottom: '30px', fontSize: '18px' }}>
          The game was won by <strong>{winner}</strong>
        </p>
        <button
          onClick={resetGameState}
          style={buttonStyle}
          onMouseEnter={(e) => (e.currentTarget.style.backgroundColor = '#0056b3')}
          onMouseLeave={(e) => (e.currentTarget.style.backgroundColor = '#007bff')}
        >
          Restart Game
        </button>
      </dialog>
    </>
  );
};

export default GameOverDialog;
