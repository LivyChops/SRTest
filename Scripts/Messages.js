$(function () {
    // Declare a proxy to reference the hub.
    var notifications = $.connection.messagesHub;

    //debugger;
    // Create a function that the hub can call to broadcast messages.
    notifications.client.updateMessages = function () {
        getAllMessages();
    };
    // Start the connection. [attempting LongPolling]
    $.connection.hub.start({ transport: 'longPolling' }).done(function () {
        alert("connection started");
        getAllMessages();
    }).fail(function (e) {
        alert(e);
    });
});


function getAllMessages() {
    var tbl = $('#messagesTable');
    $.ajax({
        url: 'http://localhost:30321/OrchardLocal/SRTest.SignalR/Sig/GetMessages', //'@Url.Action("GetMessages", "Home", new { area = "SRTest.SignalR" })', //
        contentType: 'application/html ; charset:utf-8',
        type: 'GET',
        dataType: 'html'
    }).success(function (result) {
        tbl.empty().append(result);
    }).error(function (e) {
        alert("Error:" + e.Name + " msg: " + e.message);
    });
}