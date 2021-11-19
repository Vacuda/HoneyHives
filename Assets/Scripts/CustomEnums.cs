using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum gs_GAMESTATUS
{
    FADE_IN, FADE_OUT, OUTER, INNER, TRANS_IN, TRANS_OUT
};

public enum wg_ADDRESS
{
    //none
    NONE, 
    
    //honeycomb address
    AA, BB, CC, DD, EE, FF, GG,

    //honeyslot address
    AA_AA, AA_BB, AA_CC, AA_DD, AA_EE, AA_FF, AA_GG,
    BB_AA, BB_BB, BB_CC, BB_DD, BB_EE, BB_FF, BB_GG,
    CC_AA, CC_BB, CC_CC, CC_DD, CC_EE, CC_FF, CC_GG,
    DD_AA, DD_BB, DD_CC, DD_DD, DD_EE, DD_FF, DD_GG,
    EE_AA, EE_BB, EE_CC, EE_DD, EE_EE, EE_FF, EE_GG,
    FF_AA, FF_BB, FF_CC, FF_DD, FF_EE, FF_FF, FF_GG,
    GG_AA, GG_BB, GG_CC, GG_DD, GG_EE, GG_FF, GG_GG,

    //flowerindicator address
    AA_1, AA_2, AA_3, AA_4, AA_5, AA_6, AA_7, AA_8, AA_9,
    BB_1, BB_2, BB_3, BB_4, BB_5, BB_6, BB_7, BB_8, BB_9,
    CC_1, CC_2, CC_3, CC_4, CC_5, CC_6, CC_7, CC_8, CC_9,
    DD_1, DD_2, DD_3, DD_4, DD_5, DD_6, DD_7, DD_8, DD_9,
    EE_1, EE_2, EE_3, EE_4, EE_5, EE_6, EE_7, EE_8, EE_9,
    FF_1, FF_2, FF_3, FF_4, FF_5, FF_6, FF_7, FF_8, FF_9,
    GG_1, GG_2, GG_3, GG_4, GG_5, GG_6, GG_7, GG_8, GG_9
}


public class CustomEnums : MonoBehaviour
{

}

