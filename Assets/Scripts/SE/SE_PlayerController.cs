using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE_PlayerController : MonoBehaviour
{
    /*MEMBERS*/

    //place to store controls
    private PlayerControls Controls;

    //references
    //public GameObject WorldGridObject;
    //private WorldGrid WorldGridScript;

    //public GameObject BackButtonObject;
    //private BackButton BackButtonScript;

    //public GameObject BeeBoxObject;
    //private BeeBox BeeBoxScript;

    //private VineValidator ValidatorScript;
    //private GameLevel GameLevelScript;




    /*ADMIN FUNCTIONS*/

    //called before Start
    private void Awake()
    {
        //creates new control object
        Controls = new PlayerControls();

        //GameLevelScript = GetComponentInParent<GameLevel>();

        //BackButtonScript = BackButtonObject.GetComponent<BackButton>();

        //ValidatorScript = WorldGridObject.GetComponent<VineValidator>();
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
        ////find WorldGridScript
        //WorldGridScript = WorldGridObject.GetComponent<WorldGrid>();

        ////sets up event listener to call functions upon input
        //Controls.GameLevel_Outer.Interact.performed += _ => Interact();
        //Controls.GameLevel_Outer.Spin.performed += _ => Spin();
    }


    /*METHODS*/

   
   
   

    public PlayerControls Get_Controls()
    {
        return Controls;
    }












}
