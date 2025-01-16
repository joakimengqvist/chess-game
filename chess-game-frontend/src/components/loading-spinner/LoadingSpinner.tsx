import React, { useState, useEffect } from 'react';

const LoadingSpinner: React.FC = () => {
  const [dots, setDots] = useState('.');

  useEffect(() => {
    const interval = setInterval(() => {
      setDots((prev) => (prev.length < 3 ? prev + '.' : '.'));
    }, 500);
    return () => clearInterval(interval);
  }, []);

  return (
    <div style={spinnerContainerStyle}>
        <div style={spinnerStyle}></div>
        <div style={loadingTextStyle}>
            Loading{dots}
            {dots.length === 1 && '\u00A0\u00A0'}
            {dots.length === 2 && '\u00A0'}
        </div>
    </div>
    );
};

const spinnerContainerStyle: React.CSSProperties = {
  display: 'flex',
  flexDirection: 'column',
  justifyContent: 'center',
  alignItems: 'center',
  height: '100%',
  backgroundColor: 'rgba(255, 255, 255, 0.8)',
  position: 'absolute',
  top: 0,
  left: 0,
  width: '100%',
  zIndex: 1000,
};

const spinnerStyle: React.CSSProperties = {
  width: '50px',
  height: '50px',
  border: '6px solid #ccc',
  borderTop: '6px solid #3498db',
  borderRadius: '50%',
  animation: 'spin 1s linear infinite',
};

const loadingTextStyle: React.CSSProperties = {
  marginTop: '15px',
  fontSize: '18px',
  fontWeight: 'bold',
  color: '#333',
};

// Add spinner animation
const spinnerAnimation = document.createElement('style');
spinnerAnimation.innerHTML = `
  @keyframes spin {
    0% { transform: rotate(0deg); }
    100% { transform: rotate(360deg); }
  }
`;
document.head.appendChild(spinnerAnimation);

export default LoadingSpinner;
