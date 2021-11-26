using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static wg_ADDRESS;
using static t_TRI;
using static fv_FACEVALUE;

public struct VineBlock
{
    public VineBlock(fv_FACEVALUE val, int intval)
    {
        this.Value = val;
        this.IntValue = intval;
    }

    public fv_FACEVALUE Value;
    public int IntValue;
}

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
        //find amount of equals in values
        int EqualsAmount = Get_AmountOfEqualsValues(val1, val2, val3, val4);

        //validate according to EqualsAmount
        switch (EqualsAmount)
        {
            case 0:
                return true;
            case 1:
                return Validate_With_1_Equals(val1, val2, val3, val4);
            case 2:
                return false;
            case 3:
                return Validate_With_3_Equals(val1, val2, val3, val4);
            case 4:
                return false;
            default:
                return false;
        }
    }

    private bool DoesThisValidate(fv_FACEVALUE val1, fv_FACEVALUE val2, fv_FACEVALUE val3, fv_FACEVALUE val4, fv_FACEVALUE val5, fv_FACEVALUE val6)
    {
        //find amount of equals in values
        int EqualsAmount = Get_AmountOfEqualsValues(val1, val2, val3, val4, val5, val6);

        //validate according to EqualsAmount
        switch (EqualsAmount)
        {
            case 0: 
                return true;
            case 1:
                return Validate_With_1_Equals(val1, val2, val3, val4, val5, val6);
            case 2:
                return false;
            case 3:
                return Validate_With_3_Equals(val1, val2, val3, val4, val5, val6);
            case 4:
                return false;
            case 5:
                return Validate_With_5_Equals(val1, val2, val3, val4, val5, val6);
            case 6:
                return false;
            default: 
                return false;
        }
    }

    private bool Validate_With_1_Equals(fv_FACEVALUE val1, fv_FACEVALUE val2, fv_FACEVALUE val3, fv_FACEVALUE val4)
    {


        //separate into Left and Right lists
        //remove blanks
        //remove zeros
        //merge ints
        //remove plus signs, but not do math
        //incorporate minus signs into ints, AND do math
        //do plus sign math
        //check each side for equality

        //put values into list
        List<VineBlock> AllValues = new List<VineBlock>();
        AllValues.Add(new VineBlock(val1, 0));
        AllValues.Add(new VineBlock(val2, 0));
        AllValues.Add(new VineBlock(val3, 0));
        AllValues.Add(new VineBlock(val4, 0));

        //create a left and right side list
        List<VineBlock> Left_Values = new List<VineBlock>();
        List<VineBlock> Right_Values = new List<VineBlock>();

        // runner to interpret left or right side of equation
        bool SideTrigger = false;

        //loop all 4 values, also remove blanks
        foreach (VineBlock vblock in AllValues)
        {
            //set equals trigger
            if (vblock.Value == v_equals)
            {
                SideTrigger = true;
                continue;
            }

            // skip, if blank
            if (vblock.Value == v_blank)
            {
                continue;
            }

            //left side
            if (SideTrigger == false)
            {
                //add to left
                Left_Values.Add(vblock);
            }
            //right side
            if (SideTrigger == true)
            {
                //add to right
                Right_Values.Add(vblock);
            }
        }

        PossiblyEliminate_Zeros(ref Left_Values);
        PossiblyEliminate_Zeros(ref Right_Values);

        PossiblyMerge_Ints(ref Left_Values);
        PossiblyMerge_Ints(ref Right_Values);

        PossiblyEliminate_PlusSigns_NoMath(ref Left_Values);
        PossiblyEliminate_PlusSigns_NoMath(ref Right_Values);

        PossiblyEliminate_MinusSigns_YesMath(ref Left_Values);
        PossiblyEliminate_MinusSigns_YesMath(ref Right_Values);

        PossiblyEliminate_PlusSigns_OnlyMath(ref Left_Values);
        PossiblyEliminate_PlusSigns_OnlyMath(ref Right_Values);


    /* Scrubbing Done.  Check If Equal Now */

        //if equal side counts
        if (Right_Values.Count == Left_Values.Count)
        {
            //loop indexes
            for (int i = 0; i < Right_Values.Count; i++)
            {
                //if no match
                if (Right_Values[i].Value != Left_Values[i].Value)
                {
                    return false;
                }
                //if both are v_int
                if (Right_Values[i].Value == v_int)
                {
                    //if IntValues don't match
                    if (Right_Values[i].IntValue != Right_Values[i].IntValue)
                    {
                        return false;
                    }
                }
            }

            /* Everything matches */

            return true;
        }

        //safety
        return false;
    }

    private bool Validate_With_1_Equals(fv_FACEVALUE val1, fv_FACEVALUE val2, fv_FACEVALUE val3, fv_FACEVALUE val4, fv_FACEVALUE val5, fv_FACEVALUE val6)
    {
        //separate into Left and Right lists
        //remove blanks
        //remove zeros
        //merge ints
        //remove plus signs, but not do math
        //incorporate minus signs into ints, AND do math
        //do plus sign math
        //check each side for equality

        //put values into list
        List<VineBlock> AllValues = new List<VineBlock>();
        AllValues.Add(new VineBlock(val1, 0));
        AllValues.Add(new VineBlock(val2, 0));
        AllValues.Add(new VineBlock(val3, 0));
        AllValues.Add(new VineBlock(val4, 0));
        AllValues.Add(new VineBlock(val5, 0));
        AllValues.Add(new VineBlock(val6, 0));

        //create a left and right side list
        List<VineBlock> Left_Values = new List<VineBlock>();
        List<VineBlock> Right_Values = new List<VineBlock>();

        // runner to interpret left or right side of equation
        bool SideTrigger = false;

        //loop all 6 values, also remove blanks
        foreach (VineBlock vblock in AllValues)
        {
            //set equals trigger
            if (vblock.Value == v_equals)
            {
                SideTrigger = true;
                continue;
            }

            // skip, if blank
            if (vblock.Value == v_blank)
            {
                continue;
            }

            //left side
            if (SideTrigger == false)
            {
                //add to left
                Left_Values.Add(vblock);
            }
            //right side
            if (SideTrigger == true)
            {
                //add to right
                Right_Values.Add(vblock);
            }
        }


        PossiblyEliminate_Zeros(ref Left_Values);
        PossiblyEliminate_Zeros(ref Right_Values);

        PossiblyMerge_Ints(ref Left_Values);
        PossiblyMerge_Ints(ref Right_Values);

        PossiblyEliminate_PlusSigns_NoMath(ref Left_Values);
        PossiblyEliminate_PlusSigns_NoMath(ref Right_Values);

        PossiblyEliminate_MinusSigns_YesMath(ref Left_Values);
        PossiblyEliminate_MinusSigns_YesMath(ref Right_Values);

        PossiblyEliminate_PlusSigns_OnlyMath(ref Left_Values);
        PossiblyEliminate_PlusSigns_OnlyMath(ref Right_Values);

        //Debug.Log("LeftValues------ ");
        //foreach(VineBlock block in Left_Values)
        //{
        //    if(block.Value == v_int)
        //    {
        //        Debug.Log("LeftValues: int " + block.IntValue);
        //        continue;
        //    }
        //    Debug.Log("LeftValues: " + block.Value);
        //}
        //Debug.Log("RightValues------ ");
        //foreach (VineBlock block in Right_Values)
        //{
        //    if (block.Value == v_int)
        //    {
        //        Debug.Log("RightValues: int " + block.IntValue);
        //        continue;
        //    }
        //    Debug.Log("RightValues: " + block.Value);
        //}


    /* Scrubbing Done.  Check If Equal Now */

        //if equal side counts
        if (Right_Values.Count == Left_Values.Count)
        {
            //loop indexes
            for (int i = 0; i < Right_Values.Count; i++)
            {
                //if no match
                if (Right_Values[i].Value != Left_Values[i].Value)
                {
                    return false;
                }
                //if both are v_int
                if (Right_Values[i].Value == v_int)
                {
                    //if IntValues don't match
                    if (Left_Values[i].IntValue != Right_Values[i].IntValue)
                    {
                        return false;
                    }
                }
            }

            /* Everything matches */

            return true;
        }

        //safety
        return false;
    }

    private bool Validate_With_3_Equals(fv_FACEVALUE val1, fv_FACEVALUE val2, fv_FACEVALUE val3, fv_FACEVALUE val4, fv_FACEVALUE val5, fv_FACEVALUE val6)
    {
        /* Of the 3, the middle equals is the divider.  Side equals are just symbols */

        //separate into Left and Right lists
        //remove blanks
        //remove zeros
        //merge ints
        //remove plus signs, but not do math
        //incorporate minus signs into ints, AND do math
        //do plus sign math
        //check each side for equality

        //put values into list
        List<VineBlock> AllValues = new List<VineBlock>();
        AllValues.Add(new VineBlock(val1, 0));
        AllValues.Add(new VineBlock(val2, 0));
        AllValues.Add(new VineBlock(val3, 0));
        AllValues.Add(new VineBlock(val4, 0));
        AllValues.Add(new VineBlock(val5, 0));
        AllValues.Add(new VineBlock(val6, 0));

        //create a left and right side list
        List<VineBlock> Left_Values = new List<VineBlock>();
        List<VineBlock> Right_Values = new List<VineBlock>();

        // runner to interpret left or right side of equation
        int EqualsTicker = 0;

        //loop all 6 values, also remove blanks
        foreach (VineBlock vblock in AllValues)
        {
            //increment ticker
            if(vblock.Value == v_equals)
            {
                EqualsTicker++;
            }

            // skip, if blank
            if(vblock.Value == v_blank)
            {
                continue;
            }

            //before middle
            if(EqualsTicker < 2)
            {
                //add to left
                Left_Values.Add(vblock);
            }
            //after middle
            if (EqualsTicker > 2)
            {
                //add to right
                Right_Values.Add(vblock);
            }
        }

        PossiblyEliminate_Zeros(ref Left_Values);
        PossiblyEliminate_Zeros(ref Right_Values);

        PossiblyMerge_Ints(ref Left_Values);                
        PossiblyMerge_Ints(ref Right_Values);               

        PossiblyEliminate_PlusSigns_NoMath(ref Left_Values);                
        PossiblyEliminate_PlusSigns_NoMath(ref Right_Values);               

        PossiblyEliminate_MinusSigns_YesMath(ref Left_Values);              
        PossiblyEliminate_MinusSigns_YesMath(ref Right_Values);             

        PossiblyEliminate_PlusSigns_OnlyMath(ref Left_Values);              
        PossiblyEliminate_PlusSigns_OnlyMath(ref Right_Values);             

        
    /* Scrubbing Done.  Check If Equal Now */

        //if equal side counts
        if (Right_Values.Count == Left_Values.Count)
        {
            //loop indexes
            for(int i=0; i<Right_Values.Count; i++)
            {
                //if no match
                if(Right_Values[i].Value != Left_Values[i].Value)
                {
                    return false;
                }
                //if both are v_int
                if(Right_Values[i].Value == v_int)
                {
                    //if IntValues don't match
                    if(Right_Values[i].IntValue != Right_Values[i].IntValue)
                    {
                        return false;
                    }
                }
            }

        /* Everything matches */

            return true;
        }

        //safety
        return false;
    }

    private bool Validate_With_3_Equals(fv_FACEVALUE val1, fv_FACEVALUE val2, fv_FACEVALUE val3, fv_FACEVALUE val4)
    {
        /* Of the 3, the middle equals is the divider.  Side equals are just symbols */

        //separate into Left and Right lists
        //remove blanks
        //remove zeros
        //merge ints
        //remove plus signs, but not do math
        //incorporate minus signs into ints, AND do math
        //do plus sign math
        //check each side for equality

        //put values into list
        List<VineBlock> AllValues = new List<VineBlock>();
        AllValues.Add(new VineBlock(val1, 0));
        AllValues.Add(new VineBlock(val2, 0));
        AllValues.Add(new VineBlock(val3, 0));
        AllValues.Add(new VineBlock(val4, 0));

        //create a left and right side list
        List<VineBlock> Left_Values = new List<VineBlock>();
        List<VineBlock> Right_Values = new List<VineBlock>();

        // runner to interpret left or right side of equation
        int EqualsTicker = 0;

        //loop all 4 values, also remove blanks
        foreach (VineBlock vblock in AllValues)
        {
            //increment ticker
            if (vblock.Value == v_equals)
            {
                EqualsTicker++;
            }

            // skip, if blank
            if (vblock.Value == v_blank)
            {
                continue;
            }

            //before middle
            if (EqualsTicker < 2)
            {
                //add to left
                Left_Values.Add(vblock);
            }
            //after middle
            if (EqualsTicker > 2)
            {
                //add to right
                Right_Values.Add(vblock);
            }
        }

        PossiblyEliminate_Zeros(ref Left_Values);
        PossiblyEliminate_Zeros(ref Right_Values);

        PossiblyMerge_Ints(ref Left_Values);
        PossiblyMerge_Ints(ref Right_Values);

        PossiblyEliminate_PlusSigns_NoMath(ref Left_Values);
        PossiblyEliminate_PlusSigns_NoMath(ref Right_Values);

        PossiblyEliminate_MinusSigns_YesMath(ref Left_Values);
        PossiblyEliminate_MinusSigns_YesMath(ref Right_Values);

        PossiblyEliminate_PlusSigns_OnlyMath(ref Left_Values);
        PossiblyEliminate_PlusSigns_OnlyMath(ref Right_Values);


        /* Scrubbing Done.  Check If Equal Now */

        //if equal side counts
        if (Right_Values.Count == Left_Values.Count)
        {
            //loop indexes
            for (int i = 0; i < Right_Values.Count; i++)
            {
                //if no match
                if (Right_Values[i].Value != Left_Values[i].Value)
                {
                    return false;
                }
                //if both are v_int
                if (Right_Values[i].Value == v_int)
                {
                    //if IntValues don't match
                    if (Right_Values[i].IntValue != Right_Values[i].IntValue)
                    {
                        return false;
                    }
                }
            }

            /* Everything matches */

            return true;
        }

        //safety
        return false;
    }

    private bool Validate_With_5_Equals(fv_FACEVALUE val1, fv_FACEVALUE val2, fv_FACEVALUE val3, fv_FACEVALUE val4, fv_FACEVALUE val5, fv_FACEVALUE val6)
    {
        // the one non-equal has to be a v_blank
        if(val1==v_blank || val2 == v_blank || val3 == v_blank || val4 == v_blank || val5 == v_blank || val6 == v_blank)
        {
            return true;
        }

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

    private void PossiblyMerge_Ints(ref List<VineBlock> VBlocks)
    {
        int IntValue = 1;
        int DigitTracker = 0;

        //loop Values
        for (int i=0; i< VBlocks.Count; i++)
        {
            //if digit
            if (IsDigit(VBlocks[i].Value)) {

                //first time
                if (DigitTracker == 0)
                {
                    //set to this first digit
                    IntValue = Get_Digit(VBlocks[i].Value);

                    //increment
                    DigitTracker++;
                }
                //not first time
                else
                {
                    //IntValue = 10 * previous + new digit
                    IntValue = (10 * IntValue) + Get_Digit(VBlocks[i].Value);

                    //increment
                    DigitTracker++;
                }
            }
            //if not digit and there's stored int
            else if (DigitTracker != 0)
            {
                //copy index
                int CopiedIndex = i - 1;

                //remove all ints that make up IntValue
                while(DigitTracker > 0)
                {
                    //remove
                    VBlocks.RemoveAt(CopiedIndex);

                    //decrement index and DigitTracker
                    CopiedIndex--;
                    DigitTracker--;
                }

                //CopiedIndex needs to reverse it's last decrement above to be right
                CopiedIndex++;

                //add IntValue v_int block
                VBlocks.Insert(CopiedIndex, new VineBlock(v_int, IntValue));
            }
        }

    /* After looping entire List */

        //if it ended on a digit that still needs to be packaged
        if(DigitTracker != 0)
        {
            //copy index
            int CopiedIndex = VBlocks.Count - 1;

            //remove all ints that make up IntValue
            while (DigitTracker > 0)
            {
                //remove
                VBlocks.RemoveAt(CopiedIndex);

                //decrement index and DigitTracker
                CopiedIndex--;
                DigitTracker--;
            }

            //CopiedIndex needs to reverse it's last decrement above to be right
            CopiedIndex++;

            //add IntValue v_int block
            VBlocks.Insert(CopiedIndex, new VineBlock(v_int, IntValue));
        }
    }

    private void PossiblyEliminate_MinusSigns_YesMath(ref List<VineBlock> VBlocks)
    {
        //loop Values by index
        for (int i = 0; i < VBlocks.Count; i++)
        {
            //if minus
            if (VBlocks[i].Value == v_sub)
            {
                //safety -check if first index
                if(i == 0)
                {
                    //safety -check if at end
                    if(i+1 >= VBlocks.Count)
                    {
                        //just a minus
                        continue;
                    }
                    if(VBlocks[i+1].Value == v_int)
                    {
                        //store OldInt
                        int OldInt = VBlocks[i + 1].IntValue;

                        //remove old v_int block
                        VBlocks.RemoveAt(i + 1);

                        //remove minus block
                        VBlocks.RemoveAt(i);

                        //multiply by -1
                        OldInt = OldInt * -1;

                        //build new VBlock
                        VineBlock NewVineBlock = new VineBlock(v_int, OldInt);

                        //add new VBlock
                        VBlocks.Insert(i, NewVineBlock);

                        //removed two, added one
                        //no need to change i

                    }
                }
                //not at first index
                else
                {
                    //if digit on left
                    if(VBlocks[i-1].Value == v_int)
                    {
                        //safety -check if at end
                        if (i + 1 >= VBlocks.Count)
                        {
                            //stays symbol
                            continue;
                        }

                        // digit - digit
                        if(VBlocks[i+1].Value == v_int)
                        {
                            //get new int
                            int NewInt = (VBlocks[i - 1].IntValue) - (VBlocks[i + 1].IntValue);

                            //remove right block
                            VBlocks.RemoveAt(i + 1);

                            //remove minus block
                            VBlocks.RemoveAt(i);

                            //remove left block
                            VBlocks.RemoveAt(i - 1);

                            //build new VBlock
                            VineBlock NewVineBlock = new VineBlock(v_int, NewInt);

                            //removed 3, added 1, so need to decrement i
                            i--;


                            //safety - check to see if new index is okay
                            if (i < VBlocks.Count)
                            {
                                //add new VBlock
                                VBlocks.Insert(i, NewVineBlock);
                            }
                            // index unsafe, add to end
                            else
                            {
                                //add new VBlock
                                VBlocks.Add(NewVineBlock);
                            }
                        }
                    }
                    //no v_int on left
                    else
                    {
                        //safety -check if at end
                        if (i + 1 >= VBlocks.Count)
                        {
                            //just a minus
                            continue;
                        }
                        if (VBlocks[i + 1].Value == v_int)
                        {
                            //store OldInt
                            int OldInt = VBlocks[i + 1].IntValue;

                            //remove old v_int block
                            VBlocks.RemoveAt(i + 1);

                            //remove minus block
                            VBlocks.RemoveAt(i);

                            //multiply by -1
                            OldInt = OldInt * -1;

                            //build new VBlock
                            VineBlock NewVineBlock = new VineBlock(v_int, OldInt);

                            //@@@@ new saftery here


                            //add new VBlock
                            VBlocks.Insert(i, NewVineBlock);

                            //removed two, added one
                            //no need to change i

                        }
                    }


                }


            }
        }
    }

    private void PossiblyEliminate_PlusSigns_NoMath(ref List<VineBlock> VBlocks)
    {
        //loop Values by index
        for (int i=0; i< VBlocks.Count; i++)
        {
            //if plus
            if(VBlocks[i].Value == v_add)
            {
                //safety -check if last index
                if (i + 1 == VBlocks.Count)
                {
                    //it stays as symbol
                    continue;
                }

                //digit on right
                if (IsDigit(VBlocks[i + 1].Value))
                {
                    //safety -check if first index
                    if(i-1 == -1)
                    {
                        //it is deleted, just a positive indicator
                        VBlocks.RemoveAt(i);

                        //need to deincrement index because of removal
                        i--;

                        continue;
                    }
                    //check prior index, if  not digit
                    if (!IsDigit(VBlocks[i - 1].Value))
                    {
                        //it is deleted, just a positive indicator
                        VBlocks.RemoveAt(i);

                        //need to deincrement index because of removal
                        i--;

                        continue;
                    }
                    //prior digit
                    else
                    {
                        /* WONT DO MATH YET */
                    }
                }
            }
        }
    }

    private void PossiblyEliminate_PlusSigns_OnlyMath(ref List<VineBlock> VBlocks)
    {
        //loop Values by index
        for (int i = 0; i < VBlocks.Count; i++)
        {
            //if plus - won't be first index
            if (VBlocks[i].Value == v_add)
            {
                //safety -check if last index
                if (i + 1 == VBlocks.Count)
                {
                    //it stays as symbol
                    continue;
                }

                //digit on right
                if (IsDigit(VBlocks[i + 1].Value))
                {
                   
                    //check prior index, if digit
                    if (IsDigit(VBlocks[i - 1].Value))
                    {
                        //get new int
                        int NewInt = (VBlocks[i - 1].IntValue) + (VBlocks[i + 1].IntValue);

                        //remove right block
                        VBlocks.RemoveAt(i + 1);

                        //remove minus block
                        VBlocks.RemoveAt(i);

                        //remove left block
                        VBlocks.RemoveAt(i - 1);

                        //build new VBlock
                        VineBlock NewVineBlock = new VineBlock(v_int, NewInt);

                        //removed 3, added 1, so need to decrement i
                        i--;

                        //safety - check to see if new index is okay
                        if (i < VBlocks.Count)
                        {
                            //add new VBlock
                            VBlocks.Insert(i, NewVineBlock);
                        }
                        // index unsafe, add to end
                        else
                        {
                            //add new VBlock
                            VBlocks.Add(NewVineBlock);
                        }

                    }

                }
            }
        }
    }

    private void PossiblyEliminate_Zeros(ref List<VineBlock> VBlocks)
    {
        //loop Values by index
        for(int i=0; i< VBlocks.Count; i++)
        {
            //if zero
            if(VBlocks[i].Value == v_0)
            {
                //safety -check if last index
                if(i+1 == VBlocks.Count)
                {
                    continue;
                }

                //digit on right
                if (IsDigit(VBlocks[i + 1].Value))
                {
                    //safety -check if first index
                    if(i-1 == -1)
                    {
                        //delete the zero
                        VBlocks.RemoveAt(i);

                        //need to deincrement index because of removal
                        i--;

                        continue;
                    }
                    //check prior index, if not digit
                    if (!IsDigit(VBlocks[i - 1].Value))
                    {
                        //delete the zero
                        VBlocks.RemoveAt(i);

                        //need to deincrement index because of removal
                        i--;
                    }
                }
            }
        }
    }

    private int Get_AmountOfEqualsValues(fv_FACEVALUE val1, fv_FACEVALUE val2, fv_FACEVALUE val3, fv_FACEVALUE val4)
    {
        int EqualsAmount = 0;

        if (val1 == v_equals) { EqualsAmount++; }
        if (val2 == v_equals) { EqualsAmount++; }
        if (val3 == v_equals) { EqualsAmount++; }
        if (val4 == v_equals) { EqualsAmount++; }

        return EqualsAmount;
    }

    private int Get_AmountOfEqualsValues(fv_FACEVALUE val1, fv_FACEVALUE val2, fv_FACEVALUE val3, fv_FACEVALUE val4, fv_FACEVALUE val5, fv_FACEVALUE val6)
    {
        int EqualsAmount = 0;

        if (val1 == v_equals) { EqualsAmount++; }
        if (val2 == v_equals) { EqualsAmount++; }
        if (val3 == v_equals) { EqualsAmount++; }
        if (val4 == v_equals) { EqualsAmount++; }
        if (val5 == v_equals) { EqualsAmount++; }
        if (val6 == v_equals) { EqualsAmount++; }

        return EqualsAmount;
    }
   
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
        switch (val)
        {
            case v_0:
                return true;
            case v_1:
                return true;
            case v_2:
                return true;
            case v_3:
                return true;
            case v_4:
                return true;
            case v_5:
                return true;
            case v_6:
                return true;
            case v_7:
                return true;
            case v_8:
                return true;
            case v_9:
                return true;
            case v_int:
                return true;
            default:
                return false;
        }
    }

    //private bool DoesThisValidate(fv_FACEVALUE val1, fv_FACEVALUE val2, fv_FACEVALUE val3, fv_FACEVALUE val4)
    //{
    //    Debug.Log("VALUES: " + val1 + " - " + val2 + " - " + val3 + " - " + val4);

    //    //if val1 or val4 is equals
    //    if (val1 == v_equals || val4 == v_equals)
    //    {
    //        // b = = =
    //        if (val1 == v_blank && val2 == v_equals && val3 == v_equals && val4 == v_equals)
    //        {
    //            return true;
    //        }
    //        // = b = =
    //        if (val1 == v_equals && val2 == v_blank && val3 == v_equals && val4 == v_equals)
    //        {
    //            return true;
    //        }
    //        // = = b =
    //        if (val1 == v_equals && val2 == v_equals && val3 == v_blank && val4 == v_equals)
    //        {
    //            return true;
    //        }
    //        // = = = b
    //        if (val1 == v_equals && val2 == v_equals && val3 == v_equals && val4 == v_blank)
    //        {
    //            return true;
    //        }

    //        return false;
    //    }
    //    //if val2 is equals
    //    if (val2 == v_equals)
    //    {
    //        // + = ? ?
    //        if (val1 == v_add)
    //        {
    //            // + = +
    //            if ((val3 == v_add && val4 == v_blank) || (val3 == v_blank && val4 == v_add))
    //            {
    //                return true;
    //            }

    //            return false;
    //        }
    //        // - = ? ?
    //        if (val1 == v_sub)
    //        {
    //            // - = -
    //            if ((val3 == v_sub && val4 == v_blank) || (val3 == v_blank && val4 == v_sub))
    //            {
    //                return true;
    //            }

    //            return false;
    //        }
    //        // blank = ? ?
    //        if (val1 == v_blank)
    //        {
    //            // blank = blank
    //            if (val3 == v_blank && val4 == v_blank)
    //            {
    //                return true;
    //            }

    //            return false;
    //        }
    //        // Non-Negative Digit = ? ?
    //        {
    //            int LeftDigit = Get_Digit(val1);

    //            // LeftDigit = + ?
    //            if (val3 == v_add)
    //            {
    //                // LeftDigit = + Digit
    //                if (IsDigit(val4))
    //                {
    //                    //LeftDigit = RightDigit
    //                    if (LeftDigit == Get_Digit(val4))
    //                    {
    //                        return true;
    //                    }
    //                }

    //                return false;
    //            }

    //            // LeftDigit = - ?
    //            if (val3 == v_sub)
    //            {
    //                // LeftDigit = - 0
    //                if (val4 == v_0)
    //                {
    //                    // LeftDigit = 0
    //                    if (LeftDigit == 0)
    //                    {
    //                        return true;
    //                    }
    //                }

    //                return false;
    //            }

    //            // LeftDigit = blank ?
    //            if (val3 == v_blank)
    //            {
    //                // LeftDigit = Digit
    //                if (IsDigit(val4))
    //                {
    //                    // LeftDigit = RightDigit
    //                    if (LeftDigit == Get_Digit(val4))
    //                    {
    //                        return true;
    //                    }
    //                }

    //                return false;
    //            }
    //            // LeftDigit = Digit ?
    //            {
    //                //LeftDigit = RightDigit ?
    //                if (LeftDigit == Get_Digit(val3))
    //                {
    //                    // LeftDigit = RightDigit v_blank
    //                    if (val4 == v_blank)
    //                    {
    //                        return true;
    //                    }
    //                    //nothing else works
    //                }
    //                //LeftDigit = 0 ?
    //                if (Get_Digit(val3) == 0)
    //                {
    //                    //LeftDigit = 0 RightDigit
    //                    if (LeftDigit == Get_Digit(val4))
    //                    {
    //                        return true;
    //                    }
    //                }

    //                return false;
    //            }
    //        }
    //    }
    //    //if val3 is equals
    //    if (val3 == v_equals)
    //    {
    //        // ? ? = +
    //        if (val4 == v_add)
    //        {
    //            // + ? = +
    //            if (val1 == v_add)
    //            {
    //                // + blank = +
    //                if (val2 == v_blank)
    //                {
    //                    return true;
    //                }

    //                return false;
    //            }
    //            // - ? = +
    //            if (val1 == v_sub)
    //            {
    //                return false;
    //            }
    //            // blank ? = +
    //            if (val1 == v_blank)
    //            {
    //                // + = +
    //                if (val2 == v_add)
    //                {
    //                    return true;
    //                }

    //                return false;
    //            }
    //            // Digit ? = +
    //            {
    //                return false;
    //            }
    //        }
    //        // ? ? = -
    //        if (val4 == v_sub)
    //        {
    //            // + ? = -
    //            if (val1 == v_add)
    //            {
    //                return false;
    //            }
    //            // - ? = -
    //            if (val1 == v_sub)
    //            {
    //                // - blank = -
    //                if (val2 == v_blank)
    //                {
    //                    return true;
    //                }

    //                return false;
    //            }
    //            // blank ? = -
    //            if (val1 == v_blank)
    //            {
    //                // - = -
    //                if (val2 == v_sub)
    //                {
    //                    return true;
    //                }

    //                return false;
    //            }
    //            // Digit ? = -
    //            {
    //                return false;
    //            }
    //        }
    //        // ? ? = blank
    //        if (val4 == v_blank)
    //        {
    //            // blank = blank
    //            if (val1 == v_blank && val2 == v_blank)
    //            {
    //                return true;
    //            }

    //            return false;
    //        }
    //        // ? ? = Non-Negative Digit
    //        {
    //            int RightDigit = Get_Digit(val4);

    //            // + ? = RightDigit
    //            if (val1 == v_add)
    //            {
    //                // + Digit = RightDigit
    //                if (IsDigit(val2))
    //                {
    //                    // LeftDigit = RightDigit
    //                    if (Get_Digit(val2) == RightDigit)
    //                    {
    //                        return true;
    //                    }
    //                }

    //                return false;
    //            }
    //            // - ? = RightDigit
    //            if (val1 == v_sub)
    //            {
    //                // - 0 = RightDigit
    //                if (val2 == v_0)
    //                {
    //                    // 0 == RightDigit
    //                    if (RightDigit == 0)
    //                    {
    //                        return true;
    //                    }
    //                }

    //                return false;
    //            }
    //            // blank ? = RightDigit
    //            if (val1 == v_blank)
    //            {
    //                // blank Digit = RightDigit
    //                if (IsDigit(val2))
    //                {
    //                    //LeftDigit = RightDigit
    //                    if (Get_Digit(val2) == RightDigit)
    //                    {
    //                        return true;
    //                    }
    //                }

    //                return false;
    //            }
    //            // Digit ? = RightDigit
    //            {
    //                // Digit blank = RightDigit
    //                if (val2 == v_blank)
    //                {
    //                    //LeftDigit = RightDigit
    //                    if (Get_Digit(val1) == RightDigit)
    //                    {
    //                        return true;
    //                    }
    //                }
    //                // 0 ? = RightDigit
    //                if (val1 == v_0)
    //                {
    //                    //0 Digit = RightDigit
    //                    if (Get_Digit(val2) == RightDigit)
    //                    {
    //                        return true;
    //                    }
    //                }

    //                return false;
    //            }
    //        }

    //    }


    //    /* No EQUAL signs detected * /

    //        5 + = 0 5 +

    //        5, 2201, =, 5 2201

    //        //if not same amount of shapes, false
    //        //loop indexes
    //        //if left[1] != right[1], false
    //        //if left[2] != right[2], false


    //        5, 2001, =, 5

    //        5 = 5 = 5 =

    //        -05-b+      
    //        -5, -, +

    //        Now, we've dealt with all equals signs which had turned the validation into an equation.

    //        I believe, now we look for edge cases around v_sub and v_add

    //        When v_sub and v_add are before ints, they act as positive or negative attributes to the ints.

    //        When they are after, they are math symbols

    //        5+ is wrong
    //        + + + is okay

    //        if (5 + = 5 +) because they turn into shapes, then this exception turns them back into shapes

    //        5+ != 5


    //        -/+                     are shapes
    //        -/+ after digits        are math symbols
    //        -/+ before equals       are shapes

    //        -07

    //        --0-

    //        */

    //    //  = = = = = 7


    //    return true;
    //}


}
