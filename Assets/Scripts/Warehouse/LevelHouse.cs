using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ln_LEVELNAME;
using static wg_ADDRESS;
using static fv_FACEVALUE;

static public class LevelHouse
{
    static int HoneyComb_Total = 7;

    static public void Get_SevenHoneyCombs(ref List<List<HoneySlotInfo>> hc_list)
    {
        //total amount of honeycombs in here
        //int HoneyComb_Total = 7;

        //fixed array
        int[] array = new int[7] {0,0,0,0,0,0,0};

        //start indexcounter
        int index_counter = 0;

        //safety counter
        int counter = 0;
        
        //build array in while loop
        while(index_counter < 7)
        {
            //get random number
            int rand = GetRandom_HoneyCombSolution();

            //if unique
            if (CheckUniqueness(rand, ref array))
            {
                //change number
                array[index_counter] = rand;

                //increment
                index_counter++;
            }

            //safety
            counter++;
            if(counter > 1000)
            {
                Debug.Log("Somethings wrong with Get_SevenHoneyCombs while loop");
                index_counter = 8;
            }
        }

        //rand num array is built.  Now, we'll use this to take each unique honeycomb and put it into the list

        //loop array 0-6
        for(int i=0; i<=6; i++)
        {
            //add to list
            Add_ThisHoneyComb(array[i], ref hc_list);
        }
    }


    static public void Add_ThisHoneyComb(int rand, ref List<List<HoneySlotInfo>> hc_list, wg_ADDRESS address = NONE)
    {
        /* 3rd parameter is defaulted.  If there, it will be a dummy request for only one slotinfo */
        /* this is handled at the bottom */

        //make slotlist to add
        List<HoneySlotInfo> slotlist = new List<HoneySlotInfo>();

        switch (rand)
        {
            case 1:
                slotlist.Add(new HoneySlotInfo(AA, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
                slotlist.Add(new HoneySlotInfo(BB, false, false, v_9, v_2, v_blank, v_7, v_blank, v_blank));
                slotlist.Add(new HoneySlotInfo(CC, true, true, v_7, v_7, v_blank, v_1, v_0, v_blank));
                slotlist.Add(new HoneySlotInfo(DD, true, true, v_2, v_5, v_blank, v_equals, v_add, v_blank));
                slotlist.Add(new HoneySlotInfo(EE, true, false, v_8, v_add, v_2, v_blank, v_4, v_blank));
                slotlist.Add(new HoneySlotInfo(FF, true, false, v_7, v_7, v_blank, v_equals, v_equals, v_blank));
                slotlist.Add(new HoneySlotInfo(GG, false, true, v_5, v_blank, v_blank, v_blank, v_blank, v_blank));
                break;
            case 2:
                slotlist.Add(new HoneySlotInfo(AA, true, true, v_2, v_2, v_2, v_2, v_2, v_2));
                slotlist.Add(new HoneySlotInfo(BB, false, false, v_9, v_2, v_blank, v_7, v_blank, v_blank));
                slotlist.Add(new HoneySlotInfo(CC, true, true, v_7, v_7, v_blank, v_1, v_0, v_blank));
                slotlist.Add(new HoneySlotInfo(DD, true, true, v_2, v_5, v_blank, v_equals, v_add, v_blank));
                slotlist.Add(new HoneySlotInfo(EE, true, false, v_8, v_add, v_2, v_blank, v_4, v_blank));
                slotlist.Add(new HoneySlotInfo(FF, true, false, v_7, v_7, v_blank, v_equals, v_equals, v_blank));
                slotlist.Add(new HoneySlotInfo(GG, false, true, v_5, v_blank, v_blank, v_blank, v_blank, v_blank));
                break;
            case 3:
                slotlist.Add(new HoneySlotInfo(AA, true, true, v_3, v_3, v_3, v_3, v_3, v_3));
                slotlist.Add(new HoneySlotInfo(BB, false, false, v_9, v_2, v_blank, v_7, v_blank, v_blank));
                slotlist.Add(new HoneySlotInfo(CC, true, true, v_7, v_7, v_blank, v_1, v_0, v_blank));
                slotlist.Add(new HoneySlotInfo(DD, true, true, v_2, v_5, v_blank, v_equals, v_add, v_blank));
                slotlist.Add(new HoneySlotInfo(EE, true, false, v_8, v_add, v_2, v_blank, v_4, v_blank));
                slotlist.Add(new HoneySlotInfo(FF, true, false, v_7, v_7, v_blank, v_equals, v_equals, v_blank));
                slotlist.Add(new HoneySlotInfo(GG, false, true, v_5, v_blank, v_blank, v_blank, v_blank, v_blank));
                break;
            case 4:
                slotlist.Add(new HoneySlotInfo(AA, true, true, v_4, v_4, v_4, v_4, v_4, v_4));
                slotlist.Add(new HoneySlotInfo(BB, false, false, v_9, v_2, v_blank, v_7, v_blank, v_blank));
                slotlist.Add(new HoneySlotInfo(CC, true, true, v_7, v_7, v_blank, v_1, v_0, v_blank));
                slotlist.Add(new HoneySlotInfo(DD, true, true, v_2, v_5, v_blank, v_equals, v_add, v_blank));
                slotlist.Add(new HoneySlotInfo(EE, true, false, v_8, v_add, v_2, v_blank, v_4, v_blank));
                slotlist.Add(new HoneySlotInfo(FF, true, false, v_7, v_7, v_blank, v_equals, v_equals, v_blank));
                slotlist.Add(new HoneySlotInfo(GG, false, true, v_5, v_blank, v_blank, v_blank, v_blank, v_blank));
                break;
            case 5:
                slotlist.Add(new HoneySlotInfo(AA, true, true, v_5, v_5, v_5, v_5, v_5, v_5));
                slotlist.Add(new HoneySlotInfo(BB, false, false, v_9, v_2, v_blank, v_7, v_blank, v_blank));
                slotlist.Add(new HoneySlotInfo(CC, true, true, v_7, v_7, v_blank, v_1, v_0, v_blank));
                slotlist.Add(new HoneySlotInfo(DD, true, true, v_2, v_5, v_blank, v_equals, v_add, v_blank));
                slotlist.Add(new HoneySlotInfo(EE, true, false, v_8, v_add, v_2, v_blank, v_4, v_blank));
                slotlist.Add(new HoneySlotInfo(FF, true, false, v_7, v_7, v_blank, v_equals, v_equals, v_blank));
                slotlist.Add(new HoneySlotInfo(GG, false, true, v_5, v_blank, v_blank, v_blank, v_blank, v_blank));
                break;
            case 6:
                slotlist.Add(new HoneySlotInfo(AA, true, true, v_6, v_6, v_6, v_6, v_6, v_6));
                slotlist.Add(new HoneySlotInfo(BB, false, false, v_9, v_2, v_blank, v_7, v_blank, v_blank));
                slotlist.Add(new HoneySlotInfo(CC, true, true, v_7, v_7, v_blank, v_1, v_0, v_blank));
                slotlist.Add(new HoneySlotInfo(DD, true, true, v_2, v_5, v_blank, v_equals, v_add, v_blank));
                slotlist.Add(new HoneySlotInfo(EE, true, false, v_8, v_add, v_2, v_blank, v_4, v_blank));
                slotlist.Add(new HoneySlotInfo(FF, true, false, v_7, v_7, v_blank, v_equals, v_equals, v_blank));
                slotlist.Add(new HoneySlotInfo(GG, false, true, v_5, v_blank, v_blank, v_blank, v_blank, v_blank));
                break;
            case 7:
                slotlist.Add(new HoneySlotInfo(AA, true, true, v_7, v_7, v_7, v_7, v_7, v_7));
                slotlist.Add(new HoneySlotInfo(BB, false, false, v_9, v_2, v_blank, v_7, v_blank, v_blank));
                slotlist.Add(new HoneySlotInfo(CC, true, true, v_7, v_7, v_blank, v_1, v_0, v_blank));
                slotlist.Add(new HoneySlotInfo(DD, true, true, v_2, v_5, v_blank, v_equals, v_add, v_blank));
                slotlist.Add(new HoneySlotInfo(EE, true, false, v_8, v_add, v_2, v_blank, v_4, v_blank));
                slotlist.Add(new HoneySlotInfo(FF, true, false, v_7, v_7, v_blank, v_equals, v_equals, v_blank));
                slotlist.Add(new HoneySlotInfo(GG, false, true, v_5, v_blank, v_blank, v_blank, v_blank, v_blank));
                break;
            default:
                slotlist.Add(new HoneySlotInfo(AA, true, true, v_2, v_blank, v_1, v_5, v_blank, v_add));
                slotlist.Add(new HoneySlotInfo(BB, false, false, v_9, v_2, v_blank, v_7, v_blank, v_blank));
                slotlist.Add(new HoneySlotInfo(CC, true, true, v_7, v_7, v_blank, v_1, v_0, v_blank));
                slotlist.Add(new HoneySlotInfo(DD, true, true, v_2, v_5, v_blank, v_equals, v_add, v_blank));
                slotlist.Add(new HoneySlotInfo(EE, true, false, v_8, v_add, v_2, v_blank, v_4, v_blank));
                slotlist.Add(new HoneySlotInfo(FF, true, false, v_7, v_7, v_blank, v_equals, v_equals, v_blank));
                slotlist.Add(new HoneySlotInfo(GG, false, true, v_5, v_blank, v_blank, v_blank, v_blank, v_blank));
                break;
        }

        //if not dummy piece try
        if (address == NONE)
        {
            //add to list
            hc_list.Add(slotlist);
        }
        //just need dummy piece
        else
        {
            //index of list that we should add to
            int proper_index = -1;

            //need to find proper home
            {
                //loop hc_list
                for(int i=0; i<=6; i++)
                {
                    //find first address
                    wg_ADDRESS first_address = hc_list[i][0].Address;

                    //if proper home
                    if (IsThisAProperHome(first_address, address))
                    {
                        //found index
                        proper_index = i;
                    }
                }

            }

            //find a dummy piece index
            int index = Random.Range(0, 7);  //inclusive, exclusive

            //change address and origination
            slotlist[index].Address = address;
            slotlist[index].HoneyJar_Originated = true;

            //send this slotinfo to the proper home
            hc_list[proper_index].Add(slotlist[index]);

            /* the rest of these slotinfos will be destroyed */
        }
    }









    

    //LevelInfo Get_Level_001()
    //{
    //    //make package to return
    //    LevelInfo LevelPackage = new LevelInfo();

    //    //initialize internal list
    //    LevelPackage.HoneySlots = new List<HoneySlotInfo>();

    //    //find 7 honeycomb solutions
    //    //give honeycomb address
    //    //if spinable, spin randomly




    //    //if unmovable - > place accordingly




    //    //an issue here is that these solutions produce 49 tiles.
    //    //so atleast 49 tiles made for a level

    //    //I think there should always be a piece in the honey jar.  
    //    //So, if done in linear honeycomb order.
    //    //one is free solvable. 
    //    //6 then, are honey locked
    //    //atleast ONE additional piece needs to be generated as a decoy.
    //    //so, 50 minimum.

    //    //there's various ways this can be done, according to settings.
    //    //So, it should build from a settings object.


    //    //if there is only 49 tiles, there








    //UTILITIES

    static private bool CheckUniqueness(int num, ref int[] array)
    {
        //loop array
        foreach(int setnum in array)
        {
            //if match
            if (num == setnum)
            {
                //failed uniqueness
                return false;
            }
        }

        //is unique
        return true;
    }

    static public void MakeAndAdd_DummyPiece(wg_ADDRESS address, ref List<List<HoneySlotInfo>> hc_list)
    {
        //get random number
        int rand = GetRandom_HoneyCombSolution();


        Add_ThisHoneyComb(rand, ref hc_list, address);
    }

    static private int GetRandom_HoneyCombSolution()
    {
        return Random.Range(1, HoneyComb_Total + 1); //inclusive, exclusive
    }

    static private bool IsThisAProperHome(wg_ADDRESS first_address, wg_ADDRESS address)
    {
        //change to int to determine match
        int intvalue = (int)first_address;
        wg_ADDRESS target_address = NONE;


        //comparing AA_AA to BB


        if (intvalue < 9)
        {
            target_address = AA;
        }
        else if (intvalue < 17)
        {
            target_address = BB;
        }
        else if (intvalue < 25)
        {
            target_address = CC;
        }
        else if (intvalue < 33)
        {
            target_address = DD;
        }
        else if (intvalue < 41)
        {
            target_address = EE;
        }
        else if (intvalue < 49)
        {
            target_address = FF;
        }
        else
        {
            target_address = GG;
        }

        if(target_address == address)
        {
            return true;
        }

        return false;
    }













}



//Initially, I made the level house thinking I would hand craft each LEVEL

//I think I'm struggling to see how I design all those levels.
//especially since it's not supposed to be a level design assignment




//so, why not procedural?

//options:
//EVERYTHING handmade
//honestly, I'll never do this
//this may be the better feeling game solution, though

//EVERYTHING procedural
//this means less handmade work
//honeycombs may be difficult to generate in an interesting fashion

//Honeycomb solutions are handmade, but procedurally mixed up
//magnifies handmade work
//focuses handmade work
//Honeycombs don't relate to each other at all
//one honeycomb solution may be able to spun into three directions
//there is a scenario where a puzzle is unsolvable, I think
//if completely random, it's where keys locked in honey jars mean you can't solve any, to start the cascade of solvability
//maybe if you ensure that 4 of 7 are free to solve without locks
//but what if two honeycombs unlock each other
//so, what if I ensure a->b->c->d->e->f->g
//a is without locks
//this assumes only one piece would be locked for each
//what if, 6 are free solved

//regardless

//if I build honeycomb solutions
//there could be multiple ways, some more difficult possibly, that I could choose the locked pieces