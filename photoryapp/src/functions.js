

export const setMode = mode => {
    window.localStorage.setItem('liveMode', JSON.stringify(mode));
}

export const getMode = () => {
    return JSON.parse(window.localStorage.getItem('liveMode'));
}