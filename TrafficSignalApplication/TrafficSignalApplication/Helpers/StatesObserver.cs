namespace SignalRChat.Helpers
{
    public class StatesObserver : IObserver
    {
        private SignalSubject _signalSubject;
        private States _states;
        //private NotifyClient _notifyClient;
        private readonly NotifyClient _notifyClient;

        public StatesObserver() :
            this(NotifyClient.Instance)
        {

        }

        public StatesObserver(NotifyClient notifyClient)
        {
            _notifyClient = notifyClient;
        }

        public StatesObserver(SignalSubject signalSubject)
        {
            _signalSubject = signalSubject;
            _signalSubject.Subscribe(this);
            _notifyClient = new NotifyClient();
        }

        public void Update()
        {
            _states = _signalSubject.States;
            _notifyClient.PushStatesMessage(_states);

        }

    }
}