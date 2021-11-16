using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static gs_GAMESTATUS;

public enum gs_GAMESTATUS
{
    FADE_IN, FADE_OUT, OUTER, INNER, TRANS_IN, TRANS_OUT 
};


public class GameLevel : MonoBehaviour
{
    gs_GAMESTATUS GameStatus = INNER;

    //void Start()
    //{

    //}

    //void Update()
    //{

    //}



}
