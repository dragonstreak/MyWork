function CacheData(key) {

    this.id = "#" + key;

    if (jQuery(key).length < 1) {
        jQuery("<div/>")
				.attr("id", key)
				.css("display", "none")
				.appendTo(jQuery("#cache_data_storage"))
    }

    return this;
}

CacheData.prototype = {

    id: "",

    get: function (key) {
        return jQuery(this.id).data(key);
    },

    set: function (key, val) {
        jQuery(this.id).data(key, val);
    },

    remove: function (key) {
        jQuery(this.id).removeData(key);
    },

    removeAll: function () {
        jQuery(this.id).remove();
    }
};

var templateCache = null;

var UserQuery = {
    RequestUrl: "../Handler/UserMgr.ashx",
    UserTemplateUrl: "../JTemplate/User.htm",

    EditUser: function (userId) {
        _illumin.erp.master.showLoading();
        var getUserInfoParam =
        { Method: "GetUserInfo",
          Args: {UserId: userId }
        ｝;
        $.ajax({
            url: UserQuery.RequestUrl,
            type: "post",
            dataType: "json",
            data: JSON.stringify(getUserInfoParam),
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                var getUserInfoResult = JSON.parse(response);
                if (getUserInfoResult.IsSuccess) {
                    UserQuery.PartialRender(UserQuery.UserTemplateUrl, getUserInfoResult.UserInfo, "EditUserContainer", null);
                }
                else {
                    _illumin.erp.master.showMessage(getUserInfoResult.ErrorMessage);
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                _illumin.erp.master.handerError(jqXHR, textStatus, errorThrown);
            }
        });

    },

    PartialRender: function (templateurl, data, containterId, onFinishedRenderTemplate) {
        var templateContent = null;
        var templateContent = templateCache.get(templateurl);
        if (templateContent == null || (typeof templateContent == "undefined")) {
            templateContent = $.ajax({
                url: templateurl,
                async: false
            }).responseText;
            templateCache.set(url, templateContent);
        }

        $("#" + containterId).setTemplate(templateContent, null, null);
        $("#" + containterId).processTemplate(data);

        if (onFinishedRenderTemplate && (typeof onFinishedRenderTemplate != "undefined")) {
            onFinishedRenderTemplate();
        }
    }
}


