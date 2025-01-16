
interface ChessPieceSvgProps {
    piece : string
    color : string
    isKingInDanger : boolean
}

const kingIsInDangerStyle = {
    background: '#f9bcbc',
    borderRadius: '50px',
    border: '2px solid red'
}

const ChessPieceSvg = (props : ChessPieceSvgProps) => {
    const { color, piece, isKingInDanger } = props;

    return <img src={`./${piece}_${color}.svg`} alt={`${color} ${piece} piece`} style={ isKingInDanger ? kingIsInDangerStyle : {}} />

}

export default ChessPieceSvg;