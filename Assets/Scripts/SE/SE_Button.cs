using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static fv_FACEVALUE;

public class SE_Button : MonoBehaviour
{
    public t_TRI tri;
    public bool bIsAttribute = false;

    Dropdown dropdown;

    SE_DropdownCluster cluster;
    

    private void Start()
    {
        dropdown = gameObject.GetComponent<Dropdown>();
        cluster = gameObject.transform.parent.GetComponent<SE_DropdownCluster>();

        dropdown.onValueChanged.AddListener(delegate {OnValueChange();});
    }

    public void OnValueChange()
    {
        //if move/spin
        if (bIsAttribute)
        {
            fv_FACEVALUE fv = ConvertDropdownValue_ToBool();

            cluster.ThisAttributeChanged(tri, fv);
        }
        else
        {
            fv_FACEVALUE fv = ConvertDropdownValue_ToFaceValue();

            cluster.ThisFaceValueChanged(tri, fv);
        }
    }

    private fv_FACEVALUE ConvertDropdownValue_ToFaceValue()
    {
        switch (dropdown.value)
        {
            case 0:     return v_null;
            case 1:     return v_0;
            case 2:     return v_1;
            case 3:     return v_2;
            case 4:     return v_3;
            case 5:     return v_4;
            case 6:     return v_5;
            case 7:     return v_6;
            case 8:     return v_7;
            case 9:     return v_8;
            case 10:    return v_9;
            case 11:    return v_add;
            case 12:    return v_sub;
            case 13:    return v_blank;
            case 14:    return v_equals;
            default:    return v_null;
        }
    }

    private fv_FACEVALUE ConvertDropdownValue_ToBool()
    {
        /* v_1 to signify Movable, v_0 to signify Not Movable */

        switch (dropdown.value)
        {
            case 0: return v_null;
            case 1: return v_1;
            case 2: return v_0;
            default: return v_null;
        }
    }


}
