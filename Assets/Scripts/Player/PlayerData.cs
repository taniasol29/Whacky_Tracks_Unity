using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.IO;

public class PlayerData
{
    private string _name;
    private List<int> _scores = new List<int>();
    private long _lastConnection;
    private long _creationTime;

    public PlayerData(string name)
    {
        _name = name;
        // initialiser lastConnection avec la date courante
        _creationTime = _lastConnection = TimeUtils.GetCurrentUnixSeconds();   
    }

    public string Name { get => _name; set => _name = value; }
    public List<int> Scores { get => _scores; set => _scores = value; }
    public long LastConnection { get => _lastConnection; set => _lastConnection = value; } 

    
    // This function saves player data in persistant data path
    // Player data format in file is:
    // NAME
    // SCORES()
    // LAST_CONNECTION
    // CREATION_TIME

    public void SavePlayerData()
    {
        // Preparation du chemin du sauvegarde des données
        var path = $"{Application.persistentDataPath}/player-{_creationTime}.txt";

        // Préaparation des données à sauvegarder
        // V1:
        //string playerDataStr = $"{_name}\n";
        //foreach( var s in data.Scores) 
        //{ 
        //    playerDataStr += s + " ";
        //}
        //playerDataStr += "\n";
        //playerDataStr += data.LastConnection;

        // V2:
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(_name);
        foreach (var s in _scores)
        {
            sb.Append(s + ' ');
        }
        sb.AppendLine();
        sb.AppendLine(_lastConnection.ToString());
        sb.AppendLine(_creationTime.ToString());
        var playerDataStr = sb.ToString();

        // sauvegarder l'instance dans un fichier sur HDD
        File.WriteAllText(path, playerDataStr);
    }
}
