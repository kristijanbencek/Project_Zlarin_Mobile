using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [AddComponentMenu("Infinity Code/Online Maps/Examples (API Usage)/MyTooltipStyle")]
    public class MyTooltipStyle: MonoBehaviour
    {
        private void Start()
        {
            // Subscribe to the event preparation of tooltip style.
            OnlineMapsGUITooltipDrawer.OnPrepareTooltipStyle += OnPrepareTooltipStyle;
        }

        private void OnPrepareTooltipStyle(ref GUIStyle style)
        {
            //Hide background.
            //style.normal.background = null;
            //style.fixedHeight = 600;
            //style.fixedWidth = 2000;
            //style.fontSize = Screen.width / 25;
        }
    }


