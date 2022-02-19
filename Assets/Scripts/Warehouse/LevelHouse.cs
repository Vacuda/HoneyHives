using System.Collections;
using System.Collections.Generic;
//using UnityEngine;
using static ln_LEVELNAME;
using static wg_ADDRESS;
using static fv_FACEVALUE;

static public class LevelHouse
{
    //static public List<List<HoneySlotInfo>> Get_SevenHoneyCombs()
    //{
    //    List<List<HoneySlotInfo>> list = new List<List<HoneySlotInfo>>();

    //    //get random number


    //    list.Add(Retrieve_HoneyComb(1));
    //    list.Add(Retrieve_HoneyComb(2));
    //    list.Add(Retrieve_HoneyComb(3));
    //    list.Add(Retrieve_HoneyComb(4));
    //    list.Add(Retrieve_HoneyComb(5));
    //    list.Add(Retrieve_HoneyComb(6));
    //    list.Add(Retrieve_HoneyComb(7));



    //    return list;
    //}

    static public void Get_SevenHoneyCombs(ref List<List<HoneySlotInfo>> hc_list)
    {

        //get 7 random numbers

        //loop through numbers to add honeycomb to list
        Add_ThisHoneyComb(1, ref hc_list);
        Add_ThisHoneyComb(2, ref hc_list);
        Add_ThisHoneyComb(3, ref hc_list);
        Add_ThisHoneyComb(4, ref hc_list);
        Add_ThisHoneyComb(5, ref hc_list);
        Add_ThisHoneyComb(6, ref hc_list);
        Add_ThisHoneyComb(7, ref hc_list);

        //hc_list.Add(Retrieve_HoneyComb(1));
        //hc_list.Add(Retrieve_HoneyComb(2));
        //hc_list.Add(Retrieve_HoneyComb(3));
        //hc_list.Add(Retrieve_HoneyComb(4));
        //hc_list.Add(Retrieve_HoneyComb(5));
        //hc_list.Add(Retrieve_HoneyComb(6));
        //hc_list.Add(Retrieve_HoneyComb(7));




    }


    static public void Add_ThisHoneyComb(int rand, ref List<List<HoneySlotInfo>> hc_list)
    {
        List<HoneySlotInfo> slotlist = new List<HoneySlotInfo>();


        switch (rand)
        {
            case 1:
                slotlist.Add(new HoneySlotInfo(AA, true, true, v_2, v_blank, v_1, v_5, v_blank, v_add));
                slotlist.Add(new HoneySlotInfo(BB, false, false, v_9, v_2, v_blank, v_7, v_blank, v_blank));
                slotlist.Add(new HoneySlotInfo(CC, true, true, v_7, v_7, v_blank, v_1, v_0, v_blank));
                slotlist.Add(new HoneySlotInfo(DD, true, true, v_2, v_5, v_blank, v_equals, v_add, v_blank));
                slotlist.Add(new HoneySlotInfo(EE, true, false, v_8, v_add, v_2, v_blank, v_4, v_blank));
                slotlist.Add(new HoneySlotInfo(FF, true, false, v_7, v_7, v_blank, v_equals, v_equals, v_blank));
                slotlist.Add(new HoneySlotInfo(GG, false, true, v_5, v_blank, v_blank, v_blank, v_blank, v_blank));
                break;
            case 2:
                slotlist.Add(new HoneySlotInfo(AA, true, true, v_2, v_blank, v_1, v_5, v_blank, v_add));
                slotlist.Add(new HoneySlotInfo(BB, false, false, v_9, v_2, v_blank, v_7, v_blank, v_blank));
                slotlist.Add(new HoneySlotInfo(CC, true, true, v_7, v_7, v_blank, v_1, v_0, v_blank));
                slotlist.Add(new HoneySlotInfo(DD, true, true, v_2, v_5, v_blank, v_equals, v_add, v_blank));
                slotlist.Add(new HoneySlotInfo(EE, true, false, v_8, v_add, v_2, v_blank, v_4, v_blank));
                slotlist.Add(new HoneySlotInfo(FF, true, false, v_7, v_7, v_blank, v_equals, v_equals, v_blank));
                slotlist.Add(new HoneySlotInfo(GG, false, true, v_5, v_blank, v_blank, v_blank, v_blank, v_blank));
                break;
            case 3:
                slotlist.Add(new HoneySlotInfo(AA, true, true, v_2, v_blank, v_1, v_5, v_blank, v_add));
                slotlist.Add(new HoneySlotInfo(BB, false, false, v_9, v_2, v_blank, v_7, v_blank, v_blank));
                slotlist.Add(new HoneySlotInfo(CC, true, true, v_7, v_7, v_blank, v_1, v_0, v_blank));
                slotlist.Add(new HoneySlotInfo(DD, true, true, v_2, v_5, v_blank, v_equals, v_add, v_blank));
                slotlist.Add(new HoneySlotInfo(EE, true, false, v_8, v_add, v_2, v_blank, v_4, v_blank));
                slotlist.Add(new HoneySlotInfo(FF, true, false, v_7, v_7, v_blank, v_equals, v_equals, v_blank));
                slotlist.Add(new HoneySlotInfo(GG, false, true, v_5, v_blank, v_blank, v_blank, v_blank, v_blank));
                break;
            case 4:
                slotlist.Add(new HoneySlotInfo(AA, true, true, v_2, v_blank, v_1, v_5, v_blank, v_add));
                slotlist.Add(new HoneySlotInfo(BB, false, false, v_9, v_2, v_blank, v_7, v_blank, v_blank));
                slotlist.Add(new HoneySlotInfo(CC, true, true, v_7, v_7, v_blank, v_1, v_0, v_blank));
                slotlist.Add(new HoneySlotInfo(DD, true, true, v_2, v_5, v_blank, v_equals, v_add, v_blank));
                slotlist.Add(new HoneySlotInfo(EE, true, false, v_8, v_add, v_2, v_blank, v_4, v_blank));
                slotlist.Add(new HoneySlotInfo(FF, true, false, v_7, v_7, v_blank, v_equals, v_equals, v_blank));
                slotlist.Add(new HoneySlotInfo(GG, false, true, v_5, v_blank, v_blank, v_blank, v_blank, v_blank));
                break;
            case 5:
                slotlist.Add(new HoneySlotInfo(AA, true, true, v_2, v_blank, v_1, v_5, v_blank, v_add));
                slotlist.Add(new HoneySlotInfo(BB, false, false, v_9, v_2, v_blank, v_7, v_blank, v_blank));
                slotlist.Add(new HoneySlotInfo(CC, true, true, v_7, v_7, v_blank, v_1, v_0, v_blank));
                slotlist.Add(new HoneySlotInfo(DD, true, true, v_2, v_5, v_blank, v_equals, v_add, v_blank));
                slotlist.Add(new HoneySlotInfo(EE, true, false, v_8, v_add, v_2, v_blank, v_4, v_blank));
                slotlist.Add(new HoneySlotInfo(FF, true, false, v_7, v_7, v_blank, v_equals, v_equals, v_blank));
                slotlist.Add(new HoneySlotInfo(GG, false, true, v_5, v_blank, v_blank, v_blank, v_blank, v_blank));
                break;
            case 6:
                slotlist.Add(new HoneySlotInfo(AA, true, true, v_2, v_blank, v_1, v_5, v_blank, v_add));
                slotlist.Add(new HoneySlotInfo(BB, false, false, v_9, v_2, v_blank, v_7, v_blank, v_blank));
                slotlist.Add(new HoneySlotInfo(CC, true, true, v_7, v_7, v_blank, v_1, v_0, v_blank));
                slotlist.Add(new HoneySlotInfo(DD, true, true, v_2, v_5, v_blank, v_equals, v_add, v_blank));
                slotlist.Add(new HoneySlotInfo(EE, true, false, v_8, v_add, v_2, v_blank, v_4, v_blank));
                slotlist.Add(new HoneySlotInfo(FF, true, false, v_7, v_7, v_blank, v_equals, v_equals, v_blank));
                slotlist.Add(new HoneySlotInfo(GG, false, true, v_5, v_blank, v_blank, v_blank, v_blank, v_blank));
                break;
            case 7:
                slotlist.Add(new HoneySlotInfo(AA, true, true, v_2, v_blank, v_1, v_5, v_blank, v_add));
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

        //add to list
        hc_list.Add(slotlist);
    }









    //static public List<HoneySlotInfo> Retrieve_HoneyComb(int rand)
    //{
    //    List<HoneySlotInfo> info = new List<HoneySlotInfo>();


    //    switch (rand)
    //    {
    //        case 1:
    //            info.Add(new HoneySlotInfo(AA, true, true, v_2, v_blank, v_1, v_5, v_blank, v_add));
    //            info.Add(new HoneySlotInfo(BB, false, false, v_9, v_2, v_blank, v_7, v_blank, v_blank));
    //            info.Add(new HoneySlotInfo(CC, true, true, v_7, v_7, v_blank, v_1, v_0, v_blank));
    //            info.Add(new HoneySlotInfo(DD, true, true, v_2, v_5, v_blank, v_equals, v_add, v_blank));
    //            info.Add(new HoneySlotInfo(EE, true, false, v_8, v_add, v_2, v_blank, v_4, v_blank));
    //            info.Add(new HoneySlotInfo(FF, true, false, v_7, v_7, v_blank, v_equals, v_equals, v_blank));
    //            info.Add(new HoneySlotInfo(GG, false, true, v_5, v_blank, v_blank, v_blank, v_blank, v_blank));
    //            break;
    //        case 2:
    //            info.Add(new HoneySlotInfo(AA, true, true, v_2, v_blank, v_1, v_5, v_blank, v_add));
    //            info.Add(new HoneySlotInfo(BB, false, false, v_9, v_2, v_blank, v_7, v_blank, v_blank));
    //            info.Add(new HoneySlotInfo(CC, true, true, v_7, v_7, v_blank, v_1, v_0, v_blank));
    //            info.Add(new HoneySlotInfo(DD, true, true, v_2, v_5, v_blank, v_equals, v_add, v_blank));
    //            info.Add(new HoneySlotInfo(EE, true, false, v_8, v_add, v_2, v_blank, v_4, v_blank));
    //            info.Add(new HoneySlotInfo(FF, true, false, v_7, v_7, v_blank, v_equals, v_equals, v_blank));
    //            info.Add(new HoneySlotInfo(GG, false, true, v_5, v_blank, v_blank, v_blank, v_blank, v_blank));
    //            break;
    //        case 3:
    //            info.Add(new HoneySlotInfo(AA, true, true, v_2, v_blank, v_1, v_5, v_blank, v_add));
    //            info.Add(new HoneySlotInfo(BB, false, false, v_9, v_2, v_blank, v_7, v_blank, v_blank));
    //            info.Add(new HoneySlotInfo(CC, true, true, v_7, v_7, v_blank, v_1, v_0, v_blank));
    //            info.Add(new HoneySlotInfo(DD, true, true, v_2, v_5, v_blank, v_equals, v_add, v_blank));
    //            info.Add(new HoneySlotInfo(EE, true, false, v_8, v_add, v_2, v_blank, v_4, v_blank));
    //            info.Add(new HoneySlotInfo(FF, true, false, v_7, v_7, v_blank, v_equals, v_equals, v_blank));
    //            info.Add(new HoneySlotInfo(GG, false, true, v_5, v_blank, v_blank, v_blank, v_blank, v_blank));
    //            break;
    //        case 4:
    //            info.Add(new HoneySlotInfo(AA, true, true, v_2, v_blank, v_1, v_5, v_blank, v_add));
    //            info.Add(new HoneySlotInfo(BB, false, false, v_9, v_2, v_blank, v_7, v_blank, v_blank));
    //            info.Add(new HoneySlotInfo(CC, true, true, v_7, v_7, v_blank, v_1, v_0, v_blank));
    //            info.Add(new HoneySlotInfo(DD, true, true, v_2, v_5, v_blank, v_equals, v_add, v_blank));
    //            info.Add(new HoneySlotInfo(EE, true, false, v_8, v_add, v_2, v_blank, v_4, v_blank));
    //            info.Add(new HoneySlotInfo(FF, true, false, v_7, v_7, v_blank, v_equals, v_equals, v_blank));
    //            info.Add(new HoneySlotInfo(GG, false, true, v_5, v_blank, v_blank, v_blank, v_blank, v_blank));
    //            break;
    //        case 5:
    //            info.Add(new HoneySlotInfo(AA, true, true, v_2, v_blank, v_1, v_5, v_blank, v_add));
    //            info.Add(new HoneySlotInfo(BB, false, false, v_9, v_2, v_blank, v_7, v_blank, v_blank));
    //            info.Add(new HoneySlotInfo(CC, true, true, v_7, v_7, v_blank, v_1, v_0, v_blank));
    //            info.Add(new HoneySlotInfo(DD, true, true, v_2, v_5, v_blank, v_equals, v_add, v_blank));
    //            info.Add(new HoneySlotInfo(EE, true, false, v_8, v_add, v_2, v_blank, v_4, v_blank));
    //            info.Add(new HoneySlotInfo(FF, true, false, v_7, v_7, v_blank, v_equals, v_equals, v_blank));
    //            info.Add(new HoneySlotInfo(GG, false, true, v_5, v_blank, v_blank, v_blank, v_blank, v_blank));
    //            break;
    //        case 6:
    //            info.Add(new HoneySlotInfo(AA, true, true, v_2, v_blank, v_1, v_5, v_blank, v_add));
    //            info.Add(new HoneySlotInfo(BB, false, false, v_9, v_2, v_blank, v_7, v_blank, v_blank));
    //            info.Add(new HoneySlotInfo(CC, true, true, v_7, v_7, v_blank, v_1, v_0, v_blank));
    //            info.Add(new HoneySlotInfo(DD, true, true, v_2, v_5, v_blank, v_equals, v_add, v_blank));
    //            info.Add(new HoneySlotInfo(EE, true, false, v_8, v_add, v_2, v_blank, v_4, v_blank));
    //            info.Add(new HoneySlotInfo(FF, true, false, v_7, v_7, v_blank, v_equals, v_equals, v_blank));
    //            info.Add(new HoneySlotInfo(GG, false, true, v_5, v_blank, v_blank, v_blank, v_blank, v_blank));
    //            break;
    //        case 7:
    //            info.Add(new HoneySlotInfo(AA, true, true, v_2, v_blank, v_1, v_5, v_blank, v_add));
    //            info.Add(new HoneySlotInfo(BB, false, false, v_9, v_2, v_blank, v_7, v_blank, v_blank));
    //            info.Add(new HoneySlotInfo(CC, true, true, v_7, v_7, v_blank, v_1, v_0, v_blank));
    //            info.Add(new HoneySlotInfo(DD, true, true, v_2, v_5, v_blank, v_equals, v_add, v_blank));
    //            info.Add(new HoneySlotInfo(EE, true, false, v_8, v_add, v_2, v_blank, v_4, v_blank));
    //            info.Add(new HoneySlotInfo(FF, true, false, v_7, v_7, v_blank, v_equals, v_equals, v_blank));
    //            info.Add(new HoneySlotInfo(GG, false, true, v_5, v_blank, v_blank, v_blank, v_blank, v_blank));
    //            break;
    //        default:
    //            info.Add(new HoneySlotInfo(AA, true, true, v_2, v_blank, v_1, v_5, v_blank, v_add));
    //            info.Add(new HoneySlotInfo(BB, false, false, v_9, v_2, v_blank, v_7, v_blank, v_blank));
    //            info.Add(new HoneySlotInfo(CC, true, true, v_7, v_7, v_blank, v_1, v_0, v_blank));
    //            info.Add(new HoneySlotInfo(DD, true, true, v_2, v_5, v_blank, v_equals, v_add, v_blank));
    //            info.Add(new HoneySlotInfo(EE, true, false, v_8, v_add, v_2, v_blank, v_4, v_blank));
    //            info.Add(new HoneySlotInfo(FF, true, false, v_7, v_7, v_blank, v_equals, v_equals, v_blank));
    //            info.Add(new HoneySlotInfo(GG, false, true, v_5, v_blank, v_blank, v_blank, v_blank, v_blank));
    //            break;      
    //    }

    //    return info;
    //}

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


    //    //honeycomb AA
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(AA_AA, true, true, v_2, v_blank, v_1, v_5, v_blank, v_add));
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(AA_BB, false, false, v_9, v_2, v_blank, v_7, v_blank, v_blank));
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(AA_CC, true, true, v_7, v_7, v_blank, v_1, v_0, v_blank));
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(AA_DD, true, true, v_2, v_5, v_blank, v_equals, v_add, v_blank));
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(AA_EE, true, false, v_8, v_add, v_2, v_blank, v_4, v_blank));
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(AA_FF, true, false, v_7, v_7, v_blank, v_equals, v_equals, v_blank));
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(AA_GG, false, true, v_5, v_blank, v_blank, v_blank, v_blank, v_blank));
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(AA, true, true, v_1, v_blank, v_blank, v_1, v_blank, v_1));

    //    //honeycomb BB
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(BB_AA, true, true, v_0, v_1, v_1, v_1, v_1, v_1));
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(BB_BB, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(BB_CC, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(BB_DD, true, true, v_1, v_1, v_1, v_2, v_1, v_1));
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(BB_EE, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(BB_FF, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
    //    //LevelPackage.HoneySlots.Add(new HoneySlotInfo(BB_GG, true, true, true, v_2, v_1, v_1, v_1, v_1, v_1));
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(BB, true, true, v_2, v_blank, v_blank, v_2, v_blank, v_2));

    //    //honeycomb CC
    //    //LevelPackage.HoneySlots.Add(new HoneySlotInfo(CC_AA, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(CC_BB, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(CC_CC, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
    //    //LevelPackage.HoneySlots.Add(new HoneySlotInfo(CC_DD, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
    //    //LevelPackage.HoneySlots.Add(new HoneySlotInfo(CC_EE, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(CC_FF, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(CC_GG, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(CC, true, true, v_3, v_blank, v_blank, v_3, v_blank, v_3));

    //    //honeycomb DD
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(DD_AA, true, false, v_1, v_7, v_1, v_3, v_1, v_5));
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(DD_BB, false, true, v_equals, v_3, v_1, v_9, v_sub, v_1));
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(DD_CC, false, false, v_2, v_1, v_blank, v_8, v_equals, v_1));
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(DD_DD, true, true, v_9, v_2, v_blank, v_1, v_1, v_1));
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(DD_EE, true, false, v_1, v_equals, v_1, v_blank, v_1, v_1));
    //    //LevelPackage.HoneySlots.Add(new HoneySlotInfo(DD_FF, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(DD_GG, false, true, v_1, v_1, v_add, v_sub, v_1, v_1));
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(DD, true, true, v_4, v_blank, v_blank, v_4, v_blank, v_4));

    //    //honeycomb EE
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(EE_AA, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(EE_BB, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(EE_CC, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
    //    //LevelPackage.HoneySlots.Add(new HoneySlotInfo(EE_DD, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(EE_EE, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(EE_FF, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(EE_GG, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(EE, true, true, v_5, v_blank, v_blank, v_5, v_blank, v_5));

    //    //honeycomb FF
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(FF_AA, true, true, v_1, v_1, v_1, v_2, v_1, v_1));
    //    //LevelPackage.HoneySlots.Add(new HoneySlotInfo(FF_BB, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
    //    //LevelPackage.HoneySlots.Add(new HoneySlotInfo(FF_CC, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(FF_DD, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(FF_EE, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(FF_FF, true, true, v_1, v_1, v_1, v_1, v_equals, v_1));
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(FF_GG, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(FF, true, true, v_6, v_blank, v_blank, v_6, v_blank, v_6));

    //    //honeycomb GG
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(GG_AA, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(GG_BB, false, false, v_1, v_1, v_1, v_1, v_1, v_1));
    //    //LevelPackage.HoneySlots.Add(new HoneySlotInfo(GG_CC, true, false, v_1, v_1, v_1, v_1, v_1, v_1));
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(GG_DD, false, true, v_1, v_1, v_1, v_1, v_1, v_1));
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(GG_EE, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(GG_FF, false, false, v_1, v_1, v_1, v_1, v_1, v_1));
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(GG_GG, false, false, v_1, v_1, v_1, v_1, v_1, v_1));
    //    LevelPackage.HoneySlots.Add(new HoneySlotInfo(GG, true, true, v_7, v_blank, v_blank, v_7, v_blank, v_7));

    //    return LevelPackage;
    //}

    //LevelInfo Get_Level_002()
    //{
    //    LevelInfo Package = new LevelInfo();

    //    return Package;
    //}

    //LevelInfo Get_Level_003()
    //{
    //    LevelInfo Package = new LevelInfo();

    //    return Package;
    //}

    //LevelInfo Get_Level_004()
    //{
    //    LevelInfo Package = new LevelInfo();

    //    return Package;
    //}

    //LevelInfo Get_Level_005()
    //{
    //    LevelInfo Package = new LevelInfo();

    //    return Package;
    //}






















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