using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static wg_ADDRESS;

static public class PuzzleBuilder_Title
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

        //remove pieces
        Remove_RandomPieces(ref hc_list);


        /* at this point, we just need to combine the lists of honeycombs into the new object */

        //build new puzzle object
        PuzzleInfo puz = new PuzzleInfo();

        foreach (var honeycomblist in hc_list)
        {
            foreach (var slot in honeycomblist)
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
        foreach (var honeycomb in hc_list)
        {
            //enum offset by honeyslot
            int hslot_counter = 2;

            //loop slots
            foreach (var slot in honeycomb)
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
    static private void Remove_RandomPieces(ref List<List<HoneySlotInfo>> hc_list)
    {
        //loop honeycombs - start at 1
        for (int i = 1; i <= 6; i++)
        {
            //make remove_array of indexes
            List<int> remove_array = new List<int>();

            //loop slotrder_array, backwards
            for (int a = 6; a >= 0; a--)
            {
                //get random
                float rand = Random.value;

                if(rand <= 0.27f)    
                {
                    remove_array.Add(a);
                }
            }

            //loop remove_array
            foreach(int index in remove_array)
            {
                //remove from list
                hc_list[i].RemoveAt(index);
            }
        }
    }
    static private void ShuffleSpin_FaceValues_Uniformly(ref fv_FACEVALUE[] order)
    {
        //clone array
        fv_FACEVALUE[] copy = (fv_FACEVALUE[])order.Clone();

        //get rand num to spin
        int rand = Random.Range(0, 6); //inclusive, exclusive

        //loop order
        for (int i = 0; i <= 5; i++)
        {
            //get spun index
            int spun_index = i + rand;

            //fix spun_index maybe
            if (spun_index > 5)
            {
                //reset by taking away 6;
                spun_index -= 6;
            }

            //change original  array
            order[i] = copy[spun_index];
        }
    }

   



}
