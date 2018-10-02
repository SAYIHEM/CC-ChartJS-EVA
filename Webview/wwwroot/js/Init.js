$(document).ready(() => {
    url = 'http://localhost:50658/api/TransactionHistories/100000'

    $.ajax({
        type: 'GET',
        url: url,
        dataType: 'json',
        success: (data) => {
            builder = new TableBuilder();
            builder.CreateTableFromJSON(data)
        }
    });
})