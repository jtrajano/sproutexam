export function formatDate(date)
{
    date = new Date(date);
    var day = "".concat(date.getDate() < 10 ? '0' : '').concat(date.getDate());
    var month = "".concat(date.getMonth() + 1 < 10 ? '0' : '').concat(date.getMonth() + 1);
    var year = date.getFullYear();
    return "".concat(year, "-").concat(month, "-").concat(day);
}
