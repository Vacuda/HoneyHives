using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static wg_ADDRESS;
using static gs_GAMESTATUS;


public class WorldGrid : MonoBehaviour
{
    public ColorChanger ColorChangerScript;

    //grid positions
    //private Vector3 StartPosition = new Vector3(-12.34f, 0.8f, 26.33f);
    private Vector3 StartPosition = new Vector3(-15.04f, 0.8f, 26.33f);
    private Vector3 TargetPosition;
    //float TimeToTarget = 3.0f;

    float z_set = -.18f;

    float x1_set = 7.53f;
    float x2_set = -3.5f;
    float x3_set = -14f;

    float y1_set = -11.4f;
    float y2_set = -5.29f;
    float y3_set = 1.13f;
    float y4_set = 7.18f;
    float y5_set = 13.4f;

    //public GameObject AdminObject;
    public GameObject HoneyLockObject;
    private HoneyLock honeylock;
    public GameObject BeeBoxPanel;
    public GameLevel GameLevelScript;

    //int Tracker = 0;

    public Dictionary<wg_ADDRESS,GameObject> WGRefDict = new Dictionary<wg_ADDRESS, GameObject>();


    //private Vector3 StartRotation = new Vector3(0.0f, 0.0f, 0.0f);
    private bool ActiveFlotation = true;
    private bool ActiveMovement = false;
    public wg_ADDRESS HoneyComb_Hover = NONE;
    public wg_ADDRESS HoneySlot_Hover = NONE;

    private void Awake()
    {
        //create ref dictionary
        Make_WorldGridRefDict();

        honeylock = HoneyLockObject.GetComponent<HoneyLock>();

    }

    void Start()
    {
        //set a start position to move around
        TargetPosition = StartPosition;

        //GameLevelScript = AdminObject.GetComponent<GameLevel>();
    }


    void Update()
    {
        if (ActiveFlotation)
        {
            //run flotation
            Floating_WorldGrid();
        }

        if (ActiveMovement)
        {
            Move_WorldGridTowardsTargetPosition();
        }

    }

    private void Make_WorldGridRefDict()
    {
    //add HoneyCombs

        //if()

        WGRefDict.Add(AA, this.transform.Find("AA_HoneyComb").gameObject);
        WGRefDict.Add(BB, this.transform.Find("BB_HoneyComb").gameObject);
        WGRefDict.Add(CC, this.transform.Find("CC_HoneyComb").gameObject);
        WGRefDict.Add(DD, this.transform.Find("DD_HoneyComb").gameObject);
        WGRefDict.Add(EE, this.transform.Find("EE_HoneyComb").gameObject);
        WGRefDict.Add(FF, this.transform.Find("FF_HoneyComb").gameObject);
        WGRefDict.Add(GG, this.transform.Find("GG_HoneyComb").gameObject);

    //add HoneySlots
        WGRefDict.Add(AA_AA, WGRefDict[AA].transform.Find("HoneySlot_AA").gameObject);
        WGRefDict.Add(AA_BB, WGRefDict[AA].transform.Find("HoneySlot_BB").gameObject);
        WGRefDict.Add(AA_CC, WGRefDict[AA].transform.Find("HoneySlot_CC").gameObject);
        WGRefDict.Add(AA_DD, WGRefDict[AA].transform.Find("HoneySlot_DD").gameObject);
        WGRefDict.Add(AA_EE, WGRefDict[AA].transform.Find("HoneySlot_EE").gameObject);
        WGRefDict.Add(AA_FF, WGRefDict[AA].transform.Find("HoneySlot_FF").gameObject);
        WGRefDict.Add(AA_GG, WGRefDict[AA].transform.Find("HoneySlot_GG").gameObject);

        WGRefDict.Add(BB_AA, WGRefDict[BB].transform.Find("HoneySlot_AA").gameObject);
        WGRefDict.Add(BB_BB, WGRefDict[BB].transform.Find("HoneySlot_BB").gameObject);
        WGRefDict.Add(BB_CC, WGRefDict[BB].transform.Find("HoneySlot_CC").gameObject);
        WGRefDict.Add(BB_DD, WGRefDict[BB].transform.Find("HoneySlot_DD").gameObject);
        WGRefDict.Add(BB_EE, WGRefDict[BB].transform.Find("HoneySlot_EE").gameObject);
        WGRefDict.Add(BB_FF, WGRefDict[BB].transform.Find("HoneySlot_FF").gameObject);
        WGRefDict.Add(BB_GG, WGRefDict[BB].transform.Find("HoneySlot_GG").gameObject);

        WGRefDict.Add(CC_AA, WGRefDict[CC].transform.Find("HoneySlot_AA").gameObject);
        WGRefDict.Add(CC_BB, WGRefDict[CC].transform.Find("HoneySlot_BB").gameObject);
        WGRefDict.Add(CC_CC, WGRefDict[CC].transform.Find("HoneySlot_CC").gameObject);
        WGRefDict.Add(CC_DD, WGRefDict[CC].transform.Find("HoneySlot_DD").gameObject);
        WGRefDict.Add(CC_EE, WGRefDict[CC].transform.Find("HoneySlot_EE").gameObject);
        WGRefDict.Add(CC_FF, WGRefDict[CC].transform.Find("HoneySlot_FF").gameObject);
        WGRefDict.Add(CC_GG, WGRefDict[CC].transform.Find("HoneySlot_GG").gameObject);

        WGRefDict.Add(DD_AA, WGRefDict[DD].transform.Find("HoneySlot_AA").gameObject);
        WGRefDict.Add(DD_BB, WGRefDict[DD].transform.Find("HoneySlot_BB").gameObject);
        WGRefDict.Add(DD_CC, WGRefDict[DD].transform.Find("HoneySlot_CC").gameObject);
        WGRefDict.Add(DD_DD, WGRefDict[DD].transform.Find("HoneySlot_DD").gameObject);
        WGRefDict.Add(DD_EE, WGRefDict[DD].transform.Find("HoneySlot_EE").gameObject);
        WGRefDict.Add(DD_FF, WGRefDict[DD].transform.Find("HoneySlot_FF").gameObject);
        WGRefDict.Add(DD_GG, WGRefDict[DD].transform.Find("HoneySlot_GG").gameObject);

        WGRefDict.Add(EE_AA, WGRefDict[EE].transform.Find("HoneySlot_AA").gameObject);
        WGRefDict.Add(EE_BB, WGRefDict[EE].transform.Find("HoneySlot_BB").gameObject);
        WGRefDict.Add(EE_CC, WGRefDict[EE].transform.Find("HoneySlot_CC").gameObject);
        WGRefDict.Add(EE_DD, WGRefDict[EE].transform.Find("HoneySlot_DD").gameObject);
        WGRefDict.Add(EE_EE, WGRefDict[EE].transform.Find("HoneySlot_EE").gameObject);
        WGRefDict.Add(EE_FF, WGRefDict[EE].transform.Find("HoneySlot_FF").gameObject);
        WGRefDict.Add(EE_GG, WGRefDict[EE].transform.Find("HoneySlot_GG").gameObject);

        WGRefDict.Add(FF_AA, WGRefDict[FF].transform.Find("HoneySlot_AA").gameObject);
        WGRefDict.Add(FF_BB, WGRefDict[FF].transform.Find("HoneySlot_BB").gameObject);
        WGRefDict.Add(FF_CC, WGRefDict[FF].transform.Find("HoneySlot_CC").gameObject);
        WGRefDict.Add(FF_DD, WGRefDict[FF].transform.Find("HoneySlot_DD").gameObject);
        WGRefDict.Add(FF_EE, WGRefDict[FF].transform.Find("HoneySlot_EE").gameObject);
        WGRefDict.Add(FF_FF, WGRefDict[FF].transform.Find("HoneySlot_FF").gameObject);
        WGRefDict.Add(FF_GG, WGRefDict[FF].transform.Find("HoneySlot_GG").gameObject);

        WGRefDict.Add(GG_AA, WGRefDict[GG].transform.Find("HoneySlot_AA").gameObject);
        WGRefDict.Add(GG_BB, WGRefDict[GG].transform.Find("HoneySlot_BB").gameObject);
        WGRefDict.Add(GG_CC, WGRefDict[GG].transform.Find("HoneySlot_CC").gameObject);
        WGRefDict.Add(GG_DD, WGRefDict[GG].transform.Find("HoneySlot_DD").gameObject);
        WGRefDict.Add(GG_EE, WGRefDict[GG].transform.Find("HoneySlot_EE").gameObject);
        WGRefDict.Add(GG_FF, WGRefDict[GG].transform.Find("HoneySlot_FF").gameObject);
        WGRefDict.Add(GG_GG, WGRefDict[GG].transform.Find("HoneySlot_GG").gameObject);

        //add Areas
        WGRefDict.Add(a_1, BeeBoxPanel.transform.Find("Area_1").gameObject);
        WGRefDict.Add(a_2, BeeBoxPanel.transform.Find("Area_2").gameObject);
        WGRefDict.Add(a_3, BeeBoxPanel.transform.Find("Area_3").gameObject);
        WGRefDict.Add(a_4, BeeBoxPanel.transform.Find("Area_4").gameObject);
        WGRefDict.Add(a_5, BeeBoxPanel.transform.Find("Area_5").gameObject);
        WGRefDict.Add(a_6, BeeBoxPanel.transform.Find("Area_6").gameObject);
        WGRefDict.Add(a_7, BeeBoxPanel.transform.Find("Area_7").gameObject);
        WGRefDict.Add(a_8, BeeBoxPanel.transform.Find("Area_8").gameObject);
        WGRefDict.Add(a_9, BeeBoxPanel.transform.Find("Area_9").gameObject);
        WGRefDict.Add(a_10, BeeBoxPanel.transform.Find("Area_10").gameObject);
        WGRefDict.Add(a_11, BeeBoxPanel.transform.Find("Area_11").gameObject);
        WGRefDict.Add(a_12, BeeBoxPanel.transform.Find("Area_12").gameObject);
        WGRefDict.Add(a_13, BeeBoxPanel.transform.Find("Area_13").gameObject);
        WGRefDict.Add(a_14, BeeBoxPanel.transform.Find("Area_14").gameObject);
        WGRefDict.Add(a_15, BeeBoxPanel.transform.Find("Area_15").gameObject);
        WGRefDict.Add(a_16, BeeBoxPanel.transform.Find("Area_16").gameObject);
        WGRefDict.Add(a_17, BeeBoxPanel.transform.Find("Area_17").gameObject);
        WGRefDict.Add(a_18, BeeBoxPanel.transform.Find("Area_18").gameObject);
        WGRefDict.Add(a_19, BeeBoxPanel.transform.Find("Area_19").gameObject);
        WGRefDict.Add(a_20, BeeBoxPanel.transform.Find("Area_20").gameObject);
        WGRefDict.Add(a_21, BeeBoxPanel.transform.Find("Area_21").gameObject);
        WGRefDict.Add(a_22, BeeBoxPanel.transform.Find("Area_22").gameObject);
        WGRefDict.Add(a_23, BeeBoxPanel.transform.Find("Area_23").gameObject);
        WGRefDict.Add(a_24, BeeBoxPanel.transform.Find("Area_24").gameObject);
        WGRefDict.Add(a_25, BeeBoxPanel.transform.Find("Area_25").gameObject);
        WGRefDict.Add(a_26, BeeBoxPanel.transform.Find("Area_26").gameObject);
        WGRefDict.Add(a_27, BeeBoxPanel.transform.Find("Area_27").gameObject);
        WGRefDict.Add(a_28, BeeBoxPanel.transform.Find("Area_28").gameObject);





    }

    public void Modify_AllHoneyCombColliders(bool direction)
    {
        //loop honeycombs
        foreach(Transform child in gameObject.transform)
        {
            //turn on or off each honeycomb collider
            child.transform.Find("HC_Collider").GetComponent<CircleCollider2D>().enabled = direction;
        }
    }

    public void Modify_ThisHoneyCombs_HoneySlotColliders(wg_ADDRESS honeycomb, bool direction)
    {
        //find HoneySlots array
        wg_ADDRESS[] HoneySlots = WGRefDict[honeycomb].GetComponent<HoneyComb>().HoneySlots;

        //loop HoneySlots
        foreach (wg_ADDRESS addy in HoneySlots)
        {


            //turn on colliders
            WGRefDict[addy].GetComponentInChildren<CircleCollider2D>().enabled = direction;
        }
    }


    public void Trigger_EnteringThisHoneyComb(wg_ADDRESS honeycomb)
    {
        //condense
        gs_GAMESTATUS GameStatus = GameLevelScript.Get_GameStatus();

        //only changes when in correct status
        if(GameStatus == OUTER)
        {
            //set hover address
            HoneyComb_Hover = honeycomb;

            //trigger honeylock up
            honeylock.Trigger_Jar_UP();
        }
    }

    public void Trigger_ExitingAHoneyComb()
    {
        //condense
        gs_GAMESTATUS GameStatus = GameLevelScript.Get_GameStatus();

        //only changes when in correct status
        if (GameStatus == OUTER)
        {
            //set hover address
            HoneyComb_Hover = NONE;

            //trigger honeylock down
            honeylock.Trigger_Jar_DOWN();
        }
    }

    public void Set_HoneySlot_Hover(wg_ADDRESS honeycomb)
    {
        HoneySlot_Hover = honeycomb;
    }



    void Floating_WorldGrid()
    {
        Vector3 CurrentPosition = gameObject.transform.position;

        //gs_GAMESTATUS GameStatus = Admin.GetComponent<GameLevel>().Get_GameStatus();

        //if (GameStatus == 

        //float floatslow = 0.10f;
        float floatslow = 1.0f;


        //position change
        {
            //x change
            float x_change = Mathf.Cos(Time.time) * 0.2f * floatslow;
            //y change
            float y_change = Mathf.Sin(Time.time * 2.0f) * 0.15f * floatslow;
            //z change
            float z_change = Mathf.Sin(Time.time) * 0.1f * floatslow;


            //find PositionChange based off of sin behavior
            Vector3 PositionChange = new Vector3(x_change, y_change, z_change);

            //make position change with StartPosition in mind
            gameObject.transform.position = TargetPosition + PositionChange;
        }

        //rotation change
        {
            //x change
            float x_change = 0.0f;
            //y change
            float y_change = Mathf.Sin(Time.time) * -0.005f;
            //z change
            float z_change = 0.0f;

            //find PositionChange based off of sin behavior
            Vector3 RotationChange = new Vector3(x_change, y_change, z_change);

            gameObject.transform.Rotate(RotationChange);

        }
    }


    public void Move_ToThisPosition(wg_ADDRESS pos)
    {
        ////if moving INNER to OUTER
        //if(pos == NONE)
        //{
        //    //active float again
        //    ActiveFlotation = true;

        //}
        ////if moving IN
        //else
        //{
        //    //deactivate float
        //    //ActiveFlotation = false;

        //    ////reset rotation
        //    //gameObject.transform.rotation = Quaternion.identity;
        //}

        ActiveFlotation = false;

        //turn on movement
        ActiveMovement = true;

        //get and set new position
        TargetPosition = GetNewPosition(pos);



    }

    void Move_WorldGridTowardsTargetPosition()
    {
        //Tracker++;

        Vector3 CurrentPosition = gameObject.transform.position;

        //float test = Vector3.Distance(CurrentPosition, TargetPosition);

        //Debug.Log(test);

        if(Vector3.Distance(CurrentPosition, TargetPosition) > 0.03)
        {
            //keep going
            gameObject.transform.position = Vector3.Lerp(CurrentPosition, TargetPosition, 4.50f * Time.deltaTime);

        }
        else
        {

            gameObject.transform.position = TargetPosition;
            ActiveMovement = false;
            ActiveFlotation = true;
        }

    }

    public void Check_AllHoneycombsFinalized()
    {
        //build order array of honeycombs
        wg_ADDRESS[] order_array= new wg_ADDRESS[7] { AA, BB, CC, DD, EE, FF, GG };

        //loop addresses
        foreach(var address in order_array)
        {
            //if not finalized
            if (!WGRefDict[address].GetComponent<HoneyComb>().IsHoneyComb_Finalized())
            {
                //leave function
                return;
            }
        }

        /* LEVEL COMPLETE*/

        //trigger game end
        GameLevelScript.Trigger_LevelCompletion();
    }

    /* UTILITIES */

    Vector3 GetNewPosition(wg_ADDRESS pos)
    {
        //set return vector
        Vector3 ReturnVector = new Vector3(0.0f, 0.0f, 0.0f);

        switch (pos)
        {
            case AA:
                ReturnVector.Set(x2_set, y1_set, z_set);
                break;
            case BB:
                ReturnVector.Set(x1_set, y2_set, z_set);
                break;
            case CC:
                ReturnVector.Set(x3_set, y2_set, z_set);
                break;
            case DD:
                ReturnVector.Set(x2_set, y3_set, z_set);
                break;
            case EE:
                ReturnVector.Set(x1_set, y4_set, z_set);
                break;
            case FF:
                ReturnVector.Set(x3_set, y4_set, z_set);
                break;
            case GG:
                ReturnVector.Set(x2_set, y5_set, z_set);
                break;
            case NONE:
                ReturnVector.Set(StartPosition.x, StartPosition.y, StartPosition.z);
                break;
        }
        return ReturnVector;
    }
}




