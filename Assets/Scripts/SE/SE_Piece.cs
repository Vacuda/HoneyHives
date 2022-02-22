using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static t_TRI;
using static fv_FACEVALUE;
using TMPro;

public class SE_Piece : MonoBehaviour
{
    //REFERENCES
    //public Camera MainCamera;
    //public PlayerController Controller;
    //private PlayerControls Controls;
    //public PieceGlobals pg;
    //public ColorChanger colorchanger;


    //MEMBERS


    public fv_FACEVALUE fv_1;
    public fv_FACEVALUE fv_2;
    public fv_FACEVALUE fv_3;
    public fv_FACEVALUE fv_4;
    public fv_FACEVALUE fv_5;
    public fv_FACEVALUE fv_6;

    public bool IsMovable;
    public bool IsSpinnable;


    MeshRenderer Rend_0;
    TextMeshPro TMP_1;
    TextMeshPro TMP_2;
    TextMeshPro TMP_3;
    TextMeshPro TMP_4;
    TextMeshPro TMP_5;
    TextMeshPro TMP_6;

    public void Awake()
    {
        Rend_0 = gameObject.GetComponent<MeshRenderer>();
        TMP_1 = gameObject.transform.Find("FaceValue_1").GetComponent<TextMeshPro>();
        TMP_2 = gameObject.transform.Find("FaceValue_2").GetComponent<TextMeshPro>();
        TMP_3 = gameObject.transform.Find("FaceValue_3").GetComponent<TextMeshPro>();
        TMP_4 = gameObject.transform.Find("FaceValue_4").GetComponent<TextMeshPro>();
        TMP_5 = gameObject.transform.Find("FaceValue_5").GetComponent<TextMeshPro>();
        TMP_6 = gameObject.transform.Find("FaceValue_6").GetComponent<TextMeshPro>();
    }

    public void ChangeThisValue(t_TRI tri, fv_FACEVALUE val)
    {
        switch (tri)
        {
            case TRI_1:
                fv_1 = val;
                TMP_1.text = Convert_FaceValueToString(fv_1); ;
                break;

            case TRI_2:
                fv_2 = val;
                TMP_2.text = Convert_FaceValueToString(fv_2); ;
                break;

            case TRI_3:
                fv_3 = val;
                TMP_3.text = Convert_FaceValueToString(fv_3); ;
                break;

            case TRI_4:
                fv_4 = val;
                TMP_4.text = Convert_FaceValueToString(fv_4); ;
                break;

            case TRI_5:
                fv_5 = val;
                TMP_5.text = Convert_FaceValueToString(fv_5); ;
                break;

            case TRI_6:
                fv_6 = val;
                TMP_6.text = Convert_FaceValueToString(fv_6); ;
                break;

                //edge cases, what if gone back to null


            default:
                //fv_1 = val;
                break;
        }




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
        int Offseted_NewInt = PossibleSpinReset(IntTri); //removed - Current_TriOffset

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

    string Convert_FaceValueToString(fv_FACEVALUE fv)
    {
        switch (fv)
        {
            case v_0:
                return "0";
            case v_1:
                return "1";
            case v_2:
                return "2";
            case v_3:
                return "3";
            case v_4:
                return "4";
            case v_5:
                return "5";
            case v_6:
                return "6";
            case v_7:
                return "7";
            case v_8:
                return "8";
            case v_9:
                return "9";
            case v_add:
                return "+";
            case v_sub:
                return "-";
            case v_blank:
                return "";
            case v_equals:
                return "=";
            default:
                return "?";

        }
    }






}
