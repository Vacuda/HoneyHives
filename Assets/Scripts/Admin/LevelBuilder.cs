using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static fv_FACEVALUE;

public class LevelBuilder : MonoBehaviour
{
    LevelHouse LevelHouseScript;
    public WorldGrid WorldGridObject;
    Dictionary<wg_ADDRESS, GameObject> WGRefDict;

    public GameObject PF_Piece;

    private void Awake()
    {
        //find LevelHouseScript
        LevelHouseScript = gameObject.GetComponent<LevelHouse>();

        WGRefDict = WorldGridObject.GetComponent<WorldGrid>().WGRefDict;
    }

    private void Start()
    {
        
    }

    public void Build_ThisLevel(ln_LEVELNAME level)
    {
        //get LevelInfo from LevelHouse
        LevelInfo info = LevelHouseScript.Retrieve_ThisLevel(level);

        //loop HoneySlots
        foreach(HoneySlotInfo slot in info.HoneySlots)
        {
            //find location
            Transform Location = WGRefDict[slot.Address].transform;

            //if occupied
            if (slot.IsOccupied)
            {
                //make piece
                GameObject Piece = Instantiate(PF_Piece);

                //change all six face values
                Piece.GetComponent<Piece>().fv_1 = slot.fv_1;
                Piece.GetComponent<Piece>().fv_2 = slot.fv_2;
                Piece.GetComponent<Piece>().fv_3 = slot.fv_3;
                Piece.GetComponent<Piece>().fv_4 = slot.fv_4;
                Piece.GetComponent<Piece>().fv_5 = slot.fv_5;
                Piece.GetComponent<Piece>().fv_6 = slot.fv_6;

                //change all six face values - TEXT
                Piece.transform.Find("FaceValue_1").GetComponent<TextMesh>().text = Convert_FaceValueToString(slot.fv_1);
                Piece.transform.Find("FaceValue_2").GetComponent<TextMesh>().text = Convert_FaceValueToString(slot.fv_2);
                Piece.transform.Find("FaceValue_3").GetComponent<TextMesh>().text = Convert_FaceValueToString(slot.fv_3);
                Piece.transform.Find("FaceValue_4").GetComponent<TextMesh>().text = Convert_FaceValueToString(slot.fv_4);
                Piece.transform.Find("FaceValue_5").GetComponent<TextMesh>().text = Convert_FaceValueToString(slot.fv_5);
                Piece.transform.Find("FaceValue_6").GetComponent<TextMesh>().text = Convert_FaceValueToString(slot.fv_6);


                //set position to HoneySlot
                Piece.transform.position = Location.position;

                //set parent to HoneySlot
                Piece.transform.parent = WGRefDict[slot.Address].transform;
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
