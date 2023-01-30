using UnityEngine;
using System.Collections.Generic;



public class MyMarkerSaver : MonoBehaviour
{
    /// <summary>
    /// Key in PlayerPrefs
    /// </summary>
    private static string prefsKey = "markers";

    private CustomMarkerAndLabelOnClick customMarker;

    /// <summary>
    /// Saves markers to PlayerPrefs as xml string
    /// </summary>
    public static void SaveMarkers()
    {
        // Create XMLDocument and first child
        OnlineMapsXML xml = new OnlineMapsXML("Markers");
        // Save markers data
        foreach (OnlineMapsMarker marker in OnlineMapsMarkerManager.instance)
        {
            // Create marker node
            OnlineMapsXML markerNode = xml.Create("Marker");
            markerNode.Create("Position", marker.position);
            markerNode.Create("Label", marker.label);
            //markerNode.Create("Texture", marker.texture);

        }

        // Save xml string
        PlayerPrefs.SetString(prefsKey, xml.outerXml);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Use this for initialization
    /// </summary>
    private void Start()
    {

        customMarker = GetComponent<CustomMarkerAndLabelOnClick>();
        // Try load markers
        TryLoadMarkers();

    }

    /// <summary>
    /// Try load markers from PlayerPrefs
    /// </summary>
    private void TryLoadMarkers()
    {
        // If the key does not exist, returns.
        if (!PlayerPrefs.HasKey(prefsKey))
        {
            Debug.Log("No key");
            return;
        }

        // Load xml string from PlayerPrefs
        string xmlData = PlayerPrefs.GetString(prefsKey);

        

        // Load xml document
        OnlineMapsXML xml = OnlineMapsXML.Load(xmlData);

        // Load markers
        foreach (OnlineMapsXML node in xml)
        {
            // Gets coordinates and label
            Vector2 position = node.Get<Vector2>("Position");
            string label = node.Get<string>("Label");
            //Texture2D texture = node.Get<Texture2D>("Texture2D");

            // Create marker
            OnlineMapsMarkerManager.CreateItem(position, label);

            foreach (OnlineMapsMarker marker in OnlineMapsMarkerManager.instance)
            {
                marker.OnClick += customMarker.OnMarkerClick;
            }

        }
    }
}
