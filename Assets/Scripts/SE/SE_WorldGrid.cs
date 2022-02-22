using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static wg_ADDRESS;

public class SE_WorldGrid : MonoBehaviour
{
    public ColorChanger ColorChangerScript;

    public SE_GameLevel GameLevelScript;

    private GameObject HoneyCombObject;

    private Vector3 StartPosition = new Vector3(-15.04f, 0.8f, 26.33f);

    //int Tracker = 0;

    public Dictionary<wg_ADDRESS, GameObject> WGRefDict = new Dictionary<wg_ADDRESS, GameObject>();


    public wg_ADDRESS HoneySlot_Hover = NONE;

    private void Awake()
    {
        HoneyCombObject = this.transform.Find("HoneyComb").gameObject;


        //create ref dictionary
        //Make_WorldGridRefDict();
    }

    void Start()
    {

    }


    void Update()
    {
        Floating_WorldGrid();

        

    }

    //private void Make_WorldGridRefDict()
    //{
    //    //WGRefDict.Add(NONE, HoneyCombObject);
    //    WGRefDict.Add(AA, HoneyCombObject.transform.Find("HoneySlot_AA").gameObject);
    //    WGRefDict.Add(BB, HoneyCombObject.transform.Find("HoneySlot_BB").gameObject);
    //    WGRefDict.Add(CC, HoneyCombObject.transform.Find("HoneySlot_CC").gameObject);
    //    WGRefDict.Add(DD, HoneyCombObject.transform.Find("HoneySlot_DD").gameObject);
    //    WGRefDict.Add(EE, HoneyCombObject.transform.Find("HoneySlot_EE").gameObject);
    //    WGRefDict.Add(FF, HoneyCombObject.transform.Find("HoneySlot_FF").gameObject);
    //    WGRefDict.Add(GG, HoneyCombObject.transform.Find("HoneySlot_GG").gameObject);

    //    Debug.Log("DictCount: " + WGRefDict.Count);

    //}


    public void Set_HoneySlot_Hover(wg_ADDRESS address)
    {
        HoneySlot_Hover = address;
    }

    void Floating_WorldGrid()
    {
        Vector3 CurrentPosition = gameObject.transform.position;

        //gs_GAMESTATUS GameStatus = Admin.GetComponent<GameLevel>().Get_GameStatus();

        //if (GameStatus == 

        //float floatslow = 0.10f;
        float floatslow = 1.0f;


        //position change
        {
            //x change
            float x_change = Mathf.Cos(Time.time) * 0.2f * floatslow;
            //y change
            float y_change = Mathf.Sin(Time.time * 2.0f) * 0.15f * floatslow;
            //z change
            float z_change = Mathf.Sin(Time.time) * 0.1f * floatslow;


            //find PositionChange based off of sin behavior
            Vector3 PositionChange = new Vector3(x_change, y_change, z_change);

            //make position change with StartPosition in mind
            gameObject.transform.position = StartPosition + PositionChange;
        }

        //rotation change
        {
            //x change
            float x_change = 0.0f;
            //y change
            float y_change = Mathf.Sin(Time.time) * -0.005f;
            //z change
            float z_change = 0.0f;

            //find PositionChange based off of sin behavior
            Vector3 RotationChange = new Vector3(x_change, y_change, z_change);

            gameObject.transform.Rotate(RotationChange);

        }
    }

}
