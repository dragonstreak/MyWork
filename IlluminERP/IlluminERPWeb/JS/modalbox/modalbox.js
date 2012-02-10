
if (typeof (_illumin) == "undefined")
	_illumin = {};

/********************ModalBoxHelper********************/

if (!_illumin.$) {
	_illumin.$ = function (id) {
		return "string" == typeof id ? document.getElementById(id) : id;
	};
}

_illumin.ModalBoxHelper = function () {

}
_illumin.ModalBoxHelper.isIE = (document.all) ? true : false;

_illumin.ModalBoxHelper.isIE6 = _illumin.ModalBoxHelper.isIE && ([/MSIE (\d)\.0/i.exec(navigator.userAgent)][0][1] == 6);

_illumin.ModalBoxHelper.isIE7 = _illumin.ModalBoxHelper.isIE && ([/MSIE (\d)\.0/i.exec(navigator.userAgent)][0][1] == 7);

_illumin.ModalBoxHelper.isIPad = navigator.userAgent.indexOf('iPad') > 0;

_illumin.ModalBoxHelper.addEvent = function (elm, evType, fn, useCapture) {
	if (elm.addEventListener) {
		elm.addEventListener(evType, fn, useCapture);
		return true;
	}
	else if (elm.attachEvent) {
		var r = elm.attachEvent('on' + evType, fn);
		return r;
	}
	else {
		elm['on' + evType] = fn;
	}
}

_illumin.ModalBoxHelper.Extend = function (destination, source) {
	for (var property in source) {
		destination[property] = source[property];
	}
}

_illumin.ModalBoxHelper.Bind = function (object, fun) {
	return function () {
		return fun.apply(object, arguments);
	}
}

_illumin.ModalBoxHelper.Each = function (list, fun) {
	for (var i = 0, len = list.length; i < len; i++) { fun(list[i], i); }
};

_illumin.ModalBoxHelper.Contains = function (a, b) {
	return a.contains ? a != b && a.contains(b) : !!(a.compareDocumentPosition(b) & 16);
}

_illumin.ModalBoxHelper.getWindowScrollTop = function () {
	var winScrollTop = document.body.scrollTop;

	if (winScrollTop == 0) {
		if (window.pageYOffset)
			winScrollTop = window.pageYOffset;
		else
			winScrollTop = (document.body.parentElement) ? document.body.parentElement.scrollTop : 0;
	}

	return winScrollTop;
}

_illumin.ModalBoxHelper.getViewPortSize = function () {
	var viewportwidth;
	var viewportheight;

	// the more standards compliant browsers (mozilla/netscape/opera/IE7) use window.innerWidth and window.innerHeight

	if (typeof window.innerWidth != 'undefined') {
		viewportwidth = window.innerWidth,
      viewportheight = window.innerHeight
	}

	// IE6 in standards compliant mode (i.e. with a valid doctype as the first line in the document)

	else if (typeof document.documentElement != 'undefined'
     && typeof document.documentElement.clientWidth !=
     'undefined' && document.documentElement.clientWidth != 0) {
		viewportwidth = document.documentElement.clientWidth,
       viewportheight = document.documentElement.clientHeight
	}

	// older versions of IE

	else {
		viewportwidth = document.getElementsByTagName('body')[0].clientWidth,
		viewportheight = document.getElementsByTagName('body')[0].clientHeight
	}

	return [viewportwidth, viewportheight];
}

_illumin.ModalBoxHelper.getDocumentSize = function() {
	var w = 0;
	var h = 0;

	var doc = document;
	w = Math.max(
        Math.max(doc.body.scrollWidth, doc.documentElement.scrollWidth),
        Math.max(doc.body.offsetWidth, doc.documentElement.offsetWidth),
        Math.max(doc.body.clientWidth, doc.documentElement.clientWidth)
    );

	h = Math.max(
        Math.max(doc.body.scrollHeight, doc.documentElement.scrollHeight),
        Math.max(doc.body.offsetHeight, doc.documentElement.offsetHeight),
        Math.max(doc.body.clientHeight, doc.documentElement.clientHeight)
    );

	return [w, h];
}
/********************ModalBoxHelper end********************/



/********************_illumin.OverLay********************/

_illumin.OverLay = function (options, boxId) {
	//remove old
	var prefix = "modalboxlay";
	if (_illumin.$(prefix + boxId))
		document.body.removeChild(_illumin.$(prefix + boxId));

	/*
	if(document.body.childNodes[0])
	if( document.body.childNodes[0].tagName == "DIV" &&  document.body.childNodes[0].className == "modalBoxOverlay" )
	document.body.removeChild(document.body.childNodes[0]);
	*/
	this.SetOptions(options);

	var newDiv = document.createElement("div");
	newDiv.id = prefix + boxId;
	newDiv.className = "modalBoxOverlay";
	this.Lay = _illumin.$(this.options.Lay) || document.body.insertBefore(newDiv, document.body.childNodes[0]);

	this.Color = this.options.Color;
	this.Opacity = parseInt(this.options.Opacity);
	this.zIndex = parseInt(this.options.zIndex);
	this.enablejQueryAnimation = this.options.enablejQueryAnimation;

	with (this.Lay.style) {
		display = "none";
		zIndex = this.zIndex;
		left = top = 0;
		position = "fixed";
		if (_illumin.ModalBoxHelper.isIPad) {
			width = '100%';
			height = _illumin.ModalBoxHelper.getDocumentSize()[1] + 'px';
		}
		else {
			width = height = "100%";
		}

	}

	if (_illumin.ModalBoxHelper.isIE6) {
		this.Lay.style.position = "absolute";
		//ie6 set width and height
		this._resize = _illumin.ModalBoxHelper.Bind(this, function () {
			this.Lay.style.width = Math.max(document.documentElement.scrollWidth, document.documentElement.clientWidth) + "px";
			this.Lay.style.height = Math.max(document.documentElement.scrollHeight, document.documentElement.clientHeight) + "px";
		});
		//hide select
		this.Lay.innerHTML = '<iframe style="background-color:#ccc;position:absolute;top:0;left:0;width:100%;height:100%;filter:alpha(opacity=0);"></iframe>'
	}
}
_illumin.OverLay.prototype = {
	//set default option
	SetOptions: function (options) {
		this.options = {
			Lay: null, //layer object
			Color: "#000", //bg color
			Opacity: 50, //transparent(0-100)
			zIndex: 1000, //zIndex
			enablejQueryAnimation: true
		};
		_illumin.ModalBoxHelper.Extend(this.options, options || {});
	},
	//show function
	Show: function () {
		//ie6 compatible
		if (_illumin.ModalBoxHelper.isIE6) { this._resize(); window.attachEvent("onresize", this._resize); }
		//set style
		with (this.Lay.style) {
			//set transparent
			_illumin.ModalBoxHelper.isIE ? filter = "alpha(opacity:" + this.Opacity + ")" : opacity = this.Opacity / 100;
		
			backgroundColor = this.Color;
		}

		if (jQuery
				&& this.enablejQueryAnimation
				&& !_illumin.ModalBoxHelper.isIE6
				&& !_illumin.ModalBoxHelper.isIE7
				&& !_illumin.ModalBoxHelper.isIPad)
			jQuery(this.Lay).fadeTo( 'normal', 0.5);
		else
			this.Lay.style.display = "block";
	},
	//close function
	Close: function () {

		if (jQuery
				&& this.enablejQueryAnimation
				&& !_illumin.ModalBoxHelper.isIE6
				&& !_illumin.ModalBoxHelper.isIE7
				&& !_illumin.ModalBoxHelper.isIPad)
			jQuery(this.Lay).fadeTo('normal', 0, function () { this.style.display = "none"; });
		else
			this.Lay.style.display = "none";

		if (_illumin.ModalBoxHelper.isIE6) { window.detachEvent("onresize", this._resize); }
	}
};


/********************_illumin.OverLay end********************/


/********************_illumin.ModalBox********************/
_illumin.ModalBox = function (box, options) {
	this.Box = _illumin.$(box); //display layer
	this.OverLay = new _illumin.OverLay(options, box); //over lay

	this.SetOptions(options);

	this.Fixed = !!this.options.Fixed;
	this.Over = !!this.options.Over;
	this.Center = !!this.options.Center;
	this.onShow = this.options.onShow;
	this.onClose = this.options.onClose;
	this.onShowForResize = this.options.onShowForResize;

	this.Box.style.zIndex = this.OverLay.zIndex + 1;
	this.Box.style.display = "none";

	//ie6 compatible
	if (_illumin.ModalBoxHelper.isIE6) {
		this._top = this._left = 0; this._select = [];
		this._fixed = _illumin.ModalBoxHelper.Bind(this, function () { this.Center ? this.SetCenterScroll() : this.SetFixed(); });
	}
}
_illumin.ModalBox.prototype = {
	//set default option
	SetOptions: function (options) {
		this.options = {
			Over: true, //show overlay
			Fixed: true, //fixed position
			Center: false, //center
			onShow: function () { }, //onShow event
			onClose: function () { }, //onClose event
			onShowForResize: function () { } //onShowForResize event
		};
		_illumin.ModalBoxHelper.Extend(this.options, options || {});
	},
	//ie6 fixed position compatible
	SetFixed: function () {
		this.Box.style.top = document.documentElement.scrollTop - this._top + this.Box.offsetTop + "px";
		this.Box.style.left = document.documentElement.scrollLeft - this._left + this.Box.offsetLeft + "px";

		this._top = document.documentElement.scrollTop; this._left = document.documentElement.scrollLeft;
	},
	//ie6 compatible
	SetCenter: function () {
		this.Box.style.marginTop = document.documentElement.scrollTop - this.Box.offsetHeight / 2 + "px";
		this.Box.style.marginLeft = document.documentElement.scrollLeft - this.Box.offsetWidth / 2 + "px";
	},
	SetCenterScroll: function () {
		this.Box.style.marginTop = document.documentElement.scrollTop - this.Box.offsetHeight / 2  + "px";
		this.Box.style.marginLeft = document.documentElement.scrollLeft - this.Box.offsetWidth / 2 + "px";
	},
	//show function
	Show: function (options) {
		//fix position
		this.Box.style.position = this.Fixed && !_illumin.ModalBoxHelper.isIE6 && !_illumin.ModalBoxHelper.isIPad ? "fixed" : "absolute";
		//over lay
		this.Over && this.OverLay.Show();

		this.Box.style.display = "block";

		//center
		if (this.Center) {
			this.Box.style.top = this.Box.style.left = "50%";

			//fix for ipad
			if (_illumin.ModalBoxHelper.isIPad) {
				//alert(_illumin.ModalBoxHelper.getDocumentSize())
				this.Box.style.top = (_illumin.ModalBoxHelper.getWindowScrollTop() + _illumin.ModalBoxHelper.getViewPortSize()[1] / 2) + 'px';
			}

			//set margin
			if (this.Fixed) {
				this.Box.style.marginTop = -this.Box.offsetHeight / 2 + "px";
				this.Box.style.marginLeft = -this.Box.offsetWidth / 2 + "px";
			} else {
				this.SetCenter();
			}
		}

		//ie6 compatible
		if (_illumin.ModalBoxHelper.isIE6) {
			if (!this.Over) {
				//hide select
				this._select.length = 0;
				_illumin.ModalBoxHelper.Each(document.getElementsByTagName("select"), _illumin.ModalBoxHelper.Bind(this, function (o) {
					if (!_illumin.ModalBoxHelper.Contains(this.Box, o)) { o.style.visibility = "hidden"; this._select.push(o); }
				}))
			}
			//set display position
			this.Center ? this.SetCenter() : this.Fixed && this.SetFixed();
			//set fixed position
			this.Fixed && window.attachEvent("onscroll", this._fixed);
		}

		this.onShow();
		this.onShowForResize();
	},
	//close function
	Close: function () {
		this.Box.style.display = "none";
		this.OverLay.Close();
		if (_illumin.ModalBoxHelper.isIE6) {
			window.detachEvent("onscroll", this._fixed);
			_illumin.ModalBoxHelper.Each(this._select, function (o) { o.style.visibility = "visible"; });
		}
		this.onClose();
	}
};


/********************_illumin.ModalBox end********************/


_illumin.ajaxObject = function (url, callbackFunction) {
	var that = this;
	this.updating = false;
	this.abort = function () {
		if (that.updating) {
			that.updating = false;
			that.AJAX.abort();
			that.AJAX = null;
		}
	}
	this.update = function (passData, postMethod) {
		if (that.updating) { return false; }
		that.AJAX = null;
		if (window.XMLHttpRequest) {
			that.AJAX = new XMLHttpRequest();
		} else {
			that.AJAX = new ActiveXObject("Microsoft.XMLHTTP");
		}
		if (that.AJAX == null) {
			return false;
		} else {
			that.AJAX.onreadystatechange = function () {
				if (that.AJAX.readyState == 4) {
					that.updating = false;
					that.callback(that.AJAX.responseText, that.AJAX.status, that.AJAX.responseXML);
					that.AJAX = null;
				}
			}
			that.updating = new Date();
			if (/post/i.test(postMethod)) {
				var uri = urlCall + '?' + that.updating.getTime();
				that.AJAX.open("POST", uri, true);
				that.AJAX.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
				that.AJAX.send(passData);
			} else {
				var uri = urlCall + '?' + passData + '&timestamp=' + (that.updating.getTime());
				that.AJAX.open("GET", uri, true);
				that.AJAX.send(null);
			}
			return true;
		}
	}
	var urlCall = url;
	this.callback = callbackFunction || function () { };
}