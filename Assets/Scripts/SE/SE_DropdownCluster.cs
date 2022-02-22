using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static wg_ADDRESS;
using UnityEngine.UI;

public class SE_DropdownCluster : MonoBehaviour
{
    public SE_HoneyComb honeycomb;
    public wg_ADDRESS address;
    private SE_VineValidator validator;

    public Dictionary<wg_ADDRESS, GameObject> HoneySlotRefDict = new Dictionary<wg_ADDRESS, GameObject>();

    private List<Dropdown> DropdownList = new List<Dropdown>();

    int bIsSpinnable = -1;
    int bIsMovable = -1;

    void Start()
    {
        //copy references
        HoneySlotRefDict = honeycomb.HoneySlotRefDict;

        validator = honeycomb.gameObject.transform.parent.GetComponent<SE_VineValidator>();

        foreach (Transform child in gameObject.transform)
        {
            DropdownList.Add(child.gameObject.GetComponent<Dropdown>());
        }
    }

    public void ThisFaceValueChanged(t_TRI tri, fv_FACEVALUE val)
    {
        //find PieceScript using slot address
        SE_Piece PieceScript = HoneySlotRefDict[address].transform.GetChild(0).gameObject.GetComponent<SE_Piece>();

        //send change info
        PieceScript.ChangeThisValue(tri, val);

        //validate
        validator.Validate_ThisHoneyComb();
    }

    public void ThisAttributeChanged(t_TRI tri, fv_FACEVALUE val)
    {
       
    }

    public void Reset_ThisCluster()
    {
        foreach(var item in DropdownList)
        {
            item.value = 0;
        }
    }


}
