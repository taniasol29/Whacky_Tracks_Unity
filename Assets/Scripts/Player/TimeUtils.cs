using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeUtils 
{
    public static long GetCurrentUnixSeconds()
    {
        DateTime currentTime = DateTime.Now;
        return ((DateTimeOffset)currentTime).ToUnixTimeSeconds();
    }
}
