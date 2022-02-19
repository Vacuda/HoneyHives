using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum gs_GAMESTATUS
{
    FADE_IN, FADE_OUT, OUTER, INNER, TRANS_IN, TRANS_OUT
};

public enum wg_ADDRESS
{
    //the order is important here.  PuzzleBuilder uses the order

    //none
    NONE = 0, 
    
    //honeycomb address
    //AA, BB, CC, DD, EE, FF, GG,

    //honeyslot address
    AA, AA_AA, AA_BB, AA_CC, AA_DD, AA_EE, AA_FF, AA_GG, // 1-8
    BB, BB_AA, BB_BB, BB_CC, BB_DD, BB_EE, BB_FF, BB_GG, // 9-16
    CC, CC_AA, CC_BB, CC_CC, CC_DD, CC_EE, CC_FF, CC_GG, // 17-24
    DD, DD_AA, DD_BB, DD_CC, DD_DD, DD_EE, DD_FF, DD_GG, // 25-32
    EE, EE_AA, EE_BB, EE_CC, EE_DD, EE_EE, EE_FF, EE_GG, // 33-40
    FF, FF_AA, FF_BB, FF_CC, FF_DD, FF_EE, FF_FF, FF_GG, // 41-48
    GG, GG_AA, GG_BB, GG_CC, GG_DD, GG_EE, GG_FF, GG_GG, // 49-56

    //area address
    a_1, a_2, a_3, a_4, a_5, a_6, a_7, a_8, a_9, a_10,
    a_11, a_12, a_13, a_14, a_15, a_16, a_17, a_18, a_19, a_20,
    a_21, a_22, a_23, a_24, a_25, a_26, a_27, a_28,

}

public enum ln_LEVELNAME
{
    LEVEL_001,
    LEVEL_002,
    LEVEL_003,
    LEVEL_004,
    LEVEL_005
}

public enum fv_FACEVALUE
{
    v_null,
    v_0, v_1, v_2, v_3, v_4, v_5, v_6, v_7, v_8, v_9,
    v_add, v_sub, v_blank, v_equals,
    v_int
}

public enum t_TRI
{
    TRI_1, TRI_2, TRI_3, TRI_4, TRI_5, TRI_6
}

public enum c_ACTCOLOR
{
    c_CENTER, c_PETALS, c_VINE, c_HC_WIRE, c_HC_BACK
}

//public enum m_MATERIAL
//{
    
//}


public class CustomEnums : MonoBehaviour
{

}



