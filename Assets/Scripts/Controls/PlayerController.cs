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

    public GameObject BackButtonObject;
    private BackButton BackButtonScript;

    private GameLevel GameLevelScript;

/*ADMIN FUNCTIONS*/

    //called before Start
    private void Awake()
    {
        //creates new control object
        Controls = new PlayerControls();

        GameLevelScript = GetComponentInParent<GameLevel>();

        BackButtonScript = BackButtonObject.GetComponent<BackButton>();
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
        Controls.GameLevel_Outer.Spin.performed += _ => Spin();
    }

/*METHODS*/

    void Interact()
    {
        //condense
        wg_ADDRESS HoveredOver_HoneyComb = WorldGridScript.HoveredOver_HoneyComb;
        wg_ADDRESS HoveredOver_HoneySlot = WorldGridScript.HoveredOver_HoneySlot;
        bool IsBackButton_HoveredOver = BackButtonScript.IsBackButton_HoveredOver;
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
                //turn off HoneyComb Colliders
                WorldGridScript.Modify_AllHoneyCombColliders(false);

                //change status to INNER
                GameLevelScript.Set_GameStatus(INNER);

                //set movement to new HoneyComb
                WorldGridScript.Move_ToThisPosition(HoveredOver_HoneyComb);

                //turn on HoneySlot colliders
                WorldGridScript.Modify_ThisHoneyCombs_HoneySlotColliders(HoveredOver_HoneyComb, true);

                //move back button
                BackButtonScript.Move_IntoFrame();

            }

        }
        //if INNER
        if(GameStatus == INNER)
        {
            //no HoveredOver_HoneySlot
            if(HoveredOver_HoneySlot == NONE)
            {
                if (IsBackButton_HoveredOver)
                {
                    BackOut_ToFullWorldGrid();
                }
            }
            else
            {
                //pick up piece

            }
        }
    }

    void Spin()
    {
        //condense
        wg_ADDRESS HoveredOver_HoneyComb = WorldGridScript.HoveredOver_HoneyComb;
        wg_ADDRESS HoveredOver_HoneySlot = WorldGridScript.HoveredOver_HoneySlot;
        //gs_GAMESTATUS GameStatus = GameLevelScript.Get_GameStatus();

        // @@@@ if piece in hand


        //no HoveredOver_HoneySlot
        if (HoveredOver_HoneySlot == NONE)
        {
            //do nothing
        }
        else
        {
            //find HoneySlotObject
            GameObject HoneySlotObject = WorldGridScript.WGRefDict[HoveredOver_HoneySlot];

            //check if occupied
            if(HoneySlotObject.GetComponentInChildren<Piece>() != null)
            {
                //rotate piece attached
                HoneySlotObject.GetComponentInChildren<Piece>().Rotate_Piece();

                //validate all indicators in this honeycomb
                WorldGridObject.GetComponent<VineValidator>().Validate_ThisHoneyComb(HoveredOver_HoneyComb);

            }


        }
    }

    void BackOut_ToFullWorldGrid()
    {

        //store HoneyComb
        wg_ADDRESS HoveredOver_HoneyComb = WorldGridScript.HoveredOver_HoneyComb;

        //remove current honeycomb
        WorldGridScript.Set_HoveredOver_HoneyComb(NONE);

        //turn off colliders for past honeycomb
        WorldGridScript.Modify_ThisHoneyCombs_HoneySlotColliders(HoveredOver_HoneyComb, false);

        //turn on honeycomb colliders
        WorldGridScript.Modify_AllHoneyCombColliders(true);

        //set new game status
        GameLevelScript.Set_GameStatus(OUTER);

        //move back
        WorldGridScript.Move_ToThisPosition(NONE);

        //move back button
        BackButtonScript.Move_OutOfFrame();

    }
}
