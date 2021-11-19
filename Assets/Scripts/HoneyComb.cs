using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static wg_ADDRESS;

public class HoneyComb : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public wg_ADDRESS HoneyComb_Address;
    private WorldGrid WorldGridScript;

    public wg_ADDRESS[] HoneySlots;

    private void Start()
    {
        WorldGridScript = GetComponentInParent<WorldGrid>();
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        WorldGridScript.Set_HoveredOver_HoneyComb(HoneyComb_Address);
    }

    //writing IPointerExitHander. then the function name made this work.  I think it overwrite's the base implementation written this way.
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        WorldGridScript.Set_HoveredOver_HoneyComb(NONE);
    }


}
