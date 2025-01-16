
interface ChessPieceHistorySvgProps {
    piece : string
    color : string
}

const ChessPieceHistorySvg = (props : ChessPieceHistorySvgProps) => {
    const { color, piece } = props;

    return <img src={`./${piece}_${color}_history.svg`} alt={`${color} ${piece} piece`} />

}

export default ChessPieceHistorySvg;