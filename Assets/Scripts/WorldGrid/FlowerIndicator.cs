using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static c_ACTCOLOR;

public class FlowerIndicator : MonoBehaviour
{
    //public wg_ADDRESS FlowerAddress;
    private bool IsValidated = false;
    private ColorChanger ColorChangerScript;

    //store renderers
    private Renderer Center_Renderer;
    private Renderer Petals_Renderer;
    private Renderer Vine_Renderer;

    //store Matpropblock ref
    private MaterialPropertyBlock VineMaterial;
    private MaterialPropertyBlock CenterMaterial;
    private MaterialPropertyBlock PetalsMaterial;



    public void Awake()
    {
        ColorChangerScript = transform.root.GetComponent<WorldGrid>().ColorChangerScript;

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
        ColorChangerScript.ChangeColorActivation_Lerp(Center_Renderer, CenterMaterial, c_CENTER, activation);
        ColorChangerScript.ChangeColorActivation_Lerp(Petals_Renderer, PetalsMaterial, c_PETALS, activation);
        ColorChangerScript.ChangeColorActivation_Lerp(Vine_Renderer, VineMaterial, c_VINE, activation);
    }

    private void Inform_ColorChanger_OfActivationChange_Instant(bool activation)
    {
        ColorChangerScript.ChangeColorActivation_Instant(Center_Renderer, CenterMaterial, c_CENTER, activation);
        ColorChangerScript.ChangeColorActivation_Instant(Petals_Renderer, PetalsMaterial, c_PETALS, activation);
        ColorChangerScript.ChangeColorActivation_Instant(Vine_Renderer, VineMaterial, c_VINE, activation);
    }


}
