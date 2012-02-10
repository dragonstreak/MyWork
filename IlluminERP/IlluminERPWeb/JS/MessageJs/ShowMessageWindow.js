ShowMessageWindow = Ext.extend(Ext.Window,
{
    layout: 'form',
    modal: false,
    width: 650,
    height: 500,
    resizeable: false,
    draggable: false,
    plain: true,
    expandOnShow: false,
    title: 'Show message',
    Message: undefined,
    MessageId: undefined,
    NeedGetMessageById: false,
    frame: true, //圆角
    closeAction: 'close',
    y:1,
    style: "background-image:url(../../ExtJs/resources/images/gray/window/left-right.png)",
    losable: false,
   
    initComponent: function () {
        //define the button begin
        this.buttons = [
                {
                    xtype: 'button',
                    text: 'Reply',
                    listeners: {
                        click: this.ReplyMessageHandle,
                        scope: this
                    }
                },
                {
                    xtype: 'button',
                    text: 'Reply to All',
                    listeners: {
                        click: this.ReplyToAllMessageHandle,
                        scope: this
                    }
                },
                {
                    xtype: 'button',
                    text: 'Forward',
                    listeners: {
                        click: this.ForwardMessageHandle,
                        scope: this
                    }
                },
                {
                    xtype: 'button',
                    text: 'Cancel',
                    listeners: {
                        click: function () {
                            //this.hide();
                            this.destroy();
                        },
                        scope: this
                    }

                }
            ];
        //define the button end
        //define the panel begin
        this.InitMessagePanel();
        //define the panel end
        ShowMessageWindow.superclass.initComponent.call(this, arguments);
    },
    ReplyToAllMessageHandle: function () {
        var showWindow = new SendMessageWindow({
            messageType: 2,
            initMessage: this.Message,
            title: 'Reply message',
            replyToAll: true
        });
        showWindow.show();
        this.hide();
    },
    ReplyMessageHandle: function () {
        var showWindow = new SendMessageWindow({
            messageType: 2,
            initMessage: this.Message,
            title: 'Reply message'
        });
        showWindow.show();
        this.hide();
    },
    ForwardMessageHandle: function () {
        var showWindow = new SendMessageWindow({
            messageType: 1,
            initMessage: this.Message,
            title: 'Forward message'
        });
        showWindow.show();
        this.hide();
    },
    InitMessagePanel: function () {


        this.items = [
                    { baseCls: "x-plain" //,
                        //bodyStyle:"padding-top: 15px; padding-left:10px;"
                    },
                    {

                        xtype: 'container',
                        border: false,
                        layout: 'form',
                        style: "padding:10px",
                        //anchor: '100%',
                        height: 40,
                        id: 'messageForm',
                        items: [

                                                        {
                                                            xtype: 'textfield',
                                                            fieldLabel: 'Message time',
                                                            name: 'messageTimeControl',
                                                            readOnly: true,
                                                            ref: 'MessageTimeControl',
                                                            anchor: '98%'
                                                        },
                                                        {
                                                            xtype: 'textfield',
                                                            fieldLabel: 'From',
                                                            name: 'messageSenderControl',
                                                            readOnly: true,
                                                            ref: 'MessageSenderControl',
                                                            anchor: '98%'
                                                        },
                                                        {
                                                            xtype: 'textfield',
                                                            fieldLabel: 'To',
                                                            name: 'messageReceiverControl',
                                                            readOnly: true,
                                                            ref: 'MessageReceiverControl',
                                                            anchor: '98%'
                                                        },
                                                        {
                                                            xtype: 'textfield',
                                                            fieldLabel: 'Subject',
                                                            name: 'messageSubjectControl',
                                                            readOnly: true,
                                                            ref: 'MessageSubjectControl',
                                                            anchor: '98%'
                                                        },
                                                        {
                                                            xtype: 'htmleditor',
                                                            fieldLabel: 'Message',
                                                            name: 'messageContentControl',
                                                            readOnly: true,
                                                            ref: 'MessageContentControl',
                                                            anchor: '98%'
                                                        }
                        ]
                    }
        ];
        if (this.NeedGetMessageById) {
            this.GetMessageById();
        }
        else {
            if (this.Message != 'undefined') {
                this.SetMessageForm();
            }
        }
    },
    GetMessageById: function () {
        if (this.MessageId == 'undefined')
            return;
        Ext.Ajax.request({
            url: '../MessageHandler.ashx?operation=GetMessageById&id=' + this.MessageId,
            method: 'POST',
            //params: params,
            scope: this,
            success: function (result, request) {
                var message = Ext.util.JSON.decode(result.responseText).root;
                this.Message = message;
                //SetMessageForm
                this.SetMessageForm();
            },
            failure: function (result, request) {
                alert(result);
            }
        });
    },
    SetMessageForm: function () {
        var messageForm = Ext.getCmp('messageForm');
        messageForm.MessageTimeControl.setValue(this.Message.MessageShowTime);
        messageForm.MessageSenderControl.setValue(this.Message.message_sender);
        messageForm.MessageSubjectControl.setValue(this.Message.message_subject);
        messageForm.MessageContentControl.setValue(this.Message.message_content);
        messageForm.MessageReceiverControl.setValue(this.Message.message_receivers);

    }

});