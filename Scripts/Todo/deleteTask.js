function deleteItem() {
    var params = new URLSearchParams(window.location.search);
    var xhr = new XMLHttpRequest();

    xhr.open("DELETE", `/sitecore/api/ssc/item/${params.get('Id')}?database=master`);
    xhr.onreadystatechange = function () {
        if (this.readyState == 4) {            
            if (this.status === 204) {
                document.querySelector('#deleteStatus').textContent =
                    "The item was successfully delete and will be removed from the site on the next publish";
            } else {
                document.querySelector('#deleteStatus').textContent =
                    "The item has already been deleted by another user.";
            }
        }
    };
    xhr.send(null);
}
window.onload = deleteItem;