function changeIframeSrc(controller, action, parameter) {
    var iframe = document.getElementById("myIframe");
    var newSrc = '/' + controller + '/' + action + '?ogrenciid=' + parameter;
    iframe.src = newSrc;
}