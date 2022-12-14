
using UnityEngine;
using UnityEngine.UI;

public class CameraZoom : MonoBehaviour
{
    public float zoomSpeed;
    public Vector3 touchStart;
    public GameObject[] buttons;
    public Image test;
    private float mapMinX, mapMaxX, mapMinY, mapMaxY;

    [SerializeField]
    private float zoomStep, minCamSize, maxCamSize;

    private void Awake()
    {
        //mapMinX = mapRenderer.transform.position.x - mapRenderer.bounds.size.x / 2;
        //mapMaxX = mapRenderer.transform.position.x + mapRenderer.bounds.size.x / 2;

        //mapMinY = mapRenderer.transform.position.y - mapRenderer.bounds.size.y / 2;
        //mapMaxY = mapRenderer.transform.position.y + mapRenderer.bounds.size.y / 2;
    }
    
    void Update()
    {
        PanCamera();
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            Zoom(difference * zoomSpeed);
            
        }

    }
    #region Zoom and Move mechanics
    void Zoom(float value)//Pinch zoom
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - value, minCamSize, maxCamSize);
        Camera.main.transform.position = ClampCamera(Camera.main.transform.position);

    }

    void zoomIn()//Zoom in on button click
    {
        float newSize = Camera.main.orthographicSize - zoomStep;
        Camera.main.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);

        Camera.main.transform.position = ClampCamera(Camera.main.transform.position);
    }
    void zoomOut()//Zoom out on button click
    {
        float newSize = Camera.main.orthographicSize + zoomStep;
        Camera.main.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);

        Camera.main.transform.position = ClampCamera(Camera.main.transform.position);
    }
    private void PanCamera()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 difference = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Camera.main.transform.position = ClampCamera(Camera.main.transform.position + difference);
            
        }
    }
    public void ResetTest()//No use for it yet
    {
        Camera.main.transform.position = new Vector3(0, 1, -10);
        Debug.Log("TEST");
    }
    private Vector3 ClampCamera(Vector3 targetPosition)//Always finds new bounds for camera to move in when. Put it in the code where zoomin in or out happens and where moving the camera happens.
    {
        float camHeight = Camera.main.orthographicSize;
        float camWidth = Camera.main.orthographicSize * Camera.main.aspect;

        float minX = mapMinX + camWidth;
        float maxX = mapMaxX - camWidth;
        float minY = mapMinY + camHeight;
        float maxY = mapMaxY - camHeight;

        float newX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float newY = Mathf.Clamp(targetPosition.y, minY, maxY);

        return new Vector3(newX, newY, targetPosition.z);
    }
    #endregion 

}