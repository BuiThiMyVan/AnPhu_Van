/// <reference path="../custom/custom.js" />
function showProductDeleteModal(link) {
    var $link = $(link);
    var productId = $link.data('id');
    var productName = $link.data('name');

    var modal = $('#product-delete-modal');
    modal.find('#productId').val(productId);
    modal.find('[label-name]').text(productName);

    modal.modal('show');
}

function deleteOnSuccess(data) {
    if (data.success) {
        showSuccessMessage("Sản phẩm được xóa bỏ thành công");
        location.reload();
    } else {
        console.log(data.log);
        showErrorMessage(data.message);
    }
}

function deleteOnFailure(error) {
    showErrorMessage("Đã có lỗi xảy ra trong quá trình xử lý dữ liệu");
    console.log(error);
    location.reload();
}