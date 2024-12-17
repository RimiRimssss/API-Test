using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnequipAll : MonoBehaviour
{
    public PlayerStats playerStats;

    public GameObject sword;
    public GameObject shield;
    public GameObject armour;
    public GameObject boots;
    public GameObject headGear;
    public GameObject accessory;

    public void Unequip()
    {
        playerStats.isAccessoryEquiped = false;
        playerStats.isArmourEquiped = false;
        playerStats.isBootsEquiped = false;
        playerStats.isHeadGearEquiped = false;
        playerStats.isShieldEquiped = false;
        playerStats.isSwordEquiped = false;

        playerStats.accessory = 0;
        playerStats.armour = 0;
        playerStats.boots = 0;
        playerStats.headGear = 0;
        playerStats.shield = 0;
        playerStats.sword = 0;

        sword.gameObject.SetActive(true);
        shield.gameObject.SetActive(true);
        armour.gameObject.SetActive(true);
        boots.gameObject.SetActive(true);
        headGear.gameObject.SetActive(true);
        accessory.gameObject.SetActive(true);
    }
}
