using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerIndicator : MonoBehaviour
{
    public wg_ADDRESS FlowerAddress;

    Color VineColor_GOOD = new Color32(48, 120, 43, 255);
    Color PetalColor_GOOD = new Color32(231, 231, 231, 255);
    Color CenterColor_GOOD = new Color32(231, 186, 24, 255);

    Color VineColor_BAD = new Color32(55, 72, 54, 255);
    Color CenterColor_BAD = new Color32(99, 99, 99, 255);
    Color PetalColor_BAD = new Color32(135, 125, 98, 255);

    //store renderers, store material ref
    private Renderer FlowerRenderer;
    private Renderer VineRenderer;
    private MaterialPropertyBlock VineMaterial;
    private MaterialPropertyBlock CenterMaterial;
    private MaterialPropertyBlock PetalMaterial;

    Color Current_VineColor = new Color32(55, 72, 54, 255);
    Color Current_CenterColor = new Color32(99, 99, 99, 255);
    Color Current_PetalColor = new Color32(135, 125, 98, 255);
    float TransitionSpeed = 0.02f;

    private bool IsValidated;

    public void Awake()
    {
        FlowerRenderer = gameObject.transform.Find("Flower").GetComponent<MeshRenderer>();
        VineRenderer = gameObject.transform.Find("Vine").GetComponent<MeshRenderer>();
        VineMaterial = new MaterialPropertyBlock();
        CenterMaterial = new MaterialPropertyBlock();
        PetalMaterial = new MaterialPropertyBlock();
    }

    public void Update()
    {
        Update_FlowerIndicatorColors();
    }

    private void Update_FlowerIndicatorColors()
    {
        //find destination colors
        Color Destination_CenterColor;
        Color Destination_PetalColor;
        Color Destination_VineColor;

        //if activated
        if (IsValidated)
        {
            Destination_CenterColor = CenterColor_GOOD;
            Destination_PetalColor = PetalColor_GOOD;
            Destination_VineColor = VineColor_GOOD;
        }
        else
        {
            Destination_CenterColor = CenterColor_BAD;
            Destination_PetalColor = PetalColor_BAD;
            Destination_VineColor = VineColor_BAD;
        }

        //get current property blocks
        FlowerRenderer.GetPropertyBlock(CenterMaterial);
        FlowerRenderer.GetPropertyBlock(PetalMaterial);
        VineRenderer.GetPropertyBlock(VineMaterial);

        //center - handle change
        {
            //get new color
            Color NewColor = Color.Lerp(Current_CenterColor, Destination_CenterColor, TransitionSpeed);

            //store new color
            Current_CenterColor = NewColor;

            //set new color
            CenterMaterial.SetColor("_Color", NewColor);
        }

        //petal - handle change
        {
            //get new color
            Color NewColor = Color.Lerp(Current_PetalColor, Destination_PetalColor, TransitionSpeed);

            //store new color
            Current_PetalColor = NewColor;

            //set new color
            PetalMaterial.SetColor("_Color", NewColor);
        }

        //vine - handle change
        {
            //get new color
            Color NewColor = Color.Lerp(Current_VineColor, Destination_VineColor, TransitionSpeed);

            //store new color
            Current_VineColor = NewColor;

            //set new color
            VineMaterial.SetColor("_Color", NewColor);
        }

        //set changes
        FlowerRenderer.SetPropertyBlock(CenterMaterial, 0);
        FlowerRenderer.SetPropertyBlock(PetalMaterial, 1);
        VineRenderer.SetPropertyBlock(VineMaterial);
    }

    public void Activate_Flower()
    {
        IsValidated = true;
    }

    public void Deactivate_Flower()
    {
        IsValidated = false;
    }


}
