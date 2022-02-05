using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static wg_ADDRESS;

public class CustomStructs : MonoBehaviour
{

}

public struct HoneySlotInfo
{
    //CONSTRUCTOR
    public HoneySlotInfo(wg_ADDRESS address, bool movable, bool spinnable, fv_FACEVALUE fv_1, fv_FACEVALUE fv_2, fv_FACEVALUE fv_3, fv_FACEVALUE fv_4, fv_FACEVALUE fv_5, fv_FACEVALUE fv_6)
    {
        //determine whether HoneyJar_Originated
        if (address == AA || address == BB || address == CC || address == DD || address == EE || address == FF || address == GG)
        {
            this.HoneyJar_Originated = true;
        }
        else
        {
            this.HoneyJar_Originated = false;
        }

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

    //MEMBERS

    public readonly bool HoneyJar_Originated;
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

public struct LevelInfo
{

    public List<HoneySlotInfo> HoneySlots;

}

public struct ColorChangeJob
{
    //CONSTRUCTOR
    public ColorChangeJob(MaterialPropertyBlock matblock, float speed, Color32 color, int mat_index)
    {
        this.matblock = matblock;
        this.speed = speed;
        this.color = color;
        this.mat_index = mat_index;
    }

    //MEMBERS
    public readonly MaterialPropertyBlock matblock;
    public readonly float speed;
    public readonly Color32 color;
    public readonly int mat_index;

}
