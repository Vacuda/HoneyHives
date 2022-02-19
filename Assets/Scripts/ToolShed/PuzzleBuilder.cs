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


        //place into honeycombs
        Place_IntoHoneyCombs(ref hc_list);


        //@@@@ if a setting, use this method
        if (true)
        {
            UseLinearMethod_ToDetermineHoneyLockedPieces(ref hc_list);
        }




        //move around all pieces












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


            //change address

        




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
}
