import { ReactNode } from "react";
import { resetHighlight } from "../../../../utils/highlightSquare";

interface ChessSquareProps {
    color: string
    children: ReactNode
    y: number,
    x: number,
    onDropChessPiece: (toCoordinates : Array<number>) => void;
}

export default function Square(props : ChessSquareProps) {
    const { color, children, y, x, onDropChessPiece } = props;

    const handleDrop = () => {
        onDropChessPiece([y,x]);
        resetHighlight();
    };

    // eslint-disable-next-line @typescript-eslint/no-explicit-any
    const onDragOver = (event : any) => {
        event.preventDefault()
    }

    return (
        <div onDrop={handleDrop} onDragOver={onDragOver} style={{background: color, height: 'fit-content', width: 'fit-content', margin: '2px', border: '1px solid gray'}} id={`square-${x}${y}`}>
            {children}
        </div>
    );
}