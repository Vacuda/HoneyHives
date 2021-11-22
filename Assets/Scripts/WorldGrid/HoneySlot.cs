using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static wg_ADDRESS;

public class HoneySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public wg_ADDRESS HoneySlot_Address;
    private WorldGrid WorldGridScript;

    void Start()
    {
        //turns it off.
        gameObject.GetComponent<CircleCollider2D>().enabled = false;

        WorldGridScript = GetComponentInParent<WorldGrid>();
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {

        //Debug.Log("in: " + HoneySlot_Address);
        WorldGridScript.Set_HoveredOver_HoneySlot(HoneySlot_Address);
    }

    //writing IPointerExitHander. then the function name made this work.  I think it overwrite's the base implementation written this way.
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        WorldGridScript.Set_HoveredOver_HoneySlot(NONE);
        //Debug.Log("out: " + HoneySlot_Address);
    }

}
