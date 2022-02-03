using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.EventSystems;
using static wg_ADDRESS;

public class HoneyComb : MonoBehaviour
{
    public wg_ADDRESS HoneyComb_Address;
    private WorldGrid WorldGridScript;
    private bool bIsFinaled = false;

    private MaterialPropertyBlock HC_WireframeMaterial;
    private Renderer HC_WireFrameRenderer;

    //this Dict uses truncated addresses for ease of programing
    public Dictionary<wg_ADDRESS, GameObject> HoneySlotRefDict = new Dictionary<wg_ADDRESS, GameObject>();

    public wg_ADDRESS[] HoneySlots;

    private void Awake()
    {
        Build_LocalDictionaryOfHoneySlotObjects();
    }
    private void Start()
    {
        HC_WireFrameRenderer = gameObject.GetComponent<MeshRenderer>();
        HC_WireframeMaterial = new MaterialPropertyBlock();

        HC_WireFrameRenderer.GetPropertyBlock(HC_WireframeMaterial);
        HC_WireFrameRenderer.SetPropertyBlock(HC_WireframeMaterial, 1);
    }

    private void Build_LocalDictionaryOfHoneySlotObjects()
    {
        HoneySlotRefDict.Add(AA, gameObject.transform.Find("HoneySlot_AA").gameObject);
        HoneySlotRefDict.Add(BB, gameObject.transform.Find("HoneySlot_BB").gameObject);
        HoneySlotRefDict.Add(CC, gameObject.transform.Find("HoneySlot_CC").gameObject);
        HoneySlotRefDict.Add(DD, gameObject.transform.Find("HoneySlot_DD").gameObject);
        HoneySlotRefDict.Add(EE, gameObject.transform.Find("HoneySlot_EE").gameObject);
        HoneySlotRefDict.Add(FF, gameObject.transform.Find("HoneySlot_FF").gameObject);
        HoneySlotRefDict.Add(GG, gameObject.transform.Find("HoneySlot_GG").gameObject);
    }

    public void Finalize_ThisHoneyComb()
    {
        bIsFinaled = true;
        Debug.Log("This honeycomb is finalized: " + HoneyComb_Address);

        Finalize_HC_WireframeMaterial();



    }

    public bool IsHoneyComb_Finalized()
    {
        return bIsFinaled;
    }

    private void Finalize_HC_WireframeMaterial()
    {
        HC_WireFrameRenderer.GetPropertyBlock(HC_WireframeMaterial);

        //get new color
        Color NewColor = Color.green;

        ////store new color
        //Current_PetalColor = NewColor;

        //set new color
        HC_WireframeMaterial.SetColor("_Color", NewColor);

        HC_WireFrameRenderer.SetPropertyBlock(HC_WireframeMaterial, 1);
    }
}
