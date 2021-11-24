using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static wg_ADDRESS;
using static t_TRI;
using static fv_FACEVALUE;

public class VineValidator : MonoBehaviour
{
    Dictionary<wg_ADDRESS, GameObject> WGRefDict;

    void Start()
    {
        //copy reference
        WGRefDict = gameObject.GetComponent<WorldGrid>().WGRefDict;
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
        //get truncated ref dictionary
        Dictionary<wg_ADDRESS, GameObject> HoneySlotRefDict = WGRefDict[HoneyCombAddress].GetComponent<HoneyComb>().HoneySlotRefDict;

        //loop through nine flowers
        for (int i=1; i<=9; i++)
        {
            //string FlowerName = Convert_IntToFlowerName(i);
            string FlowerName = "FlowerIndicator_" + i;

            //if flower is good
            if (Validate_ThisFlower(HoneySlotRefDict, FlowerName))
            {
                //activate
                WGRefDict[HoneyCombAddress].transform.Find(FlowerName).GetComponent<FlowerIndicator>().Activate_Flower();
            }
            //if flower is bad
            else
            {
                //deactivate
                WGRefDict[HoneyCombAddress].transform.Find(FlowerName).GetComponent<FlowerIndicator>().Deactivate_Flower();

            }
        }
    }

    private bool DoesThisValidate(fv_FACEVALUE val1, fv_FACEVALUE val2, fv_FACEVALUE val3, fv_FACEVALUE val4)
    {
        Debug.Log("VALUES: " + val1 + " - " + val2 + " - " + val3 + " - " + val4);

        //if val1 or val4 is equals
        if (val1 == v_equals || val4 == v_equals)
        {
            // b = = =
            if(val1 == v_blank && val2 == v_equals && val3 == v_equals && val4 == v_equals)
            {
                return true;
            }
            // = b = =
            if (val1 == v_equals && val2 == v_blank && val3 == v_equals && val4 == v_equals)
            {
                return true;
            }
            // = = b =
            if (val1 == v_equals && val2 == v_equals && val3 == v_blank && val4 == v_equals)
            {
                return true;
            }
            // = = = b
            if (val1 == v_equals && val2 == v_equals && val3 == v_equals && val4 == v_blank)
            {
                return true;
            }

            return false;
        }
        //if val2 is equals
        if (val2 == v_equals)
        {
            // + = ? ?
            if (val1 == v_add)
            {
                // + = +
                if ((val3 == v_add && val4 == v_blank) || (val3 == v_blank && val4 == v_add))
                {
                    return true;
                }

                return false;
            }
            // - = ? ?
            if (val1 == v_sub)
            {
                // - = -
                if ((val3 == v_sub && val4 == v_blank) || (val3 == v_blank && val4 == v_sub))
                {
                    return true;
                }

                return false;
            }
            // blank = ? ?
            if (val1 == v_blank)
            {
                // blank = blank
                if (val3 == v_blank && val4 == v_blank)
                {
                    return true;
                }

                return false;
            }
            // Non-Negative Digit = ? ?
            {
                int LeftDigit = Get_Digit(val1);

                // LeftDigit = + ?
                if(val3 == v_add)
                {
                    // LeftDigit = + Digit
                    if (IsDigit(val4))
                    {
                        //LeftDigit = RightDigit
                        if(LeftDigit == Get_Digit(val4))
                        {
                            return true;
                        }
                    }

                    return false;
                }

                // LeftDigit = - ?
                if(val3 == v_sub)
                {
                    // LeftDigit = - 0
                    if(val4 == v_0)
                    {
                        // LeftDigit = 0
                        if(LeftDigit == 0)
                        {
                            return true;
                        }
                    }

                    return false;
                }

                // LeftDigit = blank ?
                if(val3 == v_blank)
                {
                    // LeftDigit = Digit
                    if (IsDigit(val4))
                    {
                        // LeftDigit = RightDigit
                        if(LeftDigit == Get_Digit(val4))
                        {
                            return true;
                        }
                    }

                    return false;
                }
                // LeftDigit = Digit ?
                {
                    //LeftDigit = RightDigit ?
                    if(LeftDigit == Get_Digit(val3))
                    {
                        // LeftDigit = RightDigit v_blank
                        if(val4 == v_blank)
                        {
                            return true;
                        }
                        //nothing else works
                    }
                    //LeftDigit = 0 ?
                    if(Get_Digit(val3) == 0)
                    {
                        //LeftDigit = 0 RightDigit
                        if(LeftDigit == Get_Digit(val4))
                        {
                            return true;
                        }
                    }

                    return false;
                }
            }  
        }
        //if val3 is equals
        if (val3 == v_equals)
        {
            // ? ? = +
            if (val4 == v_add)
            {
                // + ? = +
                if (val1 == v_add)
                {
                    // + blank = +
                    if (val2 == v_blank)
                    {
                        return true;
                    }

                    return false;
                }
                // - ? = +
                if (val1 == v_sub)
                {
                    return false;
                }
                // blank ? = +
                if (val1 == v_blank)
                {
                    // + = +
                    if (val2 == v_add)
                    {
                        return true;
                    }

                    return false;
                }
                // Digit ? = +
                {
                    return false;
                }
            }
            // ? ? = -
            if (val4 == v_sub)
            {
                // + ? = -
                if (val1 == v_add)
                {
                    return false;
                }
                // - ? = -
                if (val1 == v_sub)
                {
                    // - blank = -
                    if (val2 == v_blank)
                    {
                        return true;
                    }

                    return false;
                }
                // blank ? = -
                if (val1 == v_blank)
                {
                    // - = -
                    if (val2 == v_sub)
                    {
                        return true;
                    }

                    return false;
                }
                // Digit ? = -
                {
                    return false;
                }
            }
            // ? ? = blank
            if (val4 == v_blank)
            {
                // blank = blank
                if (val1 == v_blank && val2 == v_blank)
                {
                    return true;
                }

                return false;
            }
            // ? ? = Non-Negative Digit
            {
                int RightDigit = Get_Digit(val4);

                // + ? = RightDigit
                if (val1 == v_add)
                {
                    // + Digit = RightDigit
                    if (IsDigit(val2))
                    {
                        // LeftDigit = RightDigit
                        if (Get_Digit(val2) == RightDigit)
                        {
                            return true;
                        }
                    }

                    return false;
                }
                // - ? = RightDigit
                if (val1 == v_sub)
                {
                    // - 0 = RightDigit
                    if (val2 == v_0)
                    {
                        // 0 == RightDigit
                        if (RightDigit == 0)
                        {
                            return true;
                        }
                    }

                    return false;
                }
                // blank ? = RightDigit
                if (val1 == v_blank)
                {
                    // blank Digit = RightDigit
                    if (IsDigit(val2))
                    {
                        //LeftDigit = RightDigit
                        if (Get_Digit(val2) == RightDigit)
                        {
                            return true;
                        }
                    }

                    return false;
                }
                // Digit ? = RightDigit
                {
                    // Digit blank = RightDigit
                    if (val2 == v_blank)
                    {
                        //LeftDigit = RightDigit
                        if (Get_Digit(val1) == RightDigit)
                        {
                            return true;
                        }
                    }
                    // 0 ? = RightDigit
                    if(val1 == v_0)
                    {
                        //0 Digit = RightDigit
                        if(Get_Digit(val2) == RightDigit)
                        {
                            return true;
                        }
                    }

                    return false;
                }
            }

        }


    /* No EQUAL signs detected * /

        5 + = 0 5 +

        5, 2201, =, 5 2201

        //if not same amount of shapes, false
        //loop indexes
        //if left[1] != right[1], false
        //if left[2] != right[2], false


        5, 2001, =, 5

        5 = 5 = 5 =

        -05-b+      
        -5, -, +

        Now, we've dealt with all equals signs which had turned the validation into an equation.

        I believe, now we look for edge cases around v_sub and v_add

        When v_sub and v_add are before ints, they act as positive or negative attributes to the ints.

        When they are after, they are math symbols

        5+ is wrong
        + + + is okay

        if (5 + = 5 +) because they turn into shapes, then this exception turns them back into shapes

        5+ != 5


        -/+                     are shapes
        -/+ after digits        are math symbols
        -/+ before equals       are shapes

        -07

        --0-

        */




        return true;
    }

    private bool DoesThisValidate(fv_FACEVALUE val1, fv_FACEVALUE val2, fv_FACEVALUE val3, fv_FACEVALUE val4, fv_FACEVALUE val5, fv_FACEVALUE val6)
    {
        return false;
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
                    fv_FACEVALUE val1 = HoneySlotRefDict[GG].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_6);
                    fv_FACEVALUE val2 = HoneySlotRefDict[GG].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_3);
                    fv_FACEVALUE val3 = HoneySlotRefDict[FF].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_6);
                    fv_FACEVALUE val4 = HoneySlotRefDict[FF].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_3);
                    return DoesThisValidate(val1, val2, val3, val4);
                }
            case "FlowerIndicator_2":
                {
                    fv_FACEVALUE val1 = HoneySlotRefDict[EE].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_6);
                    fv_FACEVALUE val2 = HoneySlotRefDict[EE].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_3);
                    fv_FACEVALUE val3 = HoneySlotRefDict[DD].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_6);
                    fv_FACEVALUE val4 = HoneySlotRefDict[DD].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_3);
                    fv_FACEVALUE val5 = HoneySlotRefDict[CC].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_3);
                    fv_FACEVALUE val6 = HoneySlotRefDict[CC].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_3);
                    return DoesThisValidate(val1, val2, val3, val4, val5, val6);
                }
            case "FlowerIndicator_3":
                {
                    fv_FACEVALUE val1 = HoneySlotRefDict[BB].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_6);
                    fv_FACEVALUE val2 = HoneySlotRefDict[BB].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_3);
                    fv_FACEVALUE val3 = HoneySlotRefDict[AA].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_6);
                    fv_FACEVALUE val4 = HoneySlotRefDict[AA].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_3);
                    return DoesThisValidate(val1, val2, val3, val4);
                }
            case "FlowerIndicator_4":
                {
                    fv_FACEVALUE val1 = HoneySlotRefDict[EE].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_5);
                    fv_FACEVALUE val2 = HoneySlotRefDict[EE].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_2);
                    fv_FACEVALUE val3 = HoneySlotRefDict[GG].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_5);
                    fv_FACEVALUE val4 = HoneySlotRefDict[GG].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_2);
                    return DoesThisValidate(val1, val2, val3, val4);
                }
            case "FlowerIndicator_5":
                {
                    fv_FACEVALUE val1 = HoneySlotRefDict[BB].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_5);
                    fv_FACEVALUE val2 = HoneySlotRefDict[BB].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_2);
                    fv_FACEVALUE val3 = HoneySlotRefDict[DD].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_5);
                    fv_FACEVALUE val4 = HoneySlotRefDict[DD].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_2);
                    fv_FACEVALUE val5 = HoneySlotRefDict[FF].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_5);
                    fv_FACEVALUE val6 = HoneySlotRefDict[FF].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_2);
                    return DoesThisValidate(val1, val2, val3, val4, val5, val6);
                }
            case "FlowerIndicator_6":
                {
                    fv_FACEVALUE val1 = HoneySlotRefDict[AA].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_5);
                    fv_FACEVALUE val2 = HoneySlotRefDict[AA].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_2);
                    fv_FACEVALUE val3 = HoneySlotRefDict[CC].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_5);
                    fv_FACEVALUE val4 = HoneySlotRefDict[CC].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_2);
                    return DoesThisValidate(val1, val2, val3, val4);
                }
            case "FlowerIndicator_7":
                {
                    fv_FACEVALUE val1 = HoneySlotRefDict[BB].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_4);
                    fv_FACEVALUE val2 = HoneySlotRefDict[BB].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_1);
                    fv_FACEVALUE val3 = HoneySlotRefDict[EE].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_4);
                    fv_FACEVALUE val4 = HoneySlotRefDict[EE].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_1);
                    return DoesThisValidate(val1, val2, val3, val4);
                }
            case "FlowerIndicator_8":
                {
                    fv_FACEVALUE val1 = HoneySlotRefDict[AA].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_4);
                    fv_FACEVALUE val2 = HoneySlotRefDict[AA].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_1);
                    fv_FACEVALUE val3 = HoneySlotRefDict[DD].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_4);
                    fv_FACEVALUE val4 = HoneySlotRefDict[DD].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_1);
                    fv_FACEVALUE val5 = HoneySlotRefDict[GG].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_4);
                    fv_FACEVALUE val6 = HoneySlotRefDict[GG].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_1);
                    return DoesThisValidate(val1, val2, val3, val4, val5, val6);
                }
            case "FlowerIndicator_9":
                {
                    fv_FACEVALUE val1 = HoneySlotRefDict[CC].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_4);
                    fv_FACEVALUE val2 = HoneySlotRefDict[CC].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_1);
                    fv_FACEVALUE val3 = HoneySlotRefDict[FF].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_4);
                    fv_FACEVALUE val4 = HoneySlotRefDict[FF].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_1);
                    return DoesThisValidate(val1, val2, val3, val4);
                }
            default:
                return false;
        }






        //switch (flower)
        //{
        //    case 1:
        //        {
        //            fv_FACEVALUE val1 = WGRefDict[addresses[0]].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_6);
        //            fv_FACEVALUE val2 = WGRefDict[addresses[0]].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_3);
        //            fv_FACEVALUE val3 = WGRefDict[addresses[1]].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_6);
        //            fv_FACEVALUE val4 = WGRefDict[addresses[1]].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_3);

        //            Debug.Log("ORDER:    " + val1 + " " + val2 + " " + val3 + " " + val4);

        //            return DoesThisValidate(val1, val2, val3, val4);
        //        }

        //}

    }

//Utilities
    private int Get_Digit(fv_FACEVALUE val)
    {
        switch (val)
        {
            case v_0:
                return 0;
            case v_1:
                return 1;
            case v_2:
                return 2;
            case v_3:
                return 3;
            case v_4:
                return 4;
            case v_5:
                return 5;
            case v_6:
                return 6;
            case v_7:
                return 7;
            case v_8:
                return 8;
            case v_9:
                return 9;
            default:
                return 99;
        }
    }

    private bool IsDigit(fv_FACEVALUE val)
    {
        if (val == v_0 || val == v_1 || val == v_2 || val == v_3 || val == v_4 || val == v_5 || val == v_6 || val == v_7 || val == v_8 || val == v_9)
        {
            return true;
        }

        return false;  
    }




}
