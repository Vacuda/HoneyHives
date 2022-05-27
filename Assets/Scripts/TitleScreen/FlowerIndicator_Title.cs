using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static c_ACTCOLOR;

public class FlowerIndicator_Title : MonoBehaviour
{
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
        ColorChangerScript = transform.root.GetComponent<WorldGrid_Title>().ColorChangerScript;

        Center_Renderer = gameObject.transform.Find("Flower_Center").GetComponent<MeshRenderer>();
        Petals_Renderer = gameObject.transform.Find("Flower_Petals").GetComponent<MeshRenderer>();
        Vine_Renderer = gameObject.transform.Find("Vine").GetComponent<MeshRenderer>();

        CenterMaterial = new MaterialPropertyBlock();
        PetalsMaterial = new MaterialPropertyBlock();
        VineMaterial = new MaterialPropertyBlock();
    }

    void Start()
    {
        //Inform_ColorChanger_OfActivationChange_Instant(false);
    }


    //UTILITIES

    public void Inform_ColorChanger_OfActivationChange_Instant(bool activation)
    {
        ColorChangerScript.ChangeColorActivation_Instant(Center_Renderer, CenterMaterial, c_CENTER, activation);
        ColorChangerScript.ChangeColorActivation_Instant(Petals_Renderer, PetalsMaterial, c_PETALS, activation);
        ColorChangerScript.ChangeColorActivation_Instant(Vine_Renderer, VineMaterial, c_VINE, activation);
    }
}
