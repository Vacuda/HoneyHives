using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Title : MonoBehaviour
{

    //place to store controls
    private PlayerControls Controls;
    private TitleLevel Level;

    private void Awake()
    {
        //creates new control object
        Controls = new PlayerControls();

        Level = gameObject.GetComponent<TitleLevel>();
    }

    //enables controls when this script is active
    private void OnEnable()
    {
        Controls.Enable();
    }

    //disable controls when this script is inactive
    private void OnDisable()
    {
        Controls.Disable();
    }

    private void Start()
    {
        //sets up event listener to call functions upon input
        Controls.TitleLevel.Interact.performed += _ => Level.Interact();
    }
}
