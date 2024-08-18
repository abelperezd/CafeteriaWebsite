function fileCheck(obj) {
    var fileExtension = ['jpeg', 'jpg', 'png'];
    if ($.inArray($(obj).val().split('.').pop().toLowerCase(), fileExtension) == -1) {
        alert("Only '.jpeg','.jpg', '.png' formats are allowed.");
        $(obj).val('');
    }
}