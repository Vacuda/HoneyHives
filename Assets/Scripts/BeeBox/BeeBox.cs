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
