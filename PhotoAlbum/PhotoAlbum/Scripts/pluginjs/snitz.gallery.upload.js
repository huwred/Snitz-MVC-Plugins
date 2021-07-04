$(window).on("load", function(){

    //Handle the file upload
    $('body').on('click', '#albumUpload', function () {

        if (typeof galleryDropzone != 'undefined')
        {
            return false;}
        var tag1 = "[image=";
        var tag2 = "]";
        $.validator.unobtrusive.parse($("#galleryUploadForm"));

        var formdata = new FormData($("#galleryUploadForm").get(0));

        var fileInput = document.getElementById('ImageFile');
        //Iterating through each files selected in fileInput
        //currently only supports one
        var errorArray = {};
        if (fileInput != null) {
            for (var i = 0; i < fileInput.files.length; i++) {
                //Append each file to FormData object
                if (isImage(fileInput.files[i])) {
                    formdata.append(fileInput.files[i].name, fileInput.files[i]);
                } else {
                    errorArray["Image Upload"] = Snitzres.TypeNotAllowed;
                    return false;
                }
                if (fileInput.files[i].size > Snitzres.MaxImageSize) {
                    errorArray["Image Upload"] = Snitzres.TooLarge;// 'Image is too large.';
                    return false;
                }
                if (fileInput.files[i].name.length > 255) {
                    errorArray["Image Upload"] = Snitzres.TooLong;
                    return false;
                }
            }
            $("#galleryUploadForm").validate().showErrors(errorArray);
        }
        
        if ($("#galleryUploadForm").valid()) {
            //Create an XMLHttpRequest and post it
            var xhr = new XMLHttpRequest();
            xhr.open('POST', SnitzVars.baseUrl + 'PhotoAlbum/Upload');
            xhr.send(formdata);
            xhr.onreadystatechange = function() {
                if (xhr.readyState === 4 && xhr.status === 200) {
                    var arr = xhr.responseText.split('|');
                    if (arr[0].replace('"', '') === 'Error') {
                        alert(arr[1]);
                    } else {
                        //alert(arr[2]);
                        if (arr[2].replace('"', '')=="true") {
                            tag1 = "[cimage=";
                        }
                        if ($("#editorDiv").length > 0) {
                            var parentDiv = $("#editorDiv");
                            var textId = parentDiv.find(".bbc-code-editor")[0].id;
                            $("#" + textId).insertAtCaret(tag1 + arr[1].replace('"', '') + tag2);
                        }
                    }
                    $('#modal-gallery-upload').modal('hide');
                }
            }
        }
        return false;
    });

    $(document).on('change', ':file', function () {
        var input = $(this),
            numFiles = input.get(0).files ? input.get(0).files.length : 1,
            label = input.val().replace(/\\/g, '/').replace(/.*\//, '');

        $("#Image").val(label);
    });

    //modal popup code
    $('body').on('click', '.gallery-link', function (e) {
        e.preventDefault();
        $(this).tooltip('hide');


        $(this).attr('data-target', '#modal-gallery-upload');
        $(this).attr('data-toggle', 'modal');
    });

    $('body').on('click', '.modal-close-btn', function () {
        $('#modal-gallery-upload').modal('hide');
    });
    $('#modal-gallery-upload').on('hidden.bs.modal', function () {
        $(this).removeData('bs.modal');
    });
    $('#CancelModal').on('click', function () {
        return false;
    });




});

//check if the upload files are allowed
function isImage(obj) {
    var filePath = obj.name;
    var type = obj.type;

    var ext = filePath.substring(filePath.lastIndexOf('.') + 1).toLowerCase();
    var acceptedFiles = SnitzVars.allowedimagetypes.split(",");
    if (type.indexOf('image') >= 0 ) {
        if (jQuery.inArray(ext, acceptedFiles) == -1) {
            return false;
        } else {
            return true;
        }
    }


    return false;
}