using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play_Level(int Level)
    {
        SceneManager.LoadScene("GameLevel", LoadSceneMode.Single);


        
        Debug.Log("Hello");
    }






}