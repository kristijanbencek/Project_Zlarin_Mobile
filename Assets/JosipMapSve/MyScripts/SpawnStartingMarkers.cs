using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStartingMarkers : MonoBehaviour
{
    public Texture2D[] markerTextures;
    private void Start()
    {
        OnlineMaps map = OnlineMaps.instance;

        // Add OnClick events to static markers
        foreach (OnlineMapsMarker marker in OnlineMapsMarkerManager.instance)
        {
            marker.OnClick += OnMarkerClick;
        }

        // Add OnClick events to dynamic markers
        OnlineMapsMarker zlarinMarker = OnlineMapsMarkerManager.CreateItem(new Vector2(15.8477155474931f, 43.691415997471f), null, "Otok Zlarin");
        OnlineMapsMarker dolphinMarker = OnlineMapsMarkerManager.CreateItem(new Vector2(15.8245983318876f, 43.6658247771875f), markerTextures[0], "Jato dupina");
        OnlineMapsMarker starfishMarker = OnlineMapsMarkerManager.CreateItem(new Vector2(15.8734400274217f, 43.6513589248992f), markerTextures[1], "Zvjezdača");
        OnlineMapsMarker fishMarker = OnlineMapsMarkerManager.CreateItem(new Vector2(15.8016792854279f, 43.7033386493289f), markerTextures[2], "Jato riba");
        OnlineMapsMarker coralMarker = OnlineMapsMarkerManager.CreateItem(new Vector2(15.8262519032679f, 43.7056486086201f), markerTextures[3], "Koraljni greben");
        zlarinMarker.OnClick += OnMarkerClick;
        dolphinMarker.OnClick += OnMarkerClick;
        starfishMarker.OnClick += OnMarkerClick;
        fishMarker.OnClick += OnMarkerClick;
        coralMarker.OnClick += OnMarkerClick;

        
    }

    private void OnMarkerClick(OnlineMapsMarkerBase marker)
    {
        // Show in console marker label.
        Debug.Log(marker.label);
    }
}
