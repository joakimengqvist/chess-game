import React from 'react';
import { useToastStore } from '../../store/toast.store';

const Toasts: React.FC = () => {
  const { toasts } = useToastStore(state => state);

  return (
    <div style={{ position: 'fixed', top: '20px', right: '20px', zIndex: 1000 }}>
      {toasts.map((toast, index) => (
        <div
          key={index}
          style={{
            backgroundColor: 'whitesmoke',
            color: toast.type === 'success' ? '#155724' : '#721C24',
            border: toast.type === 'success' ? '2px solid silver' : '1px solid #721C24',
            padding: '15px 30px',
            borderRadius: '4px',
            marginBottom: '10px',
            fontSize: '16px',
            fontWeight: 'bold',
            opacity: 1,
            animation: 'fadeIn 0.5s ease',
            display: 'flex',
            alignItems: 'center',
            justifyContent: 'flex-start',
            width: '300px'
          }}
        >
          {toast.message}
        </div>
      ))}
    </div>
  );
};

export default Toasts;
