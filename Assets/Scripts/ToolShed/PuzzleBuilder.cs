//using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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





















    //at this point, we just need to combine the lists of honeycombs into the new object


        //build new puzzle object
        PuzzleInfo puz = new PuzzleInfo();

        foreach(var honeycomblist in hc_list)
        {
            foreach(var slot in honeycomblist)
            {
                puz.HoneySlots.Add(slot);

            }


        }

        //transfer honeycombs

        return puz;
    }

    static private void Place_IntoHoneyCombs(ref List<List<HoneySlotInfo>> hc_list)
    {
        int biggercounter = 0;

        //loop through 7 honeycombs
        foreach(var honeycomb in hc_list)
        {
            int counter = 2;


            //loop slots
            foreach(var slot in honeycomb)
            {
                //needs to be 2
                slot.Address = (wg_ADDRESS)(counter + 8 * biggercounter);

                //increment counter
                counter++;
            }

            biggercounter++;

        }
    }


}
