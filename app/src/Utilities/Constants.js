export const baseUrl = 'https://localhost:7124';

//ref: https://stackoverflow.com/a/55556258/725957
export const currencyFormat = (num) => {
    return '$' + num.toFixed(2).replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,');
};

export const relationshipFormat = (num) => {
    switch(num) {
        case 1:
            return 'Spouse';
        case 2:
            return 'Domestic Partner';
        case 3:
            return 'Child';
        default:
            return 'None';
    }
}