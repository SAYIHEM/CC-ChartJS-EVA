class TableBuilder {

    constructor(json, container) {
        this.json = json;
        this.container = container;
        this.table = document.createElement('table');
        $(this.table).attr('class', 'table table-bordered');

        this.createTableFromJSON();
    }

    createTableFromJSON() {

        this._initTable();

        $(this.table).dynatable({
            features: {
                paginate: true,
            },
            table: {
                headRowSelector: 'thead',
            },
            dataset: {
                records: this.json,
                perPageDefault: 10,
            },

        });


        // Append table to container
        this.container.append(this.table)
    }

    _initTable() {
        this.container.empty();

        let thead = document.createElement('thead');
        $(thead).attr('class', 'thead-light');
        this.table.append(thead);

        this.table.append(document.createElement('tbody'));

        let json = this.json[0];
        $.each(json, (item, value) => {
            let header = '<th>' + item + '</th>';
            $(thead).append(header);
        })
    }
}