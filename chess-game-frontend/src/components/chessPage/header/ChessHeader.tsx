import { useChessBoardStore } from "../../../store/chessBoard.store";

function ChessHeader() {
    const { chessGame, resetGameState } = useChessBoardStore();

    if (!chessGame) return;
    const { status } = chessGame;
    const { isCheckmate, winner } = status;

    const statusDisplayText = status.turnOfColor == "Black" ? "Black" : "White";

    return (
        <div style={{ display: 'flex', justifyContent: 'space-between', marginBottom: '4px' }}>
            <p style={{ fontSize: '1.2em', margin: '4px' }}>
                {!isCheckmate && <>Turn of color:  <strong>{statusDisplayText}</strong></>}
                {isCheckmate && <>Game over! {winner} has won.</>}
            </p>
            <button onClick={resetGameState} style={buttonStyle}>
                Reset
            </button>
        </div>
    );
}

const buttonStyle = {
    padding: '4px 10px',
    fontSize: '1em',
    fontWeight: 'bold',
    color: 'black',
    background: 'whitesmoke',
    border: '1px solid gray',
    cursor: 'pointer',
};

export default ChessHeader;
