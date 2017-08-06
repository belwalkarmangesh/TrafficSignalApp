using System.Collections.Generic;

namespace CEXwebuy.Helpers
{
  public abstract class Subject
    {
        private List<IObserver> observers = new List<IObserver>();
        public void Attach(IObserver observer)
        {
            observers.Add(observer);
        }
        public void Detach(IObserver observer)
        {
            observers.Remove(observer);
        }
        public void Notify()
        {
            foreach (IObserver o in observers)
            {
                o.Update();
            }
        }
    }
}