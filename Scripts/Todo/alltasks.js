window.onload = function () {
    var xhr = new XMLHttpRequest();
    xhr.open("GET", "/sitecore/api/ssc/item/ED3BC3C1-43DB-4FE3-92CD-066401F1773A/children?database=master");
    xhr.onreadystatechange = function () {
        if (this.readyState == 4) {
            var items = JSON.parse(this.responseText);
            var dataSet = [];
            items.forEach(task => dataSet.push([task.Description, task.Status, task.Category, moment.parseZone(task.DateDue, 'YYYY-MM-DD')]));
            $(document).ready(function () {
                $('#allTasks').DataTable({
                    data: dataSet,
                    columns: [
                        { title: "Description" },
                        { title: "Status" },
                        { title: "Category" },
                        { title: "Due Date" }
                    ]
                });
            });
        }
    };
    xhr.send(null);

}

