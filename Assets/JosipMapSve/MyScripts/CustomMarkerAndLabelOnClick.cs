using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.Timeline;
using System.Linq;

public class CustomMarkerAndLabelOnClick : MonoBehaviour
{

    private string label;

    //private Texture2D currentIcon;

    public GameObject markerNameInputField;
    //public ChangeIconClick textureReference;

    private TMP_InputField markerNameInputText;

    double lng, lat;

    private void Start()
    {
        OnlineMaps map = OnlineMaps.instance;
        // Subscribe to the click event.
        OnlineMapsControlBase.instance.OnMapClick += OnMapClick;
        markerNameInputText = markerNameInputField.GetComponent<TMP_InputField>();

        SubscribeToOnClickEvent();
    }

    public bool markerButtonpressed
    {
        get; set;
    }

    private void OnMapClick()
    {
        if (markerButtonpressed)
        {

            // Get the coordinates under the cursor.
            OnlineMapsControlBase.instance.GetCoords(out lng, out lat);
            NameMarker();

        }

        else
        {
            label = null;
        }
    }

    private void NameMarker()
    {
        markerNameInputField.SetActive(true);
        markerNameInputText.text = "";
    }

    public void ConfirmName() //ovo mora biti string metoda
    {
        if (string.IsNullOrEmpty(markerNameInputText.text))
        {
            label = "Marker " + (OnlineMapsMarkerManager.CountItems + 1);
        }

        else
        {
            label = markerNameInputText.text;
        }
        SetLabel();
        SetTag();

        markerButtonpressed = false;

        CreateMarkerWithLabel(lng, lat, label);

        markerNameInputField.SetActive(false);

    }

    private string SetLabel()
    {
        return label;
    }

    //private void SetIcon()
    private string SetTag()
    { 
        return tag;
    }
    //{
    //    currentIcon = textureReference.currentTexture;
    //    return;

    //}

    private void CreateMarkerWithLabel(double lng, double lat, string label)
    {
        OnlineMapsMarker marker = OnlineMapsMarkerManager.CreateItem(lng, lat, label);
        marker.tags.Add(label);
        SubscribeToOnClickEvent();
        MyMarkerSaver.SaveMarkers();
    }

    public void OnMarkerClick(OnlineMapsMarkerBase marker)
    {
        label = marker.label;
        Debug.Log(marker.label);
    }

    private void SubscribeToOnClickEvent()
    {
        foreach (OnlineMapsMarker marker in OnlineMapsMarkerManager.instance)
        {
            marker.OnClick += OnMarkerClick;
        }
    }

    public void RemoveMarker()
    {

        OnlineMapsMarkerManager.instance.RemoveByTag(label);
        MyMarkerSaver.SaveMarkers();

    }
}


