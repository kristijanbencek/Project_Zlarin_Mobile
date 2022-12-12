using UnityEngine;
using UnityEngine.UI;

public class ContentZoom : MonoBehaviour
{
    [SerializeField] private Transform scrollView;
    [SerializeField] private Transform content;

    public float scrollViewScalingSpeed;
    public float contentScalingSpeed;
    //public Transform borderObject;
    public ScrollRect scrollViewBars;

    //public bool canZoomIn = true;
    //public bool canZoomOut = true;

    public float maxScrollViewScale;
    public float minScrollViewScale;

    public float maxContentScale;
    public float minContentScale;
    private void Start()
    {
        InvokeRepeating("MoveWithTouch", 0, .01f);
    }
    private void Update()
    {
        Zoom(Input.GetAxis("Mouse ScrollWheel") * scrollViewScalingSpeed, Input.GetAxis("Mouse ScrollWheel") * contentScalingSpeed);

    }
    void MoveWithTouch()
    {
        if (Input.touchCount == 2)
        {

            scrollViewBars.horizontal = false;
            scrollViewBars.vertical = false;

            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;
            Zoom(difference * scrollViewScalingSpeed,difference * contentScalingSpeed);

        }
        else
        {
            scrollViewBars.horizontal = true;
            scrollViewBars.vertical = true;
        }


        ResetSizeScrollView();
        ResetContentSize();
    }
    void Zoom(float scrollView, float contentScale)//Enables the user to zoom in or out
    {
        this.scrollView.transform.localScale += new Vector3(scrollView, scrollView, scrollView);
        content.transform.localScale += new Vector3(contentScale, contentScale, contentScale);
        //if (canZoomIn == true)
        //{
        //    scrollView.transform.localScale += new Vector3(scrollView, scrollView, scrollView);
        //}
    }


    void ResetSizeScrollView()//checks the boundries of zoom function and resets the scrollView based on the boundry it overstepped
    {
        if (scrollView.localScale.x < minScrollViewScale)
        {
            //canZoomOut = false;
            scrollView.transform.localScale = new Vector3(minScrollViewScale, minScrollViewScale, minScrollViewScale);

            // canZoomOut = true;

        }
        else if (scrollView.localScale.x > maxScrollViewScale)
        {
            // canZoomIn = false;
            scrollView.transform.localScale = new Vector3(maxScrollViewScale, maxScrollViewScale, maxScrollViewScale);

            // canZoomIn = true;

        }
    }
    void ResetContentSize()
    {
        if (content.transform.localScale.x < minContentScale)
        {
            content.transform.localScale = new Vector3(minContentScale, minContentScale, minContentScale);
        }
        else if (content.transform.localScale.x > maxContentScale)
        {
            content.transform.localScale = new Vector3(maxContentScale, maxContentScale, maxContentScale);
        }
    }
}
//ChangeLog: - 04/12/2022(changed scrollView reference from "scrollView" to "scrollView")
//           - Plus side = no out of bonds weird bullshit reseting, negative = small res picture means peace of shit quality map
