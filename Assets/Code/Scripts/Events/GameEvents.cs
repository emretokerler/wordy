using System;
using System.Collections.Generic;

public class GameEvents
{
    private class Handlers<EventType> where EventType : GameEvent
    {
        private List<Action<EventType>> handlers = new List<Action<EventType>>();
        private static Handlers<EventType> _instance = null;
        private static Handlers<EventType> instance { get => _instance ??= new Handlers<EventType>(); }

        public static void Register(Action<EventType> handler)
        {
            if (instance.handlers.Contains(handler))
            {
                return;
            }
            instance.handlers.Add(handler);
        }

        public static void Unregister(Action<EventType> handler)
        {
            instance.handlers.Remove(handler);
        }

        public static void Handle(EventType eventData)
        {
            if (instance.handlers != null)
            {
                for (int i = instance.handlers.Count - 1; i >= 0; i--)
                {
                    instance.handlers[i](eventData);
                }
            }
        }
    }

    public static void On<EventType>(Action<EventType> handler) where EventType : GameEvent
    {
        Handlers<EventType>.Register(handler);
    }

    public static void Off<EventType>(Action<EventType> handler) where EventType : GameEvent
    {
        Handlers<EventType>.Unregister(handler);
    }

    public static void Trigger<EventType>(EventType eventData) where EventType : GameEvent
    {
        Handlers<EventType>.Handle(eventData);
    }
}