using UnityEngine;
using UnityEngine.UI;
using TMPro;

[AddComponentMenu("Infinity Code/Online Maps/Examples (API Usage)/CustomMarkerAndLabelOnClick")]
public class CustomMarkerAndLabelOnClick : MonoBehaviour
{

    //private int number;

    private string labelText;
    private string label;

    //private Texture2D currentIcon;

    public GameObject markerNameInputField;
    public ChangeIconClick textureReference;

    private RemoveLastPlaced markerCounter;

    private TMP_InputField markerNameInputText;
    double lng, lat;


    private void Start()
    {
        // Subscribe to the click event.
        OnlineMapsControlBase.instance.OnMapClick += OnMapClick;
        markerNameInputText = markerNameInputField.GetComponent<TMP_InputField>();
        markerCounter = GetComponent<RemoveLastPlaced>();

    }

    public bool markerButtonpressed
    {
        get; set;
    }

    private void OnMapClick()
    {
        if (markerButtonpressed)
        {
            //StartCoroutine(SetNewMarker());


            // Get the coordinates under the cursor.
            OnlineMapsControlBase.instance.GetCoords(out lng, out lat);
            NameMarker();

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
            // Create a label for the marker.
            label = "Marker " + (OnlineMapsMarkerManager.CountItems + 1);
        }

        else
        {
            label = markerNameInputText.text;
        }
        Setlabel();
        //SetIcon();
        // Create a new marker.


        markerButtonpressed = false;

        CreateMarkerWithLabel(lng, lat, label);

        markerNameInputField.SetActive(false);

    }

    private string Setlabel()
    {
        label = markerNameInputText.text;
        return label;
    }

    //public void SetIcon()
    //{
    //    currentIcon = textureReference.currentTexture;

    //}

    private void CreateMarkerWithLabel(double lng, double lat, string label)
    {
        OnlineMapsMarkerManager.CreateItem(lng, lat, label);
        markerCounter.CountMarkers();
        MyMarkerSaver.SaveMarkers();
    }

}


