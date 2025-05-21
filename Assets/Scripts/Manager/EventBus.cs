using System;
using System.Collections.Generic;

public static class EventBus
{
    private static Dictionary<string, Action<object>> eventTable = new Dictionary<string, Action<object>>();

    public static void Subscribe(string eventName, Action<object> callback)
    {
        if (!eventTable.ContainsKey(eventName))
        {
            eventTable[eventName] = delegate { };
        }
        eventTable[eventName] += callback;
    }

    public static void Unsubscribe(string eventName, Action<object> callback)
    {
        if (eventTable.ContainsKey(eventName))
        {
            eventTable[eventName] -= callback;
        }
    }

    public static void Publish(string eventName, object param = null)
    {
        if (eventTable.ContainsKey(eventName))
        {
            eventTable[eventName]?.Invoke(param);
        }
    }
}
