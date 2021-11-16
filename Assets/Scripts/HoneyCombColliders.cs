using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static wg_HONEYCOMB;

public class HoneyCombColliders : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public wg_HONEYCOMB HoneyComb;
    private WorldGrid WorldGridScript;

    private void Start()
    {
        WorldGridScript = GetComponentInParent<WorldGrid>();
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        WorldGridScript.Activate_ThisHoneycomb(HoneyComb);
    }

    //writing IPointerExitHander. then the function name made this work.  I think it overwrite's the base implementation written this way.
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        WorldGridScript.Deactivate_Honeycomb();
    }



}
