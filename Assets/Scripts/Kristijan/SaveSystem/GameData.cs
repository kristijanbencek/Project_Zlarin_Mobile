using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public int totalHealth;
    //public float testest;


    public float currentThirst;
    public float currentHunger;
    public float currentEnergy;

    public GameData()
    {
        totalHealth = 0;//kristijanovo
        currentHunger = 0;
        currentThirst = 0;
        currentEnergy = 0;
        //testest = 0;
    }
}