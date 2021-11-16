using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static wg_HONEYCOMB;

public enum wg_HONEYCOMB
{
    NONE, AA, BB, CC, DD, EE, FF, GG
};


public class WorldGrid : MonoBehaviour
{


    private Vector3 StartPosition;
    //private Vector3 StartRotation = new Vector3(0.0f, 0.0f, 0.0f);
    private bool ActiveFlotation = true;
    public wg_HONEYCOMB ActiveHoneyComb = NONE;



    void Start()
    {
        //set a start position to move around
        StartPosition = transform.position;
    }


    void Update()
    {
        if (ActiveFlotation)
        {
            //run flotation
            Floating_WorldGrid();
        }

        

    }


    public void Activate_ThisHoneycomb(wg_HONEYCOMB Honeycomb)
    {
        switch (Honeycomb)
        {
            case AA: 
                //Debug.Log("Active Honeycomb: AA");
                ActiveHoneyComb = AA;
                break;
            case BB:
                //Debug.Log("Active Honeycomb: BB");
                ActiveHoneyComb = BB;
                break;
            case CC:
                //Debug.Log("Active Honeycomb: CC");
                ActiveHoneyComb = CC;
                break;
            case DD:
                //Debug.Log("Active Honeycomb: DD");
                ActiveHoneyComb = DD;
                break;
            case EE:
                //Debug.Log("Active Honeycomb: EE");
                ActiveHoneyComb = EE;
                break;
            case FF:
                //Debug.Log("Active Honeycomb: FF");
                ActiveHoneyComb = FF;
                break;
            case GG:
                //Debug.Log("Active Honeycomb: GG");
                ActiveHoneyComb = GG;
                break;
            default:
                ActiveHoneyComb = NONE;
                break;
        }
    }

    public void Deactivate_Honeycomb()
    {
        //Debug.Log("Active Honeycomb: NONE");
        ActiveHoneyComb = NONE;
    }



    void Floating_WorldGrid()
    {
        //position change
        {
            //x change
            float x_change = Mathf.Cos(Time.time) * 0.2f;
            //y change
            float y_change = Mathf.Sin(Time.time * 2.0f) * 0.15f;
            //z change
            float z_change = Mathf.Sin(Time.time) * 0.1f;


            //find PositionChange based off of sin behavior
            Vector3 PositionChange = new Vector3(x_change, y_change, z_change);

            //make position change with StartPosition in mind
            gameObject.transform.position = StartPosition + PositionChange;
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

    void TurnOff_ActiveFlotation()
    {
        ActiveFlotation = false;
    }

    void TurnOn_ActiveFlotation()
    {
        ActiveFlotation = true;
    }

    public void Move_ToThisPosition(wg_HONEYCOMB pos)
    {
        //deactivate float
        TurnOff_ActiveFlotation();

        ////reset rotation
        //gameObject.transform.rotation = Quaternion.identity;

        //get and set new position
        gameObject.transform.position = GetNewPosition(pos);

    }

    Vector3 GetNewPosition(wg_HONEYCOMB pos)
    {
        //slow way.  fix after tuning
        Vector3 ReturnVector = new Vector3(0.0f, 0.0f, 0.0f);
        float z_set = -8.09f;

        float x1_set = 1.65f;
        float x2_set = -0.56f;
        float x3_set = -2.69f;

        float y1_set = -1.47f;
        float y2_set = -0.23f;
        float y3_set = 1.01f;
        float y4_set = 2.23f;
        float y5_set = 3.49f;


        switch (pos)
        {
            case AA:
                Debug.Log("AT AA");
                ReturnVector.Set(x2_set, y1_set, z_set);
                break;
            case BB:
                Debug.Log("AT BB");
                ReturnVector.Set(x1_set, y2_set, z_set);
                break;
            case CC:
                Debug.Log("AT CC");
                ReturnVector.Set(x3_set, y2_set, z_set);
                break;
            case DD:
                Debug.Log("AT DD");
                ReturnVector.Set(x2_set, y3_set, z_set);
                break;
            case EE:
                Debug.Log("AT EE");
                ReturnVector.Set(x1_set, y4_set, z_set);
                break;
            case FF:
                Debug.Log("AT FF");
                ReturnVector.Set(x3_set, y4_set, z_set);
                break;
            case GG:
                Debug.Log("AT GG");
                ReturnVector.Set(x2_set, y5_set, z_set);
                break;
        }
        return ReturnVector;
    }
}




