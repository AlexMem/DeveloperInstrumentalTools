function Init() {
    const hubConnection = new signalR.HubConnectionBuilder()
        .withUrl("/chat")
        .build();

    hubConnection.on("Send", function (data) {

        let log = $('.log');
        
        let line = $('<div>').addClass('row')
            .append($('<div>').append($('<label>').text(data.user)))
            .append($('<div>').addClass('col').append($('<label>').text(data.text)));
        
        log.append(line);

    });

    $("btnSend").on("click", function (e) {
        let message = $("#input").val();
        hubConnection.invoke("Send", message);
    });

    hubConnection.start();
}

Init();