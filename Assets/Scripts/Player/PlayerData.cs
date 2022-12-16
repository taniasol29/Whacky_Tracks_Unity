using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[Serializable]
public class PlayerData
{
    [SerializeField] private string _name;
    [SerializeField] private List<int> _scores = new List<int>();
    [SerializeField] private long _lastConnection;
    [SerializeField] private long _creationTime;

    public PlayerData(string name)
    {
        _name = name;
        // initialiser lastConnection avec la date courante
        _creationTime = _lastConnection = TimeUtils.GetCurrentUnixSeconds();   
    }

    public string Name { get => _name; set => _name = value; }
    public List<int> Scores { get => _scores; set => _scores = value; }
    public long LastConnection { get => _lastConnection; set => _lastConnection = value; } 
    public long CreationTime {  get => _creationTime; set => _creationTime = value; }

    
    // This function saves player data in persistant data path
    // Player data format in file is:
    // NAME
    // SCORES()
    // LAST_CONNECTION
    // CREATION_TIME

    public void SavePlayerData()
    {
        // Preparation du chemin du sauvegarde des données
        //var path = $"{Application.persistentDataPath}/player-{_creationTime}.txt";
        var path = $"{Application.persistentDataPath}/player-{_creationTime}.json";

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
        //StringBuilder sb = new StringBuilder();
        //sb.AppendLine(_name);
        //foreach (var s in _scores)
        //{
        //    sb.Append(s + ' ');
        //}
        //sb.AppendLine();
        //sb.AppendLine(_lastConnection.ToString());
        //sb.AppendLine(_creationTime.ToString());
        //var playerDataStr = sb.ToString();

        // Serialisation JSON
        var playerDataStr = JsonUtility.ToJson(this, true);

        // Peut crypter les données ici 

        // Sauvegarder l'instance dans un fichier sur HDD
        File.WriteAllText(path, playerDataStr);
    }
}
