using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static gs_GAMESTATUS;
using static ln_LEVELNAME;


public class GameLevel : MonoBehaviour
{
    private gs_GAMESTATUS GameStatus;
    LevelBuilder Builder;

    private void Awake()
    {
        //find builder
        Builder = gameObject.GetComponent<LevelBuilder>();
    }

    void Start()
    {
        //find current level
        ln_LEVELNAME CurrentLevel = Find_CurrentLevel();

        Builder.Build_ThisLevel(CurrentLevel);


        GameStatus = OUTER;


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
