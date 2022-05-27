using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatMechanics_Title : MonoBehaviour
{
    private Vector3 StartPosition;
    public float slowness = 1.0f;
    public float x_distance = 0.2f;
    public float y_distance = 0.15f;
    public float z_distance = 0.1f;
    public float y_rotation = -0.005f;


    //I should build this out more generally.
    //x, y, z distance
    //x, y, z wav type
    //x, y, z speed
    //start position on wav




    void Start()
    {
        StartPosition = gameObject.transform.position;
    }

    void Update()
    {
        Floating_WorldGrid();
    }

    void Floating_WorldGrid()
    {
        Vector3 CurrentPosition = gameObject.transform.position;

        //position change
        {
            //x change
            float x_change = Mathf.Cos(Time.time) * x_distance * slowness;
            //y change
            float y_change = Mathf.Sin(Time.time * 2.0f) * y_distance * slowness;
            //z change
            float z_change = Mathf.Sin(Time.time) * z_distance * slowness;


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
            float y_change = Mathf.Sin(Time.time) * y_rotation;
            //z change
            float z_change = 0.0f;

            //find PositionChange based off of sin behavior
            Vector3 RotationChange = new Vector3(x_change, y_change, z_change);

            gameObject.transform.Rotate(RotationChange);

        }
    }
}
