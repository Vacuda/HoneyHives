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

    private void Awake()
    {


    }

    void Start()
    {
        //@@@@ should receive from main menu instead
        PuzzleSettings settings = new PuzzleSettings();


        PuzzleInfo puz_info = PuzzleBuilder.Build_Puzzle(settings);


        ////find current level
        //ln_LEVELNAME CurrentLevel = Find_CurrentLevel();

        //build out level
        Builder.BuildOut_ThisPuzzle(puz_info);


        GameStatus = OUTER;

        //starts the CoRoutine below
        StartCoroutine(DelayedValidation());

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

        SceneManager.LoadScene("GameLevel", LoadSceneMode.Single);
    }


}
