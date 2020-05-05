function createTaskItem(myForm,path) {    
    var service = new ItemService({ url: '/sitecore/api/ssc/item' });
    ///sitecore/api/ssc/item/110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9

    var d = new Date(myForm.duedate.value).toISOString().replace(/-/g, '').replace(/:/g, '').split('.')[0];
    var s = document.querySelector('#statusId option:checked').value;
    var c = document.querySelector('#categoryId option:checked').value;
    var obj = {
        ItemName: myForm.description.value,
        TemplateID: '{3606EE62-7048-4136-89B4-D4BEAC3B5806}',
        Description: myForm.description.value,
        Details: myForm.details.value,
        DateDue: d,
        Status: s,
        Category:c
    };

    service.create(obj)
        .path(path)
        .execute()
        .then(function (item) {            
            window.alert("Thanks. Your task will appear on the site shortly");
        })
        .fail(function (err) { window.alert(err); });
    event.preventDefault();
    return false;
}

function getItemById(id) {
    var category = '';
    var xhr = new XMLHttpRequest();
    xhr.open("GET", "https://rabbitsc.dev.local/sitecore/api/ssc/item/" + id);
    xhr.onreadystatechange = function () {
        if (this.readyState == 4) {
            category = (this.responseText);
        }
    };
    xhr.send(null);

    return category;
}