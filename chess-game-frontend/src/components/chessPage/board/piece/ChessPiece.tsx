import { Piece } from "../../../../interfaces";
import { useChessBoardStore } from "../../../../store/chessBoard.store";
import { pieceColor } from "../../../../utils/piece/pieceColor";
import { isKingInDanger } from "../../../../utils/piece/kingChecks";
import { pieceName } from "../../../../utils/piece/pieceName";
import ChessPieceSvg from "./ChessPieceSvg";
import { isTurnForPiece } from "../../../../utils/piece/isTurnForPiece";

interface ChessPieceProps {
    piece: Piece | null;
    y: number;
    x: number;
    onDragStart: (fromCoordinates: number[]) => void;
    onClickPiece: (fromCoordinates: number[]) => void;
}

const ChessPiece = (props: ChessPieceProps) => {
    const { piece, y, x, onDragStart, onClickPiece } = props;

    const { chessGame } = useChessBoardStore();

    if (!chessGame) return;

    const { status } = chessGame;

    const thisPieceTurn = isTurnForPiece(piece, status.turnOfColor);
    const onDrag = () => onDragStart([y, x]);
    const onClick = () => onClickPiece([y, x]);

    return (
        <div
            onDragStart={onDrag}
            onClick={onClick}
            draggable={thisPieceTurn}
            style={{
                height: '75px',
                width: '75px',
                cursor: !piece ? 'default' : thisPieceTurn ? "move" : "pointer",
                border: '1px solid lightgray',
            }}
        >
            {piece && (
                <div
                    style={{
                        height: "100%",
                        display: "flex",
                        justifyContent: "center",
                        alignItems: "center",
                    }}
                >
                    <ChessPieceSvg
                        piece={pieceName(piece.type)}
                        color={pieceColor(piece.color)}
                        isKingInDanger={isKingInDanger(piece, status)}
                    />
                </div>
            )}
        </div>
    );
};

export default ChessPiece;
