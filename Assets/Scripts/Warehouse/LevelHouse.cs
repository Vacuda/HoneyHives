using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ln_LEVELNAME;
using static wg_ADDRESS;
using static fv_FACEVALUE;

static public class LevelHouse
{
    //these need to change when a new template is added
    static int FourBlockTemplates = 2;
    static int SixBlockTemplates = 2;

    static float Spinnable_Rate = 0.6f;
    static float LastThree_Movable_Rate = 0.4f;

    //create order
    static wg_ADDRESS[] order = new wg_ADDRESS[7] { AA, BB, CC, DD, EE, FF, GG };


    /* BUILD HONEYCOMBS */

    static public void Get_SevenHoneyCombs(ref List<List<HoneySlotInfo>> hc_list) {

        //Add null HoneySlotInfos
        BuildOut_NullHoneySlotInfos(ref hc_list);

        //Fill HoneySlotInfo
        Fill_FaceValues(ref hc_list);

        //fill move/spin
        Fill_MoveValues(ref hc_list);

        //fill move/spin
        Fill_SpinValues(ref hc_list);
    }

    static void BuildOut_NullHoneySlotInfos(ref List<List<HoneySlotInfo>> hc_list)
    {
        //loop seven times
        for(int i=1; i<=7; i++)
        {
            //make new list
            List<HoneySlotInfo> list = new List<HoneySlotInfo>();

            //loop each slot address
            foreach (var address in order)
            {
                //add to current list
                list.Add(new HoneySlotInfo(address));
            }

            //add current list to overall list
            hc_list.Add(list);
        }
    }

    static void Fill_FaceValues(ref List<List<HoneySlotInfo>> hc_list)
    {
        //loop honeycombs
        for(int i=0; i<=6; i++)
        {
            /* flower 1 */
            {
                //get block
                fv_FACEVALUE[] four_block = Get_FourBlock();

                //change facevalue
                hc_list[i][ConvertToIndex(GG)].fv_6 = four_block[0];
                hc_list[i][ConvertToIndex(GG)].fv_3 = four_block[1];
                hc_list[i][ConvertToIndex(FF)].fv_6 = four_block[2];
                hc_list[i][ConvertToIndex(FF)].fv_3 = four_block[3];
            }

            /* flower 2 */
            {
                //get block
                fv_FACEVALUE[] six_block = Get_SixBlock();

                //change facevalue
                hc_list[i][ConvertToIndex(EE)].fv_6 = six_block[0];
                hc_list[i][ConvertToIndex(EE)].fv_3 = six_block[1];
                hc_list[i][ConvertToIndex(DD)].fv_6 = six_block[2];
                hc_list[i][ConvertToIndex(DD)].fv_3 = six_block[3];
                hc_list[i][ConvertToIndex(CC)].fv_6 = six_block[4];
                hc_list[i][ConvertToIndex(CC)].fv_3 = six_block[5];
            }

            /* flower 3 */
            {
                //get block
                fv_FACEVALUE[] four_block = Get_FourBlock();

                //change facevalue
                hc_list[i][ConvertToIndex(BB)].fv_6 = four_block[0];
                hc_list[i][ConvertToIndex(BB)].fv_3 = four_block[1];
                hc_list[i][ConvertToIndex(AA)].fv_6 = four_block[2];
                hc_list[i][ConvertToIndex(AA)].fv_3 = four_block[3];
            }

            /* flower 4 */
            {
                //get block
                fv_FACEVALUE[] four_block = Get_FourBlock();

                //change facevalue
                hc_list[i][ConvertToIndex(EE)].fv_5 = four_block[0];
                hc_list[i][ConvertToIndex(EE)].fv_2 = four_block[1];
                hc_list[i][ConvertToIndex(GG)].fv_5 = four_block[2];
                hc_list[i][ConvertToIndex(GG)].fv_2 = four_block[3];
            }

            /* flower 5 */
            {
                //get block
                fv_FACEVALUE[] six_block = Get_SixBlock();

                //change facevalue
                hc_list[i][ConvertToIndex(BB)].fv_5 = six_block[0];
                hc_list[i][ConvertToIndex(BB)].fv_2 = six_block[1];
                hc_list[i][ConvertToIndex(DD)].fv_5 = six_block[2];
                hc_list[i][ConvertToIndex(DD)].fv_2 = six_block[3];
                hc_list[i][ConvertToIndex(FF)].fv_5 = six_block[4];
                hc_list[i][ConvertToIndex(FF)].fv_2 = six_block[5];
            }

            /* flower 6 */
            {
                //get block
                fv_FACEVALUE[] four_block = Get_FourBlock();

                //change facevalue
                hc_list[i][ConvertToIndex(AA)].fv_5 = four_block[0];
                hc_list[i][ConvertToIndex(AA)].fv_2 = four_block[1];
                hc_list[i][ConvertToIndex(CC)].fv_5 = four_block[2];
                hc_list[i][ConvertToIndex(CC)].fv_2 = four_block[3];
            }

            /* flower 7 */
            {
                //get block
                fv_FACEVALUE[] four_block = Get_FourBlock();

                //change facevalue
                hc_list[i][ConvertToIndex(BB)].fv_4 = four_block[0];
                hc_list[i][ConvertToIndex(BB)].fv_1 = four_block[1];
                hc_list[i][ConvertToIndex(EE)].fv_4 = four_block[2];
                hc_list[i][ConvertToIndex(EE)].fv_1 = four_block[3];
            }

            /* flower 8 */
            {
                //get block
                fv_FACEVALUE[] six_block = Get_SixBlock();

                //change facevalue
                hc_list[i][ConvertToIndex(AA)].fv_4 = six_block[0];
                hc_list[i][ConvertToIndex(AA)].fv_1 = six_block[1];
                hc_list[i][ConvertToIndex(DD)].fv_4 = six_block[2];
                hc_list[i][ConvertToIndex(DD)].fv_1 = six_block[3];
                hc_list[i][ConvertToIndex(GG)].fv_4 = six_block[4];
                hc_list[i][ConvertToIndex(GG)].fv_1 = six_block[5];
            }

            /* flower 9 */
            {
                //get block
                fv_FACEVALUE[] four_block = Get_FourBlock();

                //change facevalue
                hc_list[i][ConvertToIndex(CC)].fv_4 = four_block[0];
                hc_list[i][ConvertToIndex(CC)].fv_1 = four_block[1];
                hc_list[i][ConvertToIndex(FF)].fv_4 = four_block[2];
                hc_list[i][ConvertToIndex(FF)].fv_1 = four_block[3];
            }


        }
    }

    static void Fill_MoveValues(ref List<List<HoneySlotInfo>> hc_list)
    {
        /* This needs to control the movable slots into a range of 1-4 */
        /* This guarantees that the Beebox won't fill up, and that the HoneyLock won't have enough movables */

        //loop honeycombs
        for(int i=0; i<=6; i++)
        {

            //all movable debug
            //hc_list[i][0].IsMovable = true;
            //hc_list[i][1].IsMovable = true;
            //hc_list[i][2].IsMovable = true;
            //hc_list[i][3].IsMovable = true;
            //hc_list[i][4].IsMovable = true;
            //hc_list[i][5].IsMovable = true;
            //hc_list[i][6].IsMovable = true;


            //make index array with all 7 indexes
            int[] index_array = new int[7] { 0, 1, 2, 3, 4, 5, 6 };

            //shuffle array
            Shuffle_IndexArray(ref index_array);

            //make first 3 unmovable = this guarantees no more than 28 are movable
            {
                hc_list[i][index_array[0]].IsMovable = false;
                hc_list[i][index_array[1]].IsMovable = false;
                hc_list[i][index_array[2]].IsMovable = false;
            }

            //make next one movable = this guarantees 7 movables
            {
                hc_list[i][index_array[3]].IsMovable = true;
            }

            //loop remaining indexes
            for (int a = 4; a <= 6; a++)
            {
                //get rands
                float rand_move = Random.value;

                //set IsMovable
                if (rand_move < LastThree_Movable_Rate)
                {
                    hc_list[i][index_array[a]].IsMovable = true;
                }
                else
                {
                    hc_list[i][index_array[a]].IsMovable = false;
                }
            }
        }
    }

    static void Fill_SpinValues(ref List<List<HoneySlotInfo>> hc_list)
    {
        //loop honeycombs
        for (int i = 0; i <= 6; i++)
        {
            //loop honeyslots
            for (int a = 0; a <= 6; a++)
            {
                //get rands
                float rand_spin = Random.value;

                //set IsSpinnable
                if (rand_spin < Spinnable_Rate)
                {
                    hc_list[i][a].IsSpinnable = true;
                }
                else
                {
                    hc_list[i][a].IsSpinnable = false;
                }

            }
        }
    }

    static public void MakeAndAdd_DummyPiece(wg_ADDRESS address, ref List<List<HoneySlotInfo>> hc_list)
    {
        //make dummy piece
        HoneySlotInfo slot = new HoneySlotInfo(address);

        //set information
        slot.HoneyJar_Originated = true;                        //needs to be true
        slot.IsMovable = true;                                  //needs to be true
        slot.IsSpinnable = Roll_EitherOr() ? true: false;       //either     //@@@@ I think the ? condition should be removed, redundant
        slot.fv_1 = GetRandomFaceValue(true);                   //any
        slot.fv_2 = GetRandomFaceValue(true);                   //any
        slot.fv_3 = GetRandomFaceValue(true);                   //any
        slot.fv_4 = GetRandomFaceValue(true);                   //any
        slot.fv_5 = GetRandomFaceValue(true);                   //any
        slot.fv_6 = GetRandomFaceValue(true);                   //any


        /* To be succinct, I need to find out which list to put this into */
        /* This will be the list with only 6 slots in it */

        //initialize index to use
        int index = 0;

        //loop hc_list
        for(int i=0; i<=6; i++)
        {
            if(hc_list[i].Count < 7)
            {
                //set index to this i
                index = i;
            }
        }

        //add dummy piece to this index
        hc_list[index].Add(slot);
    }


    /* FOUR BLOCKS */

    static fv_FACEVALUE[] Get_FourBlock()
    {
        //get rand
        int rand = Random.Range(0, FourBlockTemplates); //inclusive, exclusive

        switch (rand)
        {
            case 0: return FourBlock_AllRandom_ZeroEquals();
            case 1: return FourBlock_OneOrThreeEquals();
            default: return FourBlock_AllRandom_ZeroEquals();
        }
    }

    static fv_FACEVALUE[] FourBlock_AllRandom_ZeroEquals()
    {
        /* All values are random */

        //create block to return
        fv_FACEVALUE[] block = new fv_FACEVALUE[4];

        //loop block
        for (int i = 0; i <= 3; i++)
        {
            block[i] = GetRandomFaceValue();
        }

        return block;

        //return new fv_FACEVALUE[4] { v_equals, v_equals, v_7, v_equals };
    }

    static fv_FACEVALUE[] FourBlock_OneOrThreeEquals()
    {
        /* Left Side Equals Right Side */

        //create block to return
        fv_FACEVALUE[] block = new fv_FACEVALUE[4];

        //find common left/right facevalue
        fv_FACEVALUE commonvalue = GetRandomFaceValue(true);

        //larger left
        if (Roll_EitherOr())
        {
            //right side set
            block[2] = v_equals;
            block[3] = commonvalue;

            // 0 is commonvalue
            if (Roll_EitherOr())
            {
                //set 0
                block[0] = commonvalue;

                //set 1                                 // c _ = c
                {
                    /* v_blank works everywhere here */

                    // 0 _ = 0      //v_blank and v_0
                    // 3 _ = 3      //only v_blank
                    // + _ = +      //only v_blank
                    // - _ = -      //only v_blank
                    // b _ = b      //only v_blank
                    // = _ = =      //only v_blank

                    //set 1;
                    block[1] = v_blank;

                    //edge handle
                    if (commonvalue == v_0)
                    {
                        if (Roll_EitherOr())
                        {
                            //v_o also works
                            block[1] = v_0;
                        }
                    }

                }
            }
            // 1 is commonvalue
            else
            {
                //set 0                                 // _ c = c
                {
                    /* v_blank works everywhere here */

                    // _ 0 = 0      //v_0, v_add, v_sub, v_blank
                    // _ 3 = 3      //v_0, v_add, v_blank
                    // _ + = +      //only v_blank
                    // _ - = -      //only v_blank
                    // _ b = b      //only v_blank
                    // _ = = =      //only v_blank

                    //set 0;
                    block[0] = v_blank;

                    //edge handle
                    if (commonvalue == v_0)
                    {
                        //get val(4)
                        int rand = Random.Range(1, 5); //inclusive, exclusive

                        if(rand == 1)
                        {
                            block[0] = v_0;
                        }
                        else if (rand == 2)
                        {
                            block[0] = v_add;
                        }
                        else if (rand == 3)
                        {
                            block[0] = v_sub;
                        }

                        //rand = 4, stays as v_blank
                    }

                    //edge handle
                    if (bIsDigitMinusZero(commonvalue))
                    {
                        //get val(3)
                        int rand = Random.Range(1, 4); //inclusive, exclusive

                        if (rand == 1)
                        {
                            block[0] = v_0;
                        }
                        else if (rand == 2)
                        {
                            block[0] = v_add;
                        }

                        //rand = 3, stays as v_blank
                    }

                }

                //set 1
                block[1] = commonvalue;
            }
        }
        //larger right
        else
        {
            //left side set
            block[0] = commonvalue;
            block[1] = v_equals;

            // 2 is commonvalue
            if (Roll_EitherOr())
            {
                //set 2
                block[2] = commonvalue;

                //set 3                                 // c = c _
                {
                    /* v_blank works everywhere here */

                    // 0 = 0 _      //v_blank and v_0
                    // 3 = 3 _      //only v_blank
                    // + = + _      //only v_blank
                    // - = - _      //only v_blank
                    // b = b _      //only v_blank
                    // = = = _      //only v_blank

                    //set 3
                    block[3] = v_blank;

                    //edge handle
                    if (commonvalue == v_0)
                    {
                        if (Roll_EitherOr())
                        {
                            //v_o also works
                            block[3] = v_0;
                        }
                    }
                }
            }
            // 3 is commonvalue
            else
            {
                //set 2                                 // c = _ c
                {
                    /* v_blank works everywhere here */

                    // 0 = _ 0      //v_0, v_add, v_sub, v_blank
                    // 3 = _ 3      //v_0, v_add, v_blank
                    // + = _ +      //only v_blank
                    // - = _ -      //only v_blank
                    // b = _ b      //only v_blank
                    // = = _ =      //only v_blank

                    //set 2;
                    block[2] = v_blank;

                    //edge handle
                    if (commonvalue == v_0)
                    {
                        //get val(4)
                        int rand = Random.Range(1, 5); //inclusive, exclusive

                        if (rand == 1)
                        {
                            block[2] = v_0;
                        }
                        else if (rand == 2)
                        {
                            block[2] = v_add;
                        }
                        else if (rand == 3)
                        {
                            block[2] = v_sub;
                        }

                        //rand = 4, stays as v_blank
                    }

                    //edge handle
                    if (bIsDigitMinusZero(commonvalue))
                    {
                        //get val(3)
                        int rand = Random.Range(1, 4); //inclusive, exclusive

                        if (rand == 1)
                        {
                            block[2] = v_0;
                        }
                        else if (rand == 2)
                        {
                            block[2] = v_add;
                        }

                        //rand = 3, stays as v_blank
                    }

                }

                //set 3
                block[3] = commonvalue;
            }
        }


        return block;
    }


    /* SIX BLOCKS */

    static fv_FACEVALUE[] Get_SixBlock()
    {
        //return SixBlock_AllRandom_ZeroEquals();
        //return SixBlock_YesMath_Addition_OneEquals_AllDigits();
        //return SixBlock_NoMath_OneEquals_OneAndFourSplit();
        //return SixBlock_YesMath_Subtraction_OneEquals_AllDigits();
        return SixBlock_NoMath_OneEquals_TwoAndThreeSplit();

        //get rand
        //int rand = Random.Range(0, SixBlockTemplates); //inclusive, exclusive

        //switch (rand)
        //{
        //    case 0: return SixBlock_AllRandom_ZeroEquals();
        //    case 1: return SixBlock_NoMath_OneEquals_OneAndFourSplit();
        //    case 2: return SixBlock_YesMath_Addition_OneEquals_AllDigits();
        //    default: return SixBlock_AllRandom_ZeroEquals();
        //}
    }

    static fv_FACEVALUE[] SixBlock_AllRandom_ZeroEquals()
    {
        /* All values are random */

        //create block to return
        fv_FACEVALUE[] block = new fv_FACEVALUE[6];

        //loop block
        for (int i = 0; i <= 5; i++)
        {
            block[i] = GetRandomFaceValue();
        }

        return block;
    }

    static fv_FACEVALUE[] SixBlock_NoMath_OneEquals_OneAndFourSplit()
    {
        /* One Side Equals Four Side */
        /* Later, I Determine Left Or Right */

        //create fourblock
        fv_FACEVALUE[] fourblock = new fv_FACEVALUE[4];

        //find the one facevalue   - @@@@ this needs to be weighted towards digits
        fv_FACEVALUE onefacevalue = GetRandomFaceValue(true);

        //if digit
        if (bIsDigit(onefacevalue))
        {
            //get rand, 0 - 3
            int rand = Random.Range(0, 4); //inclusive, exclusive

            //place digit
            fourblock[rand] = onefacevalue;

            //fill, to the right, with blanks
            for(int i = rand + 1; i<=3; i++)
            {
                fourblock[i] = v_blank;
            }

            //fill, to the left, with blanks or +
            for (int i = rand - 1; i >= 0; i--)
            {
                if (Roll_EitherOr())
                {
                    fourblock[i] = v_blank;
                }
                else
                {
                    fourblock[i] = v_add;
                }
            }

            /* This is finished, but I'm going to add a chance for it to have two minus signs */

            // if digit placed at 2 or 3
            if(rand >= 2)
            {
                //get high chance to leave this code
                if(Random.value > 0.9f)
                {
                    //do nothing, move on
                }
                else
                {
                    // if digit placed at 2
                    if(rand == 2)
                    {
                        fourblock[0] = v_sub;
                        fourblock[1] = v_sub;
                    }
                    // if digit placed at 3
                    else
                    {
                        //make all sub
                        fourblock[0] = v_sub;
                        fourblock[1] = v_sub;
                        fourblock[2] = v_sub;

                        //get rand, 0 - 2
                        int newrand = Random.Range(0, 3); //inclusive, exclusive

                        //change newrand back to v_add
                        fourblock[newrand] = v_add;
                    }
                }
            }
        }
        //if NOT digit
        else
        {
            //if v_add
            if(onefacevalue == v_add)
            {
                fourblock = Get_BlankedFourBlock_WithThisValueInserted(v_add);
            }
            //if v_sub
            if (onefacevalue == v_sub)
            {
                fourblock = Get_BlankedFourBlock_WithThisValueInserted(v_sub);
            }
            //if v_blank
            if (onefacevalue == v_blank)
            {
                fourblock = Get_BlankedFourBlock_WithThisValueInserted(v_blank); 
            }
            //if v_equals
            if (onefacevalue == v_equals)
            {
                fourblock = Get_BlankedFourBlock_WithThisValueInserted(v_equals);
            }
        }

        //create block to return
        fv_FACEVALUE[] block = new fv_FACEVALUE[6];

        //place onefacevalue on left or right
        if (Roll_EitherOr())
        {
            block[0] = onefacevalue;
            block[1] = v_equals;
            block[2] = fourblock[0];
            block[3] = fourblock[1];
            block[4] = fourblock[2];
            block[5] = fourblock[3];
        }
        else
        {
            block[0] = fourblock[0];
            block[1] = fourblock[1];
            block[2] = fourblock[2];
            block[3] = fourblock[3];
            block[4] = v_equals;
            block[5] = onefacevalue;
        }

        //return block
        return block;
    }

    static fv_FACEVALUE[] SixBlock_NoMath_OneEquals_TwoAndThreeSplit()
    {
        // 2 block = 3 block
        // 2 7 = 2 _ 7
        // 2 7 = _ 2 7
        // 2 7 = 2 7 _
        // - 7 = - _ 7
        // 7 + = _ 7 +
        // 7 + = + 7 +



        /* Two Side Equals Three Side, No Math */
        /* Later, I Determine Left Or Right */

        //get random facevalues
        fv_FACEVALUE firstvalue = GetRandomFaceValue();
        fv_FACEVALUE secondvalue = GetRandomFaceValue();

        //create twoblock
        fv_FACEVALUE[] twoblock = new fv_FACEVALUE[2];

        //fill twoblock
        twoblock[0] = firstvalue;
        twoblock[1] = secondvalue;

        //create threeblock
        fv_FACEVALUE[] threeblock = new fv_FACEVALUE[3];

        //fill threeblock
        threeblock[0] = firstvalue;
        threeblock[1] = secondvalue;
        threeblock[2] = v_blank;

        //if(firstvalue == v_blank)

        //could just add a blank anywhere
        //if has a digit, can add a plus before hand






        /* Got both blocks made */
        /* Decide Left and Right, and combine */

        //create sixblock to return
        fv_FACEVALUE[] sixblock = new fv_FACEVALUE[6];

        //if left
        if (Roll_EitherOr())
        {
            sixblock[0] = threeblock[0];
            sixblock[1] = threeblock[1];
            sixblock[2] = threeblock[2];
            sixblock[3] = v_equals;
            sixblock[4] = twoblock[0];
            sixblock[5] = twoblock[1];
        }
        //if right
        else
        {
            sixblock[0] = twoblock[0];
            sixblock[1] = twoblock[1];
            sixblock[2] = v_equals;
            sixblock[3] = threeblock[0];
            sixblock[4] = threeblock[1];
            sixblock[5] = threeblock[2];
        }

        //return sixblock
        return sixblock;
    }


    static fv_FACEVALUE[] SixBlock_YesMath_Subtraction_OneEquals_AllDigits()
    {
        /* Minus Side Equals Two Int Side */
        /* int - int = int int */
        /* int - int = - int */
        /* Later, I Determine Left Or Right */

        //create threeblock
        fv_FACEVALUE[] threeblock = new fv_FACEVALUE[3];

        //fill threeblock
        threeblock[0] = GetRandomDigitValue();
        threeblock[1] = v_sub;
        threeblock[2] = GetRandomDigitValue();

        //create twoblock
        fv_FACEVALUE[] twoblock = new fv_FACEVALUE[2];

        //get result
        int firstint = VineValidator.Get_Digit(threeblock[0]);
        int secondint = VineValidator.Get_Digit(threeblock[2]);
        int result = firstint - secondint;

        //if positive, non-zero
        if (result > 0)
        {
            //get rand 1 - 4
            int rand = Random.Range(1, 5); //inclusive, exclusive

            switch (rand) // 09, _9, 9_, +9
            {
                case 1:
                    twoblock[0] = v_0;
                    twoblock[1] = VineValidator.Get_FaceValue(result);
                    break;
                case 2:
                    twoblock[0] = v_blank;
                    twoblock[1] = VineValidator.Get_FaceValue(result);
                    break;
                case 3:
                    twoblock[0] = VineValidator.Get_FaceValue(result);
                    twoblock[1] = v_blank;
                    break;
                case 4:
                    twoblock[0] = v_add;
                    twoblock[1] = VineValidator.Get_FaceValue(result);
                    break;
                default:
                    twoblock[0] = v_null;
                    twoblock[1] = v_null;
                    break;
            }
        }

        // if zero
        if (result == 0)
        {
            //get rand 1 - 5
            int rand = Random.Range(1, 6); //inclusive, exclusive

            switch (rand) //_0, 0_, 00, +0, -0
            {
                case 1:
                    twoblock[0] = v_blank;
                    twoblock[1] = v_0;
                    break;
                case 2:
                    twoblock[0] = v_0;
                    twoblock[1] = v_blank;
                    break;
                case 3:
                    twoblock[0] = v_0;
                    twoblock[1] = v_0;
                    break;
                case 4:
                    twoblock[0] = v_add;
                    twoblock[1] = v_0;
                    break;
                case 5:
                    twoblock[0] = v_sub;
                    twoblock[1] = v_0;
                    break;
                default:
                    twoblock[0] = v_null;
                    twoblock[1] = v_null;
                    break;
            }
        }

        // if negative
        if (result < 0)
        {
            // - (absolute value of result)
            twoblock[0] = v_sub;
            twoblock[1] = VineValidator.Get_FaceValue(Mathf.Abs(result));
        }

        /* Got both blocks made */
        /* Decide Left and Right, and combine */

        //create sixblock to return
        fv_FACEVALUE[] sixblock = new fv_FACEVALUE[6];

        //if left
        if (Roll_EitherOr())
        {
            sixblock[0] = threeblock[0];
            sixblock[1] = threeblock[1];
            sixblock[2] = threeblock[2];
            sixblock[3] = v_equals;
            sixblock[4] = twoblock[0];
            sixblock[5] = twoblock[1];
        }
        //if right
        else
        {
            sixblock[0] = twoblock[0];
            sixblock[1] = twoblock[1];
            sixblock[2] = v_equals;
            sixblock[3] = threeblock[0];
            sixblock[4] = threeblock[1];
            sixblock[5] = threeblock[2];
        }

        //return sixblock
        return sixblock;
    }

    static fv_FACEVALUE[] SixBlock_YesMath_Addition_OneEquals_AllDigits()
    {

        /* EDGE CASE */
        //make two sides
        // number + number number = number
        // this one seems unlikely, but is doable
        // 1+01=2


        /* Plus Side Equals Two Int Side */
        /* int + int = int int */
        /* Later, I Determine Left Or Right */

        //create threeblock
        fv_FACEVALUE[] threeblock = new fv_FACEVALUE[3];

        //fill threeblock
        threeblock[0] = GetRandomDigitValue();
        threeblock[1] = v_add;
        threeblock[2] = GetRandomDigitValue();

        //create twoblock
        fv_FACEVALUE[] twoblock = new fv_FACEVALUE[2];

        //get result
        int firstint = VineValidator.Get_Digit(threeblock[0]);
        int secondint = VineValidator.Get_Digit(threeblock[2]);
        int result = firstint + secondint;

        //if result ten or over
        if(result >= 10)
        {
            //first is 1
            twoblock[0] = v_1;

            //second is result - 10, converted to facevalue
            twoblock[1] = VineValidator.Get_FaceValue(result - 10);
        }

        //else if result positive, non-zero, less than 10
        else if(result > 0)
        {
            //get rand 1 - 4
            int rand = Random.Range(1, 5); //inclusive, exclusive

            switch (rand) // 09, _9, 9_, +9
            {
                case 1:
                    twoblock[0] = v_0;
                    twoblock[1] = VineValidator.Get_FaceValue(result);
                    break;
                case 2:
                    twoblock[0] = v_blank;
                    twoblock[1] = VineValidator.Get_FaceValue(result);
                    break;
                case 3:
                    twoblock[0] = VineValidator.Get_FaceValue(result);
                    twoblock[1] = v_blank;
                    break;
                case 4:
                    twoblock[0] = v_add;
                    twoblock[1] = VineValidator.Get_FaceValue(result);
                    break;
                default:
                    twoblock[0] = v_null;
                    twoblock[1] = v_null;
                    break;
            }
        }

        //if result 0
        if(result == 0)
        {
            //get rand 1 - 5
            int rand = Random.Range(1, 6); //inclusive, exclusive

            switch (rand) //_0, 0_, 00, +0, -0
            {
                case 1:
                    twoblock[0] = v_blank;
                    twoblock[1] = v_0;
                    break;
                case 2:
                    twoblock[0] = v_0;
                    twoblock[1] = v_blank;
                    break;
                case 3:
                    twoblock[0] = v_0;
                    twoblock[1] = v_0;
                    break;
                case 4:
                    twoblock[0] = v_add;
                    twoblock[1] = v_0;
                    break;
                case 5:
                    twoblock[0] = v_sub;
                    twoblock[1] = v_0;
                    break;
                default:
                    twoblock[0] = v_null;
                    twoblock[1] = v_null;
                    break;
            }
        }

        /* Got both blocks made */
        /* Decide Left and Right, and combine */

        //create sixblock to return
        fv_FACEVALUE[] sixblock = new fv_FACEVALUE[6];

        //if left
        if (Roll_EitherOr())
        {
            sixblock[0] = threeblock[0];
            sixblock[1] = threeblock[1];
            sixblock[2] = threeblock[2];
            sixblock[3] = v_equals;
            sixblock[4] = twoblock[0];
            sixblock[5] = twoblock[1];
        }
        //if right
        else
        {
            sixblock[0] = twoblock[0];
            sixblock[1] = twoblock[1];
            sixblock[2] = v_equals;
            sixblock[3] = threeblock[0];
            sixblock[4] = threeblock[1];
            sixblock[5] = threeblock[2];
        }

        //return sixblock
        return sixblock;
    }



    /* UTILITIES */

    public static fv_FACEVALUE GetRandomFaceValue(bool bIncludeEquals = false)
        {
            // facevalue enum limit
            int limit = 13;

            //if including equals
            if (bIncludeEquals)
            {
                limit = 14;
            }

            //get rand
            int rand = Random.Range(1, limit + 1); //inclusive, exclusive

            //cast to facevalue
            return (fv_FACEVALUE)rand;
        }

    public static fv_FACEVALUE GetRandomDigitValue()
    {
        //get rand index for enum digits
        int rand = Random.Range(1, 11); //inclusive, exclusive

        //cast to facevalue
        return (fv_FACEVALUE)rand;
    }

    static int ConvertToIndex(wg_ADDRESS address)
    {
        switch (address)
        {
            case AA: return 0;
            case BB: return 1;
            case CC: return 2;
            case DD: return 3;
            case EE: return 4;
            case FF: return 5;
            case GG: return 6;
            default: return 0;
        }
    }

    public static bool Roll_EitherOr()
    {
        return (Random.value > 0.5f);
    }

    static bool bIsDigitMinusZero(fv_FACEVALUE val)
    {
        //cast
        int valcast = (int)val;

        //if val is v_1 -> v_9
        if(valcast >= 2 && valcast <= 10)
        {
            return true;
        }

        return false;
    }

    static bool bIsDigit(fv_FACEVALUE val)
    {
        //cast
        int valcast = (int)val;

        //if val is v_0 -> v_9
        if (valcast >= 1 && valcast <= 10)
        {
            return true;
        }

        return false;
    }

    static void Shuffle_IndexArray(ref int[] index_array)
    {
        for (int i = 0; i<=6; i++)
        {
            int temp = index_array[i];
            int rand = Random.Range(i, 7); //inclusive, exclusive
            index_array[i] = index_array[rand];
            index_array[rand] = temp;
        }
    }

    static fv_FACEVALUE[] Get_BlankedFourBlock_WithThisValueInserted(fv_FACEVALUE val)
    {
        //create block to return
        fv_FACEVALUE[] block = new fv_FACEVALUE[4] {v_blank, v_blank, v_blank, v_blank };

        //get rand
        int rand = Random.Range(0, 4); //inclusive, exclusive

        //add val
        block[rand] = val;

        //return
        return block;

    }
}
