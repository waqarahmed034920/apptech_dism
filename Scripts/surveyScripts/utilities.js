function ConfirmDelete() {
    var conf = confirm("This would delete the record. Are you sure?");
    if (conf) {
        console.log(1);
        return true;
    } else {
        console.log(2);
        return false;
    }
}
