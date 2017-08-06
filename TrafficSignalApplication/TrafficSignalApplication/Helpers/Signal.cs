namespace TrafficSignal.Helpers
{
    public enum SignalState
    {
        Off = 0,
        On = 1

    }
    public class Signal
    {
        public SignalState Main { get; set; }
        public SignalState Right { get; set; }
        public SignalState Left { get; set; }
    }
}