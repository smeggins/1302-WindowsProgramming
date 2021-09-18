public class Engine
{
    private bool running;
    public oilStatus getOilStatus()
    {
        return oilStatus.Optimum;
    }

    public enum oilStatus
    {
        Optimum,
        Sufficient,
        Insufficient
    }
}

