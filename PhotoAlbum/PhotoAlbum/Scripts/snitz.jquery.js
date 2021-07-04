$.extend({
    getUrlParams: function () {
        var vars = [], hash;
        var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
        for (var i = 0; i < hashes.length; i++) {
            hash = hashes[i].split('=');
            vars.push(hash[0]);
            vars[hash[0]] = hash[1];
        }
        return vars;
    },
    getUrlParam: function (name) {
        return $.getUrlParams()[name];
    }
});
$.fn.extend({
    // form validation {
    isValid: function () {
        var self = $(this);
        $.validator.unobtrusive.parse(self);
        return self.data('unobtrusiveValidation').validate();
    } // }
});
$.fn.extend({
    //re-set all client validation given a jQuery selected form or child
    resetValidation: function () {

        var $form = this.closest('form');

        //reset jQuery Validate's internals
        $form.validate().resetForm();

        //reset unobtrusive validation summary, if it exists
        $form.find("[data-valmsg-summary=true]")
            .removeClass("validation-summary-errors")
            .addClass("validation-summary-valid")
            .find("ul").empty();

        //reset unobtrusive field level, if it exists
        $form.find("[data-valmsg-replace]")
            .removeClass("field-validation-error")
            .addClass("field-validation-valid")
            .empty();

        return $form;
    }
});

// functions to insert/select text in textarea
$.fn.extend({
    insertAtCaret: function (myValue) {
        var textComponent = $(this)[0];
        if (document.selection !== undefined) {
            this.focus();
            sel = document.selection.createRange();
            sel.text = myValue;
            this.focus();
        } else if (textComponent.selectionStart != undefined) {
            var startPos = textComponent.selectionStart;
            var endPos = textComponent.selectionEnd;
            var scrollTop = textComponent.scrollTop;
            textComponent.value = textComponent.value.substring(0, startPos) + myValue + textComponent.value.substring(endPos, textComponent.value.length);
            this.focus();
            this.selectionStart = startPos + myValue.length;
            this.selectionEnd = startPos + myValue.length;
            this.scrollTop = scrollTop;
        } else {
            this.val(this.val() + myValue);
            this.focus();
        }
    },
    surroundSelection: function (val1, val2) {
        var selectedText = '';
        var textComponent = $(this)[0]; 
        if (document.selection != undefined) {
            
            this.focus();
            var sel = document.selection.createRange();
            sel.text = val1 + sel.text + val2;
            this.focus();
        }
            // Mozilla version
        else if (textComponent.selectionStart != undefined) {
            //textComponent.focus();
            var startPos = textComponent.selectionStart;
            var endPos = textComponent.selectionEnd;
            var scrollTop = textComponent.scrollTop;
            var myValue = val1 + val2;

            if (startPos !== endPos) {
                selectedText = textComponent.value.substring(startPos, endPos);
            
                textComponent.value = textComponent.value.substring(0, startPos) + val1 + selectedText + val2 + textComponent.value.substring(endPos, textComponent.value.length);

            } else {
                textComponent.value = textComponent.value.substring(0, startPos) + myValue + textComponent.value.substring(endPos, textComponent.value.length);
                //textComponent.value += val1 + val2;
            }
            textComponent.selectionStart = startPos + myValue.length;
            textComponent.selectionEnd = startPos + myValue.length;
            textComponent.scrollTop = scrollTop;

        }
        

    },
    replaceSelection: function (val) {
        var selectedText = '';
        var textComponent = $(this)[0];
        //
        if (document.selection != undefined) {
            this.focus();
            var sel = document.selection.createRange();
            sel.text = val;
            this.focus();
        }
            // Mozilla version
        else if (textComponent.selectionStart != undefined) {
            textComponent.focus();
            var startPos = textComponent.selectionStart;
            var endPos = textComponent.selectionEnd;
            var scrollTop = textComponent.scrollTop;
            var myValue = val;

            if (startPos != endPos) {
                selectedText = textComponent.value.substring(startPos, endPos);

                textComponent.value = textComponent.value.substring(0, startPos) + val + textComponent.value.substring(endPos, textComponent.value.length);

            } else {
                textComponent.value = textComponent.value.substring(0, startPos) + myValue + textComponent.value.substring(endPos, textComponent.value.length);
                //textComponent.value += val1 + val2;
            }
            textComponent.selectionStart = startPos;
            textComponent.selectionEnd = startPos + myValue.length;
            textComponent.scrollTop = scrollTop;

        }


    },
    getSelection: function () {
        var selectedText = '';
        var textComponent = $(this)[0];

        if (document.selection != undefined) {
            this.focus();
            var sel = document.selection.createRange();
            selectedText = sel.text;
            sel.text = "";
            this.focus();
        }
            // Mozilla version
        else if (textComponent.selectionStart != undefined) {
            textComponent.focus();
            var startPos = textComponent.selectionStart;
            var endPos = textComponent.selectionEnd;
            var scrollTop = textComponent.scrollTop;
            var myValue = "";

            if (startPos != endPos) {
                selectedText = textComponent.value.substring(startPos, endPos);

                textComponent.value = textComponent.value.substring(0, startPos) + textComponent.value.substring(endPos, textComponent.value.length);

            } else {
                textComponent.value = textComponent.value.substring(0, startPos) + myValue + textComponent.value.substring(endPos, textComponent.value.length);
                //textComponent.value += val1 + val2;
            }
            textComponent.selectionStart = startPos + myValue.length;
            textComponent.selectionEnd = startPos + myValue.length;
            textComponent.scrollTop = scrollTop;

        }
        return selectedText;

    },
    selectRange:function (start, end) {
    if (!end) end = start;
    return this.each(function () {
        if (this.setSelectionRange) {
            this.focus();
            this.setSelectionRange(start, end);
        } else if (this.createTextRange) {
            var range = this.createTextRange();
            range.collapse(true);
            range.moveEnd('character', end);
            range.moveStart('character', start);
            range.select();
        }
    });
}
});
var styleCookieName = "snitztheme";
var styleCookieDuration = 30;
var styleDomain = "";

/*updates the lastactivity date for members*/
if (window.SnitzVars.userAuth === 'True') {
    $.ajax({
        async: true,
        type: "POST",
        url: window.SnitzVars.baseUrl + "Account/UpdateLastActivityDate",
        data: { userName: window.SnitzVars.userName },
        cache: false,
        success: function () { return false; }

    });
}

function pendingMemberShow(label) {
    var url = window.SnitzVars.baseUrl + 'Admin/PendingMembers';
    var dlg = BootstrapDialog.show({
        type: BootstrapDialog.TYPE_PRIMARY,
        title: 'Pending Members',
        message: '<a href="' + url + '"><i class="fa fa-users fa-1_5x animated infinite pulse"></i><span class="">' + label + '</span></a>'
    });
    setTimeout(function () {
        dlg.close();
    }, 5000);    
}
function errorDlg(title,error) {
    BootstrapDialog.show({
        type: BootstrapDialog.TYPE_WARNING,
        title: title,
        message: error
    });
}
function successDlg(title) {
    var dlg = BootstrapDialog.successShow(title);
    setTimeout(function () {
        dlg.close();
    }, 1500);
}
function switchStyle(cssTitle) {
    var i, linkTag;
    for (i = 0, linkTag = document.getElementsByTagName("link");
        i < linkTag.length; i++) {
        if ((linkTag[i].rel.indexOf("stylesheet") !== -1) &&
            linkTag[i].title) {
            linkTag[i].disabled = true;
            if (linkTag[i].title === cssTitle) {
                linkTag[i].disabled = false;
            }
        }
    }
       
}
function setStyleFromCookie() {
    var cssTitle = getCookie(styleCookieName);

    if (cssTitle.length > 0) {
        switchStyle(cssTitle);
        $("div.theme-changer select").val(cssTitle);
    }
    
    function getCookie(cookieName) {
        if ($.cookie(cookieName)) {
            return decodeURIComponent($.cookie(cookieName));
        }
        return '';
    }
}

var setConditionalValidators = function () {

    $.validator.unobtrusive.adapters.add(
            'conditional',
            ['dependentproperty', 'targetvalue'],
            function (options) {
                options.rules['conditional'] = {
                    conditional: options.params['dependentproperty'],
                    targetvalue: options.params['targetvalue']
                };
                options.messages['conditional'] = options.message;
            });

    $.validator.addMethod("conditional", function (value, element, parameters) {
        if (parameters['conditional'].match("^STRREQ")) {
            if (parameters['targetvalue'] === 'False') {
                return true;
            }
            /*we are required so check value*/
            if (element.value.length > 0) {
                return true;
            } else {
                return false;
            }

        }
        var ctl = $("[id$='" + parameters['conditional'] + "']");

        if (ctl.length > 0) {
            if (element.value.length > 0) {
                return true;
            }
            if (ctl.val() != parameters['targetvalue']) {
                return true;
            }

        } else {
            return false;
        }
        return false;
    });
}

var tooltipPos = function (tip, element) { //$this is implicit
    var position = $(element).offset();
    var sWidth = $(window).width();
    var sHeight = $(window).height();

    if (position.left > sWidth * 0.75) {
        return "left";
    }
    if (position.left < sWidth * 0.75) {
        return "right";
    }
    if (position.top < 110) {
        return "bottom";
    }
    return "top";
}

var setRequiredFields = function() {
    $('form').find(':input').each(function () {
        var cond = $(this).attr('data-val-conditional-dependentproperty');
        var req = $(this).attr('data-val-required');
        var condreq = $(this).attr('data-val-conditional-targetvalue');
        if (undefined != req) {
            if ($(this).val() == '') {
                $(this).addClass('required-val'); //.css('background-color', '#F3D1DC');
            }
        }
        //
        var check = $(this);
        if (undefined != cond) {

            debugger;
            if ($(this).val() === '') {
                
                if (undefined != condreq && condreq === 'True') {
                    $(this).addClass('required-val'); //.css('background-color', '#F3D1DC');
                }
            }
        }
        $(this).on('keyup', function () {

            if (this.length == 0) {
                $(check).addClass('required-val'); //.css('background-color', '#F3D1DC');
            } else {
                $(check).removeClass('required-val'); //.css('background-color', '');
            }

        });
    });
}

$(document).ready(function () {
    // *** TO BE CUSTOMISED ***
    function getBrowser() {
        var ua = navigator.userAgent, tem, M = ua.match(/(opera|chrome|safari|firefox|msie|trident(?=\/))\/?\s*(\d+)/i) || [];
        if (/trident/i.test(M[1])) {
            tem = /\brv[ :]+(\d+)/g.exec(ua) || [];
            return { name: 'IE', version: (tem[1] || '') };
        }
        if (M[1] === 'Chrome') {
            tem = ua.match(/\bOPR|Edge\/(\d+)/);
            if (tem != null) { return { name: 'Opera', version: tem[1] }; }
        }
        M = M[2] ? [M[1], M[2]] : [navigator.appName, navigator.appVersion, '-?'];
        if ((tem = ua.match(/version\/(\d+)/i)) != null) { M.splice(1, 1, tem[1]); }
        return {
            name: M[0],
            version: M[1]
        };
    }
    var browser = getBrowser();

    $("#clientBrowser").html(browser.name + " " + browser.version);
    $("#clientScreenWidth").html($(window).width());
    $("#clientScreenHeight").html($(window).height());
    var timezoneCookie = "timezoneoffset";
    if (!$.cookie(timezoneCookie)) { // if the timezone cookie not exists create one.

        // check if the browser supports cookie
        var testCookie = 'cookie support check';
        $.cookie(testCookie, true);

        if ($.cookie(testCookie)) { // browser supports cookie

            // delete the test cookie.
            $.cookie(testCookie, null);

            // create a new cookie 
            $.cookie(timezoneCookie, new Date().getTimezoneOffset());

            location.reload(); // re-load the page
        }
    }
    else { // if the current timezone and the one stored in cookie are different then
        // store the new timezone in the cookie and refresh the page.

        var storedOffset = parseInt($.cookie(timezoneCookie));
        var currentOffset = new Date().getTimezoneOffset();

        if (storedOffset !== currentOffset) { // user may have changed the timezone
            $.cookie(timezoneCookie, new Date().getTimezoneOffset());
            location.reload();
        }
    }
    $('.modal-dialog').draggable({
        handle: ".modal-header"
    });

    $("select[id='theme-change']")
        .on('change',
        function () {
            $(this).tooltip('hide');
            $.cookie(styleCookieName, encodeURIComponent(this.value), { path: SnitzVars.cookiePath, expires: styleCookieDuration });
            location.reload(true);
        });

    BootstrapDialog.configDefaultOptions({ animate: false });
    $('.aspinEdit').spinedit();


    //re-enable button if form fails validation
    $(document).on('invalid-form.validate', 'form', function () {
        var button = $(this).find('input[type="submit"]');
        setTimeout(function () {
            button.removeAttr('disabled');
        }, 10);
    });
    //disable button on submit
    $(document).on('submit', 'form', function () {
        var button = $(this).find('input[type="submit"]');
        setTimeout(function () {
            button.attr('disabled', 'disabled');
        }, 1);
    });

    
    //tooltip initialisers
    $('.topic-strap').tooltip({
        placement: tooltipPos,
        html:true,
        selector: "a[class=topic-link]"
    });
    $('body').tooltip({
        placement: 'auto',
        selector: '[data-toggle=tooltip]'
    });
    $('.modal-link').tooltip();
    $('.gallery-link').tooltip();
    $("abbr.timeago").tooltip();

    $('body').on('click', '.modal-link', function (evt) {
        evt.preventDefault();
        //$(this).tooltip('hide');
        $(this).attr('data-target', '#modal-container');
        $(this).attr('data-toggle', 'modal');
    });
    $('.cancel').on('click', function () {
        window.location.href = document.referrer;
        return false;
    });
    
    //open embedded gallery image in popup window
    $('.view-image').on('click', function (e) {
        e.preventDefault();
        var url = $(this).attr('href');
        var params = [
            'height=' + screen.availHeight,
            'width=' + screen.availWidth,
            'scrollbars=yes',
            'resizable=yes'
        ].join(',');
        var popup = window.open(url, 'popupwindow', params);
        popup.moveTo(0, 0);
        return false;
    });
    
    $(document).on('click', 'span.bbc-spoiler', function () {
        var content = $(this).find("span.bbc-spoiler-content");

        if (content.is(":visible")) {
            content.css('display', 'none');
        } else {
            content.css('display', 'block'); 
        }
    });

    $('.send-email').on('click', function (e) {
        e.preventDefault();
        var userid = $(this).data('id');
        $.get(window.SnitzVars.baseUrl + 'Account/EmailMember/' + userid, function (data) {
            $('#emailContainer').html(data);
            $.validator.unobtrusive.parse($("#emailMemberForm"));
            $('#emailModal').modal('show');
        });
    });
    $('.sendpm-link').on('click', function () {
        var username = $(this).data('id');
        $.get(window.SnitzVars.baseUrl + 'PrivateMessage/SendMemberPm/' + username, function (data) {
            $('#pmContainer').html(data);
            $.validator.unobtrusive.parse($("#sendPMForm"));
            $('#modal-sendpm').modal('show');
        });
    });
    $('.sendto-link').on('click', function () {
        var id = $(this).data('id');
        var archive = $.getUrlParam('archived');
        $.get(window.SnitzVars.baseUrl + 'Topic/SendTo/' + id + '?archived=' + archive, function (data) {
            $('#sendToContainer').html(data);
            $.validator.unobtrusive.parse($("#sendToForm"));
            $('#modal-sendto').modal('show');
        });
    });
    $('.showIPAddress').on('click', function () {
        debugger;
        var dilog = BootstrapDialog.show({
            title: 'IP/Domain name',
            message: '<img src="' + window.SnitzVars.baseUrl + 'content/images/link_loader.gif"/>'
        });
        var ip = $(this).data('id');
        $.get(window.SnitzVars.baseUrl + 'Account/ShowIP/?ip=' + ip, function (data) {
            dilog.setMessage(data);
        });
    });

    //clear modal cache, so that new content can be loaded
    $('#modal-container').on('hidden.bs.modal', function () {
        $(this).removeData('bs.modal');
    });
    $('.modal').on('hidden.bs.modal', function () {
        $(this).removeData('bs.modal');
    });
    /*update the session topiclist if checkbox selected*/
    $('.topic-select').on('mouseup', function () {
        $.ajax({
            type: "POST",
            url: window.SnitzVars.baseUrl + "Topic/UpdateTopicList",
            data: { topicid: $(this).val() },
            cache: false
        });
    });
    /*update the session replylist if checkbox selected*/
    $('.reply-select').on('mouseup', function () {

        $.ajax({
            type: "POST",
            url: window.SnitzVars.baseUrl + "Reply/UpdateReplyList",
            data: { replyid: $(this).val() },
            cache: false
        });
    });

    /*remove the sidebox if it's empty*/
    if ($('.side-box').is(':empty') || $.trim($('.side-box').html()).length == 0) {
        $('#right-col').remove();
        $('#main-content').removeClass('col-md-8');
        $('#main-content').removeClass('col-lg-9');

    }


    //rotat ad banners
    if ($("#banner-ad-side").length > 0) {
        var b1 = setInterval(function () {
            $.ajax({
                url: window.SnitzVars.baseUrl + "Ad/SideBanner",
                cache: false,
                dataType: "html",
                success: function (data) {
                    $("#banner-ad-side").html(data);
                    //$('#featured-img').css('visibility', 'visible').hide().fadeIn(2000);
                }
            });
        }, 30000);
    }
    if ($("#banner-ad-top").length > 0) {
        var b2 = setInterval(function () {
            $.ajax({
                url: window.SnitzVars.baseUrl + "Ad/TopBanner",
                cache: false,
                dataType: "html",
                success: function (data) {
                    $("#banner-ad-top").html(data);
                    //$('#featured-img').css('visibility', 'visible').hide().fadeIn(2000);
                }
            });
        }, 30000);
    }
    //refresh recent topics
    if ($("#recent-topics").length > 0) {
        var recent = setInterval(function () {
            $("#recent-topics").html("<i class='fa fa-spinner fa-pulse fa-3x fa-fw'></i>");
            $.ajax({
                url: window.SnitzVars.baseUrl + 'Home/RefreshRecentTopics',
                data: { "id": "1" },
                type: "POST",
                cache: false,
                success: function (data) {
                    $("#recent-topics").html(data);
                    $("abbr.timeago").timeago();
                }
            });
        }, 1000 * 60 * 5); // 5 min
    }
    //refresh message notify
    if ($("#pm-notify").length > 0) {
        var notify = setInterval(function () {
            if ($("#pm-notify").length > 0) {
                $.ajax({
                    url: window.SnitzVars.baseUrl + 'Home/PMNotify',
                    type: "POST",
                    cache: false,
                    success: function(data) {
                        $("#pm-notify").html(data);
                        $("abbr.timeago").timeago();
                    }
                });
            } else { clearInterval(notify);}
        }, 1000 * 60 * 5); // 5 min
    }
    //refresh online-users
    if ($("#online-users").length > 0) {
        var online = setInterval(function () {

            $.ajax({
                url: window.SnitzVars.baseUrl + 'Home/OnlineUsers',
                type: "POST",
                cache: false,
                success: function (data) {
                    $("#online-users").innerHTML = data;
                    $("abbr.timeago").timeago();
                }
            });
        }, 1000 * 60 * 3); // 3 min
    }
    //only enable featured image timer if the
    //featured image div is on the page
    if ($("#fimage").length > 0) {

        $("#featured-img").one("load", function () {
            // do stuff
            $('#featured-img').css('visibility', 'visible').show();
        }).each(function () {
            if (this.complete) $(this).load();
        });

        var f = setInterval(function () {
            $.ajax({
                url: window.SnitzVars.baseUrl + "PhotoAlbum/FeaturedImage",
                cache: false,
                dataType: "html",
                success: function (data) {
                    $("#fimage").html(data);
                    $('#featured-img').css('visibility', 'visible').hide().fadeIn(2000);
                }
            });
        }, 1000 * 60 * 2); // 2 min
    }

});

$(document).ajaxComplete(function () {
   // ready_or_not();
});

function ready_or_not() {

    setRequiredFields();
    //setStyleFromCookie();
    $("abbr.timeago").timeago();
}


