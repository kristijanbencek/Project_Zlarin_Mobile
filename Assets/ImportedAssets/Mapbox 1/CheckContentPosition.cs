using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class CheckContentPosition : MonoBehaviour
{
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventDataA;
    PointerEventData m_PointerEventDataB;
    PointerEventData m_PointerEventDataC;
    PointerEventData m_PointerEventDataD;
    EventSystem m_EventSystem;

    void Start()
    {
        //Fetch the Raycaster from the GameObject (the Canvas)
        m_Raycaster = GetComponent<GraphicRaycaster>();
        //Fetch the Event System from the Scene
        m_EventSystem = GetComponent<EventSystem>();
    }

    void Update()
    {
        //Check if the left Mouse button is clicked
        if (Input.GetMouseButton(0))
        {

            //Set up the new Pointer Event
            m_PointerEventDataA = new PointerEventData(m_EventSystem);
            m_PointerEventDataB = new PointerEventData(m_EventSystem);
            m_PointerEventDataC = new PointerEventData(m_EventSystem);
            m_PointerEventDataD = new PointerEventData(m_EventSystem);
            //Set the Pointer Event Position to that of the mouse position
            m_PointerEventDataA.position = new Vector2(0,0);
            m_PointerEventDataB.position = new Vector2(1080,0);
            m_PointerEventDataC.position = new Vector2(0,1920);
            m_PointerEventDataD.position = new Vector2(1080,1920);

            //Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();

            //Raycast using the Graphics Raycaster and mouse click position
            m_Raycaster.Raycast(m_PointerEventDataA, results);
            m_Raycaster.Raycast(m_PointerEventDataB, results);
            m_Raycaster.Raycast(m_PointerEventDataC, results);
            m_Raycaster.Raycast(m_PointerEventDataD, results);

            //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
            foreach (RaycastResult result in results)
            {
                Debug.Log("Hit " + result.gameObject.name);
            }
        }
    }
}
