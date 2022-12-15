using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Test : MonoBehaviour
{
    public GameData gameData;


    public int health = 1;
    public TMP_Text healthTXT;

    private void Awake()
    {
        gameData = SaveSystem.Load();
    }



    void Update()
    {
        //healthTXT.text = gameData.totalHealth.ToString();
    }

    public void AddHealth()
    {                
        gameData.totalHealth += health;
        SaveSystem.Save(gameData);
    }
}
