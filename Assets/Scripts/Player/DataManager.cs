using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager 
{
    private static DataManager _instance = null;
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
    
    private DataManager() { }

    // fonction pour créer un nouvel utilisateur
    public PlayerData NewPlayer(string n)
    {
        // création de nouvelle instance de Player Data
        PlayerData data = new PlayerData(n);
        // sauvegarder l'instance dans un fichier sur HDD

        return data;
    }
}
