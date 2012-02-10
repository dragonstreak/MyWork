
/*
==================================================================
 toDate(dateStr):���Ϸ�������(yyyy-MM-dd)����(yy-MM-dd)���ַ���
 ת������������
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
ltrim(string):ȥ����ߵĿո�
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
rtrim(string):ȥ���ұߵĿո�
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
trim(string):ȥ��ǰ��ո�
==================================================================
*/
function trim(str)
{
    return rtrim(ltrim(str));
}

/*
==================================================================
openWindow(winUrl, winName, winSize, alignCenter)
����һ�����ڣ���ѡ������Ļ��������Ͻ���ʾ
winUrl: ��ѡ
winName: ��ѡ��Ĭ��ΪURL�ĵ�ַ
winSize: ��ѡ��Ĭ��Ϊbig:800*600
alignCenter: ��ѡ��Ĭ��Ϊ������ʾ
==================================================================
 */
function openWindow(winUrl, winSize, winName, winAlign)
{
    var left = 0, top = 0;
    var iHeight = 0, iWidth = 0;

	if (winUrl == null)
	{
		alert("����δָ�� URL��");
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
���ڰ�ť��ǰҳ����ת
==================================================================
 */
function href(url)
{
	location.href = url;
}

/*
================================================================== 
�������á�ȫѡ��
cmdObj ��ȫѡ��ѡ�� targetObj�Ǹ�ѡ������
����: setCheckState(checkAll, checkbox1)
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
confirm������ɾ�����ύ��ע�����ָ���
==================================================================
 */
function confirmA(vText)
{
    return confirm("ȷ��Ҫ"+vText+"��")
}

/*
==================================================================
ɾ��ǰ��ȷ��
==================================================================
 */
function confirmDelete()
{
	return confirmA("ɾ��")
}

/*
==================================================================
����ǰ��ȷ����targetObjΪѡ���todoΪҪ��ʾ���ı�
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
ɾ��ǰ��ȷ����targetObjΪѡ���
==================================================================
 */
function confirmMultiDel(targetObj)
{  
    return confirmMultiSubmit(targetObj, 'ɾ��');
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
        alert("��ѡ������һ����¼��");
    }
    return b;
}

/*
==================================================================
�������á�ȫѡ�������Բ���Ҫ�Ϸ�һ��ͬ����targetObj ��hidden�ؼ���
cmdObj ��ȫѡ��ѡ�� targetObj�Ǹ�ѡ�����顣
����: setCheckState(checkAll, checkbox1)
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
ɾ��ȷ�ϣ����Բ���Ҫ�Ϸ�һ��ͬ����vCheckBox ��hidden�ؼ�
==================================================================
*/
function confirmMultiDelNoneHidden(vCheckBox)
{
	if(	vCheckBox == undefined)
	{
		alert('��ѡ������һ����¼��');
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
		alert('��ѡ������һ����¼��');
		return false;
	}
}
    
/*
==================================================================
cmdObjΪҪ�����ؼ���switchObjΪҪ��ʾ�����صĿؼ�
�����л�ĳһ�������Ƿ�ɼ�
==================================================================
 */
function switchVisibility(cmdObj, switchObj)
{
    if (switchObj.style.display=="")
    {
        switchObj.style.display="none";
        cmdObj.innerText = "��ʾ��ѯ���� ��";
    }
    else
    {
        switchObj.style.display="";
        cmdObj.innerText = "���ز�ѯ���� ��";
    }
}

/*
==================================================================
���ҳ��Ĳ�ѯ������Ҫ����Ҫ��յĿؼ���Ҫ��Qry��β��
==================================================================
*/
function ClearCondition()
{
    
	var formObj = document.forms[0];
	var strSuffix = 'Qry';
	for( i = 0 ; i < formObj.elements.length; i++)
	{
		var elementObj = formObj.elements[i];				
		//�������qry��β 
		//element.name.value.substring(element.name.length-3,element.name.length) 
		//����û�а���qry
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
�۵���ѯ����
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
��ʾ
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
��������
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
��ȡ�������
new add
==================================================================
*/
function getRandom() {
    var date = new Date();
    return Math.random() + "_" + date.getTime();
}
/*
==================================================================
�ر�ģ̬���ڡ�
new add
==================================================================
*/
function CloseModelWindow() {
    this.close();
}