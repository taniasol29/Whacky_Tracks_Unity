using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;

public class DataManager 
{
    private static DataManager _instance = null;
    private PlayerData _currentPlayer = null;

    public List<PlayerData> AllPlayers = new List<PlayerData>();
    
    public PlayerData CurrentPlayer
    { 
        get { return _currentPlayer; }
        set
        { 
            _currentPlayer = value; 
            _currentPlayer.LastConnection = DateTimeOffset.Now.ToUnixTimeSeconds();

            // Mettre à jour le fichier de sauvegarde (re-séliariser les données)
            // Resauvegarder le player courant 
            var path = $"{Application.persistentDataPath}/player-{_currentPlayer.CreationTime}.json";
            var currentPlayerStr = JsonUtility.ToJson(this, true);
            File.WriteAllText(path, currentPlayerStr);
        }
    }

    public static DataManager Instance 
    { 
        get 
        { 
            if(_instance == null )
                _instance = new DataManager();
            return _instance; 
        }

        private set 
        { 
            _instance = value; 
        }
    }   
    
    private DataManager() 
    {
        LoadExistingPlayers();
    }

    // Fonction pour créer un nouvel utilisateur
    public PlayerData NewPlayer(string n)
    {
        // Création de nouvelle instance de Player Data
        PlayerData newPlayer = new PlayerData(n);
        newPlayer.SavePlayerData();

        // Initialisation du personnage actuel
        //CurrentPlayer = newPlayer;
        _currentPlayer = newPlayer;

        return newPlayer;
    }

    private void LoadExistingPlayers()
    {
        // Initialisation du chemin du dossier de stockage des personnages
        var path = Application.persistentDataPath;
        foreach(var filePath in Directory.EnumerateFiles(path))
        {
            Debug.Log(filePath);
            // Lire le contenu du fichier courant
            var fileContent = File.ReadAllText(filePath);
            Debug.Log(fileContent);

            // Désérialiser le contenu dans une instance de PlayerData
            var playerData = JsonUtility.FromJson<PlayerData>(fileContent);
            // Ajout de l'instance à la liste des personnages
            AllPlayers.Add(playerData);
        }

        // Tri de la liste AllPlayers (lambda):
        AllPlayers.Sort((playerA, playerB) => playerB.LastConnection.CompareTo(playerA.LastConnection));
        //AllPlayers.Sort((playerA, playerB) => playerA.Name.CompareTo(playerB.Name));
        //var result = AllPlayers.Where(player => player.LastConnection < DateTimeOffset.Now.ToUnixTimeMilliseconds());
    }
}
