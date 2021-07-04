/***************************** TIMER Page Load *******************************/
var loopTime;
var startTime = new Date();
var pageGenerationTime = "0.0";

function pageloadTimerCount() {
    loopTime = setTimeout("pageloadTimerCount()", 100);
}

function pageloadDoTimer() {
    pageloadTimerCount();
}

function pageloadStopTimer() {
    var timeMs = Math.floor((new Date() - startTime));

    $('#loadtime').html("" + timeMs);
    $('#generatetime').html(pageGenerationTime);
    $('#pagetime').show();

    clearTimeout(loopTime);
}