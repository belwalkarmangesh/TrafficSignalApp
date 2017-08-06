using System.Collections.Generic;

namespace TrafficSignal.Helpers
{
    public class StatesData
    {
        States state1 = new States
        {
            Signal1 = new Signal {Left=SignalState.On, Main= SignalState.On,Right= SignalState.Off },
            Signal2 = new Signal {Left= SignalState.Off,Main= SignalState.Off,Right= SignalState.Off },
            Signal3 = new Signal {Left= SignalState.On, Main= SignalState.On, Right= SignalState.Off },
            Signal4 = new Signal {Left= SignalState.Off,Main= SignalState.Off,Right= SignalState.Off },
        };
        States state2 = new States
        {
            Signal1 = new Signal { Left = SignalState.Off, Main = SignalState.Off, Right = SignalState.Off },
            Signal2 = new Signal { Left = SignalState.On, Main = SignalState.On, Right = SignalState.Off },
            Signal3 = new Signal { Left = SignalState.Off, Main = SignalState.Off, Right = SignalState.Off },
            Signal4 = new Signal { Left = SignalState.On, Main = SignalState.On, Right = SignalState.Off },
        };
        States state3 = new States
        {
            Signal1 = new Signal { Left = SignalState.On, Main = SignalState.On, Right = SignalState.On },
            Signal2 = new Signal { Left = SignalState.Off, Main = SignalState.Off, Right = SignalState.Off },
            Signal3 = new Signal { Left = SignalState.Off, Main = SignalState.Off, Right = SignalState.Off },
            Signal4 = new Signal { Left = SignalState.On, Main = SignalState.Off, Right = SignalState.Off },
        };
        States state4 = new States
        {
            Signal1 = new Signal { Left = SignalState.On, Main = SignalState.Off, Right = SignalState.Off },
            Signal2 = new Signal { Left = SignalState.On, Main = SignalState.On, Right = SignalState.On },
            Signal3 = new Signal { Left = SignalState.Off, Main = SignalState.Off, Right = SignalState.Off },
            Signal4 = new Signal { Left = SignalState.Off, Main = SignalState.Off, Right = SignalState.Off },
        };
        States state5 = new States
        {
            Signal1 = new Signal { Left = SignalState.Off, Main = SignalState.Off, Right = SignalState.Off },
            Signal2 = new Signal { Left = SignalState.On, Main = SignalState.Off, Right = SignalState.Off },
            Signal3 = new Signal { Left = SignalState.On, Main = SignalState.On, Right = SignalState.On },
            Signal4 = new Signal { Left = SignalState.Off, Main = SignalState.Off, Right = SignalState.Off },
        };
        States state6 = new States
        {
            Signal1 = new Signal { Left = SignalState.Off, Main = SignalState.Off, Right = SignalState.Off },
            Signal2 = new Signal { Left = SignalState.Off, Main = SignalState.Off, Right = SignalState.Off },
            Signal3 = new Signal { Left = SignalState.On, Main = SignalState.Off, Right = SignalState.Off },
            Signal4 = new Signal { Left = SignalState.On, Main = SignalState.On, Right = SignalState.On },
        };

        public Queue<States> GenerateStates()
        {
            Queue<States> queue = new Queue<States>();
            queue.Enqueue(state1);
            queue.Enqueue(state2);
            queue.Enqueue(state3);
            queue.Enqueue(state4);
            queue.Enqueue(state5);
            queue.Enqueue(state6);

            return queue;
        }

    }
}