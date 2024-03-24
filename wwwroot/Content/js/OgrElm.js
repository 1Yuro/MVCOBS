function ogrelmchangeIframeSrc(controller, action, parameter) {
    var iframe = document.getElementById("myIframe");
    var newSrc = '/' + controller + '/' + action + '?ogrElmid=' + parameter;
    iframe.src = newSrc;
}

function psizogrelmchangeIframeSrc(controller, action, parameter) {
    var iframe = document.getElementById("myIframe");
    var newSrc = '/' + controller + '/' + action;
    iframe.src = newSrc;
}

