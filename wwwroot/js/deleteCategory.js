function getFoodId(button) {
	//previous implementation
	//return button.closest('tr').find('.id').val(); // Retrieve the note ID from the closest row to the button
	return button.attr("id").split('-')[1];
}

$(function () {
	$(".deleteButton").on('click', function (e) {
		e.preventDefault();

		const button = $(this);
		const toast = $("#toastRemove");

		toast.modal('show');

		const id = getFoodId(button);
		toast.find(".modal-body").text($("#categ-" + id).text());
		toast.find("#idToRemove").val(id)
	});
})

$(function () {
	$("#toastRemoveButton").on('click', function (e) {

		e.preventDefault();

		const toast = $("#toastRemove");
		const foodId = toast.find("#idToRemove").val()

		$.ajax({
			//do not use Url directly brecause it cannot use .NET actions
			url: deleteCategoryUrl,
			type: 'POST',
			data: { id: foodId },
			success: function (response, status, jqxhr) {
				console.log("Category removed: ", response)
				$('#' + foodId).remove();
			},
			error: function (jqxhr, status, error) {
				console.log("Error removing note: ", error);
			},
			complete: function () {
				toast.modal('hide');
			}
		});
	});
})