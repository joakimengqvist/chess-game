import { Color } from "../../enums/colors";

export const pieceColor = (pieceType : number) => {
    switch(pieceType) {
        case Color.White:
            return "white";
        case Color.Black:
            return "black";
        default:
            return "transparent"
    }
}