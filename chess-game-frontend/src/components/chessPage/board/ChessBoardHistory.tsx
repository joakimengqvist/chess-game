import { historySquareColor } from "../../../utils/squareColor";
import SquareHistory from "./Square/ChessSquareHistory";
import ChessPieceHistory from "./piece/ChessPieceHistory";
import { useChessBoardHistoryStore } from "../../../store/chessBoardHistory.store";
import { useEffect } from "react";

interface ChessBoardHistoryProps {
  isOpen: boolean
}
const ChessBoardHistory = (props: ChessBoardHistoryProps) => {
  const { isOpen } = props;
  const { history, fetchGameHistory } = useChessBoardHistoryStore();

  useEffect(() => {
    fetchGameHistory();
  }, [fetchGameHistory, isOpen]);

  const historySnapShots = history[0]?.board && history.map((historyItem, i) => (
    <div
      style={{
        padding: '4px',
        border: '1px solid #ccc',
        display: 'inline-block',
        textAlign: 'center',
      }}
    >
      <div
        style={{
          display: 'flex',
          marginBottom: '4px',
          justifyContent: 'space-between',
          width: '100%',
        }}
      >
        <p style={{ margin: 0, fontWeight: 'bold', paddingLeft: '4px' }}>
          {i % 2 === 0 ? "White's move" : "Black's move"}
        </p>
        <span style={{ paddingRight: '4px', fontWeight: 'bold' }}>
          Round {i + 1}
        </span>
      </div>
      {historyItem.board &&
        historyItem.board.map((row, y) => (
          <div key={y} style={{ display: 'flex', width: 'fit-content', margin: '0 auto' }}>
            {row.map((piece, x) => (
              <SquareHistory
                key={y + x + "square"}
                y={y}
                x={x}
                color={historySquareColor(y, x, historyItem.move)}
              >
                <ChessPieceHistory piece={piece} />
              </SquareHistory>
            ))}
          </div>
        ))}
    </div>
  ));

  return (
    <div style={{ display: 'flex', justifyContent: 'center', width: '100%' }}>
      <div
        style={{
          display: 'flex',
          flexWrap: 'wrap',
          justifyContent: 'center',
          alignItems: 'center',
          gap: '8px',
          margin: '0 auto',
          maxWidth: '100%',
        }}
      >
        {historySnapShots}
      </div>
    </div>
  );
}

export default ChessBoardHistory