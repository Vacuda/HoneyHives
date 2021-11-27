using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static wg_ADDRESS;

public struct HoneySlotInfo
{
    public HoneySlotInfo(wg_ADDRESS address, bool movable, bool spinnable, fv_FACEVALUE fv_1, fv_FACEVALUE fv_2, fv_FACEVALUE fv_3, fv_FACEVALUE fv_4, fv_FACEVALUE fv_5, fv_FACEVALUE fv_6)
    {
        this.Address = address;
        //this.IsOccupied = occupied;
        this.IsMovable = movable;
        this.IsSpinnable = spinnable;
        this.fv_1 = fv_1;
        this.fv_2 = fv_2;
        this.fv_3 = fv_3;
        this.fv_4 = fv_4;
        this.fv_5 = fv_5;
        this.fv_6 = fv_6;
    }

    public readonly wg_ADDRESS Address;
    //public readonly bool IsOccupied;
    public readonly bool IsMovable;
    public readonly bool IsSpinnable;
    public readonly fv_FACEVALUE fv_1;
    public readonly fv_FACEVALUE fv_2;
    public readonly fv_FACEVALUE fv_3;
    public readonly fv_FACEVALUE fv_4;
    public readonly fv_FACEVALUE fv_5;
    public readonly fv_FACEVALUE fv_6;

}

public struct LevelInfo{

    public List<HoneySlotInfo> HoneySlots;

}


public class LevelInfo_Class : MonoBehaviour
{

}
