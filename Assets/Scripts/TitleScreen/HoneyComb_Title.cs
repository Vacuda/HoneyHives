using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static wg_ADDRESS;
using static c_ACTCOLOR;

public class HoneyComb_Title : MonoBehaviour
{
    //this Dict uses truncated addresses for ease of programing
    public Dictionary<wg_ADDRESS, GameObject> HoneySlotRefDict = new Dictionary<wg_ADDRESS, GameObject>();



    private void Awake()
    {
        Build_LocalDictionaryOfHoneySlotObjects();
    }

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
