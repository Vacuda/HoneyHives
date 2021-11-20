using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    LevelHouse LevelHouseScript;
    public WorldGrid WorldGridObject;
    Dictionary<wg_ADDRESS, GameObject> WGRefDict;

    public GameObject PF_Piece;

    private void Awake()
    {
        //find LevelHouseScript
        LevelHouseScript = gameObject.GetComponent<LevelHouse>();

        WGRefDict = WorldGridObject.GetComponent<WorldGrid>().WGRefDict;
    }

    private void Start()
    {
        
    }

    public void Build_ThisLevel(ln_LEVELNAME level)
    {
        //get LevelInfo from LevelHouse
        LevelInfo info = LevelHouseScript.Retrieve_ThisLevel(level);

        //loop HoneySlots
        foreach(HoneySlotInfo slot in info.HoneySlots)
        {
            //find location
            Transform Location = WGRefDict[slot.Address].transform;

            //if occupied
            if (slot.IsOccupied)
            {

                GameObject lava = Instantiate(PF_Piece);
                lava.transform.position = Location.position;
                lava.transform.parent = WGRefDict[slot.Address].transform;
            }

            



        }








    }



}
