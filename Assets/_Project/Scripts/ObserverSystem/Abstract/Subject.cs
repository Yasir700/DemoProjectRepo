using System.Collections.Generic;
using UnityEngine;

namespace U.DemoProject.ObserverSystem.Abstract
{
    public abstract class Subject
    {
        List<IObserver> _observers = new List<IObserver>();

        public void RegisterObserver(IObserver observer) => _observers.Add(observer);

        protected void Notify()
        {
            if (_observers != null && _observers.Count > 0) _observers.ForEach(x => x.OnNotify());
        }

    }
}
