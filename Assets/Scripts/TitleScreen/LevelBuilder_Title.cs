using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static fv_FACEVALUE;
//using static wg_ADDRESS;
using TMPro;

public class LevelBuilder_Title : MonoBehaviour
{
    public WorldGrid_Title WorldGrid_TitleScript;
    public GameObject HodgePodge;
    public MaterialChanger MaterialChangerScript;

    Dictionary<wg_ADDRESS, GameObject> WGRefDict;

    public Material M_Piece_Full;
    public Material M_Piece_None;
    public Material M_Piece_Move;
    public Material M_Piece_Spin;

    public GameObject PF_Piece_Title;

    private void Awake()
    {
        WGRefDict = WorldGrid_TitleScript.WGRefDict;
    }


    public void BuildOut_ThisPuzzle(PuzzleInfo puz_info)
    {
        //loop HoneySlots
        foreach (HoneySlotInfo slot in puz_info.HoneySlots)
        {
            //make piece
            GameObject Piece = Instantiate(PF_Piece_Title);

            //condense
            Piece_Title PieceScript = Piece.GetComponent<Piece_Title>();

            //info transfer
            {
                //change all six face values
                PieceScript.fv_1 = slot.fv_1;
                PieceScript.fv_2 = slot.fv_2;
                PieceScript.fv_3 = slot.fv_3;
                PieceScript.fv_4 = slot.fv_4;
                PieceScript.fv_5 = slot.fv_5;
                PieceScript.fv_6 = slot.fv_6;

                //transfer attributes
                PieceScript.materialchanger = MaterialChangerScript;

                //change all six face values - TEXT
                Piece.transform.Find("FaceValue_1").GetComponent<TextMeshPro>().text = Convert_FaceValueToString(slot.fv_1);
                Piece.transform.Find("FaceValue_2").GetComponent<TextMeshPro>().text = Convert_FaceValueToString(slot.fv_2);
                Piece.transform.Find("FaceValue_3").GetComponent<TextMeshPro>().text = Convert_FaceValueToString(slot.fv_3);
                Piece.transform.Find("FaceValue_4").GetComponent<TextMeshPro>().text = Convert_FaceValueToString(slot.fv_4);
                Piece.transform.Find("FaceValue_5").GetComponent<TextMeshPro>().text = Convert_FaceValueToString(slot.fv_5);
                Piece.transform.Find("FaceValue_6").GetComponent<TextMeshPro>().text = Convert_FaceValueToString(slot.fv_6);
            }

            //material change
            {
                //get renderer
                MeshRenderer Renderer = Piece.GetComponent<MeshRenderer>();

                //copy material info
                Material[] MatArray = Renderer.materials;

                //change piece face texture
                if (slot.IsMovable)
                {
                    if (slot.IsSpinnable)
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
                    if (slot.IsSpinnable)
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

            //set location + rotation
            {

                //find location on WorldGrid
                Transform Location = WGRefDict[slot.Address].transform;

                //find rotation on WorldGrid
                Quaternion Rotation = WorldGrid_TitleScript.gameObject.transform.localRotation;

                //set position to HoneySlot
                Piece.transform.position = Location.position;

                //set rotation
                Piece.transform.rotation = Rotation;

                //set parent to HoneySlot
                Piece.transform.parent = WGRefDict[slot.Address].transform;

                //change sorting layer
                PieceScript.Change_SortingLayer_ToBack();
                    
            }
        }
    }

    public void Randomize_HodgePodge()
    {
        //loop three pieces
        foreach (Transform piece in HodgePodge.transform)
        {
            //loop 1-6, each face value
            for(int i=1; i<=6; i++)
            {
                //build string
                string facename = "FaceValue_" + i;

                //get rand value
                fv_FACEVALUE rand_value = LevelHouse.GetRandomFaceValue(true);

                //set new text
                piece.transform.Find(facename).GetComponent<TextMeshPro>().text = Convert_FaceValueToString(rand_value);
            }
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
