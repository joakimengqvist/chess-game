import { ReactNode } from "react";

interface ChessSquareProps {
    color: string
    children: ReactNode
    y: number,
    x: number,
}

export default function SquareHistory(props : ChessSquareProps) {
    const { color, children, y, x } = props;

    return (
        <div style={{background: color, height: 'fit-content', width: 'fit-content', margin: '2px', border: '1px solid gray'}} id={`square-${x}${y}`}>
            {children}
        </div>
    );
}