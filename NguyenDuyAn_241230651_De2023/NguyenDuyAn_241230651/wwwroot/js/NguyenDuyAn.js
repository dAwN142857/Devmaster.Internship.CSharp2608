$(function () {

    // Bấm vào LoaiHang trên thanh điều hướng -> lọc HangHoa bằng AJAX
    $(document).on('click', '.category-link', function (e) {
        var $vung = $('#mainContent');

        // Không phải trang danh sách (vd: trang Create) thì chuyển trang bình thường
        if ($vung.length === 0) {
            return;
        }

        e.preventDefault();

        $.get($(this).attr('href'), function (html) {
            $vung.html(html);
        });
    });

});
