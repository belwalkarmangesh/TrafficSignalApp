using System;
using System.Web;
using Microsoft.AspNet.SignalR;
namespace TrafficSignal.Helpers
{
    public class TrafficSignalHub : Hub
    {

        private readonly NotifyClient _notifyClient;

        public TrafficSignalHub() :
            this(NotifyClient.Instance)
        {

        }

        /// <summary>
        /// Initialize 
        /// </summary>
        /// <param name="notifyClient"></param>
        public TrafficSignalHub(NotifyClient notifyClient)
        {
            _notifyClient = notifyClient;
        }

        /// <summary>
        /// Called by client to start pushing messages
        /// </summary>
        public void StartSignals()
        {
           _notifyClient.PushMessages();
        }

        /// <summary>
        /// CAlled by client to stop pushinf message
        /// </summary>
        public void StopSignals()
        {
            _notifyClient.StopSignals();
        }

        /// <summary>
        /// send initial message to client on initial connect
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string Send(string message)
        {
           return _notifyClient.SendMessage(message);
        }
    }
}