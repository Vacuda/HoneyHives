using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private bool ActiveCameraMovement = false;
    public bool IsAtMainPosition = true;

    Vector3 TargetPosition;
    Vector3 MainPosition = new Vector3(0.0f, 1.0f, -10.0f);
    Vector3 SidePosition = new Vector3(1.7f, 1.0f, -10.0f);

    float CameraLerpSpeed = 0.02f;
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {
        if (ActiveCameraMovement)
        {
            //get current
            Vector3 CurrentPosition = gameObject.transform.position;

            //get new
            Vector3 NewPosition = Vector3.Lerp(CurrentPosition, TargetPosition, CameraLerpSpeed);

            //set new position
            gameObject.transform.position = NewPosition;
        }
    }

    public void Goto_SidePosition()
    {
        ActiveCameraMovement = true;
        TargetPosition = SidePosition;

        IsAtMainPosition = false;
    }

    public void Goto_MainPosition()
    {
        ActiveCameraMovement = true;
        TargetPosition = MainPosition;

        IsAtMainPosition = true;
    }
}
