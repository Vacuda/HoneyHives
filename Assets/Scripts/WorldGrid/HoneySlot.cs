using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static wg_ADDRESS;

public class HoneySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public wg_ADDRESS HoneySlot_Address;

    void Start()
    {
        //turns it off.
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {

        Debug.Log("in: " + HoneySlot_Address);
        //WorldGridScript.Activate_ThisHoneycomb(HoneyComb_Address);
    }

    //writing IPointerExitHander. then the function name made this work.  I think it overwrite's the base implementation written this way.
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        //WorldGridScript.Deactivate_Honeycomb();
        //Debug.Log("out: " + HoneySlot_Address);
    }

}
