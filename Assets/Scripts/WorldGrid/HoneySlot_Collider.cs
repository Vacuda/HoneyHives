using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static wg_ADDRESS;

public class HoneySlot_Collider : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private wg_ADDRESS HoneySlot_Address;
    private WorldGrid WorldGridScript;

    void Start()
    {
        //turns it off.
        gameObject.GetComponent<CircleCollider2D>().enabled = false;

        //                HS_Collider       -    HS           -  HC       - WorldGrid
        WorldGridScript = gameObject.transform.parent.transform.parent.GetComponentInParent<WorldGrid>();

        //                HS_Collider       -    HS
        HoneySlot_Address = gameObject.transform.parent.GetComponent<HoneySlot>().HoneySlot_Address;

    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        WorldGridScript.Set_HoveredOver_HoneySlot(HoneySlot_Address);
    }

    //writing IPointerExitHander. then the function name made this work.  I think it overwrite's the base implementation written this way.
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        WorldGridScript.Set_HoveredOver_HoneySlot(NONE);
    }





}
