using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static wg_ADDRESS;
using static gs_GAMESTATUS;


public class PlayerController : MonoBehaviour
{

/*MEMBERS*/

    //place to store controls
    private PlayerControls Controls;

    //references
    public GameObject WorldGridObject;
    private WorldGrid WorldGridScript;
    private GameLevel GameLevelScript;

/*ADMIN FUNCTIONS*/

    //called before Start
    private void Awake()
    {
        //creates new control object
        Controls = new PlayerControls();

        GameLevelScript = GetComponentInParent<GameLevel>();
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
        //find WorldGridScript
        WorldGridScript = WorldGridObject.GetComponent<WorldGrid>();

        //sets up event listener to call functions upon input
        Controls.GameLevel_Outer.Interact.performed += _ => Interact();
        Controls.GameLevel_Outer.CancelBack.performed += _ => CancelBack();
    }

/*METHODS*/

    void Interact()
    {
        //condense
        wg_ADDRESS HoveredOver_HoneyComb = WorldGridScript.HoveredOver_HoneyComb;
        gs_GAMESTATUS GameStatus = GameLevelScript.Get_GameStatus();

        //if OUTER
        if(GameStatus == OUTER)
        {
            //no HoveredOver_HoneyComb
            if (HoveredOver_HoneyComb == NONE)
            {
                //do nothing
            }
            else
            {
                //change status to INNER
                GameLevelScript.Set_GameStatus(INNER);

                //set movement to new HoneyComb
                WorldGridScript.Move_ToThisPosition(HoveredOver_HoneyComb);

                //turn on HoneySlot colliders
                WorldGridScript.Modify_ThisHoneyCombs_HoneySlotColliders(HoveredOver_HoneyComb, true);
            }

        }
        //if INNER
        if(GameStatus == INNER)
        {

        }
    }

    void CancelBack()
    {
        //condense
        gs_GAMESTATUS GameStatus = GameLevelScript.Get_GameStatus();

        //if INNER
        if(GameStatus == INNER)
        {
            //condense
            wg_ADDRESS HoveredOver_HoneyComb = WorldGridScript.HoveredOver_HoneyComb;

            //back out
            WorldGridScript.Set_HoveredOver_HoneyComb(NONE);

            //turn off colliders
            WorldGridScript.Modify_ThisHoneyCombs_HoneySlotColliders(HoveredOver_HoneyComb, false);

            GameLevelScript.Set_GameStatus(OUTER);

            WorldGridScript.Move_ToThisPosition(NONE);

        }
        //if OUTER
        else
        {
            //do nothing
        }

        


    }
}
