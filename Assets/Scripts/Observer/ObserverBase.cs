using UnityEngine;
using System;

namespace Observer
{
    public class ObserverBase : MonoBehaviour
    {
        protected void Register(string eventName, Action handler)
        {
            ObserverManager.Register(eventName, handler);
        }

        protected void Unregister(string eventName, Action handler)
        {
            ObserverManager.Unregister(eventName, handler);
        }

        protected void Push(string eventName)
        {
            ObserverManager.Push(eventName);
        }
    }
}