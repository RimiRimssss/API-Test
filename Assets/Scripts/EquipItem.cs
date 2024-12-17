using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipItem : MonoBehaviour
{
    public PlayerStats playerStats;

    public bool isSword;
    public bool isShield;
    public bool isArmour;
    public bool isBoots;
    public bool isHeadGear;
    public bool isAccessory;

    public bool isInRange;

    public AudioSource sfxPickUp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isInRange = false;
    }


    void OnMouseDown()
    {
        if (isInRange)
        {
            sfxPickUp.Play();
            if (isSword)
            {
                playerStats.isSwordEquiped = true;
                playerStats.sword = 10;
                this.gameObject.SetActive(false);
            }
            if (isShield)
            {
                playerStats.isShieldEquiped = true;
                playerStats.shield = 5;
                this.gameObject.SetActive(false);
            }
            if (isArmour)
            {
                playerStats.isArmourEquiped = true;
                playerStats.armour = 2;
                this.gameObject.SetActive(false);
            }
            if (isBoots)
            {
                playerStats.isBootsEquiped = true;
                playerStats.boots = 3;
                this.gameObject.SetActive(false);
            }
            if (isHeadGear)
            {
                playerStats.isHeadGearEquiped = true;
                playerStats.headGear = 4;
                this.gameObject.SetActive(false);
            }
            if (isAccessory)
            {
                playerStats.isAccessoryEquiped = true;
                playerStats.accessory = 2;
                this.gameObject.SetActive(false);
            }
        }
    }
}
