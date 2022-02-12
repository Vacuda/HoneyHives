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

    public GameObject BeeBoxObject;
    private BeeBox BeeBoxScript;

    private VineValidator ValidatorScript;
    private GameLevel GameLevelScript;

    public Camera MainCameraObject;
    private MainCamera MainCameraScript;

    public HoneyLock HoneyLockScript;


    //Piece In Hand - Reference
    public GameObject PieceInHand;

/*ADMIN FUNCTIONS*/

    //called before Start
    private void Awake()
    {
        //creates new control object
        Controls = new PlayerControls();

        GameLevelScript = GetComponentInParent<GameLevel>();

        BackButtonScript = BackButtonObject.GetComponent<BackButton>();

        ValidatorScript = WorldGridObject.GetComponent<VineValidator>();

        BeeBoxScript = BeeBoxObject.GetComponent<BeeBox>();

        MainCameraScript = MainCameraObject.GetComponent<MainCamera>();
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

    private void Update()
    {
        float Mouse_X = Controls.GameLevel_Outer.MousePointer.ReadValue<Vector2>().x;

        if (MainCameraScript.IsAtMainPosition)
        {
            if(Mouse_X > 1860.0f)
            {
                MainCameraScript.Goto_SidePosition();

            }

        }
        else
        {
            if (Mouse_X < 120.0f)
            {
                MainCameraScript.Goto_MainPosition();

            }
        }



        //1720
    }

/*METHODS*/

    void Interact()
    {
        //condense
        wg_ADDRESS HoveredOver_HoneyComb = WorldGridScript.HoveredOver_HoneyComb;
        wg_ADDRESS HoveredOver_HoneySlot = WorldGridScript.HoveredOver_HoneySlot;
        wg_ADDRESS HoveredOver_Area = BeeBoxScript.HoveredOver_Area;
        bool IsBackButton_HoveredOver = BackButtonScript.IsBackButton_HoveredOver;
        gs_GAMESTATUS GameStatus = GameLevelScript.Get_GameStatus();
        
        //if HoveredOver_Area
        if(HoveredOver_Area != NONE)
        {
            //find AreaObject
            GameObject AreaObject = WorldGridScript.WGRefDict[HoveredOver_Area];

            //check if occupied
            if (AreaObject.GetComponentInChildren<Piece>() != null)
            {
                //if piece in hand
                if (PieceInHand != null)
                {
                    //trigger negative feedback
                }
                else
                {
                    //condense
                    Piece PieceScript = AreaObject.GetComponentInChildren<Piece>();

                    //check if movable
                    if (PieceScript.IsMovable)
                    {
                        //pick up piece
                        PieceScript.Pickup_Piece();

                        //put piece in hand
                        PieceInHand = PieceScript.gameObject;
                    }
                    //not movable
                    else
                    {
                        //trigger negative feedback
                    }
                }
            }
            //not occupied
            else
            {
                //if piece in hand
                if (PieceInHand != null)
                {
                    //put piece down
                    PieceInHand.GetComponent<Piece>().Place_Piece(AreaObject, false);

                    //remove piece from hand
                    PieceInHand = null;
                }
                else
                {
                    //do nothing
                }
            }
        }

        //if OUTER
        if (GameStatus == OUTER)
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
        if (GameStatus == INNER)
        {
            //no HoveredOver_HoneySlot
            if (HoveredOver_HoneySlot == NONE)
            {
                if (IsBackButton_HoveredOver)
                {
                    BackOut_ToFullWorldGrid();
                }
            }
            else
            {
                //find HoneySlotObject
                GameObject HoneySlotObject = WorldGridScript.WGRefDict[HoveredOver_HoneySlot];

                //check if occupied
                if (HoneySlotObject.GetComponentInChildren<Piece>() != null)
                {                    
                    //if piece in hand
                    if (PieceInHand != null)
                    {
                        //trigger negative feedback
                    }
                    else
                    {
                        //condense
                        Piece PieceScript = HoneySlotObject.GetComponentInChildren<Piece>();

                        //check if movable
                        if (PieceScript.IsMovable)
                        {
                            //pick up piece
                            PieceScript.Pickup_Piece();

                            //put piece in hand
                            PieceInHand = PieceScript.gameObject;

                            //validate all indicators in this honeycomb
                            ValidatorScript.Validate_ThisHoneyComb(HoveredOver_HoneyComb);
                        }
                        //not movable
                        else
                        {
                            //trigger negative feedback
                        }
                    }
                }
                //not occupied
                else
                {
                    //if piece in hand
                    if (PieceInHand != null)
                    {
                        //put piece down
                        PieceInHand.GetComponent<Piece>().Place_Piece(HoneySlotObject, true);

                        //remove piece from hand
                        PieceInHand = null;

                        //validate all indicators in this honeycomb
                        ValidatorScript.Validate_ThisHoneyComb(HoveredOver_HoneyComb);
                    }
                    else
                    {
                        //do nothing
                    }
                }
            }
        }
    }

    void Spin()
    {
        //condense
        wg_ADDRESS HoveredOver_HoneyComb = WorldGridScript.HoveredOver_HoneyComb;
        wg_ADDRESS HoveredOver_HoneySlot = WorldGridScript.HoveredOver_HoneySlot;
        wg_ADDRESS HoveredOver_Area = BeeBoxScript.HoveredOver_Area;
        //gs_GAMESTATUS GameStatus = GameLevelScript.Get_GameStatus();

        //if piece in hand
        if (PieceInHand != null)
        {
            //condense
            Piece PieceScript = PieceInHand.GetComponent<Piece>();

            //if spinnable
            if (PieceScript.IsSpinnable)
            {
                //rotate piece attached
                PieceScript.Rotate_Piece();
            }
            else
            {
                //trigger negative feedback
                PieceScript.NegativeFeedback_PieceRotation();
            }

            //leave spin function
            return;
        }

    /* No Piece In Hand */

        //if HoveredOver_Area
        if(HoveredOver_Area != NONE)
        {
            //find AreaObject
            GameObject AreaObject = WorldGridScript.WGRefDict[HoveredOver_Area];

            //check if occupied
            if (AreaObject.GetComponentInChildren<Piece>() != null)
            {
                //condense
                Piece PieceScript = AreaObject.GetComponentInChildren<Piece>();

                //if spinnable
                if (PieceScript.IsSpinnable)
                {
                    //rotate piece attached
                    PieceScript.Rotate_Piece();
                }
                else
                {
                    //trigger negative feedback
                    PieceScript.NegativeFeedback_PieceRotation();
                }
            }

            //exit spin function
            return;
        }

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
            if (HoneySlotObject.GetComponentInChildren<Piece>() != null)
            {
                //condense
                Piece PieceScript = HoneySlotObject.GetComponentInChildren<Piece>();

                //if spinnable
                if (PieceScript.IsSpinnable)
                {
                    //rotate piece attached
                    PieceScript.Rotate_Piece();

                    //validate all indicators in this honeycomb
                    ValidatorScript.Validate_ThisHoneyComb(HoveredOver_HoneyComb);
                }
                else
                {
                    //trigger negative feedback
                }



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

        HoneyLockScript.BringDown_HoneyLock();

    }

    public PlayerControls Get_Controls()
    {
        return Controls;
    }

}
