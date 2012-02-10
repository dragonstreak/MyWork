
jQuery(document).ready(function () {
    setSelectedModuleStyleByPage();
    setLeftMenuStyle();

});

function setSelectedModuleStyleByPage() {
    var pageUrl = location.href;
    var qsPositon = pageUrl.indexOf("?");
    qsPositon = qsPositon > 0? qsPositon:pageUrl.length;
    var paraString = pageUrl.substring(0, qsPositon);
    var getPageModuleParam = { Method: "GetPageModule",
        Args: { PageUrl: pageUrl
        }
    };

    jQuery.ajax(
    { type: 'post',
        url: '../Handler/SystemMgr.ashx',
        data: JSON.stringify(getPageModuleParam),
        contentType: 'application/json; charset=utf-8',
        //        data: '{"Jdata":[{"Method":"GetPageModule", "Args":[{ "pageUrl":"' + pageUrl + '"}]}]}',
        //        contentType: 'text/json',
        success: function (response) {
            var getPageModuleResult = JSON.parse(response)
            var moduleName = getPageModuleResult.ModuleName;
            var menu = jQuery('a[ModuleName="' + moduleName + '"]');
            if (menu != undefined && menu.length > 0) {
                menu.addClass("active");
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("call service error!");
        }
    }
     );
}

function getRequestParameter(parameterName){ 
    var url = location.href;  
    var paraString = url.substring(url.indexOf("?")+1,url.length).split("&");  
    var paraObj = {}  
    for (i=0; j=paraString[i]; i++){  
    paraObj[j.substring(0,j.indexOf("=")).toLowerCase()] = j.substring(j.indexOf("=")+1,j.length);  
    }  
    var returnValue = paraObj[parameterName.toLowerCase()];  
    if(typeof(returnValue)=="undefined"){  
        return "";  
    }
    else{  
        return returnValue; 
    }
}


function setLeftMenuStyle() {
    $("div[ID$='LeftMenuPanel']").css({ background: "#555555", width: "160px", "max-width": "180px", "min-width": "120px", "text-align": "left" });

}

var $j = jQuery;
if (typeof (_illumin.erp) == "undefined")
    _illumin.erp = {};

if (typeof (_illumin.erp.master) == "undefined")
    _illumin.erp.master = {};

$j.fn.center = function () {
    this.css("position", "absolute");
    this.css("top", (($(window).height() - this.ourerHeight()) / 2) + $(window).scrollTop() + "px");
    this.css("left", (($(window).width() - this.outerWidth()) / 2) + $(window).scrollLeft() + "px");
    return this;
}

_illumin.erp.master.showMessage = function (msg) {
    $j("#promptMessage").html(msg);
    //settimeout for ie8
    setTimeout("$j('#promptMessageContainer').center();	$j('#promptMessage').center();	$j('#promptMessageContainer').fadeIn();	$j('#promptMessage').fadeIn();", 50);

    setTimeout("$j('#promptMessageContainer').fadeOut()", 2050);
    setTimeout("$j('#promptMessage').fadeOut()", 2050);
}


//handle Error
_illumin.erp.master.handerError = function (jqXHR, textStatus, errorThrown) {
    alert('System error. Please try again.');
    //alert(jqXHR.responseText);
    _illumin.erp.master.hideLoading();
}

//modal box initalization helper
_illumin.erp.master.initialModalBox = function (containerId, enablejQueryAnimation) {
    if (!(_illumin && _illumin.ModalBox)) {
        alert('missing script file!');
        return;
    }

    var instanceObj = new _illumin.ModalBox(containerId, enablejQueryAnimation);

    instanceObj.OverLay.Color = '#000';
    instanceObj.OverLay.Opacity = '30';
    instanceObj.OverLay.enablejQueryAnimation = !(enablejQueryAnimation === false);
    instanceObj.Fixed = true;
    instanceObj.Center = true;


    return instanceObj;
}

//modalbox instance
_illumin.erp.master.mbLoading = null;

//show loading modalbox
_illumin.erp.master.showLoading = function () {
    if (_illumin.erp.master.mbLoading)
        _illumin.erp.master.mbLoading.Show();
}

//hide loading modalbox
_illumin.erp.master.hideLoading = function () {
    if (_illumin.erp.master.mbLoading)
        _illumin.erp.master.mbLoading.Close();
}

//initial loading on document ready.
$j(function () {
    if (!_illumin.erp.master.mbLoading) {
        _illumin.erp.master.mbLoading = _illumin.erp.master.initialModalBox('divLoading', false);
        _illumin.erp.master.mbLoading.OverLay.Opacity = '0';
    }
})