using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.EventSystems;
using static wg_ADDRESS;

public class HoneyComb : MonoBehaviour//, IPointerEnterHandler, IPointerExitHandler
{
    public wg_ADDRESS HoneyComb_Address;
    private WorldGrid WorldGridScript;


    //this Dict uses truncated addresses for ease of programing
    public Dictionary<wg_ADDRESS, GameObject> HoneySlotRefDict = new Dictionary<wg_ADDRESS, GameObject>();

    public wg_ADDRESS[] HoneySlots;

    private void Awake()
    {
        Build_LocalDictionaryOfHoneySlotObjects();
    }

    //private void Start()
    //{
    //    WorldGridScript = GetComponentInParent<WorldGrid>();

    //}

    //void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    //{
    //    WorldGridScript.Set_HoveredOver_HoneyComb(HoneyComb_Address);
    //}

    ////writing IPointerExitHander. then the function name made this work.  I think it overwrite's the base implementation written this way.
    //void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    //{
    //    WorldGridScript.Set_HoveredOver_HoneyComb(NONE);
    //}

    private void Build_LocalDictionaryOfHoneySlotObjects()
    {
        HoneySlotRefDict.Add(AA, gameObject.transform.Find("HoneySlot_AA").gameObject);
        HoneySlotRefDict.Add(BB, gameObject.transform.Find("HoneySlot_BB").gameObject);
        HoneySlotRefDict.Add(CC, gameObject.transform.Find("HoneySlot_CC").gameObject);
        HoneySlotRefDict.Add(DD, gameObject.transform.Find("HoneySlot_DD").gameObject);
        HoneySlotRefDict.Add(EE, gameObject.transform.Find("HoneySlot_EE").gameObject);
        HoneySlotRefDict.Add(FF, gameObject.transform.Find("HoneySlot_FF").gameObject);
        HoneySlotRefDict.Add(GG, gameObject.transform.Find("HoneySlot_GG").gameObject);
    }
}
