var sample = (function ($) {
    var module = {};

    module.$ = $; // property inject jquery framework
    module.getUrl = function () { return document.URL; };

    module.onContentMouseover = function () {
        module.$('#sampleContent').css("background-color", "#ffffff");
    };

    module.onContentMouseout = function () {
        module.$('#sampleContent').css("background-color", "#dddddd");
    };

    module.$(document).ready(function () {
        module.$('#sampleContent').mouseover(
            function () { module.onContentMouseover() });
        module.$('#sampleContent').mouseout(
            function () { module.onContentMouseout() });
    });

    return module;
})(jQuery);

