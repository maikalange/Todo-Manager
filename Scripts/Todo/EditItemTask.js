document.onload = function () {
    getItem();
}

function getItem() {
    var params = new URLSearchParams('Id');
    var item = new ItemService({ url: "/sitecore/api/ssc/item" + params.get('Id') });
    item.fetchItem(id).execute().then(function (task) {
        task.should.be.an.instanceOf(ItemService.Item);
        done();
        console.log(task);
        console.table(task)
    }).fail(done);
    console.table(item);
    console.log(params);
}