//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static wg_ADDRESS;

static public class PuzzleBuilder
{
    static public PuzzleInfo Build_Puzzle(PuzzleSettings settings)
    {
        //build new honeycomb list
        List<List<HoneySlotInfo>> hc_list = new List<List<HoneySlotInfo>>();

        //populate with seven raw honeycombs
        LevelHouse.Get_SevenHoneyCombs(ref hc_list);

        //if settings spinnable
        if (settings.bSpinPieces)
        {
            //spin relative pieces
            Spin_SpinablePieces(ref hc_list);
        }

        //place into honeycombs
        Place_IntoHoneyCombs(ref hc_list);

        //build list of movable spots
        List<wg_ADDRESS> movable_list = Build_MovableSlotList(ref hc_list);

        //@@@@ if a setting, use this method
        if (true)
        {
            UseLinearMethod_ToDetermineHoneyLockedPieces(ref hc_list);
        }

        //if settings move pieces
        if (settings.bMovePieces)
        {
            //shuffle movable pieces
            Shuffle_MovablePieces(ref hc_list, ref movable_list);
        }

        /* at this point, we just need to combine the lists of honeycombs into the new object */

        //build new puzzle object
        PuzzleInfo puz = new PuzzleInfo();

        foreach(var honeycomblist in hc_list)
        {
            foreach(var slot in honeycomblist)
            {
                //add to new list
                puz.HoneySlots.Add(slot);
            }
        }

        return puz;
    }

    static private void Place_IntoHoneyCombs(ref List<List<HoneySlotInfo>> hc_list)
    {
        //this function changes the slot address BB->CC_BB, thus placing it into a honeycomb
        //it uses an int casted to an enum slot

        //enum offset by honeycomb
        int hc_counter = 0;

        //loop through 7 honeycombs
        foreach(var honeycomb in hc_list)
        {
            //enum offset by honeyslot
            int hslot_counter = 2;

            //loop slots
            foreach(var slot in honeycomb)
            {
                //change address
                slot.Address = (wg_ADDRESS)(hslot_counter + 8 * hc_counter);

                //increment counter
                hslot_counter++;
            }

            //increment counter
            hc_counter++;
        }
    }

    static private void UseLinearMethod_ToDetermineHoneyLockedPieces(ref List<List<HoneySlotInfo>> hc_list)
    {
        /* This creates a random line of honeycombs.  The first is unaltered. */
        /* Then, each successive honeycomb finds a movable piece to remove and move to the previous honeycomb */
        /* This honeycomb is then honeylocked into this new honeycomb */

        //initialize array for order of honeycomb line
        int[] comborder_array = new int[7] { 0, 1, 2, 3, 4, 5, 6 };

        //randomize array
        Shuffle_Array(ref comborder_array);

        //initialize proper indexes
        int proper_index = 0;
        int proper_prev_index;
        int[] slotorder_array = new int[7] { 0, 1, 2, 3, 4, 5, 6 };

        //Index 0 is skipped - First honeycomb is skipped

        //loop honeycombs - start at 1
        for (int i = 1; i<=6; i++)
        {
            //get indexes from order_array
            proper_index = comborder_array[i];
            proper_prev_index = comborder_array[i - 1];

            //get another index array
            Shuffle_Array(ref slotorder_array);

            //loop slotrder_array
            for(int a=0; a<=6; a++)
            {
                //condense
                HoneySlotInfo slotinfo = hc_list[proper_index][a];

                //found a suitable slot
                if (slotinfo.IsMovable)
                {
                    //BB_AA -> AA

                    //get prev honeycomb first address
                    wg_ADDRESS prev_address = hc_list[proper_prev_index][0].Address;

                    //change this address to prev honeycomb honey-locked spot
                    slotinfo.Address = Get_HoneyLockedAddress(prev_address);

                    //change to honeylocked
                    slotinfo.HoneyJar_Originated = true;

                    //go to prev honeycomb, add
                    hc_list[proper_prev_index].Add(slotinfo);

                    //remove from old list
                    hc_list[proper_index].Remove(slotinfo);

                    //no longer need to loop
                    break;
                }
            }
        }

    /* All but the final honeycomb has a honeylocked piece */

        //create dummy honeylocked piece
        {
            //get this honeycomb first address
            wg_ADDRESS first_address = hc_list[proper_index][0].Address;

            //get honey locked address for final honeycomb
            wg_ADDRESS hc_address = Get_HoneyLockedAddress(first_address);

            //make and add a dummy piece to honey slot address
            LevelHouse.MakeAndAdd_DummyPiece(hc_address, ref hc_list);
        }
    }

    static private void Shuffle_MovablePieces(ref List<List<HoneySlotInfo>> hc_list, ref List<wg_ADDRESS> movable_list)
    {
        /* The shuffled movable list works as a guide to place any movable pieces found in hc_list */

        //shuffle movable list
        Shuffle_List(ref movable_list);

        //use movable_list as guide to move all movable pieces by changing address
        {
            //start index
            int index = 0;

            //loop through 7 honeycombs
            foreach (var honeycomb in hc_list)
            {
                //loop 7 slots
                foreach (var slot in honeycomb)
                {
                    //if movable
                    if (slot.IsMovable)
                    {
                        //if not honey lock originated
                        if (!slot.HoneyJar_Originated)
                        {
                            //change address
                            slot.Address = movable_list[index];

                            //increment through movables
                            index++;
                        }
                    }
                }
            }
        }
    }

    static private void Spin_SpinablePieces(ref List<List<HoneySlotInfo>> hc_list)
    {
        /* Go to every spinnable piece and move each face value down it's own conveyor belt by 1-5 units */

        //loop through 7 honeycombs
        foreach (var honeycomb in hc_list)
        {
            //loop slots
            foreach (var slot in honeycomb)
            {
                //if spinnable
                if (slot.IsSpinnable)
                {
                    //if not honey lock originated
                    if (!slot.HoneyJar_Originated)
                    {
                        //store order
                        fv_FACEVALUE[] order = new fv_FACEVALUE[6]
                        {
                            slot.fv_1, slot.fv_2, slot.fv_3, slot.fv_4, slot.fv_5, slot.fv_6
                        };

                        //Debug.Log("----------------");
                        //foreach(var item in order)
                        //{
                        //    Debug.Log("facevalues: " + item.ToString());
                        //}
                        //Debug.Log("0000");

                        //shuffle order
                        ShuffleSpin_FaceValues_Uniformly(ref order);

                        //foreach (var item in order)
                        //{
                        //    Debug.Log("facevalues: " + item.ToString());
                        //}
                        //Debug.Log("----------------");

                        //change honeyslot info
                        slot.fv_1 = order[0];
                        slot.fv_2 = order[1];
                        slot.fv_3 = order[2];
                        slot.fv_4 = order[3];
                        slot.fv_5 = order[4];
                        slot.fv_6 = order[5];
                    }
                }
            }
        }
    }

    //UTILITIES
    static private void Shuffle_Array(ref int[] array)
    {
        for (int i=0; i<=6; i++)
        {
            int temp = array[i];
            int rand = Random.Range(i, 7); //inclusive, exclusive
            array[i] = array[rand];
            array[rand] = temp;
        }
    }

    static private void Shuffle_List(ref List<wg_ADDRESS> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            wg_ADDRESS temp = list[i];
            int rand = Random.Range(i, list.Count); //inclusive, exclusive
            list[i] = list[rand];
            list[rand] = temp;
        }
    }

    static private wg_ADDRESS Get_HoneyLockedAddress(wg_ADDRESS address)
    {
        //change AA_DD into AA

        //change to int to determine honeylockaddress
        int intvalue = (int)address;

        if(intvalue < 9)
        {
            return AA;
        }
        if (intvalue < 17)
        {
            return BB;
        }
        if (intvalue < 25)
        {
            return CC;
        }
        if (intvalue < 33)
        {
            return DD;
        }
        if (intvalue < 41)
        {
            return EE;
        }
        if (intvalue < 49)
        {
            return FF;
        }

        return GG;
    }

    static private void ShuffleSpin_FaceValues_Uniformly(ref fv_FACEVALUE[] order)
    {
        //clone array
        fv_FACEVALUE[] copy = (fv_FACEVALUE[])order.Clone();

        //get rand num to spin
        int rand = Random.Range(0, 6); //inclusive, exclusive

        //loop order
        for(int i=0; i<=5; i++)
        {
            //get spun index
            int spun_index = i + rand;

            //fix spun_index maybe
            if(spun_index > 5)
            {
                //reset by taking away 6;
                spun_index -= 6;
            }

            //change original  array
            order[i] = copy[spun_index];
        }
    }

    static List<wg_ADDRESS> Build_MovableSlotList(ref List<List<HoneySlotInfo>> hc_list)
    {
        //initialize return list
        List<wg_ADDRESS> list = new List<wg_ADDRESS>();

        //loop through 7 honeycombs
        foreach (var honeycomb in hc_list)
        {
            //loop slots
            foreach (var slot in honeycomb)
            {
                //if movable
                if (slot.IsMovable){ 

                    //if not honey lock originated
                    if (!slot.HoneyJar_Originated){

                        //add address
                        list.Add(slot.Address);
                    }
                }
            }
        }

        return list;
    }



}
