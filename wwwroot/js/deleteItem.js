$(function () {
	$(".deleteButton").on('click', function (e) {
		e.preventDefault();

		const button = $(this);
		const toast = $("#toastRemove");

		toast.modal('show');

		const id = getItemId(button);
		toast.find(".modal-body").text($("#text-" + id).text());
		toast.find("#idToRemove").val(id)
	});
})

$(function () {
	$("#toastRemoveButton").on('click', function (e) {

		e.preventDefault();

		const toast = $("#toastRemove");
		const foodId = toast.find("#idToRemove").val()

		$.ajax({
			url: deleteItemUrl,
			type: 'POST',
			data: { id: foodId },
			success: function (response, status, jqxhr) {
				console.log("Food removed: ", response)
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
