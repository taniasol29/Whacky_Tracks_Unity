using System;

public class TimeUtils 
{
    public static long GetCurrentUnixSeconds()
    {
        return DateTimeOffset.Now.ToUnixTimeSeconds();
    }
}
