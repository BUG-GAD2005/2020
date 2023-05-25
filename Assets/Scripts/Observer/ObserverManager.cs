using UnityEngine;
using System;
using System.Collections.Generic;

namespace Observer
{
    public static class ObserverManager
    {
        private static Dictionary<string, List<Action>> functionListeners = new Dictionary<string, List<Action>>();

        public static void Register(string eventName, Action handler)
        {
            if (!functionListeners.ContainsKey(eventName))
            {
                functionListeners[eventName] = new List<Action>();
            }

            functionListeners[eventName].Add(handler);
        }

        public static void Unregister(string eventName, Action handler)
        {
            if (functionListeners.ContainsKey(eventName))
            {
                functionListeners[eventName].Remove(handler);
            }
        }

        public static void Push(string eventName)
        {
            if (functionListeners.ContainsKey(eventName))
            {
                var handlers = functionListeners[eventName];
                foreach (var handler in handlers)
                {
                    handler?.Invoke();
                }
            }
            else
            {
                Debug.LogWarning($"Event '{eventName}' does not exist. Make sure to register it before notifying.");
            }
        }
    }
}