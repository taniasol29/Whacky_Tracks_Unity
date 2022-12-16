using System;

public class TimeUtils 
{
    public static long GetCurrentUnixSeconds()
    {
        DateTime currentTime = DateTime.Now;
        return ((DateTimeOffset)currentTime).ToUnixTimeSeconds();
    }
}
