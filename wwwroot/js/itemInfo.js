$(function () {
	$(".infoButton").on('click', function (e) {
		e.preventDefault();

		const button = $(this);
		const toast = $("#toastInfo");

		toast.modal('show');

		const id = getItemId(button);
		toast.find("#infoTitle").text($("#text-" + id).text());
		toast.find("#infoDescription").text($("#description-" + id).text());
		toast.find("#infoFooter").html($("#cardFooter-" + id).html());

		//Display image
		//const imageSrc = $("#img-" + id).attr("src");
		//toast.find("#infoImage").attr("src", imageSrc);
		const imageElement = $("#img-" + id);
		if (imageElement.length && imageElement.attr("src")) {
			toast.find("#infoImage").attr("src", imageElement.attr("src")).show();
			toast.find("#infoDescriptionContainer").attr("class", "col-8").show();
			toast.find("#infoImageContainer").show(); // Hide the image element if no image is available
		} else {
			toast.find("#infoImage").hide(); // Hide the image element if no image is available
			toast.find("#infoDescriptionContainer").attr("class", "col-12").show();
			toast.find("#infoImageContainer").hide(); // Hide the image element if no image is available
		}

		//toast.find(".modal-body").text($("#text-" + id).text());

	});
})