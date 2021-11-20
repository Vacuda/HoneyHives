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

    public readonly wg_ADDRESS Address;
    public readonly bool IsOccupied;
    public readonly bool IsMovable;
    public readonly bool IsSpinnable;
    public readonly v_VALUE tri1;
    public readonly v_VALUE tri2;
    public readonly v_VALUE tri3;
    public readonly v_VALUE tri4;
    public readonly v_VALUE tri5;
    public readonly v_VALUE tri6;

}

public struct LevelInfo{

    public List<HoneySlotInfo> HoneySlots;

}


public class LevelInfo_Class : MonoBehaviour
{

}
