using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static wg_ADDRESS;


public class WorldGrid : MonoBehaviour
{

    //grid positions
    private Vector3 StartPosition;
    private Vector3 TargetPosition;
    //float TimeToTarget = 3.0f;

    float z_set = -.18f;

    float x1_set = 8.41f;
    float x2_set = -2.85f;
    float x3_set = -14f;

    float y1_set = -11.4f;
    float y2_set = -5.29f;
    float y3_set = 1.13f;
    float y4_set = 7.08f;
    float y5_set = 13.4f;

    

    int Tracker = 0;

    //public GameObject Admin;

    public Dictionary<wg_ADDRESS,GameObject> WGRefDict = new Dictionary<wg_ADDRESS, GameObject>();


    //private Vector3 StartRotation = new Vector3(0.0f, 0.0f, 0.0f);
    private bool ActiveFlotation = true;
    private bool ActiveMovement = false;
    public wg_ADDRESS HoveredOver_HoneyComb = NONE;



    void Start()
    {
        //set a start position to move around
        StartPosition = transform.position;
        TargetPosition = StartPosition;

        //create ref dictionary
        Make_WorldGridRefDict();
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
        //add Honeycombs
        WGRefDict.Add(AA, this.transform.Find("AA_HoneyComb").gameObject);
        WGRefDict.Add(AA_AA, WGRefDict[AA].transform.Find("AA_AA").gameObject);
        WGRefDict.Add(AA_BB, WGRefDict[AA].transform.Find("AA_BB").gameObject);
        WGRefDict.Add(AA_CC, WGRefDict[AA].transform.Find("AA_CC").gameObject);
        WGRefDict.Add(AA_DD, WGRefDict[AA].transform.Find("AA_DD").gameObject);
        WGRefDict.Add(AA_EE, WGRefDict[AA].transform.Find("AA_EE").gameObject);
        WGRefDict.Add(AA_FF, WGRefDict[AA].transform.Find("AA_FF").gameObject);
        WGRefDict.Add(AA_GG, WGRefDict[AA].transform.Find("AA_GG").gameObject);

        WGRefDict.Add(BB, this.transform.Find("BB_HoneyComb").gameObject);
        WGRefDict.Add(BB_AA, WGRefDict[BB].transform.Find("BB_AA").gameObject);
        WGRefDict.Add(BB_BB, WGRefDict[BB].transform.Find("BB_BB").gameObject);
        WGRefDict.Add(BB_CC, WGRefDict[BB].transform.Find("BB_CC").gameObject);
        WGRefDict.Add(BB_DD, WGRefDict[BB].transform.Find("BB_DD").gameObject);
        WGRefDict.Add(BB_EE, WGRefDict[BB].transform.Find("BB_EE").gameObject);
        WGRefDict.Add(BB_FF, WGRefDict[BB].transform.Find("BB_FF").gameObject);
        WGRefDict.Add(BB_GG, WGRefDict[BB].transform.Find("BB_GG").gameObject);

        WGRefDict.Add(CC, this.transform.Find("CC_HoneyComb").gameObject);
        WGRefDict.Add(CC_AA, WGRefDict[CC].transform.Find("CC_AA").gameObject);
        WGRefDict.Add(CC_BB, WGRefDict[CC].transform.Find("CC_BB").gameObject);
        WGRefDict.Add(CC_CC, WGRefDict[CC].transform.Find("CC_CC").gameObject);
        WGRefDict.Add(CC_DD, WGRefDict[CC].transform.Find("CC_DD").gameObject);
        WGRefDict.Add(CC_EE, WGRefDict[CC].transform.Find("CC_EE").gameObject);
        WGRefDict.Add(CC_FF, WGRefDict[CC].transform.Find("CC_FF").gameObject);
        WGRefDict.Add(CC_GG, WGRefDict[CC].transform.Find("CC_GG").gameObject);

        WGRefDict.Add(DD, this.transform.Find("DD_HoneyComb").gameObject);
        WGRefDict.Add(DD_AA, WGRefDict[DD].transform.Find("DD_AA").gameObject);
        WGRefDict.Add(DD_BB, WGRefDict[DD].transform.Find("DD_BB").gameObject);
        WGRefDict.Add(DD_CC, WGRefDict[DD].transform.Find("DD_CC").gameObject);
        WGRefDict.Add(DD_DD, WGRefDict[DD].transform.Find("DD_DD").gameObject);
        WGRefDict.Add(DD_EE, WGRefDict[DD].transform.Find("DD_EE").gameObject);
        WGRefDict.Add(DD_FF, WGRefDict[DD].transform.Find("DD_FF").gameObject);
        WGRefDict.Add(DD_GG, WGRefDict[DD].transform.Find("DD_GG").gameObject);

        WGRefDict.Add(EE, this.transform.Find("EE_HoneyComb").gameObject);
        WGRefDict.Add(EE_AA, WGRefDict[EE].transform.Find("EE_AA").gameObject);
        WGRefDict.Add(EE_BB, WGRefDict[EE].transform.Find("EE_BB").gameObject);
        WGRefDict.Add(EE_CC, WGRefDict[EE].transform.Find("EE_CC").gameObject);
        WGRefDict.Add(EE_DD, WGRefDict[EE].transform.Find("EE_DD").gameObject);
        WGRefDict.Add(EE_EE, WGRefDict[EE].transform.Find("EE_EE").gameObject);
        WGRefDict.Add(EE_FF, WGRefDict[EE].transform.Find("EE_FF").gameObject);
        WGRefDict.Add(EE_GG, WGRefDict[EE].transform.Find("EE_GG").gameObject);

        WGRefDict.Add(FF, this.transform.Find("FF_HoneyComb").gameObject);
        WGRefDict.Add(FF_AA, WGRefDict[FF].transform.Find("FF_AA").gameObject);
        WGRefDict.Add(FF_BB, WGRefDict[FF].transform.Find("FF_BB").gameObject);
        WGRefDict.Add(FF_CC, WGRefDict[FF].transform.Find("FF_CC").gameObject);
        WGRefDict.Add(FF_DD, WGRefDict[FF].transform.Find("FF_DD").gameObject);
        WGRefDict.Add(FF_EE, WGRefDict[FF].transform.Find("FF_EE").gameObject);
        WGRefDict.Add(FF_FF, WGRefDict[FF].transform.Find("FF_FF").gameObject);
        WGRefDict.Add(FF_GG, WGRefDict[FF].transform.Find("FF_GG").gameObject);

        WGRefDict.Add(GG, this.transform.Find("GG_HoneyComb").gameObject);
        WGRefDict.Add(GG_AA, WGRefDict[GG].transform.Find("GG_AA").gameObject);
        WGRefDict.Add(GG_BB, WGRefDict[GG].transform.Find("GG_BB").gameObject);
        WGRefDict.Add(GG_CC, WGRefDict[GG].transform.Find("GG_CC").gameObject);
        WGRefDict.Add(GG_DD, WGRefDict[GG].transform.Find("GG_DD").gameObject);
        WGRefDict.Add(GG_EE, WGRefDict[GG].transform.Find("GG_EE").gameObject);
        WGRefDict.Add(GG_FF, WGRefDict[GG].transform.Find("GG_FF").gameObject);
        WGRefDict.Add(GG_GG, WGRefDict[GG].transform.Find("GG_GG").gameObject);

    }

    public void Modify_ThisHoneyCombs_HoneySlotColliders(wg_ADDRESS honeycomb, bool direction)
    {
        //find HoneySlots array
        wg_ADDRESS[] HoneySlots = WGRefDict[honeycomb].GetComponent<HoneyComb>().HoneySlots;

        //loop HoneySlots
        foreach (wg_ADDRESS addy in HoneySlots)
        {
            //turn on colliders
            WGRefDict[addy].GetComponent<CircleCollider2D>().enabled = direction;
        }
    }


    public void Set_HoveredOver_HoneyComb(wg_ADDRESS honeycomb)
    {
        HoveredOver_HoneyComb = honeycomb;
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
        Tracker++;

        Vector3 CurrentPosition = gameObject.transform.position;

        float test = Vector3.Distance(CurrentPosition, TargetPosition);

        //Debug.Log(test);

        if(Vector3.Distance(CurrentPosition, TargetPosition) > 0.03)
        {
            //keep going
            gameObject.transform.position = Vector3.Lerp(CurrentPosition, TargetPosition, 4.50f * Time.deltaTime);

        }
        else
        {
            //Debug.Log(Tracker);
            gameObject.transform.position = TargetPosition;
            ActiveMovement = false;
            ActiveFlotation = true;
        }

    }

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




