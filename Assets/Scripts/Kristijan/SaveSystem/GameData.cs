using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    /*
     * todo
     * -make so that the language and age panel loads on first start only -Complete
     * -save age system  
     * -import animations
     * -import final map package -Complete
     * -dodat setting za mjenjanje godina i jezika -Complete
     * -notifications
     * -map ui 
     * -questions and answers
     */

    public int totalHealth;
    //public float testest;

    public float currentThirst;
    public float currentHunger;
    public float currentEnergy;

    public bool firstLoad;

    public GameData()
    {
        totalHealth = 0;//kristijanovo
        currentHunger = 0;
        currentThirst = 0;
        currentEnergy = 0;

        firstLoad = true;
        //testest = 0;
    }
}
