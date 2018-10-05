class ChartController {

    constructor(json, container) {
        this.json = json;
        this.container = container;



        this._init();
    }

    _init() {
        this.container.empty();
        this.canvas = document.createElement('canvas');
        $(this.canvas).attr('id', 'pie_chart');
        this.container.append(this.canvas);

        this.renderPieChart1();

    }


    renderPieChart1() {

        // Filter JSON
        console.log(this.json);
        $.each(this.json, (no, object) => {
            $.each(object, (item, value) => {
                if (!(item === 'customerId' || item === 'totalDue' || item === 'salesOrderId')) {
                    delete object[item];
                }
            });
        });

        let customers = new Array(0);
        let totalDues = new Array(0);
        let ID = new Array(0);
        $.each(this.json, (no, obj) => {
            ID.push(obj['salesOrderId']);
            customers.push(obj['customerId']);
            totalDues.push(obj['totalDue']);
        });

        let colors = this._generateRandomColors(customers.length);

        let pieChart = new Chart(this.canvas, {
            type: 'pie',
            data: {
                labels: customers,
                datasets: [{
                    label: 'Total Dues of customers',
                    data: totalDues,
                    backgroundColor: colors[0],
                    borderColor: colors[1],
                    borderWidth: 1
                }]
            },
        });
        option: {
            events: ['click']
        }


        $("#pie_chart").click(
            function (evt) {
                var activePoints = pieChart.getElementsAtEvent(evt);
                let link = 'http://localhost:50658/api/SalesOrderDetail/' + ID[activePoints[0]._index];
                window.open(link, '_blank');

                /*$.ajax({
                    type: 'GET',
                    url: link,
                    dataType: 'json',
                    success: (data) => {

                        // Check if empty
                        if ($.isEmptyObject(data)) {
                            alert("No data returned.");
                            return;
                        }
                        alert(JSON.stringify(data));

                    }
                });*/

                /*var url = "http://example.com/?label=" + activePoints[0].label + "&value=" + activePoints[0].value;
                alert(url);*/
            }
        );   
    }


    _generateRandomColors(count) {
        let colors = new Array(0);
        let background = new Array(0);
        let border = new Array(0);
        let opacity = 0;

        for (let i = 0; i < count; i++) {
            let r = _getRandomVal();
            let g = _getRandomVal();
            let b = _getRandomVal();

            opacity = 0.3;
            background.push(
                "rgba(" +
                r.toString() + ", " +
                g.toString() + ", " +
                b.toString() + ", " +
                opacity.toString() + ")"
            );

            opacity = 1;
            border.push(
                "rgba(" +
                r.toString() + ", " +
                g.toString() + ", " +
                b.toString() + ", " +
                opacity.toString() + ")"
            );
        }

        colors.push(background);
        colors.push(border);
        return colors;

        function _getRandomVal() {
            return Math.floor(Math.random() * 255);
        }
    }
}