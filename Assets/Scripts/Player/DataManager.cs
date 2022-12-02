using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Text;

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
        data.SavePlayerData();

        return data;
    }
}
