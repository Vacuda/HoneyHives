using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static gs_GAMESTATUS;


public class GameLevel : MonoBehaviour
{
    private gs_GAMESTATUS GameStatus;

    void Start()
    {
        GameStatus = OUTER;

        ReadLevelFile();
    }



    public void Set_GameStatus(gs_GAMESTATUS status)
    {
        GameStatus = status;
    }

    public gs_GAMESTATUS Get_GameStatus()
    {
        return GameStatus;
    }

    void ReadLevelFile()
    {
        /*
         Need to create a mechanism that can load a level based off a set of info
         
        1) Place to house levels (LevelHouse)
        2) Enum (LevelName)
        3) Custom Struct for this level info (LevelInfo)
         */
    }


}
