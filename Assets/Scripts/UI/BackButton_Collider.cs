using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class BackButton_Collider : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    BackButton BackButtonScript;

    void Start()
    {
        BackButtonScript = gameObject.transform.parent.GetComponent<BackButton>();
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        BackButtonScript.IsBackButton_HoveredOver = true;
    }

    //writing IPointerExitHander. then the function name made this work.  I think it overwrite's the base implementation written this way.
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        BackButtonScript.IsBackButton_HoveredOver = false;
    }
}
