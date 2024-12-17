using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheck : MonoBehaviour
{
    public PlayerStats playerStats;

    public GameObject ambientBGM;
    public GameObject conflictBGM;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(playerStats.playerType == "FIRE")
            {
                playerStats.buff = 10;
            }
            else if(playerStats.playerType == "WATER")
            {
                playerStats.buff = -5;
            }
            else
            {
                playerStats.buff = 0;
            }

            ambientBGM.gameObject.SetActive(false);
            conflictBGM.gameObject.SetActive(true);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        playerStats.buff = 0;
        ambientBGM.gameObject.SetActive(true);
        conflictBGM.gameObject.SetActive(false);
    }
}
