export const turnStringToNumberEnum = (color : string | null) => {
    if (color === 'White') return 1;
    if (color === 'Black') return 0;
    return;
}