using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static wg_HONEYCOMB;

public class PlayerController : MonoBehaviour
{
    //place to store controls
    private PlayerControls Controls;

    public GameObject WorldGridObject;

    //called before Start
    private void Awake()
    {
        //creates new control object
        Controls = new PlayerControls();
    }

    //enables controls when this script is active
    private void OnEnable()
    {
        Controls.Enable();
    }

    //disable controls when this script is inactive
    private void OnDisable()
    {
        Controls.Disable();
    }

    void Start()
    {


        //sets up event listener to call function
        Controls.GameLevel_Outer.Interact.performed += _ => Interact();
    }


    void Update()
    {
        
        
    }

    void Interact()
    {

        //Debug.Log("Interacted:");

        //condense
        wg_HONEYCOMB ActiveHoneyComb = WorldGridObject.GetComponent<WorldGrid>().ActiveHoneyComb;


        if (ActiveHoneyComb != NONE)
        {
            WorldGridObject.GetComponent<WorldGrid>().Move_ToThisPosition(ActiveHoneyComb);

        }
        else
        {
            //do nothing
        }


    }
}
