using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static wg_ADDRESS;
using static c_ACTCOLOR;
using static fv_FACEVALUE;
using TMPro;

public class SE_HoneyComb : MonoBehaviour
{
    public wg_ADDRESS HoneyComb_Address;
    private ColorChanger ColorChangerScript;

    private MaterialPropertyBlock HC_WireframeMaterial;
    private MaterialPropertyBlock HC_BackgroundMaterial;
    private Renderer HC_WireFrameRenderer;
    private Renderer HC_BackgroundRenderer;

    public Material M_Piece_Full;
    public Material M_Piece_None;
    public Material M_Piece_Move;
    public Material M_Piece_Spin;
    public Material M_Piece_Sides;

    //this Dict uses truncated addresses for ease of programing
    public Dictionary<wg_ADDRESS, GameObject> HoneySlotRefDict = new Dictionary<wg_ADDRESS, GameObject>();

    //public wg_ADDRESS[] HoneySlots;

    private void Awake()
    {
        Build_LocalDictionaryOfHoneySlotObjects();

        ColorChangerScript = gameObject.transform.parent.GetComponent<SE_WorldGrid>().ColorChangerScript;






    }
    private void Start()
    {

        //initial values
        DisplayProperFaceValues();
    }

    private void Build_LocalDictionaryOfHoneySlotObjects()
    {
        HoneySlotRefDict.Add(AA, gameObject.transform.Find("HoneySlot_AA").gameObject);
        HoneySlotRefDict.Add(BB, gameObject.transform.Find("HoneySlot_BB").gameObject);
        HoneySlotRefDict.Add(CC, gameObject.transform.Find("HoneySlot_CC").gameObject);
        HoneySlotRefDict.Add(DD, gameObject.transform.Find("HoneySlot_DD").gameObject);
        HoneySlotRefDict.Add(EE, gameObject.transform.Find("HoneySlot_EE").gameObject);
        HoneySlotRefDict.Add(FF, gameObject.transform.Find("HoneySlot_FF").gameObject);
        HoneySlotRefDict.Add(GG, gameObject.transform.Find("HoneySlot_GG").gameObject);

        Debug.Log("honeyslots found: " + HoneySlotRefDict.Count);
    }

    public void Finalize_ThisHoneyComb()
    {

        Debug.Log("This honeycomb is finalized: " + HoneyComb_Address);




    }

    void DisplayProperFaceValues()
    {
        //loop slots
        foreach(var slot in HoneySlotRefDict)
        {
            //condense
            GameObject Piece = slot.Value.transform.GetChild(0).gameObject;
            SE_Piece PieceScript = Piece.GetComponent<SE_Piece>();

            //change all six face values - TEXT
            Piece.transform.Find("FaceValue_1").GetComponent<TextMeshPro>().text = Convert_FaceValueToString(PieceScript.fv_1);
            Piece.transform.Find("FaceValue_2").GetComponent<TextMeshPro>().text = Convert_FaceValueToString(PieceScript.fv_2);
            Piece.transform.Find("FaceValue_3").GetComponent<TextMeshPro>().text = Convert_FaceValueToString(PieceScript.fv_3);
            Piece.transform.Find("FaceValue_4").GetComponent<TextMeshPro>().text = Convert_FaceValueToString(PieceScript.fv_4);
            Piece.transform.Find("FaceValue_5").GetComponent<TextMeshPro>().text = Convert_FaceValueToString(PieceScript.fv_5);
            Piece.transform.Find("FaceValue_6").GetComponent<TextMeshPro>().text = Convert_FaceValueToString(PieceScript.fv_6);

            //get renderer
            MeshRenderer Renderer = Piece.GetComponent<MeshRenderer>();

            //copy material info
            Material[] MatArray = Renderer.materials;

            //change piece face texture
            if (PieceScript.IsMovable)
            {
                if (PieceScript.IsSpinnable)
                {
                    //full
                    MatArray[1] = M_Piece_Full;
                }
                else
                {
                    //mov
                    MatArray[1] = M_Piece_Move;
                }

            }
            else
            {
                if (PieceScript.IsSpinnable)
                {
                    //spin
                    MatArray[1] = M_Piece_Spin;
                }
                else
                {



                    //none - at default, no need to change
                }
            }

            //set to use altered MatArray
            Renderer.materials = MatArray;


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
