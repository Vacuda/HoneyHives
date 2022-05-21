using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static menu_BUTTON;

public class PauseMenu_Collider : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public menu_BUTTON ButtonPressed;

    private PauseMenu Menu;

    private void Start()
    {
        Menu = gameObject.transform.root.GetComponent<PauseMenu>();

        if (!Menu)
        {
            Debug.Log("Didn't find pause menu");
        }
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        Menu.Change_HoveredOver(ButtonPressed);

        Debug.Log("on over");

    }

    //writing IPointerExitHander. then the function name made this work.  I think it overwrite's the base implementation written this way.
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        Menu.Change_HoveredOver(menu_NONE);
        Debug.Log("on exit");
    }
}
