using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ln_LEVELNAME;
using static wg_ADDRESS;
using static fv_FACEVALUE;

public class LevelHouse : MonoBehaviour
{
    public LevelInfo Retrieve_ThisLevel(ln_LEVELNAME name)
    {
        switch (name)
        {
            case LEVEL_001: 
                return Get_Level_001();
            case LEVEL_002: 
                return Get_Level_002();
            case LEVEL_003: 
                return Get_Level_003();
            case LEVEL_004: 
                return Get_Level_004();
            case LEVEL_005: 
                return Get_Level_005();
            default:
                return Get_Level_001();
        }
    }

    LevelInfo Get_Level_001()
    {
        //make package to return
        LevelInfo LevelPackage = new LevelInfo();

        //initialize internal list
        LevelPackage.HoneySlots = new List<HoneySlotInfo>();

        //honeycomb AA
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(AA_AA, true, true, v_blank, v_blank, v_1, v_blank, v_blank, v_add));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(AA_BB, false, false, v_blank, v_2, v_blank, v_blank, v_blank, v_blank));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(AA_CC, true, true, v_7, v_7, v_blank, v_1, v_0, v_blank));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(AA_DD, false, true, v_2, v_5, v_blank, v_blank, v_add, v_blank));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(AA_EE, true, false, v_blank, v_blank, v_blank, v_blank, v_blank, v_blank));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(AA_FF, true, false, v_7, v_7, v_blank, v_equals, v_equals, v_blank));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(AA_GG, false, true, v_3, v_blank, v_blank, v_equals, v_blank, v_blank));

        //honeycomb BB
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(BB_AA, true, true, v_0, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(BB_BB, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(BB_CC, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(BB_DD, true, true, v_1, v_1, v_1, v_2, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(BB_EE, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(BB_FF, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        //LevelPackage.HoneySlots.Add(new HoneySlotInfo(BB_GG, true, true, true, v_2, v_1, v_1, v_1, v_1, v_1));

        //honeycomb CC
        //LevelPackage.HoneySlots.Add(new HoneySlotInfo(CC_AA, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(CC_BB, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(CC_CC, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        //LevelPackage.HoneySlots.Add(new HoneySlotInfo(CC_DD, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        //LevelPackage.HoneySlots.Add(new HoneySlotInfo(CC_EE, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(CC_FF, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(CC_GG, true, true, v_1, v_1, v_1, v_1, v_1, v_1));

        //honeycomb DD
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(DD_AA, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(DD_BB, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(DD_CC, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(DD_DD, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(DD_EE, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        //LevelPackage.HoneySlots.Add(new HoneySlotInfo(DD_FF, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(DD_GG, true, true, v_1, v_1, v_1, v_1, v_1, v_1));

        //honeycomb EE
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(EE_AA, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(EE_BB, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(EE_CC, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        //LevelPackage.HoneySlots.Add(new HoneySlotInfo(EE_DD, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(EE_EE, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(EE_FF, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(EE_GG, true, true, v_1, v_1, v_1, v_1, v_1, v_1));

        //honeycomb FF
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(FF_AA, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        //LevelPackage.HoneySlots.Add(new HoneySlotInfo(FF_BB, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        //LevelPackage.HoneySlots.Add(new HoneySlotInfo(FF_CC, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(FF_DD, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(FF_EE, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(FF_FF, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(FF_GG, true, true, v_1, v_1, v_1, v_1, v_1, v_1));

        //honeycomb GG
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(GG_AA, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(GG_BB, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(GG_CC, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(GG_DD, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(GG_EE, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(GG_FF, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(GG_GG, true, true, v_1, v_1, v_1, v_1, v_1, v_1));

        return LevelPackage;
    }

    LevelInfo Get_Level_002()
    {
        LevelInfo Package = new LevelInfo();

        return Package;
    }

    LevelInfo Get_Level_003()
    {
        LevelInfo Package = new LevelInfo();

        return Package;
    }

    LevelInfo Get_Level_004()
    {
        LevelInfo Package = new LevelInfo();

        return Package;
    }

    LevelInfo Get_Level_005()
    {
        LevelInfo Package = new LevelInfo();

        return Package;
    }






















}
