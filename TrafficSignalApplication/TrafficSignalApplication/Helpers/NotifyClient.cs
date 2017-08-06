using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using Microsoft.AspNet.SignalR.Hubs;


namespace TrafficSignal.Helpers
{
    public class NotifyClient
    {
        #region Private

        private Queue<States> _states;
        private StatesData statesData;
        private States states;
        private readonly TimeSpan _updateInterval = TimeSpan.FromMilliseconds(15000);
        private Timer _timer;

        /// <summary>
        /// Create single instance of Notify Client
        /// </summary>
        private readonly static Lazy<NotifyClient> _instance = new Lazy<NotifyClient>(
            () => new NotifyClient(Microsoft.AspNet.SignalR.GlobalHost.ConnectionManager.GetHubContext<TrafficSignalHub>().Clients));

        private IHubConnectionContext<dynamic> Clients
        {
            get;
            set;
        }

        #endregion private

        #region Public

        public NotifyClient()
        {
            
        }

        public static NotifyClient Instance
        {
            get
            {
                return _instance.Value;
            }
        }


        /// <summary>
        /// Initiaize various variables
        /// </summary>
        /// <param name="clients"></param>
        public NotifyClient(IHubConnectionContext<dynamic> clients)
        {
            Clients = clients;
            statesData = new StatesData();
            _states = statesData.GenerateStates();
            
        }

        /// <summary>
        /// This method is called by Hub to push messages to client on given intervals
        /// </summary>
        public void PushMessages()
        {
           _timer = new Timer(PushStatesMessage, null, _updateInterval, _updateInterval);
        }

        /// <summary>
        /// Initial message on connecting to client
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string SendMessage(string message)
        {            
            return message;
        }

        /// <summary>
        /// This method on intervals sends/pushes methods to listening client.
        /// </summary>
        /// <param name="state"></param>
        public void PushStatesMessage(object state)
        {
            if (_states.Count == 0)
            {
                _states = statesData.GenerateStates();
            }
            states = _states.Dequeue();
            Clients.All.pushMessage(states);
        }

        /// <summary>
        /// This method is used to terminate timer & connection ,and stop sending messages.
        /// </summary>
        public void StopSignals()
        {
            Clients.All.signalsStopped("All signals are stopped");
            if (_timer != null)
            {
                _timer.Dispose();
               
            }

        }

        #endregion Public
    }
}
