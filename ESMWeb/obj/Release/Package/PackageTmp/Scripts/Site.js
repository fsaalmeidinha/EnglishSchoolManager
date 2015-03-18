String.format = function () {
    var s = arguments[0];
    for (var i = 0; i < arguments.length - 1; i++) {
        var reg = new RegExp("\\{" + i + "\\}", "gm");
        s = s.replace(reg, arguments[i + 1]);
    }

    return s;
}

//Date.prototype.toJSON = function() { return "{timestamp}+" . this.getTime() }
Date.prototype.toJSON = function () { return String.format("/Date({0})/", this.getTime() - this.getTimezoneOffset() * 60000) }

function customJSONstringify(obj) {
    return JSON.stringify(obj).replace(/\/Date/g, "\\\/Date").replace(/\)\//g, "\)\\\/")
}