using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOut : MonoBehaviour
{
    bool isZoomOut=false;
    public void ZoomOuts()
    {
        if (!isZoomOut)
        {
            PanZoom.zoomOutMax = 14;
            isZoomOut = true;
        }
        else
        {
            PanZoom.zoomOutMax = 8;
            isZoomOut = false;
        }

    }
}
