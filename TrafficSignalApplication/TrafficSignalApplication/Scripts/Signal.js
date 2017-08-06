$(function () {

    var ConnectionStarted;
    var hub = $.connection.trafficSignalHub;
    function init() {
        return hub.server.send('Welcome to Traffic signal App').done(function (msg) {
            console.log('Initialize Hub ' + msg);
            animateMe($('#object1'), 3000);
        });
    }

    // Start the connection
    $.connection.hub.start()
        .then(init)
        .done(function (state) {
            console.log(state);
            ConnectionStarted = true;
        });

    hub.client.pushMessage = function (message) {
        var myArray = [];
        $.each(message, function (signal, states) {
            console.log('Current signal : ' + signal + 'and States ' + ' Left : ' + states['Left'] + 'Main : ' + states['Main'] + ' Right : ' + states['Right']);
            myArray.push({ signal: signal, sigMain: states['Main'], sigRight: states['Right'], sigLeft: states['Left'] });
        });
        assignSignalStates(myArray);
    };
    
    hub.client.signalsStopped = function (message) {
        orange();
        console.log('Signal are stopped');
        stopConnection();
    };

    function stopConnection() {
        $.connection.hub.stop();
        ConnectionStarted = false;
    }
        
    $('#startSignal').click(function () {
        intialState();        
        // Call the Send method on the hub.
        hub.server.startSignals();        
    });

    $('#stopSignal').click(function () {
        // Call the Send method on the hub.
        hub.server.stopSignals();        
    });

    function orange() {
        clearRedAndGreenLights();
        $('#Signal1Orangelight').css('opacity', 1)
        $('#Signal2Orangelight').css('opacity', 1)
        $('#Signal3Orangelight').css('opacity', 1)
        $('#Signal4Orangelight').css('opacity', 1)
    }

    function clearOrangelight() {
        $('#Signal1Orangelight').css('opacity', 0.4)
        $('#Signal2Orangelight').css('opacity', 0.4)
        $('#Signal3Orangelight').css('opacity', 0.4)
        $('#Signal4Orangelight').css('opacity', 0.4)
    }

    function intialState() {
        $('#Signal1Redlight').css('opacity', 0.4)
        $('#Signal1Greenlight').css('opacity', 1);
        $('#Signal4Redlight').css('opacity', 0.4)
        $('#Signal4Greenlight').css('opacity', 0.4);
        $('#Signal2Redlight').css('opacity', 0.4)
        $('#Signal2Greenlight').css('opacity', 0.4);
        $('#Signal3Redlight').css('opacity', 0.4);
        $('#Signal3Greenlight').css('opacity', 0.4);
    }

    function assignSignalStates(arr, initialState) {
        clearOrangelight();
            //state 1
            if ((arr[0].signal == 'Signal1' && arr[0].sigMain == 1 && arr[0].sigLeft == 1 && arr[0].sigRight == 0) && (arr[2].signal == 'Signal3' && arr[2].sigMain == 1 && arr[2].sigLeft == 1 && arr[2].sigRight == 0)) {
                $('#Signal1Redlight').css('opacity', 0.4);
                $('#Signal1Greenlight').css('opacity', 1);
                $('#Signal4Redlight').css('opacity', 0.4)
                $('#Signal4Greenlight').css('opacity', 1);
                $('#Signal2Redlight').css('opacity', 1);
                $('#Signal2Greenlight').css('opacity', 0.4);
                $('#Signal3Redlight').css('opacity', 1);
                $('#Signal3Greenlight').css('opacity', 0.4);
            }
            //state 2
            if ((arr[1].signal == 'Signal2' && arr[1].sigMain == 1 && arr[1].sigLeft == 1 && arr[1].sigRight == 0) && (arr[3].signal == 'Signal4' && arr[3].sigMain == 1 && arr[3].sigLeft == 1 && arr[3].sigRight == 0)) {
                $('#Signal3Redlight').css('opacity', 0.4)
                $('#Signal3Greenlight').css('opacity', 1);
                $('#Signal2Redlight').css('opacity', 0.4);
                $('#Signal2Greenlight').css('opacity', 1);
                $('#Signal1Redlight').css('opacity', 1)
                $('#Signal1Greenlight').css('opacity', 0.4);
                $('#Signal4Redlight').css('opacity', 1)
                $('#Signal4Greenlight').css('opacity', 0.4);
            }
            //state 3
            if ((arr[0].signal == 'Signal1' && arr[0].sigMain == 1 && arr[0].sigLeft == 1 && arr[0].sigRight == 1) && (arr[3].signal == 'Signal4' && arr[3].sigLeft == 1 && arr[3].sigMain == 0 && arr[3].sigRight == 0)) {

                $('#Signal1Redlight').css('opacity', 0.4)
                $('#Signal1Greenlight').css('opacity', 1);
                $('#Signal2Redlight').css('opacity', 0.4);
                $('#Signal2Greenlight').css('opacity', 1);
                $('#Signal3Redlight').css('opacity', 1)
                $('#Signal3Greenlight').css('opacity', 0.4);
                $('#Signal4Redlight').css('opacity', 1)
                $('#Signal4Greenlight').css('opacity', 0.4);
            }
            //state 4
            if ((arr[0].signal == 'Signal1' && arr[0].sigLeft == 1 && arr[0].sigMain == 0 && arr[0].sigRight == 0) && (arr[1].signal == 'Signal2' && arr[1].sigLeft == 1 && arr[1].sigMain == 1 && arr[1].sigRight == 1)) {

                $('#Signal1Redlight').css('opacity', 0.4)
                $('#Signal1Greenlight').css('opacity', 1);
                $('#Signal3Redlight').css('opacity', 0.4);
                $('#Signal3Greenlight').css('opacity', 1);
                $('#Signal2Redlight').css('opacity', 1)
                $('#Signal2Greenlight').css('opacity', 0.4);
                $('#Signal4Redlight').css('opacity', 1)
                $('#Signal4Greenlight').css('opacity', 0.4);
            }
            //state 5
            if ((arr[1].signal == 'Signal2' && arr[1].sigLeft == 1 && arr[1].sigMain == 0 && arr[1].sigRight == 0) && (arr[2].signal == 'Signal3' && arr[2].sigLeft == 1 && arr[2].sigMain == 1 && arr[2].sigRight == 1)) {

                $('#Signal3Redlight').css('opacity', 0.4)
                $('#Signal3Greenlight').css('opacity', 1);
                $('#Signal4Redlight').css('opacity', 0.4);
                $('#Signal4Greenlight').css('opacity', 1);
                $('#Signal1Redlight').css('opacity', 1)
                $('#Signal1Greenlight').css('opacity', 0.4);
                $('#Signal2Redlight').css('opacity', 1)
                $('#Signal2Greenlight').css('opacity', 0.4);
            }
            //state 6
            if ((arr[2].signal == 'Signal3' && arr[2].sigLeft == 1 && arr[2].sigMain == 0 && arr[2].sigRight == 0) && (arr[3].signal == 'Signal4' && arr[3].sigLeft == 1 && arr[3].sigMain == 1 && arr[3].sigRight == 1)) {

                $('#Signal2Redlight').css('opacity', 0.4)
                $('#Signal2Greenlight').css('opacity', 1);
                $('#Signal4Redlight').css('opacity', 0.4);
                $('#Signal4Greenlight').css('opacity', 1);
                $('#Signal3Redlight').css('opacity', 1)
                $('#Signal3Greenlight').css('opacity', 0.4);
                $('#Signal1Redlight').css('opacity', 1)
                $('#Signal1Greenlight').css('opacity', 0.4);
            }        
    }

    function clearRedAndGreenLights() {     
        $('#Signal1Redlight').css('opacity', 0.4);
        $('#Signal1Greenlight').css('opacity', 0.4);
        $('#Signal2Redlight').css('opacity', 0.4);
        $('#Signal2Greenlight').css('opacity', 0.4);
        $('#Signal3Redlight').css('opacity', 0.4);
        $('#Signal3Greenlight').css('opacity', 0.4);
        $('#Signal4Redlight').css('opacity', 0.4);
        $('#Signal4Greenlight').css('opacity', 0.4);
    }
    
});