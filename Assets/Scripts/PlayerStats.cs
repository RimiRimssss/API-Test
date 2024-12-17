using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class PlayerStats : MonoBehaviour
{
    public string playerType;
    public int buff;

    public int pStr;
    public int pDef;
    public int pSpd;
    public int pHP;

    public int sword;
    public int shield;
    public int armour;
    public int boots;
    public int headGear;
    public int accessory;

    public bool isSwordEquiped;
    public bool isShieldEquiped;
    public bool isArmourEquiped;
    public bool isBootsEquiped;
    public bool isHeadGearEquiped;
    public bool isAccessoryEquiped;

    public GameObject txtSword;
    public GameObject txtShield;
    public GameObject txtArmour;
    public GameObject txtBoots;
    public GameObject txtHeadGear;
    public GameObject txtAccessory;

    public int pTempStr;
    public int pTempDef;
    public int pTempSpd;
    public int pTempHP;

    public Text txtStr;
    public Text txtDef;
    public Text txtSpd;
    public Text txtHP;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        GetValues();
        DisplayUI();
        CheckEquiped();
        GetComponent<NavMeshAgent>().speed = pTempSpd;
    }

    void GetValues()
    {
        pTempStr = pStr + sword + accessory + buff;
        pTempDef = pDef + shield + armour + headGear + buff;
        pTempSpd = pSpd + boots + accessory + buff;
        pTempHP = pHP + armour + accessory + buff;
    }

    void DisplayUI()
    {
        txtStr.text = "Str: " + pTempStr;
        txtDef.text = "Def: " + pTempDef;
        txtSpd.text = "Spd: " + pTempSpd;
        txtHP.text = "HP: " + pTempHP;
    }

    void CheckEquiped()
    {
        if (isSwordEquiped)
        {
            txtSword.gameObject.SetActive(true);
        }

        if (isShieldEquiped)
        {
            txtShield.gameObject.SetActive(true);
        }

        if (isBootsEquiped)
        {
            txtBoots.gameObject.SetActive(true);
        }

        if (isHeadGearEquiped)
        {
            txtHeadGear.gameObject.SetActive(true);
        }

        if (isArmourEquiped)
        {
            txtArmour.gameObject.SetActive(true);
        }

        if (isAccessoryEquiped)
        {
            txtAccessory.gameObject.SetActive(true);
        }

        if(!isSwordEquiped && !isShieldEquiped && !isBootsEquiped && !isHeadGearEquiped && !isArmourEquiped && !isAccessoryEquiped)
        {
            txtSword.gameObject.SetActive(false);
            txtShield.gameObject.SetActive(false);
            txtBoots.gameObject.SetActive(false);
            txtHeadGear.gameObject.SetActive(false);
            txtArmour.gameObject.SetActive(false);
            txtAccessory.gameObject.SetActive(false);

        }
    }
}
