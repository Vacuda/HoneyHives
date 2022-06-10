using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static fv_FACEVALUE;
using static wg_ADDRESS;
using TMPro;

public class LevelBuilder : MonoBehaviour
{
    public WorldGrid WorldGridScript;
    public HoneyLock HoneyLockScript;
    public PieceGlobals PieceGlobalsScript;
    public ColorChanger ColorChangerScript;
    public MaterialChanger MaterialChangerScript;
    public GameObject BeeBoxPanel;
    public TMP_FontAsset EqualsHighlight_Font;

    Dictionary<wg_ADDRESS, GameObject> WGRefDict;
    public PlayerController Controller;
    public Camera MainCamera;

    public Material M_Piece_Full;
    public Material M_Piece_None;
    public Material M_Piece_Move;
    public Material M_Piece_Spin;

    public GameObject PF_Piece;

    private void Awake()
    {
        WGRefDict = WorldGridScript.WGRefDict;
    }


    public void BuildOut_ThisPuzzle(PuzzleInfo puz_info)
    {
        //loop HoneySlots
        foreach (HoneySlotInfo slot in puz_info.HoneySlots)
        {
            //make piece
            GameObject Piece = Instantiate(PF_Piece);

            //condense
            Piece PieceScript = Piece.GetComponent<Piece>();

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
                PieceScript.IsMovable = slot.IsMovable;
                PieceScript.IsSpinnable = slot.IsSpinnable;
                PieceScript.Controller = Controller;
                PieceScript.MainCamera = MainCamera;
                PieceScript.pg = PieceGlobalsScript;
                PieceScript.colorchanger = ColorChangerScript;
                PieceScript.materialchanger = MaterialChangerScript;
                PieceScript.BeeBoxPanel = BeeBoxPanel;

                //create build aid
                fv_FACEVALUE[] fv_array = new fv_FACEVALUE[6] {slot.fv_1, slot.fv_2, slot.fv_3, slot.fv_4, slot.fv_5, slot.fv_6};

                //set index
                int index = 0;

                //loop faces
                foreach(Transform face in Piece.transform)
                {
                    //get TMPro
                    TextMeshPro current_tmpro = face.GetComponent<TextMeshPro>();

                    //change to proper text
                    current_tmpro.text = Convert_FaceValueToString(fv_array[index]);

                    //check if equals
                    if(fv_array[index] == v_equals)
                    {
                        //change font asset to equalshighlight
                        current_tmpro.font = EqualsHighlight_Font;

                        //change text size
                        current_tmpro.fontSize = 5;
                    }

                    //iterate index
                    index++;
                }
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
                        //no front material change - at default, no need to change

                        //change unmovabales to green
                        MaterialChangerScript.MaterialChange_Instant(Piece);

                        //set to deactivated
                        PieceScript.SetTo_Deactivated();
                    }
                }

                //set to use altered MatArray
                Renderer.materials = MatArray;
            }

            //set location
            {
                //if HoneyJar Piece
                if (slot.HoneyJar_Originated){

                    //change scale
                    PieceScript.Change_Scale_ToHoneyJar();

                    //change sorting layer
                    PieceScript.Change_SortingLayer_ToMid();

                    //change position - offscreen
                    Piece.transform.position = PieceGlobalsScript.OffsiteLocation;

                    //add to honeylock dictionary
                    HoneyLockScript.AddTo_HoneyLockPieceDictionary(slot.Address, Piece);
                }
                else
                {
                    //if movable
                    if (slot.IsMovable)
                    {
                        //put in beebox
                        PieceScript.FindPlacement_OnBeeBox();
                    }
                    else
                    {
                        //find location on WorldGrid
                        Transform Location = WGRefDict[slot.Address].transform;

                        //set position to HoneySlot
                        Piece.transform.position = Location.position;

                        //set parent to HoneySlot
                        Piece.transform.parent = WGRefDict[slot.Address].transform;

                        //change sorting layer
                        PieceScript.Change_SortingLayer_ToBack();
                    }
                }    
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
