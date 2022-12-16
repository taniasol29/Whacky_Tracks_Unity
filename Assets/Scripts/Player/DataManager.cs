using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager 
{
    private static DataManager _instance = null;

    public PlayerData CurrentPlayer = null;

    public List<PlayerData> AllPlayers = new List<PlayerData>();
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

    // Fonction pour cr�er un nouvel utilisateur
    public PlayerData NewPlayer(string n)
    {
        // Cr�ation de nouvelle instance de Player Data
        PlayerData newPlayer = new PlayerData(n);
        newPlayer.SavePlayerData();

        // Initialisation du personnage actuel
        CurrentPlayer = newPlayer;

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

            // D�s�rialiser le contenu dans une instance de PlayerData
            var playerData = JsonUtility.FromJson<PlayerData>(fileContent);
            // Ajout de l'instance � la liste des personnages
            AllPlayers.Add(playerData);
        }
    }
}
