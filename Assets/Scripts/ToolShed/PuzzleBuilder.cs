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

        //spin relative pieces
        Spin_SpinablePieces(ref hc_list);

        //place into honeycombs
        Place_IntoHoneyCombs(ref hc_list);

        //initialize list of vacant spots
        List<wg_ADDRESS> vacant_list;

        //@@@@ if a setting, use this method
        if (true)
        {
            vacant_list = UseLinearMethod_ToDetermineHoneyLockedPieces(ref hc_list);
        }

        //shuffle movable pieces
        Shuffle_MovablePieces(ref hc_list, vacant_list);

    /* at this point, we just need to combine the lists of honeycombs into the new object */

        //build new puzzle object
        PuzzleInfo puz = new PuzzleInfo();

        foreach(var honeycomblist in hc_list)
        {
            foreach(var slot in honeycomblist)
            {
                //Debug.Log("address: " + slot.Address);


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

    static private List<wg_ADDRESS> UseLinearMethod_ToDetermineHoneyLockedPieces(ref List<List<HoneySlotInfo>> hc_list)
    {
        //initialize list to retrun
        List<wg_ADDRESS> returnlist = new List<wg_ADDRESS>();

        //initialize array for order of honeycomb line
        int[] order_array = new int[7] { 0, 1, 2, 3, 4, 5, 6 };

        //randomize array
        RandomizeArray(ref order_array);

    //Index 0 is skipped

        //start at 1
        int i = 1;

        //safety counter
        int counter = 0;

        //initialize proper indexes
        int proper_index = 0;
        int proper_prev_index = 0;

        //while loop, from indexes 1-6
        while(i < 7)
        {
            //get indexes from order_array
            proper_index = order_array[i];
            proper_prev_index = order_array[i - 1];

            //get rand piece from the 7
            int rand = Random.Range(0, 7); //inclusive, exclusive 0-6

            //condense
            HoneySlotInfo slotinfo = hc_list[proper_index][rand];

            //if movable
            if (slotinfo.IsMovable)
            {
                //BB_AA -> AA

                //get prev honeycomb first address
                wg_ADDRESS prev_address = hc_list[proper_prev_index][0].Address;

                //store old address for returnlist
                returnlist.Add(slotinfo.Address);

                //change this address to prev honeycomb honey-locked spot
                slotinfo.Address = Get_HoneyLockedAddress(prev_address);

                //change to honeylocked
                slotinfo.HoneyJar_Originated = true;

                //go to prev honeycomb, add
                hc_list[proper_prev_index].Add(slotinfo);

                //remove from old list
                hc_list[proper_index].Remove(slotinfo);

                //increment to next honeycomb in the order from order_array
                i++;
            }
            else
            {
                //keep trying to get a movable piece
            }

            


            //safety counter
            counter++;
            if(counter > 1000)
            {
                Debug.Log("something wrong.");
            }


            //i'm trying to understand how to move these things around
            //right now, they exist as a list of a list of HoneySlotInfo objects (not gameObjects)
            //and they WILL BE placed according to the addresses

            //if I want to move an address, I can just change it
            //But it needs to be done in an organized way to make sure no slots are double booked

            //that's the only thing that matters right now, because this is only just information
            //and the gameObjects are built from this blueprint
        }

    /* All but the final honeycomb has a honeylocked piece */

        //create dummy honeylocked piece

        //get this honeycomb first address
        wg_ADDRESS first_address = hc_list[proper_index][0].Address;

        //get honey locked address for final honeycomb
        wg_ADDRESS hc_address = Get_HoneyLockedAddress(first_address);

        //make and add a dummy piece to honey slot address
        LevelHouse.MakeAndAdd_DummyPiece(hc_address, ref hc_list);



        return returnlist;

    }

    static private void Shuffle_MovablePieces(ref List<List<HoneySlotInfo>> hc_list, List<wg_ADDRESS> prev_vacant_list)
    {
        //initialize list of vacant_list
        List<wg_ADDRESS> vacant_list = new List<wg_ADDRESS>();

        //build vacant_list
        {
            //loop through 7 honeycombs
            foreach (var honeycomb in hc_list)
            {
                //loop slots
                foreach (var slot in honeycomb)
                {
                    //if movable
                    if(slot.IsMovable){

                        //if not honey lock originated
                        if (!slot.HoneyJar_Originated)
                        {
                            //add address
                            vacant_list.Add(slot.Address);
                        }
                    }
                }
            }
        }

        //combine vacant_list and prev_vacant_list
        foreach(var item in prev_vacant_list)
        {
            //add
            vacant_list.Add(item);
        }

        //shuffle list
        ShuffleList(ref vacant_list);

        //use vacant_list as guide to move all movable pieces by changing address
        {
            //start index
            int index = 0;

            //loop through 7 honeycombs
            foreach (var honeycomb in hc_list)
            {
                //loop slots
                foreach (var slot in honeycomb)
                {
                    //if movable
                    if (slot.IsMovable)
                    {
                        //if not honey lock originated
                        if (!slot.HoneyJar_Originated)
                        {
                            //change address
                            slot.Address = vacant_list[index];

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
    static private void RandomizeArray(ref int[] array)
    {
        for (int i=0; i<=6; i++)
        {
            int temp = array[i];
            int rand = Random.Range(i, 7); //inclusive, exclusive
            array[i] = array[rand];
            array[rand] = temp;
        }
    }

    static private void ShuffleList(ref List<wg_ADDRESS> list)
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

   
}
