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

        //Debug.Log("----");
        //bool lava = Validate_With_1_Equals(v_7, v_add, v_sub, v_3, v_equals, v_1);
        //Debug.Log("7 + - 3 = 1");
        //Debug.Log(lava);
        //Debug.Log("----");
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
        HoneyComb ThisHoneyComb = WGRefDict[HoneyCombAddress].GetComponent<HoneyComb>();

        //finalized check
        if (ThisHoneyComb.IsHoneyComb_Finalized())
        {
            return;
        }

        //get truncated ref dictionary
        Dictionary<wg_ADDRESS, GameObject> HoneySlotRefDict = ThisHoneyComb.HoneySlotRefDict;

        //start counter
        int ValidFlowerCounter = 0;

        //loop through nine flowers
        for (int i=1; i<=9; i++)
        {
            //build FlowerName
            string FlowerName = "FlowerIndicator_" + i;

            //if flower is good
            if (Validate_ThisFlower(HoneySlotRefDict, FlowerName))
            {
                //activate
                WGRefDict[HoneyCombAddress].transform.Find(FlowerName).GetComponent<FlowerIndicator>().Activate_Flower();

                //increment counter
                ValidFlowerCounter++;
            }
            //if flower is bad
            else
            {
                //deactivate
                WGRefDict[HoneyCombAddress].transform.Find(FlowerName).GetComponent<FlowerIndicator>().Deactivate_Flower();
            }
        }

        //if all 9 Flowers are valid
        if(ValidFlowerCounter == 9){
            //finalize honeycomb
            ThisHoneyComb.Finalize_ThisHoneyComb();
        }
    }

    /* The following are static because they are also used for the VineValidor_Title on the TitleScreen */

    static public bool DoesThisValidate(fv_FACEVALUE val1, fv_FACEVALUE val2, fv_FACEVALUE val3, fv_FACEVALUE val4)
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

    static public bool DoesThisValidate(fv_FACEVALUE val1, fv_FACEVALUE val2, fv_FACEVALUE val3, fv_FACEVALUE val4, fv_FACEVALUE val5, fv_FACEVALUE val6)
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
                return Validate_With_2_Equals(val1, val2, val3, val4, val5, val6);
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

    static private bool Validate_With_1_Equals(fv_FACEVALUE val1, fv_FACEVALUE val2, fv_FACEVALUE val3, fv_FACEVALUE val4)
    {
        //separate into Left and Right lists
        //remove blanks
        //remove zeros
        //merge ints
        //remove plus signs and minus signs, but not do math
        //do minus sign math
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

        PossiblyEliminate_MinusAndPlusSigns_NoMathx3(ref Left_Values);
        PossiblyEliminate_MinusAndPlusSigns_NoMathx3(ref Right_Values);

        PossiblyEliminate_MinusSigns_OnlyMath(ref Left_Values);
        PossiblyEliminate_MinusSigns_OnlyMath(ref Right_Values);

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
                    if (Right_Values[i].IntValue != Left_Values[i].IntValue)
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

    static private bool Validate_With_1_Equals(fv_FACEVALUE val1, fv_FACEVALUE val2, fv_FACEVALUE val3, fv_FACEVALUE val4, fv_FACEVALUE val5, fv_FACEVALUE val6)
    {
        //separate into Left and Right lists
        //remove blanks
        //remove zeros
        //merge ints
        //remove plus signs and minus signs, but not do math
        //do minus sign math
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

        PossiblyEliminate_MinusAndPlusSigns_NoMathx3(ref Left_Values);
        PossiblyEliminate_MinusAndPlusSigns_NoMathx3(ref Right_Values);

        PossiblyEliminate_MinusSigns_OnlyMath(ref Left_Values);
        PossiblyEliminate_MinusSigns_OnlyMath(ref Right_Values);

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

    static private bool Validate_With_2_Equals(fv_FACEVALUE val1, fv_FACEVALUE val2, fv_FACEVALUE val3, fv_FACEVALUE val4, fv_FACEVALUE val5, fv_FACEVALUE val6)
    {
        /* Three blocks need to equal each other */

        //put values into list
        List<VineBlock> AllValues = new List<VineBlock>();
        AllValues.Add(new VineBlock(val1, 0));
        AllValues.Add(new VineBlock(val2, 0));
        AllValues.Add(new VineBlock(val3, 0));
        AllValues.Add(new VineBlock(val4, 0));
        AllValues.Add(new VineBlock(val5, 0));
        AllValues.Add(new VineBlock(val6, 0));

        //create a A list, B list, and C list
        List<VineBlock> A_Values = new List<VineBlock>();
        List<VineBlock> B_Values = new List<VineBlock>();
        List<VineBlock> C_Values = new List<VineBlock>();

        // runner to interpret which list to put it in
        int ListTrigger = 0;

        //loop all 6 values, also remove blanks
        foreach (VineBlock vblock in AllValues)
        {
            //set equals trigger
            if (vblock.Value == v_equals)
            {
                ListTrigger++;
                continue;
            }

            // skip, if blank
            if (vblock.Value == v_blank)
            {
                continue;
            }

            // A-List
            if (ListTrigger == 0)
            {
                //add to A-List
                A_Values.Add(vblock);
            }

            // B-List
            if (ListTrigger == 1)
            {
                //add to B-List
                B_Values.Add(vblock);
            }

            // C-List
            if (ListTrigger == 2)
            {
                //add to C-List
                C_Values.Add(vblock);
            }
        }

        //scrub each list
        {
            //A-List
            if (A_Values.Count > 1)
            {
                PossiblyEliminate_Zeros(ref A_Values);
                PossiblyMerge_Ints(ref A_Values);
                PossiblyEliminate_MinusAndPlusSigns_NoMathx3(ref A_Values);
                PossiblyEliminate_MinusSigns_OnlyMath(ref A_Values);
                PossiblyEliminate_PlusSigns_OnlyMath(ref A_Values);
            }
            else
            {
                PossiblyMerge_Ints(ref A_Values);
            }

            //B-List
            if (B_Values.Count > 1)
            {
                PossiblyEliminate_Zeros(ref B_Values);
                PossiblyMerge_Ints(ref B_Values);
                PossiblyEliminate_MinusAndPlusSigns_NoMathx3(ref B_Values);
                PossiblyEliminate_MinusSigns_OnlyMath(ref B_Values);
                PossiblyEliminate_PlusSigns_OnlyMath(ref B_Values);
            }
            else
            {
                PossiblyMerge_Ints(ref B_Values);
            }

            //C-List
            if (C_Values.Count > 1)
            {
                PossiblyEliminate_Zeros(ref C_Values);
                PossiblyMerge_Ints(ref C_Values);
                PossiblyEliminate_MinusAndPlusSigns_NoMathx3(ref C_Values);
                PossiblyEliminate_MinusSigns_OnlyMath(ref C_Values);
                PossiblyEliminate_PlusSigns_OnlyMath(ref C_Values);
            }
            else
            {
                PossiblyMerge_Ints(ref C_Values);
            }

        }

        /* Scrubbing Done.  Check If Equal Now */

        //if equal counts
        if (A_Values.Count == B_Values.Count && A_Values.Count == C_Values.Count)
        {
            //loop indexes
            for (int i = 0; i < A_Values.Count; i++)
            {
                //if no match between all three
                if (A_Values[i].Value != B_Values[i].Value || A_Values[i].Value != C_Values[i].Value)
                {
                    return false;
                }
                //if all are v_int
                if (A_Values[i].Value == v_int)
                {
                    //if IntValues don't match
                    if (A_Values[i].IntValue != B_Values[i].IntValue || A_Values[i].IntValue != C_Values[i].IntValue)
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

    static private bool Validate_With_3_Equals(fv_FACEVALUE val1, fv_FACEVALUE val2, fv_FACEVALUE val3, fv_FACEVALUE val4, fv_FACEVALUE val5, fv_FACEVALUE val6)
    {
        /* Of the 3, the middle equals is the divider.  Side equals are just symbols */

        //separate into Left and Right lists
        //remove blanks
        //remove zeros
        //merge ints
        //remove plus signs and minus signs, but not do math
        //do minus sign math
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
            //at middle
            if (EqualsTicker == 2)
            {
                //increment ticker again, sending to right side now
                EqualsTicker++;
            }
        }

        PossiblyEliminate_Zeros(ref Left_Values);
        PossiblyEliminate_Zeros(ref Right_Values);

        PossiblyMerge_Ints(ref Left_Values);                
        PossiblyMerge_Ints(ref Right_Values);

        PossiblyEliminate_MinusAndPlusSigns_NoMathx3(ref Left_Values);
        PossiblyEliminate_MinusAndPlusSigns_NoMathx3(ref Right_Values);               

        PossiblyEliminate_MinusSigns_OnlyMath(ref Left_Values);              
        PossiblyEliminate_MinusSigns_OnlyMath(ref Right_Values);             

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
                    if(Left_Values[i].IntValue != Right_Values[i].IntValue)
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

    static private bool Validate_With_3_Equals(fv_FACEVALUE val1, fv_FACEVALUE val2, fv_FACEVALUE val3, fv_FACEVALUE val4)
    {
        /* Of the 3, the middle equals is the divider.  Side equals are just symbols */

        //separate into Left and Right lists
        //remove blanks
        //remove zeros
        //merge ints
        //remove plus signs and minus signs, but not do math
        //do minus sign math
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
            //at middle
            if(EqualsTicker == 2)
            {
                //increment ticker again, sending to right side now
                EqualsTicker++;
            }
        }
        
        PossiblyEliminate_Zeros(ref Left_Values);
        PossiblyEliminate_Zeros(ref Right_Values);

        PossiblyMerge_Ints(ref Left_Values);
        PossiblyMerge_Ints(ref Right_Values);

        PossiblyEliminate_MinusAndPlusSigns_NoMathx3(ref Left_Values);
        PossiblyEliminate_MinusAndPlusSigns_NoMathx3(ref Right_Values);

        PossiblyEliminate_MinusSigns_OnlyMath(ref Left_Values);
        PossiblyEliminate_MinusSigns_OnlyMath(ref Right_Values);

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

    static private bool Validate_With_5_Equals(fv_FACEVALUE val1, fv_FACEVALUE val2, fv_FACEVALUE val3, fv_FACEVALUE val4, fv_FACEVALUE val5, fv_FACEVALUE val6)
    {
        // the one non-equal has to be a v_blank
        if(val1==v_blank || val2 == v_blank || val3 == v_blank || val4 == v_blank || val5 == v_blank || val6 == v_blank)
        {
            return true;
        }

        return false;
    }

    static private bool Validate_ThisFlower(Dictionary<wg_ADDRESS, GameObject> HoneySlotRefDict, string flowername)
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
                    if(HoneySlotRefDict[GG].GetComponentInChildren<Piece>() == null || HoneySlotRefDict[FF].GetComponentInChildren<Piece>() == null)
                    {
                        return false;
                    }

                    fv_FACEVALUE val1 = HoneySlotRefDict[GG].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_6);
                    fv_FACEVALUE val2 = HoneySlotRefDict[GG].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_3);
                    fv_FACEVALUE val3 = HoneySlotRefDict[FF].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_6);
                    fv_FACEVALUE val4 = HoneySlotRefDict[FF].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_3);
                    return DoesThisValidate(val1, val2, val3, val4);
                }
            case "FlowerIndicator_2":
                {
                    //null check
                    if (HoneySlotRefDict[EE].GetComponentInChildren<Piece>() == null || HoneySlotRefDict[DD].GetComponentInChildren<Piece>() == null || HoneySlotRefDict[CC].GetComponentInChildren<Piece>() == null)
                    {
                        return false;
                    }

                    fv_FACEVALUE val1 = HoneySlotRefDict[EE].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_6);
                    fv_FACEVALUE val2 = HoneySlotRefDict[EE].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_3);
                    fv_FACEVALUE val3 = HoneySlotRefDict[DD].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_6);
                    fv_FACEVALUE val4 = HoneySlotRefDict[DD].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_3);
                    fv_FACEVALUE val5 = HoneySlotRefDict[CC].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_6);
                    fv_FACEVALUE val6 = HoneySlotRefDict[CC].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_3);
                    return DoesThisValidate(val1, val2, val3, val4, val5, val6);
                }
            case "FlowerIndicator_3":
                {
                    //null check
                    if (HoneySlotRefDict[BB].GetComponentInChildren<Piece>() == null || HoneySlotRefDict[AA].GetComponentInChildren<Piece>() == null)
                    {
                        return false;
                    }

                    fv_FACEVALUE val1 = HoneySlotRefDict[BB].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_6);
                    fv_FACEVALUE val2 = HoneySlotRefDict[BB].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_3);
                    fv_FACEVALUE val3 = HoneySlotRefDict[AA].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_6);
                    fv_FACEVALUE val4 = HoneySlotRefDict[AA].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_3);
                    return DoesThisValidate(val1, val2, val3, val4);
                }
            case "FlowerIndicator_4":
                {
                    //null check
                    if (HoneySlotRefDict[EE].GetComponentInChildren<Piece>() == null || HoneySlotRefDict[GG].GetComponentInChildren<Piece>() == null)
                    {
                        return false;
                    }

                    fv_FACEVALUE val1 = HoneySlotRefDict[EE].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_5);
                    fv_FACEVALUE val2 = HoneySlotRefDict[EE].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_2);
                    fv_FACEVALUE val3 = HoneySlotRefDict[GG].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_5);
                    fv_FACEVALUE val4 = HoneySlotRefDict[GG].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_2);
                    return DoesThisValidate(val1, val2, val3, val4);
                }
            case "FlowerIndicator_5":
                {
                    //null check
                    if (HoneySlotRefDict[BB].GetComponentInChildren<Piece>() == null || HoneySlotRefDict[DD].GetComponentInChildren<Piece>() == null || HoneySlotRefDict[FF].GetComponentInChildren<Piece>() == null)
                    {
                        return false;
                    }

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
                    //null check
                    if (HoneySlotRefDict[AA].GetComponentInChildren<Piece>() == null || HoneySlotRefDict[CC].GetComponentInChildren<Piece>() == null)
                    {
                        return false;
                    }

                    fv_FACEVALUE val1 = HoneySlotRefDict[AA].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_5);
                    fv_FACEVALUE val2 = HoneySlotRefDict[AA].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_2);
                    fv_FACEVALUE val3 = HoneySlotRefDict[CC].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_5);
                    fv_FACEVALUE val4 = HoneySlotRefDict[CC].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_2);
                    return DoesThisValidate(val1, val2, val3, val4);
                }
            case "FlowerIndicator_7":
                {
                    //null check
                    if (HoneySlotRefDict[BB].GetComponentInChildren<Piece>() == null || HoneySlotRefDict[EE].GetComponentInChildren<Piece>() == null)
                    {
                        return false;
                    }

                    fv_FACEVALUE val1 = HoneySlotRefDict[BB].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_4);
                    fv_FACEVALUE val2 = HoneySlotRefDict[BB].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_1);
                    fv_FACEVALUE val3 = HoneySlotRefDict[EE].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_4);
                    fv_FACEVALUE val4 = HoneySlotRefDict[EE].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_1);
                    return DoesThisValidate(val1, val2, val3, val4);
                }
            case "FlowerIndicator_8":
                {
                    //null check
                    if (HoneySlotRefDict[AA].GetComponentInChildren<Piece>() == null || HoneySlotRefDict[DD].GetComponentInChildren<Piece>() == null || HoneySlotRefDict[GG].GetComponentInChildren<Piece>() == null)
                    {
                        return false;
                    }

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
                    //null check
                    if (HoneySlotRefDict[CC].GetComponentInChildren<Piece>() == null || HoneySlotRefDict[FF].GetComponentInChildren<Piece>() == null)
                    {
                        return false;
                    }

                    fv_FACEVALUE val1 = HoneySlotRefDict[CC].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_4);
                    fv_FACEVALUE val2 = HoneySlotRefDict[CC].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_1);
                    fv_FACEVALUE val3 = HoneySlotRefDict[FF].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_4);
                    fv_FACEVALUE val4 = HoneySlotRefDict[FF].GetComponentInChildren<Piece>().Get_FaceValue_WithOffset(TRI_1);
                    return DoesThisValidate(val1, val2, val3, val4);
                }
            default:
                return false;
        }
    }

    //Utilities

    static private void PossiblyMerge_Ints(ref List<VineBlock> VBlocks)
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

    static private void PossiblyEliminate_MinusAndPlusSigns_NoMathx3(ref List<VineBlock> VBlocks)
    {
        //do atleast three times
        for (int times = 0; times < 3; times++)
        {
            //loop Values by index
            for (int i = 0; i < VBlocks.Count; i++)
            {
                //if plus
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
                        //safety -check if first index
                        if (i - 1 == -1)
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

                //if minus
                if (VBlocks[i].Value == v_sub)
                {
                    //safety -check if first index
                    if (i == 0)
                    {
                        //safety -check if at end
                        if (i + 1 >= VBlocks.Count)
                        {
                            //just a minus
                            continue;
                        }
                        //to right, int
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
                        if (VBlocks[i - 1].Value == v_int)
                        {
                            //safety -check if at end
                            if (i + 1 >= VBlocks.Count)
                            {
                                //stays symbol
                                continue;
                            }

                            // digit - digit
                            if (VBlocks[i + 1].Value == v_int)
                            {
                                //do nothing, no math yet
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
                            //to right, int
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
    }

    static private void PossiblyEliminate_MinusSigns_OnlyMath(ref List<VineBlock> VBlocks)
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

    static private void PossiblyEliminate_PlusSigns_OnlyMath(ref List<VineBlock> VBlocks)
    {
        //loop Values by index
        for (int i = 0; i < VBlocks.Count; i++)
        {
            //if plus
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

    static private void PossiblyEliminate_Zeros(ref List<VineBlock> VBlocks)
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

    static private int Get_AmountOfEqualsValues(fv_FACEVALUE val1, fv_FACEVALUE val2, fv_FACEVALUE val3, fv_FACEVALUE val4)
    {
        int EqualsAmount = 0;

        if (val1 == v_equals) { EqualsAmount++; }
        if (val2 == v_equals) { EqualsAmount++; }
        if (val3 == v_equals) { EqualsAmount++; }
        if (val4 == v_equals) { EqualsAmount++; }

        return EqualsAmount;
    }

    static private int Get_AmountOfEqualsValues(fv_FACEVALUE val1, fv_FACEVALUE val2, fv_FACEVALUE val3, fv_FACEVALUE val4, fv_FACEVALUE val5, fv_FACEVALUE val6)
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
   
    static public int Get_Digit(fv_FACEVALUE val)
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

    static public fv_FACEVALUE Get_FaceValue(int val)
    {
        return (fv_FACEVALUE)(val + 1);
    }

    static private bool IsDigit(fv_FACEVALUE val)
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

    static public void Run_SpecificTestValidate()
    {
        fv_FACEVALUE fv_1 = v_9;
        fv_FACEVALUE fv_2 = v_equals;
        fv_FACEVALUE fv_3 = v_sub;
        fv_FACEVALUE fv_4 = v_add;
        fv_FACEVALUE fv_5 = v_sub;
        fv_FACEVALUE fv_6 = v_9;

        bool result = DoesThisValidate(fv_1, fv_2, fv_3, fv_4, fv_5, fv_6);

        Debug.Log("Test validation: " + result);


    }
}
