using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    public bool IsBackButton_HoveredOver = false;
    private Vector3 TargetPosition;
    private Vector3 OutPosition = new Vector3(-1.2f, -0.20f, -8.6f);
    private Vector3 InPosition = new Vector3(-1.2f, 0.15f, -8.6f);
    private bool ActiveMovement = false;


    private void Start()
    {
        TargetPosition = OutPosition;
        gameObject.transform.position = OutPosition;
    }

    private void Update()
    {
        if (ActiveMovement)
        {
            Vector3 CurrentPosition = gameObject.transform.position;

            Vector3 NewPosition = Vector3.Lerp(CurrentPosition, TargetPosition, 0.07f);

            gameObject.transform.position = NewPosition;


            if(Vector3.Distance(CurrentPosition, TargetPosition) < 0.03)
            {
                gameObject.transform.position = TargetPosition;
                ActiveMovement = false;
            }

        }
    }

    public void Move_IntoFrame()
    {

        TargetPosition = InPosition;

        ActiveMovement = true;
    }
    public void Move_OutOfFrame()
    {
        TargetPosition = OutPosition;

        ActiveMovement = true;
    }

}
