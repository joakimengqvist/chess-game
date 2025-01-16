export const highlightSquare = (x: number, y: number, color: string) => {
    const element = document.getElementById(`square-${x}${y}`);

    if (element) {
        element.style.boxShadow = `inset 0 0 10px ${color}, inset 0 0px 6px ${color}, inset 0 0px 4px ${color}, inset 0 4px 16px rgba(0, 0, 0, 0.3)`;
        element.style.transition = "box-shadow 0.3s ease";
    }
};

export const resetHighlight = () => {
    for (let x = 0; x < 8; x++) {
        for (let y = 0; y < 8; y++) {
            const element = document.getElementById(`square-${x}${y}`);
            if (element) {
                element.style.boxShadow = "";
            }
        }
    }
};