using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static c_ACTCOLOR;

public class FlowerIndicator : MonoBehaviour
{
    public wg_ADDRESS FlowerAddress;
    private bool IsValidated = false;
    private ColorChanger ColorChangerScript;

    //store renderers, store material ref
    private Renderer Center_Renderer;
    private Renderer Petals_Renderer;
    private Renderer Vine_Renderer;

    private MaterialPropertyBlock VineMaterial;
    private MaterialPropertyBlock CenterMaterial;
    private MaterialPropertyBlock PetalsMaterial;

    //these colors are consistent.  they should be more global

    //Color VineColor_GOOD = new Color32(48, 120, 43, 255);
    //Color PetalColor_GOOD = new Color32(231, 231, 231, 255);
    //Color CenterColor_GOOD = new Color32(231, 186, 24, 255);

    //Color VineColor_BAD = new Color32(55, 72, 54, 255);
    //Color CenterColor_BAD = new Color32(99, 99, 99, 255);
    //Color PetalColor_BAD = new Color32(135, 125, 98, 255);

    ////store renderers, store material ref

    //Color Current_VineColor = new Color32(55, 72, 54, 255);
    //Color Current_CenterColor = new Color32(99, 99, 99, 255);
    //Color Current_PetalColor = new Color32(135, 125, 98, 255);
    //float TransitionSpeed = 0.02f;


    public void Awake()
    {
        ColorChangerScript = gameObject.transform.parent.transform.parent.GetComponent<WorldGrid>().ColorChangerScript;

        Center_Renderer = gameObject.transform.Find("Flower_Center").GetComponent<MeshRenderer>();
        Petals_Renderer = gameObject.transform.Find("Flower_Petals").GetComponent<MeshRenderer>();
        Vine_Renderer = gameObject.transform.Find("Vine").GetComponent<MeshRenderer>();

        CenterMaterial = new MaterialPropertyBlock();
        PetalsMaterial = new MaterialPropertyBlock();
        VineMaterial = new MaterialPropertyBlock();
    }

    void Start()
    {
        Inform_ColorChanger_OfActivationChange_Instant(false);
    }

    void Update()
    {

        //@@@@ This shouldn't happen every tick.  Should be a shut off mechanism when its done.
        //How to compare colors/vector4?  
        //Or put a time trigger on it?

        //Update_FlowerIndicatorColors();
    }

    //private void Update_FlowerIndicatorColors()
    //{
    //    //find destination colors
    //    Color Destination_CenterColor;
    //    Color Destination_PetalColor;
    //    Color Destination_VineColor;

    //    //if activated
    //    if (IsValidated)
    //    {
    //        Destination_CenterColor = CenterColor_GOOD;
    //        Destination_PetalColor = PetalColor_GOOD;
    //        Destination_VineColor = VineColor_GOOD;
    //    }
    //    else
    //    {
    //        Destination_CenterColor = CenterColor_BAD;
    //        Destination_PetalColor = PetalColor_BAD;
    //        Destination_VineColor = VineColor_BAD;
    //    }

    //    //get current property blocks
    //    FlowerRenderer.GetPropertyBlock(CenterMaterial);
    //    FlowerRenderer.GetPropertyBlock(PetalMaterial);
    //    VineRenderer.GetPropertyBlock(VineMaterial);

    //    //center - handle change
    //    {
    //        //get new color
    //        Color NewColor = Color.Lerp(Current_CenterColor, Destination_CenterColor, TransitionSpeed);

    //        //store new color
    //        Current_CenterColor = NewColor;

    //        //set new color
    //        CenterMaterial.SetColor("_Color", NewColor);
    //    }

    //    //petal - handle change
    //    {
    //        //get new color
    //        Color NewColor = Color.Lerp(Current_PetalColor, Destination_PetalColor, TransitionSpeed);

    //        //store new color
    //        Current_PetalColor = NewColor;

    //        //set new color
    //        PetalMaterial.SetColor("_Color", NewColor);
    //    }

    //    //vine - handle change
    //    {
    //        //get new color
    //        Color NewColor = Color.Lerp(Current_VineColor, Destination_VineColor, TransitionSpeed);

    //        //store new color
    //        Current_VineColor = NewColor;

    //        //set new color
    //        VineMaterial.SetColor("_Color", NewColor);
    //    }

    //    //set changes
    //    FlowerRenderer.SetPropertyBlock(CenterMaterial, 0);
    //    FlowerRenderer.SetPropertyBlock(PetalMaterial, 1);
    //    VineRenderer.SetPropertyBlock(VineMaterial);
    //}

    public void Activate_Flower()
    {
        //if not validated
        if (!IsValidated)
        {
            //swap to true
            IsValidated = true;

            Inform_ColorChanger_OfActivationChange(true);
        }
    }

    public void Deactivate_Flower()
    {
        //if validated
        if (IsValidated)
        {
            //swap to false
            IsValidated = false;

            Inform_ColorChanger_OfActivationChange(false);
        }
    }

    //UTILITIES

    private void Inform_ColorChanger_OfActivationChange(bool activation)
    {
        ColorChangerScript.ChangeColorActivation_Linear(Center_Renderer, CenterMaterial, c_CENTER, activation);
        ColorChangerScript.ChangeColorActivation_Linear(Petals_Renderer, PetalsMaterial, c_PETALS, activation);
        ColorChangerScript.ChangeColorActivation_Linear(Vine_Renderer, VineMaterial, c_VINE, activation);
    }

    private void Inform_ColorChanger_OfActivationChange_Instant(bool activation)
    {
        ColorChangerScript.ChangeColorActivation_Instant(Center_Renderer, CenterMaterial, c_CENTER, activation);
        ColorChangerScript.ChangeColorActivation_Instant(Petals_Renderer, PetalsMaterial, c_PETALS, activation);
        ColorChangerScript.ChangeColorActivation_Instant(Vine_Renderer, VineMaterial, c_VINE, activation);
    }


}
