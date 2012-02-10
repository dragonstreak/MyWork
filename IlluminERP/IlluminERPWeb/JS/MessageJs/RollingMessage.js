function rollingMessage() {
    var runner = new Ext.util.TaskRunner();
    this.StartRolling = function () {
    runner.start(this.task);
    }
    this.EndRolling = function () {
    runner.end(this.task);
    }
    this.task = {
        run: function () {
            var params = { id: 1 };
            Ext.Ajax.request({
                //url: '../MessageHandler.ashx?operation=GetUnremindMessage&userid=' + LoginUserId,
                url: '../MessageHandler.ashx?operation=GetUnremindMessage',

                method: 'POST',
                params: params,
                //timeout: 30000000,
                //headers:{'Content-Type':'application/json;utf-8'},
                success: function (result, request) {

                    var message = Ext.util.JSON.decode(result.responseText);
                    var messageCount = message.total;                   
                    if (messageCount == "0")
                        return;
                    
                    //alert(message.content);

                    var tipw = new MyLib.NewMessageTip(
                        {
                            title: 'You have ' + messageCount + ' new message',
                            autoHide: 10,
                            //5秒自动关闭e
                            //html: message.content,
                            messageContent: message
                        });
                    tipw.show();
                },
                failure: function (result, request) {
                    alert('something wrong');

                }
            });
        },
        interval: 60000
    }
}

   
