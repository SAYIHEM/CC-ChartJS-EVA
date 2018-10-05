class Controller {

    constructor() {
        this.serverURL = "http://localhost:50658/api/";
        this.apiURL = $('textarea#request_url').val();
        //this.apiURL = "SalesOrderHeader/50000-50005";

        this._init();
    }

    update() {
        let url = this.serverURL + this.apiURL;

        $.ajax({
            type: 'GET',
            url: url,
            dataType: 'json',
            success: (data) => {

                // Check if empty
                if ($.isEmptyObject(data)) {
                    alert("No data returned.");
                    return;
                }

                // Build Table
                let builder = new TableBuilder(data, $('#TableView'));

                // Build Chart
                let chartController = new ChartController(data, $('#ChartView'))

            }
        });
    }

    _init() {
        // CLick handler - URL update
        $("#btn_update").click(() => {
            this.apiURL = $('textarea#request_url').val();
            this.update();
        })
    }
}