SendMessageWindow = Ext.extend(Ext.Window,
{
    //id: 'showMessageWindow',
    layout: 'form',
    modal: true,
    width: 630,
    height: 500,
    resizeable: false,
    draggable: false,
    plain: true,
    expandOnShow: false,
    title: 'Send message',
    closeAction: 'close',
    selectedUserIds: [],
    selectedUserNames: [],
    messageType: 0,
    initMessage: undefined,
    replyToAll: false,
    losable: false,
    y: 1,
    draggable:true,
    //tbar: ['aaaa'],
   
  
    constructor: function(config) {
        Ext.apply(this, config);
//        messageGridSearchPlugin = new Ext.ux.grid.Search({
//            mode: 'local',     //remote为读取后台数据，local为读取本地数据  
//            position: 'top',   //top在tbar里显示，bottom在bbar里显示  
//            iconCls: 'icon-zoom',  //css样式  
//            searchText: '搜索',
//            showSelectAll: false,
//            //checkIndexes: ['wan_ip'],
//            readonlyIndexes: [''],
//            disableIndexes: [''],
//            minChars: 2,
//            autoFocus: true,
//            width: 200 ,
//            checkIndexes: 'first'
//        });
//        config.plugins = [messageGridSearchPlugin];
        SendMessageWindow.superclass.constructor.call(this, config);
    },
    initComponent: function () {
        this.selectedUserNames.length = 0;
        this.selectedUserIds.length = 0;
        this.buttons = [
                {
                    xtype: 'button',
                    text: 'Check Name',
                    listeners: {
                        click: this.CheckName,
                        scope: this
                    }
                },
                {
                    xtype: 'button',
                    text: 'Send',
                    listeners: {
                        click: this.sendMessageButtonClick,
                        scope: this
                    }
                },
                {
                    xtype: 'button',
                    text: 'Cancel',
                    listeners: {
                        click: function () {
                            //this.close();
                            this.destroy();
                        },
                        scope: this
                    }

                }
            ];
        this.initSendMessagePanel();
        SendMessageWindow.superclass.initComponent.call(this, arguments);
        if (this.messageType != 0) {
            this.InitReplyForwardContent();
            if (this.messageType = 2) {
                this.InitReplyUserList();
            }
        }
    },
    initSendMessagePanel: function () {
        //left panel begin
        var messagePart = {
            columnWidth: .7,
            layout: 'form',
            defaultType: 'textarea',
            labelWidth: 50,
            id: 'messageForm',
            autoDestroy: false,
            items: [
            {
                fieldLabel: 'TO',
                labelStyle: 'text-align:right;width:50;vertical-align:bottom;',
                name: 'txtReceiver',
                id: 'txtReceiver',
                ref: 'receiver',
                anchor: '96%'
            },
            {
                fieldLabel: 'Subject',
                labelStyle: 'text-align:right;width:50;vertical-align:bottom;',
                name: 'txtSubject',
                id: 'txtSubject',
                ref: 'subject',
                anchor: '96%'
            },
            {
                xtype: 'htmleditor',
                fieldLabel: 'Content',
                name: 'txtContent',
                id: 'txtContent',
                ref: 'content',
                hideLabel: true,
                anchor: '98%'
            }
            ]
        }
        //left panel end
        //right panel begin
        //gridpanel

        var sm = new Ext.grid.CheckboxSelectionModel();
        var cm = new Ext.grid.ColumnModel
        ([
            sm,
            { header: "E_Name", dataIndex: "E_Name", width: 50 },
            { header: "C_Name", dataIndex: "C_Name", width: 50 }

        ]);
        cm.defaultSortable = true;
        var fields =
        [
            { name: "ID" },
            { name: "E_Name" },
            { name: "C_Name" },
            { name: "Code" }
        ];

        var url = '../MessageHandler.ashx?operation=GetUserList';
        // var url = "../henrytest/GridService.aspx";
        var store = new Ext.data.Store
        ({
            //autoLoad:true,
            pruneModifiedRecords: true,
            proxy: new Ext.data.HttpProxy({ url: url }),
            reader: new Ext.data.JsonReader({ totalProperty: "totalPorperty", root: "root", fields: fields })
            ,
            listeners: {
                scope: this,
                load: function () {
                    if (this.messageType == 2) {
                        this.CheckName();
                        //sm.selectFirstRow();
                        //sm.selectRow(2, true);
                    }

                }
            }

        });

        store.load({ params: { start: 0, limit: 5 }

        });
        store.on('load', function () {

            //userListGrid.getSelectionModel().selectFirstRow();

        })
        var userListGrid = new Ext.grid.GridPanel({
            columnWidth:.3,
            id: 'userListGrid',

            frame: true,
            //title: 'User List',
            autoScroll: true,
            layout: 'fit',
            //store:userListStore,
            //loadMask: true,
            //autoHeight: true,
            autoWidth: true,
            deferRowRender: false,
            viewConfig: { forceFit: true },
            store: store,
            sm: sm,
            cm: cm,
            tbar:[],  
            plugins: [new Ext.ux.grid.Search({
                //iconCls: 'icon-zoom'
                //				,readonlyIndexes:['note']
				//, disableIndexes: ['samplePerYear']
                //, minChars: 1
                //, autoFocus: false
                //, menuStyle: 'radio'
                //,
                disableIndexes: ['C_Name'],
                checkIndexes: ['E_Name'],
                 mode: 'local'
                , position: 'top'
                //, checkIndexes: 'first'
            })],
            height: 430,
            listeners: {
                scope: this,
                cellclick: function (grid, rowIndex, columnIndex, eventObj) {
                    var selectedRec = grid.getStore().getAt(rowIndex);
                    var userId = selectedRec.data.ID;
                    var userName = selectedRec.data.E_Name;
                    var selectionModel = grid.getSelectionModel();
                    if (selectionModel.isSelected(rowIndex)) {
                        this.AddUser(userId, userName);
                    }
                    else {
                        this.DeleteUser(userId, userName);
                    }
                },
                afterRender: function () {
                    if (this.messageType == 2) {
                        //this.CheckName();
                    }
                }
            }
        });

        //fieldset
        var fieldset_Tests = new Ext.form.FieldSet({
            title: 'User List',
            //layout:'table',
            defaults: {
                bodyStyle: 'padding:1px;background-color: transparent;'
            },
            layout: 'form',
            id: 'fieldset_tests',
            autoHeight: true,
            width: 250,
            
            autoScroll: true,
            border: true,
            items: [
            userListGrid
            ]
        });
        //userlist part
        var userListPart = {
            columnWidth: .3,
            layout: 'column',
            items: [
        fieldset_Tests
        ]
        };
        //right panel 
        this.items = [{
            layout: 'column',
            items: [messagePart, userListGrid]
        }];

    },
    InitReplyForwardContent: function () {
        //if we reply or forward message, we shoule set the message for the content.
        var messageForm = Ext.getCmp('messageForm');
        if (messageForm == undefined)
            return;
        if (this.initMessage) {
            var content = "<br><br><br>--------------------------------<br>" + this.initMessage.message_content;
            messageForm.content.setValue(content);
        }
    },
    InitReplyUserList: function () {
        //use check name function to set the user.
        if (this.initMessage) {
            var receiverUser = "";
            if (this.replyToAll) {
                receiverUser = this.initMessage.message_sender + ";" + this.initMessage.message_receivers;
            }
            else {
                receiverUser = this.initMessage.message_sender;

            }
            var messageForm = Ext.getCmp('messageForm');
            if (messageForm == undefined)
                return;
            messageForm.receiver.setValue(receiverUser);
        }

    },
    sendMessageButtonClick: function () {
        var messageForm = Ext.getCmp('messageForm');
        if (messageForm == undefined)
            return;

        var messageContent = escape(messageForm.content.getValue());
        var messageSubject = messageForm.subject.getValue();
        var messageReceiverIds = this.selectedUserIds.join(';');
        var messageReceiverNames = messageForm.receiver.getValue();
        var type = this.messageType; //send message
        var params = { content: messageContent, receivers: messageReceiverNames,
            //, sender: LoginUserName,
            //tony remove login user id.
            //senderId: LoginUserId, 
            subject: messageSubject, type: type, receiverIds: messageReceiverIds
        };
        Ext.Ajax.request({
            url: '../MessageHandler.ashx?operation=SendMessage',
            method: 'POST',
            params: params,
            scope: this,
            //timeout: 30000000,
            //headers:{'Content-Type':'application/json;utf-8'},
            success: function (result, request) {
                this.close();

            },
            failure: function (result, request) {
                alert(result);

            }
        });
        //params = { content: messageForm.content, };
    },
    AddUser: function (userId, userName) {

        for (var i = 0; i < this.selectedUserIds.length; i++) {
            if (this.selectedUserIds[i] == userId) {
                return;
            }
        }
        this.selectedUserIds.push(userId);
        for (var i = 0; i < this.selectedUserNames.length; i++) {
            if (this.selectedUserNames[i] == userName) {
                return;
            }
        }
        this.selectedUserNames.push(userName);
        //refresh receiver textarea
        this.RefreshReceiverText();
    },
    DeleteUser: function (userId, userName) {
        for (var i = 0; i < this.selectedUserIds.length; i++) {
            if (this.selectedUserIds[i] == userId) {
                this.selectedUserIds.splice(i, 1);
                break;
            }
        }
        for (var i = 0; i < this.selectedUserNames.length; i++) {
            if (this.selectedUserNames[i] == userName) {
                this.selectedUserNames.splice(i, 1);
                break;
            }
        }
        this.RefreshReceiverText();
    },
    RefreshReceiverText: function () {
        var messageForm = Ext.getCmp('messageForm');
        if (messageForm == undefined)
            return;
        var userNames = '';
        for (var i = 0; i < this.selectedUserNames.length; i++) {
            userNames += this.selectedUserNames[i] + ";";
        }
        messageForm.receiver.setValue(userNames);
    },
    CheckName: function () {
        var messageForm = Ext.getCmp('messageForm');
        if (messageForm == undefined)
            return;
        var names = messageForm.receiver.getValue();
        var nameArr = names.split(';');
        var userNeedInsertArr = [];
        var grid = Ext.getCmp('userListGrid');
        var checkedUserId = 0;
        for (var i = 0; i < nameArr.length; i++) {
            var username = nameArr[i].toUpperCase();
            if (this.IsInUserArr(username)) {
                continue;
            }
            //check name from datasource
            var nameValid = false;

            var checkedUserName = '';
            var record = null;
            //support match e_name,c_name,code
            var rowIndex = -1;
            grid.store.each(function (rec) {
                rowIndex = rowIndex + 1;
                //check e name
                if (rec.data.E_Name.toUpperCase() == username) {
                    nameValid = true;
                    checkedUserName = rec.data.E_Name;
                    checkedUserId = rec.data.ID;
                    //record = rec;
                    return false;
                }
                //check c name
                //                if (rec.data.C_Name = username) {
                //                    nameValid = true;
                //                    checkedUserName = rec.data.E_Name;
                //                    checkedUserId = rec.data.ID;
                //                    record = rec;
                //                    return false;
                //                }
                //check code
                if (rec.data.Code.toUpperCase() == username) {
                    nameValid = true;
                    checkedUserName = rec.data.E_Name;
                    checkedUserId = rec.data.ID;
                    //record = rec;
                    return false;
                }

            });
            if (nameValid) {
                this.AddUser(checkedUserId, checkedUserName);
                //set selection
                var selection_User = grid.getSelectionModel();
                selection_User.selectRow(rowIndex, true);

                //tony xu;henry.fu;应该替换成tony xu;henry fu
                //var nameText = messageForm.content.getValue();
                //new RegExp("cat,{0,}","gi");或者/cat,{0,}/gi;,i大小写不敏感 
                //var nameReg = new RegExp(username+";{0,}","g"); 
                //nameText = nameText.replace(nameReg,"");
                //messageForm.content.setValue(nameText);

                //	var userNeedAdd = {
                //		initName:username,
                //		validName:checkedUserName,
                //		validId:checkedUserId					
                //	};
                //	userNeedInsertArr.push(userNeedAdd);
            }

        }

    },
    IsInUserArr: function (userName) {
        for (var i = 0; i < this.selectedUserNames.length; i++) {
            if (this.selectedUserNames[i].toUpperCase() == userName) {
                return true;
            }
        }
        return false;
    }
});