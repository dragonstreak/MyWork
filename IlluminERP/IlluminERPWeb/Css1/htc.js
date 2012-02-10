



if(className)
{
	var i, oldname = className, newname = "", namearray = className.split(" ");

	for (i in namearray)
	{
		switch (namearray[i])
		{
			case "text":
				newname += " textover ";
				break;
			case "button":
				newname += " buttonover ";
				break;
			case "buttons":
				newname += " buttonsover ";
				break;
			case "num":
				newname += " numover ";
				//enableIntOnly(this);
				break;
			case "date":
				newname += " dateover ";
				enableDateOnly(this);
				break;
			case "time":
				newname += " timeover ";
				break;
			case "col":
				newname += " colover ";
				break;

			case "dgn":
			case "dga":
			case "dgalert":
				newname += " dgover ";
				break;

			case "btnadd":
				newname += " btnadd btnover ";
				break;
			case "btndel":
				newname += " btndel btnover ";
				break;
			case "btnok":
				newname += " btnok btnover ";
				break;
			case "btncancel":
				newname += " btncancel btnover ";
				break;
			case "btnclose":
				newname += " btnclose btnover ";
				break;
			case "btnqry":
				newname += " btnqry btnover ";
				break;
			case "btnreset":
				newname += " btnreset btnover ";
				break;
			case "btnexcel":
				newname += " btnexcel btnover ";
				break;
			case "btnnext":
				newname += " btnnext btnover ";
				break;
			case "btnback":
				newname += " btnback btnover ";
				break;
			case "btnstat":
				newname += " btnstat btnover ";
				break;
			case "btnprint":
				newname += " btnprint btnover ";
				break;
			case "btnhelp":
				newname += " btnhelp btnover ";
				break;
			case "btnsetup":
				newname += " btnsetup btnover ";
				break;
			case "btnsave":
				newname += " btnsave btnover ";
				break;
			case "btnedit":
				newname += " btnedit btnover ";
				break;
			case "btnproup":
				newname += " btnproup btnover ";
				break;
			case "btnprodown":
				newname += " btnprodown btnover ";
				break;
			case "btnadjust":
				newname += " btnadjust btnover ";
				break;
			case "btnnyear":
				newname += " btnnyear btnover ";
				break;
			case "btnupload":
				newname += " btnupload btnover ";
				break;
			case "btncopy":
				newname += " btncopy btnover ";
				break;

			default:
				newname += namearray[i] + " ";
		}
	}
}
//if(newname == "detail")
//{
//	for(i=0;i<rows.length;i++)
//	{
//		for(j=0;j<rows[i].cells.length;j++)
//		{
//			if(j%2==1)
//			rows[i].cells[j].className = "royalblue";
//		}
//	}
//}

function DoMouseClick()
{
	if(oldname=="dgn" || oldname=="dga")
		className = "dgs";
}

function DoMouseOver()
{
	if(!isContentEditable)
		className = newname;
}

function DoMouseOut()
{
	if(!isContentEditable)
		className = oldname;
}

function DoOnFocus()
{
	if(isContentEditable)
		className = newname;
}

function DoOnBlur()
{
	if(isContentEditable)
		className = oldname;
}

function regInput(obj, reg, inputStr)
{
/**
任意数字：/^[0-9]*$/
限2位小数：/^\d*\.?\d{0,2}$/
小写英文：/^[a-z]*$/
大写英文：/^[A-Z]*$/
日　 期：/^\d{1,4}([-\/](\d{1,2}([-\/](\d{1,2})?)?)?)?$/
任意中文：input：		/^$/
	  paste or drop：	/^[\u4E00-\u9FA5]*$/
		
**/
var docSel = document.selection.createRange()

if (docSel.parentElement().tagName != "INPUT") return false
oSel = docSel.duplicate()
oSel.text = ""

var srcRange = obj.createTextRange()

oSel.setEndPoint("StartToStart", srcRange)

var str = oSel.text + inputStr + srcRange.text.substr(oSel.text.length)

return reg.test(str)
}

function enableDateOnly(obj)
{
	obj.onkeypress = function(){return regInput(this, /^\d{1,4}([-\/](\d{1,2}([-\/](\d{1,2})?)?)?)?$/, String.fromCharCode(event.keyCode))}
	obj.onpaste = function(){return regInput(this, /^\d{1,4}([-\/](\d{1,2}([-\/](\d{1,2})?)?)?)?$/, window.clipboardData.getData('Text'))}
	obj.ondrop =  function(){return regInput(this, /^\d{1,4}([-\/](\d{1,2}([-\/](\d{1,2})?)?)?)?$/, event.dataTransfer.getData('Text'))}	
}

function enableIntOnly(obj)
{
	obj.onkeypress = function(){return regInput(this, /^[0-9]*$/, String.fromCharCode(event.keyCode))}
	obj.onpaste = function(){return regInput(this, /^[0-9]*$/, window.clipboardData.getData('Text'))}
	obj.ondrop =  function(){return regInput(this, /^[0-9]*$/, event.dataTransfer.getData('Text'))}	
}

function enableNumber2Only(obj)
{
	obj.onkeypress = function(){return regInput(this, /^\d*\.?\d{0,2}$/, String.fromCharCode(event.keyCode))}
	obj.onpaste = function(){return regInput(this, /^\d*\.?\d{0,2}$/, window.clipboardData.getData('Text'))}
	obj.ondrop =  function(){return regInput(this, /^\d*\.?\d{0,2}$/, event.dataTransfer.getData('Text'))}	
}

function enableNumber4Only(obj)
{
	obj.onkeypress = function(){return regInput(this, /^\d*\.?\d{0,4}$/, String.fromCharCode(event.keyCode))}
	obj.onpaste = function(){return regInput(this, /^\d*\.?\d{0,4}$/, window.clipboardData.getData('Text'))}
	obj.ondrop =  function(){return regInput(this, /^\d*\.?\d{0,4}$/, event.dataTransfer.getData('Text'))}	
}

