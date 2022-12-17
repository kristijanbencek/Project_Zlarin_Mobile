using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralState : MonoBehaviour
{
    public GameData gameData;
    public GameManager gm;

    [SerializeField] GameObject coralModel;
    [SerializeField] Animator coralAnimator;


    private void Start()
    {
        InvokeRepeating("IsTheModelActive", 0, 1);
    }
    void UpdateMethod()
    {
       
    }
    void IsTheModelActive()
    {
        gameData = SaveSystem.Load();
        if (gameData.firstLoad == true)
        {
            coralModel.SetActive(false);
        }
        else
        {
            coralModel.SetActive(true);
        }

    }
}
