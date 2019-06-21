// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $('#form-tags-1').tagsInput();

    var _validFileExtensions = [".jpg", ".jpeg", ".bmp", ".gif", ".png"];

    $("#btnUpload").click(function () {
        if (!Validate()) {
            $("#formTest").attr("action", "");
            return false;
        }
        $("#formTest").attr("action", "../Home/Index");
        return true;
    });

    $('#fileUpdate').on("click", function () {
        $(this).next('input[type="file"]').click();
        $(this).next('input[type="file"]').change(function () {
            fileName = $(this).val().replace(/C:\\fakepath\\/i, '')
            $('#fileName').text(fileName).animate({
                marginTop: '13px'
            });
        });
    });


    function Validate() {
        var arrInputs = document.getElementById("imageUpload");
        if (arrInputs.files.length == 0) {
            alert("Please select file before upload");
            return false;
        }
        var sFileName = arrInputs.files[0].name;
        if (sFileName.length > 0) {
            var blnValid = false;
            for (var j = 0; j < _validFileExtensions.length; j++) {
                var sCurExtension = _validFileExtensions[j];
                if (sFileName.substr(sFileName.length - sCurExtension.length, sCurExtension.length).toLowerCase() == sCurExtension.toLowerCase()) {
                    blnValid = true;
                    break;
                }
            }

            if (!blnValid) {
                alert("Sorry, " + sFileName + " is invalid, allowed extensions are: " + _validFileExtensions.join(", "));
                return false;
            }
        }

        return true;
    }
});