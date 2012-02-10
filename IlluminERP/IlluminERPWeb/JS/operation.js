
/*
==================================================================
 toDate(dateStr):将合法的日期(yyyy-MM-dd)或者(yy-MM-dd)的字符串
 转换成日期类型
==================================================================
 */
function toDate(dateStr)
{
    var arrDate = dateStr.split("-");

    var year = parseInt(arrDate[0], 10);
    var month = parseInt(arrDate[1], 10);
    var day = parseInt(arrDate[2], 10);

    if(year<100)
      if(year<50)
        year += 2000;
      else
        year += 1900;

    var date =  new Date(year, month - 1, day);

    return date;
}

/*
==================================================================
ltrim(string):去除左边的空格
==================================================================
*/
function ltrim(str)
{
    var whitespace = new String(" \t\n\r");
    var s = new String(str);
    
    if (whitespace.indexOf(s.charAt(0)) != -1)
    {
        var j=0, i = s.length;
        while (j < i && whitespace.indexOf(s.charAt(j)) != -1)
            j++;

        s = s.substring(j, i);
    }
    return s;
}

/*
==================================================================
rtrim(string):去除右边的空格
==================================================================
*/
function rtrim(str)
{
    var whitespace = new String(" \t\n\r");
    var s = new String(str);

    if (whitespace.indexOf(s.charAt(s.length-1)) != -1)
    {
        var i = s.length - 1;
        while (i >= 0 && whitespace.indexOf(s.charAt(i)) != -1)
            i--;

        s = s.substring(0, i+1);
    }
    return s;
}

/*
==================================================================
trim(string):去除前后空格
==================================================================
*/
function trim(str)
{
    return rtrim(ltrim(str));
}

/*
==================================================================
openWindow(winUrl, winName, winSize, alignCenter)
弹出一个窗口，可选择在屏幕中央或左上角显示
winUrl: 必选
winName: 可选，默认为URL的地址
winSize: 可选，默认为big:800*600
alignCenter: 可选，默认为居中显示
==================================================================
 */
function openWindow(winUrl, winSize, winName, winAlign)
{
    var left = 0, top = 0;
    var iHeight = 0, iWidth = 0;

	if (winUrl == null)
	{
		alert("错误：未指定 URL！");
		return;
	}
	switch(winSize)
	{
		case "big":
			iHeight = 600;
			iWidth = 800;
			break;
		case "normal":
			iHeight = 384;
			iWidth = 512;
			break;
		case "small":
			iHeight = 240;
			iWidth = 320;
			break;
		default:
			iHeight = 600;
			iWidth = 800;
	}
	if (winName == null)
	{
		winName = winUrl.substr(0,winUrl.indexOf("."));
	}
	switch(winAlign)
	{
		case 0:
			top = 0;
			left = 0;
			break;
		default:
			top = (window.screen.height - iHeight) / 2 - 30;
			left = (window.screen.width - iWidth) / 2 - 10;
	}
    
    var feature = "toolbar=no,resizable=yes,scrollbars=yes,status=no,height="+iHeight+",width="+iWidth+",left="+left+",top="+top;
	window.open(winUrl, winName, feature);
}

/*
================================================================== 
用于按钮当前页面跳转
==================================================================
 */
function href(url)
{
	location.href = url;
}

/*
================================================================== 
用于设置“全选”
cmdObj 是全选复选框， targetObj是复选框数组
例子: setCheckState(checkAll, checkbox1)
==================================================================
 */
function setCheckState(cmdObj, targetObj)
{       
    for(var i=0;i<targetObj.length;i++)
    {
        targetObj[i].checked = cmdObj.checked;
    }
}


/*
==================================================================
confirm，例如删除，提交，注销，恢复等
==================================================================
 */
function confirmA(vText)
{
    return confirm("确定要"+vText+"吗？")
}

/*
==================================================================
删除前的确定
==================================================================
 */
function confirmDelete()
{
	return confirmA("删除")
}

/*
==================================================================
操作前的确定，targetObj为选择框，todo为要显示的文本
==================================================================
*/
function confirmMultiSubmit(targetObj, toDo)
{    
    if (hasRecordSelected(targetObj))
    {
        return confirmA(toDo);
    }
    else
    {
		return false;
    }
}

/*
==================================================================
删除前的确定，targetObj为选择框
==================================================================
 */
function confirmMultiDel(targetObj)
{  
    return confirmMultiSubmit(targetObj, '删除');
}

function hasRecordSelected(targetObj)
{
	var b = false;
    for (i=0;i<targetObj.length;i++)
    {
        if (targetObj[i].checked) 
        {
            b=true;
            break;
        }
    }
    if (! b)
    {
        alert("请选择至少一条记录！");
    }
    return b;
}

/*
==================================================================
用于设置“全选”，可以不需要拖放一个同名的targetObj 的hidden控件，
cmdObj 是全选复选框， targetObj是复选框数组。
例子: setCheckState(checkAll, checkbox1)
==================================================================
 */
function setCheckStateNoneHidden(cmdObj, targetObj)
{
	if(targetObj == undefined)
	{
		return;
	}
	if(targetObj.length == undefined)
	{
		targetObj.checked = cmdObj.checked;
		return;
	}
    for(var i=0;i<targetObj.length;i++)
    {
        targetObj[i].checked = cmdObj.checked;
    }
}

/*
==================================================================
删除确认，可以不需要拖放一个同名的vCheckBox 的hidden控件
==================================================================
*/
function confirmMultiDelNoneHidden(vCheckBox)
{
	if(	vCheckBox == undefined)
	{
		alert('请选择至少一条记录！');
		return false;				
	}
	var bSelect=false;
	for (i=0;i<vCheckBox.length;i++)
	{
		if (vCheckBox[i].checked) 
		{
			bSelect=true;
			break;
		}
	}
	if (bSelect || (!bSelect && vCheckBox.value != undefined && vCheckBox.checked) )
		return confirmDelete();
	else
	{
		alert('请选择至少一条记录！');
		return false;
	}
}
    
/*
==================================================================
cmdObj为要操作控件，switchObj为要显示或隐藏的控件
用于切换某一个区域是否可见
==================================================================
 */
function switchVisibility(cmdObj, switchObj)
{
    if (switchObj.style.display=="")
    {
        switchObj.style.display="none";
        cmdObj.innerText = "显示查询条件 ▼";
    }
    else
    {
        switchObj.style.display="";
        cmdObj.innerText = "隐藏查询条件 ▲";
    }
}

/*
==================================================================
清空页面的查询条件，要求需要清空的控件需要以Qry结尾。
==================================================================
*/
function ClearCondition()
{
    
	var formObj = document.forms[0];
	var strSuffix = 'Qry';
	for( i = 0 ; i < formObj.elements.length; i++)
	{
		var elementObj = formObj.elements[i];				
		//如果是以qry结尾 
		//element.name.value.substring(element.name.length-3,element.name.length) 
		//或者没有包含qry
		if(elementObj.name != '' && elementObj.name != undefined) {
		    alert(elementObj.name);
		    if(elementObj.name.indexOf(strSuffix)!= -1)
			{
				if(elementObj.value != '')
				{
					elementObj.value ='';
				}
				if(elementObj.length > 0)
				{
					elementObj.selectedIndex = 0;
				}
			}
		}
	}
}

/*
==================================================================
折叠查询条件
==================================================================
*/

function adv(table,tbody)
{
	var caption = table.getElementsByTagName("caption")[0];
	if (tbody == null){
		var tbody = table.getElementsByTagName("tbody")[1];
	}
	if(caption.className=="adv" && tbody.className=="hide")
	{
		caption.className = "advover";
		tbody.className = "display";
	}
	else
	{
		caption.className = "adv";
		tbody.className = "hide";
	}
}

/*
==================================================================
演示
==================================================================
*/

function demo(te,xt)
{
	if ( window.confirm(te) )
	{
		if (xt != null){alert(xt)}
		close();
	}
}

/*
==================================================================
增加新行
==================================================================
*/

function addRow()
{
	var ts = document.getElementById("tbody1");
	var newRow = ts.insertRow(-1);
	var newCell,rs;
	for ( var i = 0; i < ts.rows[0].cells.length; i++ )
	{
		newCell = newRow.insertCell(i);
		rs = ts.rows.length - 2;
		newCell.innerHTML = ts.rows[rs].cells[i].innerHTML;
		newCell.align = ts.rows[rs].cells[i].align;
	}
}

function ShowMessage(message) {
    alert(message);
}


/*
==================================================================
获取随机数。
new add
==================================================================
*/
function getRandom() {
    var date = new Date();
    return Math.random() + "_" + date.getTime();
}
/*
==================================================================
关闭模态窗口。
new add
==================================================================
*/
function CloseModelWindow() {
    this.close();
}