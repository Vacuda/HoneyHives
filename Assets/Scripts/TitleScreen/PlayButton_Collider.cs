using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class PlayButton_Collider : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TitleLevel Level;

    private Renderer rend;
    private TextMeshPro text_mesh;
    public Material Panel_Material_Highlighted;
    private Material Panel_Material;


    Color TextColor_Hightlighted = new Color32(231, 231, 231, 255);
    Color TextColor = new Color32(58, 24, 3, 255);

    private void Start()
    {
        rend = transform.parent.transform.Find("Panel").gameObject.transform.GetComponent<Renderer>();
        text_mesh = transform.parent.transform.Find("Text_Play").gameObject.transform.GetComponent<TextMeshPro>();
        Panel_Material = rend.material;
    }


    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("over play button");
        Level.Trigger_HoveringOver_PlayButton(true);

        Trigger_PlayButton_Highlighted(true);
    }

    //writing IPointerExitHander. then the function name made this work.  I think it overwrite's the base implementation written this way.
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("EXITING play button");
        Level.Trigger_HoveringOver_PlayButton(false);

        Trigger_PlayButton_Highlighted(false);
    }

    void Trigger_PlayButton_Highlighted(bool Highlighted)
    {
        var mats = rend.materials;

        if (Highlighted)
        {
            mats[0] = Panel_Material_Highlighted;
            text_mesh.color = TextColor_Hightlighted;
        }
        else
        {
            mats[0] = Panel_Material;
            text_mesh.color = TextColor;
        }

        rend.materials = mats;
    }
}
