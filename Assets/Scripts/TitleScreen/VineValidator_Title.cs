using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static wg_ADDRESS;
using static t_TRI;
using static fv_FACEVALUE;

//public struct VineBlock
//{
//    public VineBlock(fv_FACEVALUE val, int intval)
//    {
//        this.Value = val;
//        this.IntValue = intval;
//    }

//    public fv_FACEVALUE Value;
//    public int IntValue;
//}

public class VineValidator_Title : MonoBehaviour
{
    Dictionary<wg_ADDRESS, GameObject> WGRefDict;

    void Awake()
    {
        //copy reference
        WGRefDict = gameObject.GetComponent<WorldGrid_Title>().WGRefDict;
    }

    public void Validate_AllHoneyCombs()
    {

        Validate_ThisHoneyComb(AA);
        Validate_ThisHoneyComb(BB);
        Validate_ThisHoneyComb(CC);
        Validate_ThisHoneyComb(DD);
        Validate_ThisHoneyComb(EE);
        Validate_ThisHoneyComb(FF);
        Validate_ThisHoneyComb(GG);
    }

    public void Validate_ThisHoneyComb(wg_ADDRESS HoneyCombAddress)
    {
        //condense
        HoneyComb_Title ThisHoneyComb = WGRefDict[HoneyCombAddress].GetComponent<HoneyComb_Title>();

        //get truncated ref dictionary
        Dictionary<wg_ADDRESS, GameObject> HoneySlotRefDict = ThisHoneyComb.HoneySlotRefDict;

        //loop through nine flowers
        for (int i = 1; i <= 9; i++)
        {
            //build FlowerName
            string FlowerName = "FlowerIndicator_" + i;

            //if flower is good
            if (Validate_ThisFlower(HoneySlotRefDict, FlowerName))
            {
                //activate
                WGRefDict[HoneyCombAddress].transform.Find(FlowerName).GetComponent<FlowerIndicator_Title>().Inform_ColorChanger_OfActivationChange_Instant(true);
            }
            //if flower is bad
            else
            {
                //deactivate
                WGRefDict[HoneyCombAddress].transform.Find(FlowerName).GetComponent<FlowerIndicator_Title>().Inform_ColorChanger_OfActivationChange_Instant(false);
            }
        }
    }

    private bool Validate_ThisFlower(Dictionary<wg_ADDRESS, GameObject> HoneySlotRefDict, string flowername)
    {
        /*
         This finds each value that is needed, with a correct offset and sends it off for validation to 
        an overloaded function that will validate 4 values or 6.
         */

        switch (flowername)
        {
            case "FlowerIndicator_1":
                {
                    //null check
                    if (HoneySlotRefDict[GG].GetComponentInChildren<Piece_Title>() == null || HoneySlotRefDict[FF].GetComponentInChildren<Piece_Title>() == null)
                    {
                        return false;
                    }

                    fv_FACEVALUE val1 = HoneySlotRefDict[GG].GetComponentInChildren<Piece_Title>().Get_FaceValue_WithOffset(TRI_6);
                    fv_FACEVALUE val2 = HoneySlotRefDict[GG].GetComponentInChildren<Piece_Title>().Get_FaceValue_WithOffset(TRI_3);
                    fv_FACEVALUE val3 = HoneySlotRefDict[FF].GetComponentInChildren<Piece_Title>().Get_FaceValue_WithOffset(TRI_6);
                    fv_FACEVALUE val4 = HoneySlotRefDict[FF].GetComponentInChildren<Piece_Title>().Get_FaceValue_WithOffset(TRI_3);
                    return VineValidator.DoesThisValidate(val1, val2, val3, val4);
                }
            case "FlowerIndicator_2":
                {
                    //null check
                    if (HoneySlotRefDict[EE].GetComponentInChildren<Piece_Title>() == null || HoneySlotRefDict[DD].GetComponentInChildren<Piece_Title>() == null || HoneySlotRefDict[CC].GetComponentInChildren<Piece_Title>() == null)
                    {
                        return false;
                    }

                    fv_FACEVALUE val1 = HoneySlotRefDict[EE].GetComponentInChildren<Piece_Title>().Get_FaceValue_WithOffset(TRI_6);
                    fv_FACEVALUE val2 = HoneySlotRefDict[EE].GetComponentInChildren<Piece_Title>().Get_FaceValue_WithOffset(TRI_3);
                    fv_FACEVALUE val3 = HoneySlotRefDict[DD].GetComponentInChildren<Piece_Title>().Get_FaceValue_WithOffset(TRI_6);
                    fv_FACEVALUE val4 = HoneySlotRefDict[DD].GetComponentInChildren<Piece_Title>().Get_FaceValue_WithOffset(TRI_3);
                    fv_FACEVALUE val5 = HoneySlotRefDict[CC].GetComponentInChildren<Piece_Title>().Get_FaceValue_WithOffset(TRI_3);
                    fv_FACEVALUE val6 = HoneySlotRefDict[CC].GetComponentInChildren<Piece_Title>().Get_FaceValue_WithOffset(TRI_3);
                    return VineValidator.DoesThisValidate(val1, val2, val3, val4, val5, val6);
                }
            case "FlowerIndicator_3":
                {
                    //null check
                    if (HoneySlotRefDict[BB].GetComponentInChildren<Piece_Title>() == null || HoneySlotRefDict[AA].GetComponentInChildren<Piece_Title>() == null)
                    {
                        return false;
                    }

                    fv_FACEVALUE val1 = HoneySlotRefDict[BB].GetComponentInChildren<Piece_Title>().Get_FaceValue_WithOffset(TRI_6);
                    fv_FACEVALUE val2 = HoneySlotRefDict[BB].GetComponentInChildren<Piece_Title>().Get_FaceValue_WithOffset(TRI_3);
                    fv_FACEVALUE val3 = HoneySlotRefDict[AA].GetComponentInChildren<Piece_Title>().Get_FaceValue_WithOffset(TRI_6);
                    fv_FACEVALUE val4 = HoneySlotRefDict[AA].GetComponentInChildren<Piece_Title>().Get_FaceValue_WithOffset(TRI_3);
                    return VineValidator.DoesThisValidate(val1, val2, val3, val4);
                }
            case "FlowerIndicator_4":
                {
                    //null check
                    if (HoneySlotRefDict[EE].GetComponentInChildren<Piece_Title>() == null || HoneySlotRefDict[GG].GetComponentInChildren<Piece_Title>() == null)
                    {
                        return false;
                    }

                    fv_FACEVALUE val1 = HoneySlotRefDict[EE].GetComponentInChildren<Piece_Title>().Get_FaceValue_WithOffset(TRI_5);
                    fv_FACEVALUE val2 = HoneySlotRefDict[EE].GetComponentInChildren<Piece_Title>().Get_FaceValue_WithOffset(TRI_2);
                    fv_FACEVALUE val3 = HoneySlotRefDict[GG].GetComponentInChildren<Piece_Title>().Get_FaceValue_WithOffset(TRI_5);
                    fv_FACEVALUE val4 = HoneySlotRefDict[GG].GetComponentInChildren<Piece_Title>().Get_FaceValue_WithOffset(TRI_2);
                    return VineValidator.DoesThisValidate(val1, val2, val3, val4);
                }
            case "FlowerIndicator_5":
                {
                    //null check
                    if (HoneySlotRefDict[BB].GetComponentInChildren<Piece_Title>() == null || HoneySlotRefDict[DD].GetComponentInChildren<Piece_Title>() == null || HoneySlotRefDict[FF].GetComponentInChildren<Piece_Title>() == null)
                    {
                        return false;
                    }

                    fv_FACEVALUE val1 = HoneySlotRefDict[BB].GetComponentInChildren<Piece_Title>().Get_FaceValue_WithOffset(TRI_5);
                    fv_FACEVALUE val2 = HoneySlotRefDict[BB].GetComponentInChildren<Piece_Title>().Get_FaceValue_WithOffset(TRI_2);
                    fv_FACEVALUE val3 = HoneySlotRefDict[DD].GetComponentInChildren<Piece_Title>().Get_FaceValue_WithOffset(TRI_5);
                    fv_FACEVALUE val4 = HoneySlotRefDict[DD].GetComponentInChildren<Piece_Title>().Get_FaceValue_WithOffset(TRI_2);
                    fv_FACEVALUE val5 = HoneySlotRefDict[FF].GetComponentInChildren<Piece_Title>().Get_FaceValue_WithOffset(TRI_5);
                    fv_FACEVALUE val6 = HoneySlotRefDict[FF].GetComponentInChildren<Piece_Title>().Get_FaceValue_WithOffset(TRI_2);
                    return VineValidator.DoesThisValidate(val1, val2, val3, val4, val5, val6);
                }
            case "FlowerIndicator_6":
                {
                    //null check
                    if (HoneySlotRefDict[AA].GetComponentInChildren<Piece_Title>() == null || HoneySlotRefDict[CC].GetComponentInChildren<Piece_Title>() == null)
                    {
                        return false;
                    }

                    fv_FACEVALUE val1 = HoneySlotRefDict[AA].GetComponentInChildren<Piece_Title>().Get_FaceValue_WithOffset(TRI_5);
                    fv_FACEVALUE val2 = HoneySlotRefDict[AA].GetComponentInChildren<Piece_Title>().Get_FaceValue_WithOffset(TRI_2);
                    fv_FACEVALUE val3 = HoneySlotRefDict[CC].GetComponentInChildren<Piece_Title>().Get_FaceValue_WithOffset(TRI_5);
                    fv_FACEVALUE val4 = HoneySlotRefDict[CC].GetComponentInChildren<Piece_Title>().Get_FaceValue_WithOffset(TRI_2);
                    return VineValidator.DoesThisValidate(val1, val2, val3, val4);
                }
            case "FlowerIndicator_7":
                {
                    //null check
                    if (HoneySlotRefDict[BB].GetComponentInChildren<Piece_Title>() == null || HoneySlotRefDict[EE].GetComponentInChildren<Piece_Title>() == null)
                    {
                        return false;
                    }

                    fv_FACEVALUE val1 = HoneySlotRefDict[BB].GetComponentInChildren<Piece_Title>().Get_FaceValue_WithOffset(TRI_4);
                    fv_FACEVALUE val2 = HoneySlotRefDict[BB].GetComponentInChildren<Piece_Title>().Get_FaceValue_WithOffset(TRI_1);
                    fv_FACEVALUE val3 = HoneySlotRefDict[EE].GetComponentInChildren<Piece_Title>().Get_FaceValue_WithOffset(TRI_4);
                    fv_FACEVALUE val4 = HoneySlotRefDict[EE].GetComponentInChildren<Piece_Title>().Get_FaceValue_WithOffset(TRI_1);
                    return VineValidator.DoesThisValidate(val1, val2, val3, val4);
                }
            case "FlowerIndicator_8":
                {
                    //null check
                    if (HoneySlotRefDict[AA].GetComponentInChildren<Piece_Title>() == null || HoneySlotRefDict[DD].GetComponentInChildren<Piece_Title>() == null || HoneySlotRefDict[GG].GetComponentInChildren<Piece_Title>() == null)
                    {
                        return false;
                    }

                    fv_FACEVALUE val1 = HoneySlotRefDict[AA].GetComponentInChildren<Piece_Title>().Get_FaceValue_WithOffset(TRI_4);
                    fv_FACEVALUE val2 = HoneySlotRefDict[AA].GetComponentInChildren<Piece_Title>().Get_FaceValue_WithOffset(TRI_1);
                    fv_FACEVALUE val3 = HoneySlotRefDict[DD].GetComponentInChildren<Piece_Title>().Get_FaceValue_WithOffset(TRI_4);
                    fv_FACEVALUE val4 = HoneySlotRefDict[DD].GetComponentInChildren<Piece_Title>().Get_FaceValue_WithOffset(TRI_1);
                    fv_FACEVALUE val5 = HoneySlotRefDict[GG].GetComponentInChildren<Piece_Title>().Get_FaceValue_WithOffset(TRI_4);
                    fv_FACEVALUE val6 = HoneySlotRefDict[GG].GetComponentInChildren<Piece_Title>().Get_FaceValue_WithOffset(TRI_1);
                    return VineValidator.DoesThisValidate(val1, val2, val3, val4, val5, val6);
                }
            case "FlowerIndicator_9":
                {
                    //null check
                    if (HoneySlotRefDict[CC].GetComponentInChildren<Piece_Title>() == null || HoneySlotRefDict[FF].GetComponentInChildren<Piece_Title>() == null)
                    {
                        return false;
                    }

                    fv_FACEVALUE val1 = HoneySlotRefDict[CC].GetComponentInChildren<Piece_Title>().Get_FaceValue_WithOffset(TRI_4);
                    fv_FACEVALUE val2 = HoneySlotRefDict[CC].GetComponentInChildren<Piece_Title>().Get_FaceValue_WithOffset(TRI_1);
                    fv_FACEVALUE val3 = HoneySlotRefDict[FF].GetComponentInChildren<Piece_Title>().Get_FaceValue_WithOffset(TRI_4);
                    fv_FACEVALUE val4 = HoneySlotRefDict[FF].GetComponentInChildren<Piece_Title>().Get_FaceValue_WithOffset(TRI_1);
                    return VineValidator.DoesThisValidate(val1, val2, val3, val4);
                }
            default:
                return false;
        }
    }
}
