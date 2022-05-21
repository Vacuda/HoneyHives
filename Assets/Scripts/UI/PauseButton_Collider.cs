using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PauseButton_Collider : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    PauseButton PauseButtonScript;

    void Start()
    {
        PauseButtonScript = gameObject.transform.parent.GetComponent<PauseButton>();
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("on over");
        PauseButtonScript.IsPauseButton_HoveredOver = true;
    }

    //writing IPointerExitHander. then the function name made this work.  I think it overwrite's the base implementation written this way.
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("on exit");
        PauseButtonScript.IsPauseButton_HoveredOver = false;
    }
}
