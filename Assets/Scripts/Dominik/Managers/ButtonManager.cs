using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonManager : MonoBehaviour
{
    [Header("Other scripts references")]
    public GameManager gm;
    public void WalkWithMe()
    {
        //UIManager.happySad.value += 10;
        gm.WalkingMechanic();
    }
    public void PlayWithMe()
    {
        gm.PlayMechanic();
        //UIManager.happySad.value += 10;
    }
    public void FeedMe()
    {
        gm.HungerMechanic();
        //UIManager.healthinesSlider.value += 10;
    }
    public void WaterMe()
    {
        gm.ThirstMechanic();
        //UIManager.healthinesSlider.value += 10;
    }
    public void Slumber()
    {
        gm.EnergyMechanic();
        //UIManager.healthinesSlider.value += 10;
    }
}
