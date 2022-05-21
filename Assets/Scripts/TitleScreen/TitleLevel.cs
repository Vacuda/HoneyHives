using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleLevel : MonoBehaviour
{
    public LevelBuilder_Title Builder;
    //public WorldGrid WorldGridObject;


    void Start()
    {
        PopulateWorldGrid();

        Builder.Randomize_HodgePodge();
    }


    void PopulateWorldGrid()
    {
        PuzzleSettings settings = new PuzzleSettings();

        //DEBUG SETTINGS HERE

        settings.bSpinPieces = true;
        settings.bMovePieces = false;
        settings.bIsTitleLevel = false;  //unneeded

        //DEBUG SETTINGS HERE

        PuzzleInfo puz_info = PuzzleBuilder_Title.Build_Puzzle(settings);


        //build out level
        Builder.BuildOut_ThisPuzzle(puz_info);
    }


    public void Play_GameLevel()
    {
        SceneManager.LoadSceneAsync("GameLevel", LoadSceneMode.Single);
    }

}
