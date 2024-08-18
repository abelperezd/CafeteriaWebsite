function getItemId(button) {
	//previous implementation
	//return button.closest('tr').find('.id').val(); // Retrieve the note ID from the closest row to the button
	return button.attr("id").split('-')[1];
}