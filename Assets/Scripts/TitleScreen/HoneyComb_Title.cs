using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static wg_ADDRESS;
using static c_ACTCOLOR;

public class HoneyComb_Title : MonoBehaviour
{
    private ColorChanger ColorChangerScript;
    private MaterialPropertyBlock HC_WireframeMaterial;
    private MaterialPropertyBlock HC_BackgroundMaterial;
    private Renderer HC_WireFrameRenderer;
    private Renderer HC_BackgroundRenderer;

    //this Dict uses truncated addresses for ease of programing
    public Dictionary<wg_ADDRESS, GameObject> HoneySlotRefDict = new Dictionary<wg_ADDRESS, GameObject>();



    private void Awake()
    {
        Build_LocalDictionaryOfHoneySlotObjects();

        ColorChangerScript = gameObject.transform.parent.GetComponent<WorldGrid_Title>().ColorChangerScript;

        HC_WireFrameRenderer = gameObject.GetComponent<MeshRenderer>();
        HC_BackgroundRenderer = gameObject.transform.Find("BG").GetComponent<MeshRenderer>();
        HC_WireframeMaterial = new MaterialPropertyBlock();
        HC_BackgroundMaterial = new MaterialPropertyBlock();
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
        Finalize_HC_BackgroundMaterial();
        Finalize_HC_WireframeMaterial();
        Finalize_DeactivatedPieceMaterials();
    }

    private void Finalize_HC_WireframeMaterial()
    {
        ColorChangerScript.ChangeColorActivation_Lerp(HC_WireFrameRenderer, HC_WireframeMaterial, c_HC_WIRE, false);

    }

    private void Finalize_HC_BackgroundMaterial()
    {
        ColorChangerScript.ChangeColorActivation_Lerp(HC_BackgroundRenderer, HC_BackgroundMaterial, c_HC_BACK, false);
    }

    private void Finalize_DeactivatedPieceMaterials()
    {
        //loop honey slots
        foreach (var honeyslot in HoneySlotRefDict)
        {

            //condense
            GameObject slot = honeyslot.Value;

            //if piece in slot
            if (slot.transform.childCount == 2)
            {

                //condense
                Piece_Title PieceScript = slot.transform.GetChild(1).gameObject.GetComponent<Piece_Title>();

                //deactivate
                PieceScript.Deactivate_Piece();
            }
        }
    }
}
