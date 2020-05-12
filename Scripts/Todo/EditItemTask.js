document.onload = function () {
    getItem();
}

function getItem() {
    var params = new URLSearchParams('Id');
    var item = new ItemService({ url: "/sitecore/api/ssc/item"});
    item.fetchItem('{5B6AC191-817A-4570-B46C-F30CC5553045}').execute().then(function (task) {
        task.should.be.an.instanceOf(ItemService.Item);
        done();
        console.log(task);
        console.table(task)
    }).fail(done);
    console.table(item);
    console.log(params);
}