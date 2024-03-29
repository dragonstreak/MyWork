/*
==================================================================
是否为空
==================================================================
*/
function isEmpty(strValue)
{
	strValue=strValue.replace(/^\s+|\s+$/g, "");
	return (strValue == null || strValue == "");
}

/*
==================================================================
是否为正有理数
==================================================================
*/
function isPositive(strValue)
{
	return isInt(strValue, "+") || isFloat(strValue, "+");
}

/*
==================================================================
是否为负有理数
==================================================================
*/
function isNegative(strValue)
{
	return isInt(strValue, "-") || isFloat(strValue, "-");
}


/*
==================================================================
判断objStr是否为合法的Email地址
==================================================================
 */
function isValidEmail(objStr)
{
	if(objStr=="")
		return false;
	var reg = /^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$/;
	objStr = objStr.toString();
	return (objStr.match(reg) != null);
}

/*
==================================================================
判断objStr是否为合法的日期(yyyy-MM-dd)或者(yy-MM-dd)
==================================================================
 */
function isDate(objStr)
{
    var reg = /^((\d{4})|(\d{2}))-(\d{1,2})-(\d{1,2})$/;
    
    if(trim(objStr)=="")
		return false;
	else
		objStr = objStr.toString();
		
    if(objStr.match(reg) == null)
        return false;

    var arrDate = objStr.split("-");

    var year = parseInt(arrDate[0], 10);
    var month = parseInt(arrDate[1], 10);
    var day = parseInt(arrDate[2], 10);

    if(year<100)
      if(year<50)
        year += 2000;
      else
      	year += 1900;

    var date =  new Date(year, month - 1, day);
    var y = parseInt(date.getYear(), 10);
    //如果年份是19**，Date.getYear()返回的是末两位数字作为年份，所以一定要加上1900才是正确的年份
    if(y < 100)
    	y += 1900;

    if ((y == year && parseInt(date.getMonth(), 10) == month - 1 && parseInt(date.getDate(), 10) == day)
         && year >= 1900 && year <= 2049)
        return true;
    else
        return false;
}


/*
==================================================================
(测试字符串, sign(+、-、empty)；zero(empty、1、true)
判断是否为整数、正整数、负整数、正整数+0、负整数+0
==================================================================
 */
function isInt(objStr, sign, zero)
{
    var reg;    
    var bolzero;    

    if(trim(objStr)=="")
        return false;
    else
        objStr=objStr.toString();  

    if((sign==null) || (trim(sign)==""))
        sign="+-";

    if((zero==null) || (trim(zero)==""))
        bolzero=false;
    else
    {
        zero=zero.toString();
        bolzero = (zero=="true" || zero=="1");
	}
    

    switch(sign)
    {
        case "+-":
            //整数
            reg=/(^-?|^\+?)\d+$/;            
            break;
        case "+": 
            if(!bolzero)           
                //正整数
                reg=/^\+?[0-9]*[1-9][0-9]*$/;
            else
            {
                //正整数+0
                //reg=/^\+?\d+$/;
                reg=/^\+?[0-9]*[0-9][0-9]*$/;
            }
            break;
        case "-":
            if(!bolzero)
                //负整数
                reg=/^-[0-9]*[1-9][0-9]*$/;
            else
                //负整数+0
                //reg=/^-\d+$/;
                reg=/^-[0-9]*[0-9][0-9]*$/;           
            break;
        default:
            alert("检查符号参数，只可为(空、+、-)");
            return false;
            break;
    }

    return (objStr.match(reg) != null);    
}

 

/*
==================================================================
(测试字符串, sign(+、-、empty)；zero(empty、1、true)
判断是否为浮点数、正浮点数、负浮点数、正浮点数+0、负浮点数+0
==================================================================
 */
function isFloat(objStr,sign,zero)
{
    var reg;    
    var bolzero;    

    if(trim(objStr)=="")
        return false;
    else
        objStr=objStr.toString();   

    if((sign==null)||(trim(sign)==""))
        sign="+-";

    if((zero==null)||(trim(zero)==""))
        bolzero=false;
    else
    {
        zero=zero.toString();
        bolzero = (zero=="true" || zero=="1");
    }

    switch(sign)
    {
        case "+-":
            //浮点数
            reg=/^((-?|\+?)\d+)(\.\d+)?$/;
            break;
        case "+": 
            if(!bolzero)           
            {
                //正浮点数
                reg=/^\+?(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$/;
            }
            else
            {
                //正浮点数+0
                reg=/^\+?\d+(\.\d+)?$/;
            }
            break;
        case "-":
            if(!bolzero)
            {
                //负浮点数
                reg=/^-(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$/;
            }
            else
            {
                //负浮点数+0
                reg=/^((-\d+(\.\d+)?)|(0+(\.0+)?))$/;
            }            
            break;
        default:
            alert("检查符号参数，只可为(空、+、-)");
            return false;
            break;
    }

    return (objStr.match(reg) != null);
}
/*
==================================================================
将srcStr四舍五入到nAfterDot位小数
==================================================================
*/
function FormatNumber(srcStr,nAfterDot)
{
  var srcStr,nAfterDot;
  var resultStr,nTen;
  srcStr = ""+srcStr+"";
  strLen = srcStr.length;
  dotPos = srcStr.indexOf(".",0);
  if (dotPos == -1){
    resultStr = srcStr+".";
    for (i=0;i<nAfterDot;i++){
      resultStr = resultStr+"0";
    }
  }
  else{
    if ((strLen - dotPos - 1) >= nAfterDot){
      nAfter = dotPos + nAfterDot + 1;
      nTen =1;
      for(j=0;j<nAfterDot;j++){
        nTen = nTen*10;
      }
      resultStr = Math.round(parseFloat(srcStr)*nTen)/nTen;
    }
    else{
      resultStr = srcStr;
      for (i=0;i<(nAfterDot - strLen + dotPos + 1);i++){
        resultStr = resultStr+"0";
      }
      
    }
  } 
 return resultStr;

}


/*
==================================================================
字符输入控制
==================================================================
*/
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

/*
==================================================================
只能输入整数，使用时在form中加入该脚本即可
==================================================================
*/
function enableIntOnly(obj)
{
	var reg = /^[0-9]*$/
	obj.onkeypress = function(){return regInput(this,reg , String.fromCharCode(event.keyCode))}
	obj.onpaste = function(){return regInput(this, reg, window.clipboardData.getData('Text'))}
	obj.ondrop =  function(){return regInput(this,reg, event.dataTransfer.getData('Text'))}	
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

/*
==================================================================
使用时在form中加入该脚本即可，type为空时，即只能输入整数
type为2,4时，表示2,4位小数，为'a'表示小写，为'A'表示大写，为
'date'表示只能输入日期
==================================================================
*/
function enableOnly(obj, type)
{
	var reg ;
	if(type == null)
		reg = /^[0-9]*$/
	else if (type == 2)
		reg = /^\d*\.?\d{0,2}$/
	else if (type == 4)
		reg = /^\d*\.?\d{0,4}$/
	else if (type == 'a')
		reg = /^[a-z]*$/
	else if (type == 'A')
		reg = /^[A-Z]*$/
	else if (type == 'date')
		reg = /^\d{1,4}([-\/](\d{1,2}([-\/](\d{1,2})?)?)?)?$/
	else
		return
		
	obj.onkeypress = function(){return regInput(this, reg, String.fromCharCode(event.keyCode))}
	obj.onpaste = function(){return regInput(this, reg, window.clipboardData.getData('Text'))}
	obj.ondrop =  function(){return regInput(this, reg, event.dataTransfer.getData('Text'))}	
}