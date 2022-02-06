using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.EventSystems;
using static wg_ADDRESS;
using static c_ACTCOLOR;

public class HoneyComb : MonoBehaviour
{
    public wg_ADDRESS HoneyComb_Address;
    //private WorldGrid WorldGridScript;
    private bool bIsFinaled = false;
    private ColorChanger ColorChangerScript;

    private MaterialPropertyBlock HC_WireframeMaterial;
    private Renderer HC_WireFrameRenderer;

    //this Dict uses truncated addresses for ease of programing
    public Dictionary<wg_ADDRESS, GameObject> HoneySlotRefDict = new Dictionary<wg_ADDRESS, GameObject>();

    public wg_ADDRESS[] HoneySlots;

    private void Awake()
    {
        Build_LocalDictionaryOfHoneySlotObjects();

        ColorChangerScript = gameObject.transform.parent.GetComponent<WorldGrid>().ColorChangerScript;

        HC_WireFrameRenderer = gameObject.GetComponent<MeshRenderer>();
        HC_WireframeMaterial = new MaterialPropertyBlock();
    }
    private void Start()
    {
        Inform_ColorChanger_OfActivationChange_Instant(true);
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
        Finalize_DeactivatedPieceMaterials();


    }

    public bool IsHoneyComb_Finalized()
    {
        return bIsFinaled;
    }

    private void Finalize_HC_WireframeMaterial()
    {
        ColorChangerScript.ChangeColorActivation_Lerp(HC_WireFrameRenderer, HC_WireframeMaterial, c_HONEYCOMB, false, 1);

    }

    private void Inform_ColorChanger_OfActivationChange_Instant(bool activation)
    {
        ColorChangerScript.ChangeColorActivation_Instant(HC_WireFrameRenderer, HC_WireframeMaterial, c_HONEYCOMB, activation, 1);
    }

    private void Finalize_DeactivatedPieceMaterials()
    {
        //loop honey slots
        foreach(var honeyslot in HoneySlotRefDict){

            //condense
            GameObject slot = honeyslot.Value;

            //if piece in slot
            if(slot.transform.childCount == 3){

                //condense
                Piece PieceScript = slot.transform.GetChild(2).gameObject.GetComponent<Piece>();

                //if piece is unmovable
                if (!PieceScript.IsMovable){

                    //deactivate
                    PieceScript.Deactivate_Piece();
                }
            }

        }
    }
}
