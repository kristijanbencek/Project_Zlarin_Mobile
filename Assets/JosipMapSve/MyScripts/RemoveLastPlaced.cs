using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveLastPlaced : MonoBehaviour
{
    private int markerCount;


    private void Start()
    {
        Invoke("CountMarkers",0.5f);
    }

    public void CountMarkers()
    {
        markerCount = OnlineMapsMarkerManager.CountItems;
        Debug.Log(markerCount);
    }

    public void RemoveMarker()
    {
        OnlineMapsMarkerManager.RemoveItemAt(markerCount-1);
        markerCount = OnlineMapsMarkerManager.CountItems;
        Debug.Log(markerCount);
        MyMarkerSaver.SaveMarkers();
    }
}
