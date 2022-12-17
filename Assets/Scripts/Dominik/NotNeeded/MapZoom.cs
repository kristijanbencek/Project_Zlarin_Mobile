using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapZoom : MonoBehaviour
{
    Vector3 touchStart;

    public ScrollRect scrollBars;
    public GameObject content;
    public float scaling;
    public float maxScale;
    public float minScale;
    public float zoomOutMin = 1;
    public float zoomOutMax = 8;
    public float zoomSpeed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.touchCount == 2)
        {
            scrollBars.horizontal = false;
            scrollBars.vertical = false;
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            zoom(difference * zoomSpeed, difference * scaling);
            ScaleContent(difference);

        }
        else if (Input.GetMouseButton(0))
        {
            scrollBars.horizontal = true;
            scrollBars.vertical = true;
            Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Camera.main.transform.position += direction;
        }
        // zoom(Input.GetAxis("Mouse ScrollWheel"));
    }

    void zoom(float increment, float scale)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }
    void ScaleContent(float scale)
    {
        content.transform.localScale = new Vector3(Mathf.Clamp(content.transform.localScale.x, 2, 10), Mathf.Clamp(content.transform.localScale.y, 2, 10), 1);
        content.transform.localScale += new Vector3(scale, scale, 0) * scaling;
       
    }
}
