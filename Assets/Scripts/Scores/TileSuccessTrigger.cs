using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSuccessTrigger : MonoBehaviour
{
    public bool isFirstTile = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.name.Equals("Player") && !isFirstTile)
        {
            ScoresManager.Instance.OnTileSuccessTrigger?.Invoke();
        }
    }
}
