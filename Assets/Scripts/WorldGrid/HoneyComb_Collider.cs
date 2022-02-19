using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static wg_ADDRESS;

public class HoneyComb_Collider : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private WorldGrid WorldGridScript;
    private HoneyLock HoneyLockScript;
    private wg_ADDRESS HoneyComb_Address;

    private void Start()
    {
        // HC_Collider - HoneyComb - WorldGrid - Get Script
        WorldGridScript = gameObject.transform.parent.GetComponentInParent<WorldGrid>();

        // HC_Collider - HoneyComb - HoneyCombScript
        HoneyComb_Address = gameObject.transform.parent.GetComponent<HoneyComb>().HoneyComb_Address;


        HoneyLockScript = WorldGridScript.HoneyLockObject.GetComponent<HoneyLock>();
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        WorldGridScript.Set_HoneyComb_Hover(HoneyComb_Address);


        HoneyLockScript.BringUp_HoneyLock();
    }

    //writing IPointerExitHander. then the function name made this work.  I think it overwrite's the base implementation written this way.
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        WorldGridScript.Set_HoneyComb_Hover(NONE);

        HoneyLockScript.BringDown_HoneyLock();
    }
}
