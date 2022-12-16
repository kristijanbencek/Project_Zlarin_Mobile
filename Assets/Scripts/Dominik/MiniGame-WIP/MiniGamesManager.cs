using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGamesManager : MonoBehaviour
{
    [SerializeField] Transform protectPlayer;
    [SerializeField] ProtectMeSpawner protectMe;
    public void LoadColorMiniGame()
    {

    }
    public void LoadGarbageClearGame()
    {

    }
    public void LoadCoralProtectGame()
    {
        protectMe.ingame = true;
    }
}
