using System;
public class EventBus
{
    private static EventBus _instance;
    public static EventBus Instance
    {
        get
        {
            _instance ??= new EventBus();
            return _instance;
        }
    }
    public Action FinishedGraffiti;
    public Action<bool> PaintActivate;
    public Action CheckingPaintedGrafity;

}
