using System;

namespace TopSocket.JSON;

internal class JDay
{
    public int count = -1;
    public bool isDay = true;
    public float time = Single.NaN;


    public JDay()
    {
        var dnm = DayNightManager.instance;
        if (dnm != null)
        {
            count = dnm.dayCount;
            isDay = dnm.isDay > 0.5;
            time = dnm.timeOfDay;
        }
    }
}