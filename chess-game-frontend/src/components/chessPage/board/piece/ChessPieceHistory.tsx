import { Piece } from "../../../../interfaces";
import { useChessBoardStore } from "../../../../store/chessBoard.store";
import { pieceColor } from "../../../../utils/piece/pieceColor";
import { pieceName } from "../../../../utils/piece/pieceName";
import ChessPieceHistorySvg from "./ChessPieceHistorySvg";

interface ChessPieceHistoryProps {
    piece: Piece | null;
}

const ChessPieceHistory = (props: ChessPieceHistoryProps) => {
    const { piece } = props;

    const { chessGame } = useChessBoardStore();

    if (!chessGame) return;
    return (
        <div
            style={{
                height: '22px',
                width: '22px',
                border: '1px solid lightgray',
            }}
        >
            {piece && (
                <div
                >
                    <ChessPieceHistorySvg
                        piece={pieceName(piece.type)}
                        color={pieceColor(piece.color)}
                    />
                </div>
            )}
        </div>
    );
};

export default ChessPieceHistory;
