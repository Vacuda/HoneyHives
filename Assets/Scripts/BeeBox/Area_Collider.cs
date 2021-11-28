using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static wg_ADDRESS;

public class Area_Collider : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    
    BeeBox BeeBoxScript;
    wg_ADDRESS AreaAddress;

    void Start()
    {
        //BeeBoxScript = gameObject.transform.parent.transform.parent.transform.parent.GetComponent<BeeBox>();
        BeeBoxScript = gameObject.transform.root.GetComponent<BeeBox>();
        AreaAddress = gameObject.transform.parent.GetComponent<Area>().AreaAddress;
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        BeeBoxScript.Set_HoveredOver_Area(AreaAddress);
    }

    //writing IPointerExitHander. then the function name made this work.  I think it overwrite's the base implementation written this way.
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        BeeBoxScript.Set_HoveredOver_Area(NONE);
    }
}
