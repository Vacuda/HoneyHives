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

    public void Display(wg_HONEYCOMB Honeycomb)
    {
        switch (Honeycomb)
        {
            case AA: 
                Debug.Log("Mouse over AA");
                break;
            case BB:
                Debug.Log("Mouse over BB");
                break;
            case CC:
                Debug.Log("Mouse over CC");
                break;
            case DD:
                Debug.Log("Mouse over DD");
                break;
            case EE:
                Debug.Log("Mouse over EE");
                break;
            case FF:
                Debug.Log("Mouse over FF");
                break;
            case GG:
                Debug.Log("Mouse over GG");
                break;
        }
    }

    void OnMouseOver()
    {
        //Debug.Log("Mouse over WorldGrid");
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

}




