using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static wg_ADDRESS;
using static gs_GAMESTATUS;
using UnityEngine.SceneManagement;


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
    public PauseButton PauseButtonScript;

    public PauseMenu PauseMenuScript;
    public FinishMenu FinishMenuScript;


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
        Controls.GameLevel.Interact.performed += _ => Interact();
        Controls.GameLevel.Spin.performed += _ => Spin();
    }

    private void Update()
    {
        float Mouse_X = Controls.GameLevel.MousePointer.ReadValue<Vector2>().x;

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
        wg_ADDRESS HoneyComb_Hover = WorldGridScript.HoneyComb_Hover;
        wg_ADDRESS HoneySlot_Hover = WorldGridScript.HoneySlot_Hover;
        wg_ADDRESS Area_Hover = BeeBoxScript.Area_Hover;
        bool IsBackButton_HoveredOver = BackButtonScript.IsBackButton_HoveredOver;
        bool IsPauseButton_HoveredOver = PauseButtonScript.IsPauseButton_HoveredOver;
        bool IsExitButton_HoveredOver = false;
        bool IsNewButton_HoveredOver = false;
        gs_GAMESTATUS GameStatus = GameLevelScript.Get_GameStatus();

        //is over exit button?
        if(PauseMenuScript.IsExitButton_HoveredOver || FinishMenuScript.IsExitButton_HoveredOver)
        {
            IsExitButton_HoveredOver = true;
        }

        //is over new button?
        if (PauseMenuScript.IsNewButton_HoveredOver || FinishMenuScript.IsNewButton_HoveredOver)
        {
            IsNewButton_HoveredOver = true;
        }

        //if over pause button
        if (IsPauseButton_HoveredOver == true)
        {
            PauseMenuScript.InteractWithPauseButton();

            
            return;
        }

        if (IsExitButton_HoveredOver)
        {

            Debug.Log("should quit.");
            Application.Quit();
        }
        

        if (IsNewButton_HoveredOver)
        {

            Debug.Log("should be new.");
            SceneManager.LoadSceneAsync("GameLevel", LoadSceneMode.Single);
        }

        //if Area_Hover
        if (Area_Hover != NONE)
        {
            //find AreaObject
            GameObject AreaObject = WorldGridScript.WGRefDict[Area_Hover];

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
            //no HoneyComb_Hover
            if (HoneyComb_Hover == NONE)
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
                WorldGridScript.Move_ToThisPosition(HoneyComb_Hover);

                //turn on HoneySlot colliders
                WorldGridScript.Modify_ThisHoneyCombs_HoneySlotColliders(HoneyComb_Hover, true);

                //move back button
                BackButtonScript.Move_IntoFrame();

            }

        }
        //if INNER
        if (GameStatus == INNER)
        {
            //no HoneySlot_Hover
            if (HoneySlot_Hover == NONE)
            {
                if (IsBackButton_HoveredOver)
                {
                    BackOut_ToFullWorldGrid();
                }
            }
            else
            {
                //find HoneySlotObject
                GameObject HoneySlotObject = WorldGridScript.WGRefDict[HoneySlot_Hover];

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
                            ValidatorScript.Validate_ThisHoneyComb(HoneyComb_Hover);
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
                        ValidatorScript.Validate_ThisHoneyComb(HoneyComb_Hover);
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
        wg_ADDRESS HoneyComb_Hover = WorldGridScript.HoneyComb_Hover;
        wg_ADDRESS HoneySlot_Hover = WorldGridScript.HoneySlot_Hover;
        wg_ADDRESS Area_Hover = BeeBoxScript.Area_Hover;
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

        //if Area_Hover
        if(Area_Hover != NONE)
        {
            //find AreaObject
            GameObject AreaObject = WorldGridScript.WGRefDict[Area_Hover];

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

        //no HoneySlot_Hover
        if (HoneySlot_Hover == NONE)
        {
            //do nothing
        }
        else
        {
            //find HoneySlotObject
            GameObject HoneySlotObject = WorldGridScript.WGRefDict[HoneySlot_Hover];

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
                    ValidatorScript.Validate_ThisHoneyComb(HoneyComb_Hover);
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
        wg_ADDRESS HoneyComb_Hover = WorldGridScript.HoneyComb_Hover;

        //set new game status
        GameLevelScript.Set_GameStatus(OUTER);  //needs to happen before triggering exiting honeycomb

        //remove current honeycomb
        WorldGridScript.Trigger_ExitingAHoneyComb();

        //turn off colliders for past honeycomb
        WorldGridScript.Modify_ThisHoneyCombs_HoneySlotColliders(HoneyComb_Hover, false);

        //turn on honeycomb colliders
        WorldGridScript.Modify_AllHoneyCombColliders(true);

        //move back
        WorldGridScript.Move_ToThisPosition(NONE);

        //move back button
        BackButtonScript.Move_OutOfFrame();



    }

    public PlayerControls Get_Controls()
    {
        return Controls;
    }

}
