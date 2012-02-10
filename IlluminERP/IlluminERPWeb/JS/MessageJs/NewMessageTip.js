Ext.ns('MyLib');
/** 
* 右下角的小贴士窗口
* @author tipx.javaeye.com
* @params conf 参考Ext.Window
*         conf中添加autoHide配置项, 默认3秒自动隐藏, 设置自动隐藏的时间(单位:秒), 不需要自动隐藏时设置为false
* @注: 使用独立的window管理组(manager:new Ext.WindowGroup()), 达到总是显示在最前的效果
*/
(function ($) {
    //新建window组，避免被其它window影响显示在最前的效果
    var tipsGroupMgr = new Ext.WindowGroup();
    tipsGroupMgr.zseed = 99999; //将小贴士窗口前置

    $.NewMessageTip = Ext.extend(Ext.Window,
    {
        width: 200,
        height: 150,
        layout: 'fit',
        modal: false,
        plain: true,
        shadow: false,
        //去除阴影
        draggable: false,
        //默认不可拖拽
        resizable: false,
        closable: true,
        closeAction: 'hide',
        //默认关闭为隐藏
        autoHide: 5,
        //n秒后自动隐藏，为false时,不自动隐藏
        manager: tipsGroupMgr,
        messageContent: undefined,
        //设置window所属的组
        constructor: function (conf) {
            $.NewMessageTip.superclass.constructor.call(this, conf);
            this.initPosition(true);
        },
        initEvents: function () {
            $.NewMessageTip.superclass.initEvents.call(this);
            //自动隐藏
            if (false !== this.autoHide) {
                var task = new Ext.util.DelayedTask(this.hide, this),
                second = (parseInt(this.autoHide) || 3) * 1000;
                this.on('beforeshow',
                function (self) {
                    task.delay(second);
                });
            }
            this.on('beforeshow', this.showTips);
            this.on('beforehide', this.hideTips);

            Ext.EventManager.onWindowResize(this.initPosition, this); //window大小改变时，重新设置坐标
            Ext.EventManager.on(window, 'scroll', this.initPosition, this); //window移动滚动条时，重新设置坐标
        },
        //参数: flag - true时强制更新位置
        initPosition: function (flag) {
            if (true !== flag && this.hidden) { //不可见时，不调整坐标
                return false;
            }
            var doc = document,
            bd = (doc.body || doc.documentElement);
            //ext取可视范围宽高(与上面方法取的值相同), 加上滚动坐标
            var left = bd.scrollLeft + Ext.lib.Dom.getViewWidth() - 4 - this.width;
            var top = bd.scrollTop + Ext.lib.Dom.getViewHeight() - 4 - this.height;
            this.setPosition(left, top);
        },
        showTips: function () {
            var self = this;
            if (!self.hidden) {
                return false;
            }

            self.initPosition(true); //初始化坐标
            self.el.slideIn('b',
            {
                callback: function () {
                    //显示完成后,手动触发show事件,并将hidden属性设置false,否则将不能触发hide事件
                    self.fireEvent('show', self);
                    self.hidden = false;
                }
            });
            return false; //不执行默认的show
        },
        hideTips: function () {
            var self = this;
            if (self.hidden) {
                return false;
            }

            self.el.slideOut('b',
            {
                callback: function () {
                    //渐隐动作执行完成时,手动触发hide事件,并将hidden属性设置true
                    self.fireEvent('hide', self);
                    self.hidden = true;
                }
            });
            return false; //不执行默认的hide
        }
        ,
        initComponent: function () {
            this.buttons = [
                {
                    xtype: 'button',
                    text: 'Open',
                    listeners: {
                        scope:this,
                        click: function () {

                            //alert(this.messageContent.content);
                            //alert(Ext.getCmp('messageTab').title);

                            var message = Ext.getCmp('messageTab').getActiveTab().currentMessage;
                            var showWindow = new ShowMessageWindow({
                            //id: 'showWindow',
                            MessageId: message.id,
                            NeedGetMessageById:true,
                            plain: true
                        });
                        this.SetMessageReaded(message.id);
                        showWindow.show();
                        }
                        
                    }
                }
            ];
            this.initMessageContent();
            $.NewMessageTip.superclass.initComponent.call(this, arguments);
        },
        SetMessageReaded:function(messageId){
         var params = { messageId: messageId };
            Ext.Ajax.request({
                url: '../MessageHandler.ashx?operation=SetReceiverMessageReaded',

                method: 'POST',
                params: params,
              
                success: function (result, request) {
                },
                failure: function (result, request) {
                    alert('something wrong');

                }
            });
        },
        initMessageContent:function(){
            var tabArr = [];
            for(var i =0;i<this.messageContent.root.length;i++)
            {
                var message = this.messageContent.root[i];
                var tabItem = {
                    title:message.message_sender,
                    html:message.message_content,
                    messageId:message.id,
                    currentMessage:message
                }
                tabArr.push(tabItem);
            }
            var tabPanel =   new Ext.TabPanel({
                    activeTab:0,//当前标签为第1个tab（从0开始索引）
                    border:false,
                    items:tabArr,                  
                    autoScroll:true,
                    enableTabScroll:true,
                    height:20,
                    ref:'messageTab',
                    id:'messageTab'
                });
                this.items=[];
           this.items.push(tabPanel);
        },
        ShowMessage:function()
        {
            //alert('');
        }

    });
})(MyLib);

