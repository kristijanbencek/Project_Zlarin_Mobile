using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonManager : MonoBehaviour
{
    public UI_Manager UIManager;
    //Hrana
    //Voda
    //Šetnja
    //Igra
    //Spavanje

    public void WalkWithMe()
    {
        UIManager.happySad.value += 10;
    }
    public void PlayWithMe()
    {
        UIManager.happySad.value += 10;
    }
    public void FeedMe()
    {
        UIManager.healthinesSlider.value += 10;
    }
    public void WaterMe()
    {
        UIManager.healthinesSlider.value += 10;
    }
    public void Slumber()
    {
        UIManager.healthinesSlider.value += 10;
    }
}
