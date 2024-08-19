export const formatCurrency = (value) => {
    return Intl.NumberFormat('en-GB', {style: 'currency', currency: 'GBP'}).format (value);
}