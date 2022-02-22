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
    //private WorldGrid WorldGridScript;
    private bool bIsFinalized = false;
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

        HC_WireFrameRenderer = gameObject.GetComponent<MeshRenderer>();
        HC_BackgroundRenderer = gameObject.transform.Find("BG").GetComponent<MeshRenderer>();
        HC_WireframeMaterial = new MaterialPropertyBlock();
        HC_BackgroundMaterial = new MaterialPropertyBlock();




    }
    private void Start()
    {
        Inform_ColorChanger_OfActivationChange_Instant(true);

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
        bIsFinalized = true;
        Debug.Log("This honeycomb is finalized: " + HoneyComb_Address);

        if (bIsFinalized)
        {

        }

        //Finalize_CopyAndPlaceRelevantPieces();

        //Finalize_HC_BackgroundMaterial();
        //Finalize_HC_WireframeMaterial();
        //Finalize_DeactivatedPieceMaterials();
        //Finalize_FreeHoneyLockedPiece();
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

    //public bool IsHoneyComb_Finalized()
    //{
    //    return bIsFinalized;
    //}

    //private void Finalize_HC_WireframeMaterial()
    //{
    //    ColorChangerScript.ChangeColorActivation_Lerp(HC_WireFrameRenderer, HC_WireframeMaterial, c_HC_WIRE, false);

    //}

    //private void Finalize_HC_BackgroundMaterial()
    //{
    //    ColorChangerScript.ChangeColorActivation_Lerp(HC_BackgroundRenderer, HC_BackgroundMaterial, c_HC_BACK, false);
    //}

    private void Inform_ColorChanger_OfActivationChange_Instant(bool activation)
    {

        ColorChangerScript.ChangeColorActivation_Instant(HC_WireFrameRenderer, HC_WireframeMaterial, c_HC_WIRE, activation);
        ColorChangerScript.ChangeColorActivation_Instant(HC_BackgroundRenderer, HC_BackgroundMaterial, c_HC_BACK, activation);
    }

    

    //private void Finalize_DeactivatedPieceMaterials()
    //{
    //    //loop honey slots
    //    foreach (var honeyslot in HoneySlotRefDict)
    //    {

    //        //condense
    //        GameObject slot = honeyslot.Value;

    //        //if piece in slot
    //        if (slot.transform.childCount == 3)
    //        {

    //            //condense
    //            Piece PieceScript = slot.transform.GetChild(2).gameObject.GetComponent<Piece>();

    //            //deactivate
    //            PieceScript.Deactivate_Piece();
    //        }
    //    }
    //}



}
