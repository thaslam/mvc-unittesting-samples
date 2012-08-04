var sample = (function ($) {
    var module = {};

    module.getUrl = function () { return document.URL; };

    return module;
})(jQuery);
