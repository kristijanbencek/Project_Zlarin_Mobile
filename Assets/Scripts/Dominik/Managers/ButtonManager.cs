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
        gm.WalkingMechanic();
        
    }
    public void PlayWithMe()
    {
        gm.PlayMechanic();
        
    }
    public void FeedMe()
    {
        gm.HungerMechanic();
       
    }
    public void WaterMe()
    {
        gm.ThirstMechanic();
        
    }
    //public void Slumber()
    //{
    //    gm.EnergyMechanic();
        
    //}
    
}
