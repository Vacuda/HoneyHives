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
    }

    //void Update()
    //{

    //}

    public void Set_GameStatus(gs_GAMESTATUS status)
    {
        GameStatus = status;
    }

    public gs_GAMESTATUS Get_GameStatus()
    {
        return GameStatus;
    }


}
