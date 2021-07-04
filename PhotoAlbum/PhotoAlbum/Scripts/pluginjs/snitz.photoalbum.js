$(document).ready(function () {

    function customwidth() {
        var formwidth = $('#width-check').width();
        $('.dropdown-menu1').width(formwidth);
    }

    customwidth();
    $(window).resize(function (e) {
        customwidth();
    });

    //open gallery in popup window
    $('a.view-gallery').click(function () {
        var url = $(this).attr('href');
        var params = [
            'height=' + (screen.height-80),
            'width=' + (screen.width - 80),
            'fullscreen',
            'scrollbars=yes',
            'resizable=yes'
        ].join(',');
        var popup = window.open(url, 'popupwindow', params);
        popup.moveTo(5,5);
        return false;
    });

    $('a.image-comment').click(function () {
        var url = $(this).attr('href');
        var params = [
            //'height=' + (screen.height / 2),
            //'width=' + (screen.width / 2),
            'scrollbars=yes',
            'resizable=yes'
        ].join(',');
        var popup = window.open(url, 'popupwindow', params);
        //popup.moveTo(screen.width / 4, screen.height / 4);
        return false;
    });

    $(document).on('change','#album-sortby',function () {
        $(this).closest('form').submit();
    });
    $(document).on('change', '#album-sortdesc', function () {
        $(this).closest('form').submit();
    });
    $(document).on('change','#GroupFilter',function () {
        $(this).closest('form').submit();
    });
    $(document).on('change','#viewthumbs',function () {
        $(this).closest('form').submit();
    });
    $(document).on('change','#speciesonly',function () {
        $(this).closest('form').submit();
    });
    //$(document).on('click', ".pager-link a", function () {
    //    $(this).closest('form').attr('action', $(this).attr('href'));
    //    $(this).closest('form').submit();
    //    return false;
    //});
    $(document).on('click','.thumb',function () {
        $('.thumb:checkbox:checked').each(function () {
            $("#delete_button").show();
        });
    });
    $(document).on('click','#delete_button',function (e) {
        e.preventDefault();
        var files = "<ul>";
        $('.thumb:checkbox:checked').each(function () {
            files = files + "<li>" + $(this).data('img') + "</li>";
        });
        files = files + "</ul>";
        BootstrapDialog.confirm({
            title: Snitzres.DelImages,
            message: '<label>' + Snitzres.DelImgMsg + ' </label><br/>' + files, callback: function (ok) {
                if (ok) $('#delForm').submit();
            }
        });

    });
    $(document).on('click','.delButton', function () {
        $(this).closest('form')[0].submit();
    });
    //$(document).on('change','#album-sortby',function () {
    //    $(this).closest('form').submit();
    //});

    $.contextMenu({
        className: 'data-title',
        selector: '.target',
        callback: function (key, opt) {
            var imageid = opt.$trigger.attr("id").replace("img_", "");
            switch (key) {
                case "edit":
                    {
                        $.ajax({
                            url: SnitzVars.baseUrl + 'PhotoAlbum/Edit/' + imageid,
                            type: "GET",
                            success: function (data) {
                                $('#modal-upload-container').html(data);
                                $.validator.unobtrusive.parse($("#editImageForm"));
                                $('#modal-gallery-upload').modal('show');

                            },
                            error: function (xhr) {
                                alert(xhr.responseText);

                            }
                        });
                        break;
                    }
                case "delete":
                    {
                        $.ajax({
                            url: SnitzVars.baseUrl + 'PhotoAlbum/Delete/' + imageid,
                            type: "GET",
                            success: function (data) {
                                location.reload();
                            },
                            error: function (xhr) {
                                alert(xhr.responseText);
                            }
                        });
                        break;
                    }
                case "private":
                    {
                        $.ajax({
                            url: SnitzVars.baseUrl + 'PhotoAlbum/TogglePrivacy/' + imageid,
                            type: "GET",
                            success: function (data) {
                                location.reload();
                            },
                            error: function (xhr) {
                                alert(xhr.responseText);
                            }
                        });
                        break;
                    }
                case "feature":
                    {
                        $.ajax({
                            url: SnitzVars.baseUrl + 'PhotoAlbum/ToggleDoNotFeature/' + imageid,
                            type: "GET",
                            success: function (data) {
                                location.reload();
                            },
                            error: function (xhr) {
                                alert(xhr.responseText);
                            }
                        });
                        break;
                    }
            }
        },
        items: {
            "edit": { name: Snitzres.ImgEditInf, icon: "fa-edit" },
            "private": { name: Snitzres.ImgPrivate, icon: "fa-user" },
            "feature": { name: Snitzres.ImgFeature, icon: "fa-picture-o" },
            "delete": {
                name: Snitzres.DelImages,
                icon: "fa-trash"
            }
        },
        events: {
            show: function (opt) {
                // show event is executed every time the menu is shown!
                // find all clickable commands and set their title-attribute
                // to their textContent value
                opt.$trigger.tooltip('hide');
                $('.data-title').attr('data-menutitle', opt.$trigger.parent().attr("data-original-title"));

            }
        }
    });


    $('#SlideshowImages')
        .on('click',
        '.left',
        function () {
            var idx = $('#galleryImage').data("id") - 1;
            $.ajax({
                type: "GET",
                url: SnitzVars.baseUrl + 'PhotoAlbum/Next/' + idx + '?member=' + $('#galleryImage').data("user"),
                success: function (data) {
                    $('#galleryImage').fadeOut(500, function () {
                        $('#galleryImage').attr('src', data.src);
                        $('#galleryImage').fadeIn(500);
                    });
                    $('#galleryImage').data("id", data.idx);
                    $('#galleryImageLbl').text(data.desc);
                },
                error: function (error) {
                    BootstrapDialog.alert({
                        title: Snitzres.ErrTitle,
                        message: error
                    });
                }
            });
        });
    $('#SlideshowImages')
        .on('click',
        '.right',
        function () {
            var idx = $('#galleryImage').data("id") + 1;
            $.ajax({
                type: "GET",
                url: SnitzVars.baseUrl + 'PhotoAlbum/Next/' + idx + '?member=' + $('#galleryImage').data("user"),
                success: function (data) {
                    $('#galleryImage').fadeOut(500, function () {
                        $('#galleryImage').attr('src', data.src);
                        $('#galleryImage').fadeIn(500);
                    });
                    $('#galleryImage').data("id", data.idx);
                    $('#galleryImageLbl').text(data.desc);
                },
                error: function (error) {
                    BootstrapDialog.alert({
                        title: Snitzres.ErrTitle,
                        message: error
                    });
                }
            });
        });



    $('body').on('change', '#showhidethumbs', function () {
        if ($(this).is(':checked')) {
            $(".col-thumb").show();
        } else {
            $(".col-thumb").hide();
        }
    });
    $('body').on('change', '#checkAll', function () {
        var checkboxes = $(this).closest('form').find(':checkbox');
        if ($(this).is(':checked')) {
            checkboxes.prop('checked', true);
        } else {
            checkboxes.prop('checked', false);
        }
    });

});