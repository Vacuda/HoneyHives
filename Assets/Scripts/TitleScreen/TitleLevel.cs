using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleLevel : MonoBehaviour
{
    public LevelBuilder_Title Builder;
    public VineValidator_Title Validator;
    public bool bSkipOpening = false;

    public GameObject BlackScreen;
    public GameObject LogoScreen;
    private CanvasGroup BlackScreen_CanvasGroup;
    private FadeInOut BlackScreen_FadeInOut;
    private FadeInOut LogoScreen_FadeInOut;


    //public GameObject TitleBlocks;
    public MoverBase TitleBlocks_Mover;
    //public GameObject WorldGridObject;
    public MoverBase WorldGrid_Mover;
    public HodgePodge HodgePodgeScript;
    public Animator _Animator;





    bool PlayButton_HoveredOver = false;
    bool ExitButton_HoveredOver = false;

    void Start()
    {
        //set references
        BlackScreen_CanvasGroup = BlackScreen.GetComponent<CanvasGroup>();
        BlackScreen_FadeInOut = BlackScreen.GetComponent<FadeInOut>();
        LogoScreen_FadeInOut = LogoScreen.GetComponent<FadeInOut>();

        //prepare pieces
        PopulateWorldGrid();
        Builder.Randomize_HodgePodge();
        Validator.Validate_AllHoneyCombs();

        Set_HoneyLock_ToStayUp();


        if (bSkipOpening)
        {
            Unlock_PlayerController();
        }
        else
        {
            //start level opening
            StartCoroutine(Sequence_LevelOpening());
        }
    }


    void PopulateWorldGrid()
    {
        PuzzleSettings settings = new PuzzleSettings();

        //DEBUG SETTINGS HERE

        settings.bSpinPieces = true;
        settings.bMovePieces = false;
        settings.bMoveMovablesToBeeBox = false;

        //DEBUG SETTINGS HERE

        PuzzleInfo puz_info = PuzzleBuilder_Title.Build_Puzzle(settings);


        //build out level
        Builder.BuildOut_ThisPuzzle(puz_info);
    }

    public void Interact()
    {
        Debug.Log("Interact Worked");

        if (ExitButton_HoveredOver)
        {
            Debug.Log("should quit");
            Application.Quit();
        }

        if (PlayButton_HoveredOver)
        {
            Debug.Log("should play game level");

            //start exit sequence
            StartCoroutine(Sequence_TitleScreenExit());
        }
    }


    public void Trigger_HoveringOver_PlayButton(bool activation)
    {
            
        if (activation)
        {
            PlayButton_HoveredOver = true;
        }
        else
        {
            PlayButton_HoveredOver = false;
        }
    }

    public void Trigger_HoveringOver_ExitButton(bool activation)
    {
        if (activation)
        {
            ExitButton_HoveredOver = true;
        }
        else
        {
            ExitButton_HoveredOver = false;
        }
    }

    IEnumerator Sequence_LevelOpening()
    {
        //set blackscreen full
        BlackScreen_CanvasGroup.alpha = 1.0f;

        //fade in logo
        yield return StartCoroutine(LogoScreen_FadeInOut.Start_FadeInAndOut(1.0f));

        //fade out blackscreen
        yield return StartCoroutine(BlackScreen_FadeInOut.Start_Fade(false));

        //give control
        Unlock_PlayerController();
    }

    IEnumerator Sequence_TitleScreenExit()
    {
        //move titleblocks towards screen
        TitleBlocks_Mover.Activate_Move();

        //move hodge podge towards screen
        HodgePodgeScript.Activate_MoveSequence();

        //move WorldGrid
        WorldGrid_Mover.Activate_Move();

        //pull down honey lock
        _Animator.Play("state_GoingDown");

        //wait on fade out
        yield return StartCoroutine(BlackScreen_FadeInOut.Start_Fade(true));

        //load game level
        SceneManager.LoadScene("GameLevel", LoadSceneMode.Single);
    }

    void Unlock_PlayerController()
    {
        //allow raycasting, allow pressing play button
        BlackScreen_CanvasGroup.blocksRaycasts = false;
    }

    void Set_HoneyLock_ToStayUp()
    {
        ////set to stay up
        //_Animator.SetBool("bKeepLockUp", true);

        ////goto Up state
        //_Animator.Play("Base.state_GoingUp");
    }
}
