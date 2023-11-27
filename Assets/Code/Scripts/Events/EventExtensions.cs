public static class EventExtensions
{
    public static void Trigger<T>(this T customEvent) where T : GameEvent
    {
        GameEvents.Trigger(customEvent);
    }
}