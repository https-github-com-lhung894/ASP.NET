function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('.your_picture_image')
                .attr('src', e.target.result);
        };

        reader.readAsDataURL(input.files[0]);
    }
}

function capphatmanv() {
    $('#manv').val('123456');
}

function capphattaikhoan() {
    $('#taikhoan').val('123456');
}

function capphatmapb() {
    $('#mapb').val('123456');
}