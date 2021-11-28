using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeBox : MonoBehaviour
{
    public wg_ADDRESS HoveredOver_Area;


    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    public void Set_HoveredOver_Area(wg_ADDRESS address)
    {
        HoveredOver_Area = address;

        //Debug.Log(HoveredOver_AreaAddress);
    }
}
