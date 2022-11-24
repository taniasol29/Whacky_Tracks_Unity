using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    private string name;
    private List<int> scores = new List<int>();
    private long lastConnection;

    public PlayerData(string name)
    {
        this.name = name;
        // initialiser lastConnection avec la date courante
        DateTime currentTime = DateTime.Now;
        this.lastConnection = ((DateTimeOffset)currentTime).ToUnixTimeSeconds();
        
    }

    public string Name { get => name; set => name = value; }
    public List<int> Scores { get => scores; set => scores = value; }
    public long LastConnection { get => lastConnection; set => lastConnection = value; }

   
}
