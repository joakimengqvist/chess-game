import { useState } from "react";
import ChessPiece from "./piece/ChessPiece";
import Square from "./Square/ChessSquare";
import { squareColor } from "../../../utils/squareColor";
import { highlightPossibleMoves } from "../../../utils/highlightPossibleMoves";
import { resetHighlight } from "../../../utils/highlightSquare";
import { useChessBoardStore } from "../../../store/chessBoard.store";

const ChessBoard = () => {
  const [fromCoordinates, setFromCordinates] = useState<Array<number>>([0,0]);

  const { chessGame, movePiece } = useChessBoardStore();

  if (!chessGame) return;

  const onDropChessPiece = (toCoordinates : Array<number>) => {
    resetHighlight();
    movePiece(toCoordinates, fromCoordinates);
  };

  const onDragStart = (fromCoordinates : Array<number>) => {
    highlightMoves(fromCoordinates);
    setFromCordinates(fromCoordinates);
};

  const onClickPiece = (fromCoordinates : Array<number>) => {
    highlightMoves(fromCoordinates);
  }

  const highlightMoves = (fromCoordinates : Array<number>) => {
    resetHighlight();
    highlightPossibleMoves(fromCoordinates, chessGame.board);
  }

  return chessGame.board && chessGame.board.map((row, y) => (
    <div key={y} style={{display: "flex", width: 'fit-content' }}>
      {row.map((piece, x) => (
        <Square
          key={y + x + "square"}
          y={y}
          x={x}
          color={squareColor(y, x)}
          onDropChessPiece={onDropChessPiece}
          >
          <ChessPiece piece={piece} y={y} x={x} onDragStart={onDragStart} onClickPiece={onClickPiece} />
        </Square>
      ))}
    </div>
  ))
};

export default ChessBoard