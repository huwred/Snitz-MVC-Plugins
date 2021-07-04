﻿

$(document).ready(function () {
    //Handle the file upload
    $('body').on('click', '#submitUpload', function () {
        var parentDiv = $("#editorDiv");
        var textId = parentDiv.find(".bbc-code-editor")[0].id;
        var val1 = "[file]";
        var val2 = "[/file]";
        var formdata = new FormData(); //FormData object
        var fileInput = document.getElementById('fileInput');
        //Iterating through each files selected in fileInput
        //There is currently only one
        for (var i = 0; i < fileInput.files.length; i++) {
            //Append each file to FormData object
            if (checkFileType(fileInput.files[i])) {
                
                formdata.append(fileInput.files[i].name, fileInput.files[i]);
            } else {
                
                BootstrapDialog.alert(
                {
                    title: "Error ",
                    message: 'File type not allowed.'
                });
                return false;
            }
            if (fileInput.files[i].size > (SnitzVars.MaxFileSize * 1024 * 1024)) {
                BootstrapDialog.alert(
                {
                    title: "Error ",
                    message: 'File is too large.'
                });
                return false;
            }
        }

        //Create an XMLHttpRequest and post it
        var xhr = new XMLHttpRequest();
        xhr.open('POST', SnitzVars.baseUrl + 'Home/Upload');
        xhr.send(formdata);
        xhr.onerror = function (ev) {
            //
            BootstrapDialog.alert(
            {
                title: "Error ",
                message: ev.error
            });
        }
        xhr.onreadystatechange = function() {
            if (xhr.readyState === 4 && xhr.status === 200) {
                var arr = xhr.responseText.split('|');
                if (arr[0] === "error") {
                    BootstrapDialog.alert(
                    {
                        title: "Error ",
                        message: 'Error uploading'
                    });
                } else {
                    if (arr[1].indexOf("image") >= 0) {
                        val1 = "[img]";
                        val2 = "[/img]";
                    }
                    if (arr[1].indexOf("pdf") >= 0) {
                        val1 = "[pdf]";
                        val2 = "[/pdf]";
                    }
                    textId = parentDiv.find(".bbc-code-editor")[0].id;
                    $("#" + textId).insertAtCaret(val1 + arr[0].replace('"', '') + val2);
                    $('#modal-container').modal('hide');              
                    
                }

            }
        }
        return false;
    });
});

//check if the upload files are allowed
function checkFileType(obj) {
    var filePath = obj.name;
    var type = obj.type;

    var ext = filePath.substring(filePath.lastIndexOf('.')).toLowerCase();
    var acceptedFiles = SnitzVars.allowedfiles.split(",");
    if (type.indexOf('compressed') >= 0 || type.indexOf('zip') >= 0 || type.indexOf('pdf') >= 0) {
        if (jQuery.inArray(ext, acceptedFiles) == -1) {
            return false;
        } else {
            return true;
        }
    }

    return false;
}
$(document).on('change', ':file', function () {
    var input = $(this),
        numFiles = input.get(0).files ? input.get(0).files.length : 1,
        label = input.val().replace(/\\/g, '/').replace(/.*\//, '');

    $("#Attached").val(label);
});