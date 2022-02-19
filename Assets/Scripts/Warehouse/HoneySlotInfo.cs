using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static wg_ADDRESS;

public class HoneySlotInfo
{
    //CONSTRUCTOR
    public HoneySlotInfo(wg_ADDRESS address, bool movable, bool spinnable, fv_FACEVALUE fv_1, fv_FACEVALUE fv_2, fv_FACEVALUE fv_3, fv_FACEVALUE fv_4, fv_FACEVALUE fv_5, fv_FACEVALUE fv_6)
    {
        ////determine whether HoneyJar_Originated
        //if (address == AA || address == BB || address == CC || address == DD || address == EE || address == FF || address == GG)
        //{
        //    this.HoneyJar_Originated = true;
        //}
        //else
        //{
        //    this.HoneyJar_Originated = false;
        //}

        this.HoneyJar_Originated = false;
        this.Address = address;
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

    public bool HoneyJar_Originated;
    public wg_ADDRESS Address;
    public bool IsMovable;
    public bool IsSpinnable;
    public fv_FACEVALUE fv_1;
    public fv_FACEVALUE fv_2;
    public fv_FACEVALUE fv_3;
    public fv_FACEVALUE fv_4;
    public fv_FACEVALUE fv_5;
    public fv_FACEVALUE fv_6;
}
