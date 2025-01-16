import { useEffect, useState } from "react";
import { useChessBoardStore } from "../../store/chessBoard.store";
import GameOverDialog from "../game-over-dialog/GameOverDialog";
import LoadingDialog from "../loading-dialog/LoadingDialog";
import ChessBoard from "./board/ChessBoard";
import ChessHeader from "./header/ChessHeader";
import ChessBoardHistory from "./board/ChessBoardHistory";
import { buttonStyle } from "../../utils/styles/buttonStyle";

function ChessPage() {
    const [isHistoryModalOpen, setIsHistoryModalOpen] = useState(false);
    const { fetchGameState } = useChessBoardStore();

    useEffect(() => {
        fetchGameState();
    }, [fetchGameState]);

    const openHistoryModal = () => setIsHistoryModalOpen(true);
    const closeHistoryModal = () => setIsHistoryModalOpen(false);

    return (
        <div style={{ display: 'flex', flexDirection: 'column', alignItems: 'center', paddingTop: '20px' }}>
            <div style={{position: 'relative'}}>
            <ChessHeader />
            <div style={{ width: 'fit-content', position: 'relative'}}>
                <GameOverDialog />
                <LoadingDialog />
                <div style={{border: '1px solid gray'}}>
                    <div style={{border: '1px solid lightgray', padding: '2px'}}>
                        <ChessBoard />
                    </div>
                </div>
            </div>
            <dialog
  open={isHistoryModalOpen}
  style={{
    position: 'fixed',
    zIndex: 100,
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    width: '100vw',
    height: '100vh',
    padding: '0', // Remove padding to control spacing manually
    overflow: 'hidden', // Ensure scrolling is within the content area
    border: '1px solid #ccc', // Optional: Divider line
  }}
>
  {/* Sticky Header */}
  <div
    style={{
      position: 'sticky',
      top: 0,
      zIndex: 101,
      display: 'flex',
      justifyContent: 'space-between',
      padding: '16px 20px', // Padding for spacing
      backgroundColor: '#fff', // Match modal background
      borderBottom: '1px solid #ccc', // Optional: Divider line
    }}
  >
    <h2 style={{ margin: 0 }}>History</h2>
    <button style={buttonStyle} onClick={closeHistoryModal}>
      X
    </button>
  </div>

  {/* Scrollable Content */}
  <div
    style={{
      width: '100%',
      height: 'calc(90vh - 10px)', // Adjust height to account for sticky header
      overflowY: 'auto', // Enable vertical scrolling
      padding: '10px',
      borderBottom: '1px solid #ccc', // Optional: Divider line
    }}
  >
    <ChessBoardHistory isOpen={isHistoryModalOpen} />
  </div>
</dialog>

            <div style={{display: 'flex', width: '100%', justifyContent: 'flex-end', paddingTop: '8px'}}>
            <button style={buttonStyle} onClick={openHistoryModal}>History</button>
            </div>
        </div>
    </div>
    )
}

export default ChessPage
