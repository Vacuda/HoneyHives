using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static t_TRI;

public class Piece_Title : MonoBehaviour
{
    //REFERENCES
    //public Camera MainCamera;
    //public PlayerController Controller;
    //private PlayerControls Controls;
    //public PieceGlobals pg;
    //public ColorChanger colorchanger;
    public MaterialChanger materialchanger;
    //public GameObject BeeBoxPanel;

    //MEMBERS

    public int Current_TriOffset = 0;
    public fv_FACEVALUE fv_1;
    public fv_FACEVALUE fv_2;
    public fv_FACEVALUE fv_3;
    public fv_FACEVALUE fv_4;
    public fv_FACEVALUE fv_5;
    public fv_FACEVALUE fv_6;

    public MeshRenderer Rend_0;
    MeshRenderer Rend_1;
    MeshRenderer Rend_2;
    MeshRenderer Rend_3;
    MeshRenderer Rend_4;
    MeshRenderer Rend_5;
    MeshRenderer Rend_6;

    public void Awake()
    {
        Rend_0 = gameObject.GetComponent<MeshRenderer>();
        Rend_1 = gameObject.transform.Find("FaceValue_1").gameObject.GetComponent<MeshRenderer>();
        Rend_2 = gameObject.transform.Find("FaceValue_2").gameObject.GetComponent<MeshRenderer>();
        Rend_3 = gameObject.transform.Find("FaceValue_3").gameObject.GetComponent<MeshRenderer>();
        Rend_4 = gameObject.transform.Find("FaceValue_4").gameObject.GetComponent<MeshRenderer>();
        Rend_5 = gameObject.transform.Find("FaceValue_5").gameObject.GetComponent<MeshRenderer>();
        Rend_6 = gameObject.transform.Find("FaceValue_6").gameObject.GetComponent<MeshRenderer>();
    }

    public void Deactivate_Piece()
    {
        //deactivate piece material
        materialchanger.MaterialChange_Instant(gameObject);

    }


    //UTILITIES

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
        if (integer < 1)
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

    public void Change_SortingLayer_ToBack()
    {
        Rend_0.sortingOrder = 0;
        Rend_1.sortingOrder = 1;
        Rend_2.sortingOrder = 1;
        Rend_3.sortingOrder = 1;
        Rend_4.sortingOrder = 1;
        Rend_5.sortingOrder = 1;
        Rend_6.sortingOrder = 1;
    }

}
