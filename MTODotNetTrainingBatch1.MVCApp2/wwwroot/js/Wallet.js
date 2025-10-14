$('#btnSave').click(function () {
	let item = {
		WalletName: $('#WalletName').val(),
		Username: $('#Username').val(),
		MobileNo: $('#MobileNo').val(),
		Balance: $('#Balance').val(),
	};

	$.ajax({
		url: '/Wallet/Save',
		type: 'POST',
		data: { requestModel: item },
		success: function (response) {
			console.log({ response });
			if (!response.IsSuccess) {
				alert("Error: " + response.Message);
				return;
			}
			alert(response.Message);
			window.location.href = "/Wallet/Index";
		},
		error: function (request, status, error) {
			alert(request.responseText);
		}
	});
});
