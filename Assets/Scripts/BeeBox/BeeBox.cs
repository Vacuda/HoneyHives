using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeBox : MonoBehaviour
{
    public wg_ADDRESS Area_Hover;


    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    public void Set_Area_Hover(wg_ADDRESS address)
    {
        Area_Hover = address;

        //Debug.Log(Area_HoverAddress);
    }
}


//State Machine Implemention


//I looked into this when wanting to control when the honeyjar should pop up and when it shouldn't.  
//When you are consistently adding states as enums, you always have to check states to perform actions.

//in a state machine, you create a system that houses the implementation of something into the code of the specific state.
//and also lets you remove all of the if checks


//on one hand, it seems like I'm trying to refactor everything just to make it somewhat easier to control this honeyjar.
//but I know it'll be a great learning experience to implement this, and I think it will change how I implement tons of things

//specifically, like the player controller button, which checks a lot before knowing what to do when you press the interact button

//now, the controller ...

//one concern is how this breaks up my code.  Originally, I would put a lot of implementation of something in the item itself
//like honeyjar.  That should house the code to move it up and down.
//with states...

//does this mean I need a state machine for the honeyjar
//and the world grid
//and the beebox

//this is suppose to be a gamestate state machine
//starting
//outer
//moving in
//inner
//moving out


//so, functionality of the honeyjar
//do I put the function that calls the honeyjar movement in each relevant state
//but keep the functionality in honeyjar

//so, I'm not sure how much this'll fix on my current project
//and I'm not sure how long it will take
//but generally, I think I'll learn a good bit by rebuilding the game with this in mind.
//also seems like one of those things that I will always use and never look back.

//because this is so different, I should make a new branch
//should I export a playable game first?