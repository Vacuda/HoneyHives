using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slide_Collider : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    SlideButton SlideButtonScript;

    void Start()
    {

        SlideButtonScript = gameObject.transform.parent.GetComponent<SlideButton>();
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        SlideButtonScript.bIsHoveredOver = true;
    }

    //writing IPointerExitHander. then the function name made this work.  I think it overwrite's the base implementation written this way.
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        SlideButtonScript.bIsHoveredOver = false;
    }
}
