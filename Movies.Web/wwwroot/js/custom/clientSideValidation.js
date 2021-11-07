$(function () {
    // register FileSize validation
    $.validator.unobtrusive.adapters.add('filesize', ['maxsize'], function (options) {
        options.rules['filesize'] = { maxsize: options.params.maxsize };
        if (options.message) {
            options.messages['filesize'] = options.message;
        }
    });

    $.validator.addMethod('filesize', function (value, element, param) {
        if (value === "") {
            return true;
        }
        var maxsize = parseInt(param.maxsize);
        if (element.files != undefined && element.files[0] != undefined && element.files[0].size != undefined) {
            var filesize = parseInt(element.files[0].size);
            return filesize <= maxsize;
        }
        return true; // in case browser does not support HTML5 file API
    });

    //register FileExtensionCustom validation
    $.validator.unobtrusive.adapters.add('fileextensioncustom', ['extensionsstring'], function (options) {
        options.rules['fileextensioncustom'] = { extensionsstring: options.params.extensionsstring };
        if (options.message) {
            options.messages['fileextensioncustom'] = options.message;
        }
    });

    $.validator.addMethod('fileextensioncustom', function (value, element, param) {
        if (value === "") {
            return true;
        }
        var extensions = param.extensionsstring.split(',');
        if (element.files != undefined && element.files[0] != undefined && element.files[0].name != undefined) {
            for (var i = 0; i < extensions.length; i++) {
                if (element.files[0].name.endsWith(extensions[i])) {
                    return true;
                }
            }
        }
        return false;
    });
}(jQuery));


$(function () {
}(jQuery));