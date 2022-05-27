using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static wg_ADDRESS;

public class WorldGrid_Title : MonoBehaviour
{
    public Dictionary<wg_ADDRESS, GameObject> WGRefDict = new Dictionary<wg_ADDRESS, GameObject>();

    public ColorChanger ColorChangerScript;

    private void Awake()
    {
        //create ref dictionary
        Make_WorldGridRefDict();
    }

    private void Make_WorldGridRefDict()
    {
        //add HoneyCombs
        WGRefDict.Add(AA, this.transform.Find("AA_HoneyComb").gameObject);
        WGRefDict.Add(BB, this.transform.Find("BB_HoneyComb").gameObject);
        WGRefDict.Add(CC, this.transform.Find("CC_HoneyComb").gameObject);
        WGRefDict.Add(DD, this.transform.Find("DD_HoneyComb").gameObject);
        WGRefDict.Add(EE, this.transform.Find("EE_HoneyComb").gameObject);
        WGRefDict.Add(FF, this.transform.Find("FF_HoneyComb").gameObject);
        WGRefDict.Add(GG, this.transform.Find("GG_HoneyComb").gameObject);

        //add HoneySlots
        WGRefDict.Add(AA_AA, WGRefDict[AA].transform.Find("HoneySlot_AA").gameObject);
        WGRefDict.Add(AA_BB, WGRefDict[AA].transform.Find("HoneySlot_BB").gameObject);
        WGRefDict.Add(AA_CC, WGRefDict[AA].transform.Find("HoneySlot_CC").gameObject);
        WGRefDict.Add(AA_DD, WGRefDict[AA].transform.Find("HoneySlot_DD").gameObject);
        WGRefDict.Add(AA_EE, WGRefDict[AA].transform.Find("HoneySlot_EE").gameObject);
        WGRefDict.Add(AA_FF, WGRefDict[AA].transform.Find("HoneySlot_FF").gameObject);
        WGRefDict.Add(AA_GG, WGRefDict[AA].transform.Find("HoneySlot_GG").gameObject);

        WGRefDict.Add(BB_AA, WGRefDict[BB].transform.Find("HoneySlot_AA").gameObject);
        WGRefDict.Add(BB_BB, WGRefDict[BB].transform.Find("HoneySlot_BB").gameObject);
        WGRefDict.Add(BB_CC, WGRefDict[BB].transform.Find("HoneySlot_CC").gameObject);
        WGRefDict.Add(BB_DD, WGRefDict[BB].transform.Find("HoneySlot_DD").gameObject);
        WGRefDict.Add(BB_EE, WGRefDict[BB].transform.Find("HoneySlot_EE").gameObject);
        WGRefDict.Add(BB_FF, WGRefDict[BB].transform.Find("HoneySlot_FF").gameObject);
        WGRefDict.Add(BB_GG, WGRefDict[BB].transform.Find("HoneySlot_GG").gameObject);

        WGRefDict.Add(CC_AA, WGRefDict[CC].transform.Find("HoneySlot_AA").gameObject);
        WGRefDict.Add(CC_BB, WGRefDict[CC].transform.Find("HoneySlot_BB").gameObject);
        WGRefDict.Add(CC_CC, WGRefDict[CC].transform.Find("HoneySlot_CC").gameObject);
        WGRefDict.Add(CC_DD, WGRefDict[CC].transform.Find("HoneySlot_DD").gameObject);
        WGRefDict.Add(CC_EE, WGRefDict[CC].transform.Find("HoneySlot_EE").gameObject);
        WGRefDict.Add(CC_FF, WGRefDict[CC].transform.Find("HoneySlot_FF").gameObject);
        WGRefDict.Add(CC_GG, WGRefDict[CC].transform.Find("HoneySlot_GG").gameObject);

        WGRefDict.Add(DD_AA, WGRefDict[DD].transform.Find("HoneySlot_AA").gameObject);
        WGRefDict.Add(DD_BB, WGRefDict[DD].transform.Find("HoneySlot_BB").gameObject);
        WGRefDict.Add(DD_CC, WGRefDict[DD].transform.Find("HoneySlot_CC").gameObject);
        WGRefDict.Add(DD_DD, WGRefDict[DD].transform.Find("HoneySlot_DD").gameObject);
        WGRefDict.Add(DD_EE, WGRefDict[DD].transform.Find("HoneySlot_EE").gameObject);
        WGRefDict.Add(DD_FF, WGRefDict[DD].transform.Find("HoneySlot_FF").gameObject);
        WGRefDict.Add(DD_GG, WGRefDict[DD].transform.Find("HoneySlot_GG").gameObject);

        WGRefDict.Add(EE_AA, WGRefDict[EE].transform.Find("HoneySlot_AA").gameObject);
        WGRefDict.Add(EE_BB, WGRefDict[EE].transform.Find("HoneySlot_BB").gameObject);
        WGRefDict.Add(EE_CC, WGRefDict[EE].transform.Find("HoneySlot_CC").gameObject);
        WGRefDict.Add(EE_DD, WGRefDict[EE].transform.Find("HoneySlot_DD").gameObject);
        WGRefDict.Add(EE_EE, WGRefDict[EE].transform.Find("HoneySlot_EE").gameObject);
        WGRefDict.Add(EE_FF, WGRefDict[EE].transform.Find("HoneySlot_FF").gameObject);
        WGRefDict.Add(EE_GG, WGRefDict[EE].transform.Find("HoneySlot_GG").gameObject);

        WGRefDict.Add(FF_AA, WGRefDict[FF].transform.Find("HoneySlot_AA").gameObject);
        WGRefDict.Add(FF_BB, WGRefDict[FF].transform.Find("HoneySlot_BB").gameObject);
        WGRefDict.Add(FF_CC, WGRefDict[FF].transform.Find("HoneySlot_CC").gameObject);
        WGRefDict.Add(FF_DD, WGRefDict[FF].transform.Find("HoneySlot_DD").gameObject);
        WGRefDict.Add(FF_EE, WGRefDict[FF].transform.Find("HoneySlot_EE").gameObject);
        WGRefDict.Add(FF_FF, WGRefDict[FF].transform.Find("HoneySlot_FF").gameObject);
        WGRefDict.Add(FF_GG, WGRefDict[FF].transform.Find("HoneySlot_GG").gameObject);

        WGRefDict.Add(GG_AA, WGRefDict[GG].transform.Find("HoneySlot_AA").gameObject);
        WGRefDict.Add(GG_BB, WGRefDict[GG].transform.Find("HoneySlot_BB").gameObject);
        WGRefDict.Add(GG_CC, WGRefDict[GG].transform.Find("HoneySlot_CC").gameObject);
        WGRefDict.Add(GG_DD, WGRefDict[GG].transform.Find("HoneySlot_DD").gameObject);
        WGRefDict.Add(GG_EE, WGRefDict[GG].transform.Find("HoneySlot_EE").gameObject);
        WGRefDict.Add(GG_FF, WGRefDict[GG].transform.Find("HoneySlot_FF").gameObject);
        WGRefDict.Add(GG_GG, WGRefDict[GG].transform.Find("HoneySlot_GG").gameObject);
    }
}
