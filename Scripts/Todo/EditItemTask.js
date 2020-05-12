window.onload = function () {
    bindList('#categoryId', 'D3D68F62-061B-4847-ACC4-CA1109EAA718');
    bindList('#statusId', '499D7705-DD88-44E0-B352-43E46FD16FCB');
    var params = new URLSearchParams(window.location.search);
    var xhr = new XMLHttpRequest();
    if (params.get('Id') !== null) {
        xhr.open("GET", "/sitecore/api/ssc/item/" + params.get('Id'));
        xhr.onreadystatechange = function () {
            if (this.readyState == 4) {
                console.table(JSON.parse(this.responseText));

                bindToForm(JSON.parse(this.responseText));
            }
        };
        xhr.send(null);
    }
}


function bindList(listId,itemId) {
    var xhr = new XMLHttpRequest();
    xhr.open("GET", "/sitecore/api/ssc/item/" + itemId + "/children");
    xhr.onreadystatechange = function () {
        if (this.readyState == 4) {
            var categories = JSON.parse(this.responseText);
            for (var i = 0; i < categories.length; i++) {
                var item = new Option(categories[i].ItemName, categories[i].ItemName);
                document.querySelector(listId).appendChild(item);
            }
        }
    };
    xhr.send(null);
}

function editItemTask(form, path) {

}

function bindToForm(task) {
    if (task !== null || typeof task !== undefined) {
        document.querySelector('#description').setAttribute('value', task.Description);
        document.querySelector('#details').textContent = task.Details;
        document.querySelector('#duedate').setAttribute('value', moment.parseZone(task.DateDue).format("YYYY-MM-DD"));
        document.querySelector('#categoryId').setAttribute('value', task.Category);
        document.querySelector('#statusId').setAttribute('value', task.Status);
    }
} 