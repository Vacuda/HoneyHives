using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static gs_GAMESTATUS;
using static ln_LEVELNAME;


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
        //find current level
        ln_LEVELNAME CurrentLevel = Find_CurrentLevel();

        //build out level
        Builder.Build_ThisLevel(CurrentLevel);


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

    ln_LEVELNAME Find_CurrentLevel()
    {
        //@@@@ here we'll have to figure out the level that is supposed to be built

        return LEVEL_001;

    }


}
