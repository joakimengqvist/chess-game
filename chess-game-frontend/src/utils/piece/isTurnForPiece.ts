import { Piece } from "../../interfaces";
import { turnStringToNumberEnum } from "./turnStringToNumber";

export const isTurnForPiece = (piece : Piece | null, turnOfColor: string ) => piece?.color === turnStringToNumberEnum(turnOfColor);