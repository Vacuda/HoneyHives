using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ln_LEVELNAME;
using static wg_ADDRESS;
using static fv_FACEVALUE;

public class LevelHouse : MonoBehaviour
{
    public LevelInfo Retrieve_ThisLevel(ln_LEVELNAME name)
    {
        switch (name)
        {
            case LEVEL_001: 
                return Get_Level_001();
            case LEVEL_002: 
                return Get_Level_002();
            case LEVEL_003: 
                return Get_Level_003();
            case LEVEL_004: 
                return Get_Level_004();
            case LEVEL_005: 
                return Get_Level_005();
            default:
                return Get_Level_001();
        }
    }

    LevelInfo Get_Level_001()
    {
        //make package to return
        LevelInfo LevelPackage = new LevelInfo();

        //initialize internal list
        LevelPackage.HoneySlots = new List<HoneySlotInfo>();

        //honeycomb AA
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(AA_AA, true, true, v_2, v_blank, v_1, v_5, v_blank, v_add));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(AA_BB, false, false, v_9, v_2, v_blank, v_7, v_blank, v_blank));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(AA_CC, true, true, v_7, v_7, v_blank, v_1, v_0, v_blank));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(AA_DD, true, true, v_2, v_5, v_blank, v_equals, v_add, v_blank));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(AA_EE, true, false, v_8, v_add, v_2, v_blank, v_4, v_blank));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(AA_FF, true, false, v_7, v_7, v_blank, v_equals, v_equals, v_blank));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(AA_GG, false, true, v_5, v_blank, v_blank, v_blank, v_blank, v_blank));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(AA, true, true, v_1, v_blank, v_blank, v_1, v_blank, v_1));

        //honeycomb BB
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(BB_AA, true, true, v_0, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(BB_BB, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(BB_CC, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(BB_DD, true, true, v_1, v_1, v_1, v_2, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(BB_EE, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(BB_FF, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        //LevelPackage.HoneySlots.Add(new HoneySlotInfo(BB_GG, true, true, true, v_2, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(BB, true, true, v_2, v_blank, v_blank, v_2, v_blank, v_2));

        //honeycomb CC
        //LevelPackage.HoneySlots.Add(new HoneySlotInfo(CC_AA, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(CC_BB, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(CC_CC, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        //LevelPackage.HoneySlots.Add(new HoneySlotInfo(CC_DD, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        //LevelPackage.HoneySlots.Add(new HoneySlotInfo(CC_EE, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(CC_FF, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(CC_GG, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(CC, true, true, v_3, v_blank, v_blank, v_3, v_blank, v_3));

        //honeycomb DD
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(DD_AA, true, false, v_1, v_7, v_1, v_3, v_1, v_5));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(DD_BB, false, true, v_equals, v_3, v_1, v_9, v_sub, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(DD_CC, false, false, v_2, v_1, v_blank, v_8, v_equals, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(DD_DD, true, true, v_9, v_2, v_blank, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(DD_EE, true, false, v_1, v_equals, v_1, v_blank, v_1, v_1));
        //LevelPackage.HoneySlots.Add(new HoneySlotInfo(DD_FF, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(DD_GG, false, true, v_1, v_1, v_add, v_sub, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(DD, true, true, v_4, v_blank, v_blank, v_4, v_blank, v_4));

        //honeycomb EE
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(EE_AA, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(EE_BB, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(EE_CC, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        //LevelPackage.HoneySlots.Add(new HoneySlotInfo(EE_DD, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(EE_EE, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(EE_FF, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(EE_GG, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(EE, true, true, v_5, v_blank, v_blank, v_5, v_blank, v_5));

        //honeycomb FF
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(FF_AA, true, true, v_1, v_1, v_1, v_2, v_1, v_1));
        //LevelPackage.HoneySlots.Add(new HoneySlotInfo(FF_BB, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        //LevelPackage.HoneySlots.Add(new HoneySlotInfo(FF_CC, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(FF_DD, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(FF_EE, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(FF_FF, true, true, v_1, v_1, v_1, v_1, v_equals, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(FF_GG, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(FF, true, true, v_6, v_blank, v_blank, v_6, v_blank, v_6));

        //honeycomb GG
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(GG_AA, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(GG_BB, false, false, v_1, v_1, v_1, v_1, v_1, v_1));
        //LevelPackage.HoneySlots.Add(new HoneySlotInfo(GG_CC, true, false, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(GG_DD, false, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(GG_EE, true, true, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(GG_FF, false, false, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(GG_GG, false, false, v_1, v_1, v_1, v_1, v_1, v_1));
        LevelPackage.HoneySlots.Add(new HoneySlotInfo(GG, true, true, v_7, v_blank, v_blank, v_7, v_blank, v_7));

        return LevelPackage;
    }

    LevelInfo Get_Level_002()
    {
        LevelInfo Package = new LevelInfo();

        return Package;
    }

    LevelInfo Get_Level_003()
    {
        LevelInfo Package = new LevelInfo();

        return Package;
    }

    LevelInfo Get_Level_004()
    {
        LevelInfo Package = new LevelInfo();

        return Package;
    }

    LevelInfo Get_Level_005()
    {
        LevelInfo Package = new LevelInfo();

        return Package;
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