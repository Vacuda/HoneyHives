using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverBase : MonoBehaviour
{
    /* This function doesn't actually change movement.  It changes the Starting position that the rail that the Float Mechanics run on. */



    bool ActiveMove = false;

    public float target_x = 0.0f;
    public float target_y = 1.0f;
    public float target_z = -10.0f;
    public float duration = 1.0f;


    private Vector3 TargetPosition;
    private Vector3 StartPosition;
    private float time_start;
    FloatMechanics floater;



    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.position;
        TargetPosition = new Vector3(target_x, target_y, target_z);

        floater = gameObject.transform.GetComponent<FloatMechanics>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ActiveMove)
        {
            MoveTowardsTarget();
        }
    }

    public void Activate_Move()
    {
        ActiveMove = true;
        time_start = Time.time;
    }

    void MoveTowardsTarget()
    {
        //get time change
        float timechange = Time.time - time_start;

        //get precentage
        float percentage_complete = timechange / duration;

        Vector3 NewPosition = Vector3.Lerp(StartPosition, TargetPosition, percentage_complete);

        //set new start position
        floater.StartPosition = NewPosition;

    }
}
