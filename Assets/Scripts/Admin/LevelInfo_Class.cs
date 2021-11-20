using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static wg_ADDRESS;

public struct HoneySlotInfo
{
    public HoneySlotInfo(wg_ADDRESS address, bool occupied, bool movable, bool spinnable, v_VALUE tri1, v_VALUE tri2, v_VALUE tri3, v_VALUE tri4, v_VALUE tri5, v_VALUE tri6)
    {
        this.Address = address;
        this.IsOccupied = occupied;
        this.IsMovable = movable;
        this.IsSpinnable = spinnable;
        this.tri1 = tri1;
        this.tri2 = tri2;
        this.tri3 = tri3;
        this.tri4 = tri4;
        this.tri5 = tri5;
        this.tri6 = tri6;
    }

    readonly wg_ADDRESS Address;
    readonly bool IsOccupied;
    readonly bool IsMovable;
    readonly bool IsSpinnable;
    readonly v_VALUE tri1;
    readonly v_VALUE tri2;
    readonly v_VALUE tri3;
    readonly v_VALUE tri4;
    readonly v_VALUE tri5;
    readonly v_VALUE tri6;

}

public struct LevelInfo{

    //public HoneySlotInfo[] HoneySlots = new HoneySlotInfo[49];
    public List<HoneySlotInfo> HoneySlots;

}


public class LevelInfo_Class : MonoBehaviour
{

}
