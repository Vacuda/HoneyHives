using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static t_TRI;

public class Piece : MonoBehaviour
{
    int Current_TriOffset = 0;
    public fv_FACEVALUE fv_1;
    public fv_FACEVALUE fv_2;
    public fv_FACEVALUE fv_3;
    public fv_FACEVALUE fv_4;
    public fv_FACEVALUE fv_5;
    public fv_FACEVALUE fv_6;

    public void Rotate_Piece()
    {
        //increment
        Current_TriOffset++;
 
        //possible reset
        if(Current_TriOffset > 5)
        {
            Current_TriOffset = Current_TriOffset - 6;
        }

        //store this piece (My Parent's Parent)
        GameObject HoneySlotParent = gameObject.transform.parent.gameObject;

        //detach from parent
        gameObject.transform.parent = null;

        //rotate
        gameObject.transform.Rotate(0.0f, 0.0f, -60.0f);

        //loop children
        foreach (Transform child in gameObject.transform)
        {
            //rotate upwards 
            child.transform.Rotate(0.0f, 0.0f, -60.0f);
        }

        //re-attach to parent
        gameObject.transform.parent = HoneySlotParent.transform;
    }


    public fv_FACEVALUE Get_FaceValue_WithOffset(t_TRI tri)
    {
        /* 
        I need the current value in this triangle.
        Take into account the offset and give me the fv_FACEVALUE there.
        */

        //convert tri to IntTri
        int IntTri = Convert_TriToInt(tri);

        //find offseted new int that corresponds to the face value we need due to spinning
        int Offseted_NewInt = PossibleSpinReset(IntTri - Current_TriOffset);

        //switch based off of current offset int 1-6
        switch (Offseted_NewInt)
        {
            case 1:
                return fv_1;
            case 2:
                return fv_2;
            case 3:
                return fv_3;
            case 4:
                return fv_4;
            case 5:
                return fv_5;
            case 6:
                return fv_6;
            default:
                return fv_1;
        }

      



    }

    int PossibleSpinReset(int integer)
    {
        if(integer < 1)
        {
            return integer + 6;
        }
        else
        {
            return integer;
        }
    }

    int Convert_TriToInt(t_TRI tri)
    {
        switch (tri)
        {
            case TRI_1:
                return 1;
            case TRI_2:
                return 2;
            case TRI_3:
                return 3;
            case TRI_4:
                return 4;
            case TRI_5:
                return 5;
            case TRI_6:
                return 6;
            default:
                return 0;
        }
    }

    //t_TRI Convert_IntToTri(int interger)
    //{
    //    switch (interger)
    //    {
    //        case 1:
    //            return TRI_1;
    //        case 2:
    //            return TRI_2;
    //        case 3:
    //            return TRI_3;
    //        case 4:
    //            return TRI_4;
    //        case 5:
    //            return TRI_5;
    //        case 6:
    //            return TRI_6;
    //        default:
    //            return TRI_1;
    //    }
    //}

}
