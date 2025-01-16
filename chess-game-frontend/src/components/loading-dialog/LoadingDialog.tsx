import React from 'react';
import LoadingSpinner from '../loading-spinner/LoadingSpinner';
import { useChessBoardStore } from '../../store/chessBoard.store';

const LoadingDialog: React.FC = () => {
    const { loading } = useChessBoardStore();
    if (!loading) return null;

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
        <LoadingSpinner />
    </>
  );
};

export default LoadingDialog;
