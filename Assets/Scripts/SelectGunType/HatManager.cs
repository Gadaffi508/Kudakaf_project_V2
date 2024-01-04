using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatManager : MonoBehaviour
{
    public List<PlayerData> playersData = new List<PlayerData>();
    public int currentPlayerData;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out PlayerController player))
        {
            if (player.charecterType == CharecterType.None)
            {
                player.playerData = playersData[currentPlayerData];
                player.charecterType = CharecterType.Wizard;
                player.GetPlayerData();
                Destroy(gameObject);
            }
        }
    }
}
