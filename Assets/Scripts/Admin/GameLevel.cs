using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static gs_GAMESTATUS;
using UnityEngine.SceneManagement;


public class GameLevel : MonoBehaviour
{
    private gs_GAMESTATUS GameStatus;
    public LevelBuilder Builder;
    public WorldGrid WorldGridObject;
    public PauseMenu Menu;
    public FinishMenu finish_menu;
    public GameObject BlackScreen;
    private FadeInOut BlackScreen_FadeInOut;

    private void Awake()
    {
        BlackScreen_FadeInOut = BlackScreen.GetComponent<FadeInOut>();

    }

    void Start()
    {
        //@@@@ should receive from main menu instead
        PuzzleSettings settings = new PuzzleSettings();

    //DEBUG SETTINGS HERE

        settings.bSpinPieces = false;
        settings.bMovePieces = false;
        settings.bIsTitleLevel = false;

    //DEBUG SETTINGS HERE

        PuzzleInfo puz_info = PuzzleBuilder.Build_Puzzle(settings);

        //build out level
        Builder.BuildOut_ThisPuzzle(puz_info);


        GameStatus = OUTER;

        ////starts the CoRoutine below
        //StartCoroutine(DelayedValidation());

        //start opening sequence
        StartCoroutine(Sequence_LevelOpening());
    }

    IEnumerator DelayedValidation()
    {
        //pause 
        yield return new WaitForSeconds(1);

        //Verify each HoneyComb
        WorldGridObject.GetComponent<VineValidator>().Validate_AllHoneyCombs();
    }

    public void Set_GameStatus(gs_GAMESTATUS status)
    {
        GameStatus = status;
    }

    public gs_GAMESTATUS Get_GameStatus()
    {
        return GameStatus;
    }

    public void Trigger_LevelCompletion()
    {
        Debug.Log("Level COMPLETE");

        finish_menu.BringUpFinishMenu();

        //SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    private IEnumerator Sequence_LevelOpening()
    {
        //trigger fade in
        yield return StartCoroutine(BlackScreen_FadeInOut.Start_Fade(false));


        //yield return new WaitForSeconds(1);

        //Verify each HoneyComb
        WorldGridObject.GetComponent<VineValidator>().Validate_AllHoneyCombs();

        //give control to player
        Unlock_PlayerController();

        yield return null;
    }

    void Unlock_PlayerController()
    {
        //allow raycasting, allow pressing play button
        BlackScreen.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }


}
