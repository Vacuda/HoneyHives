using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static menu_BUTTON;

public class FinishMenu : MonoBehaviour
{
    public bool IsExitButton_HoveredOver = false;
    public bool IsNewButton_HoveredOver = false;


    Vector3 OutPosition = new Vector3(-0.0299999993f, 1.00999999f, -48.52573109f);
    Vector3 InPosition = new Vector3(-0.0299999993f, 1.00999999f, -8.52573109f);

    private void Start()
    {
        this.transform.position = OutPosition;
    }


    public void BringUpFinishMenu()
    {

        this.transform.position = InPosition;

    }

    public void Change_HoveredOver(menu_BUTTON button)
    {

        if (button == menu_EXIT)
        {
            IsExitButton_HoveredOver = true;
        }
        else if(button == menu_NEW)
        {
            IsNewButton_HoveredOver = true;
        }
        else
        {
            IsExitButton_HoveredOver = false;
            IsNewButton_HoveredOver = false;
        }
    }
}
