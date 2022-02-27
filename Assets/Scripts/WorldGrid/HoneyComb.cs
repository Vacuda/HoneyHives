using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.EventSystems;
using static wg_ADDRESS;
using static c_ACTCOLOR;

public class HoneyComb : MonoBehaviour
{
    private HoneyLock HoneyLockScript;






    public wg_ADDRESS HoneyComb_Address;
    //private WorldGrid WorldGridScript;
    private bool bIsFinalized = false;
    private ColorChanger ColorChangerScript;

    private MaterialPropertyBlock HC_WireframeMaterial;
    private MaterialPropertyBlock HC_BackgroundMaterial;
    private Renderer HC_WireFrameRenderer;
    private Renderer HC_BackgroundRenderer;

    //this Dict uses truncated addresses for ease of programing
    public Dictionary<wg_ADDRESS, GameObject> HoneySlotRefDict = new Dictionary<wg_ADDRESS, GameObject>();

    public wg_ADDRESS[] HoneySlots;

    private void Awake()
    {
        Build_LocalDictionaryOfHoneySlotObjects();

        ColorChangerScript = gameObject.transform.parent.GetComponent<WorldGrid>().ColorChangerScript;

        HC_WireFrameRenderer = gameObject.GetComponent<MeshRenderer>();
        HC_BackgroundRenderer = gameObject.transform.Find("BG").GetComponent<MeshRenderer>();
        HC_WireframeMaterial = new MaterialPropertyBlock();
        HC_BackgroundMaterial = new MaterialPropertyBlock();

        HoneyLockScript = gameObject.transform.parent.GetComponent<WorldGrid>().HoneyLockObject.GetComponent<HoneyLock>();


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
        bIsFinalized = true;
        Debug.Log("This honeycomb is finalized: " + HoneyComb_Address);

        Finalize_CopyAndPlaceRelevantPieces();

        Finalize_HC_BackgroundMaterial();
        Finalize_HC_WireframeMaterial();
        Finalize_DeactivatedPieceMaterials();
        Finalize_FreeHoneyLockedPiece();
    }

    public bool IsHoneyComb_Finalized()
    {
        return bIsFinalized;
    }

    private void Finalize_HC_WireframeMaterial()
    {
        ColorChangerScript.ChangeColorActivation_Lerp(HC_WireFrameRenderer, HC_WireframeMaterial, c_HC_WIRE, false);

    }

    private void Finalize_HC_BackgroundMaterial()
    {
        ColorChangerScript.ChangeColorActivation_Lerp(HC_BackgroundRenderer, HC_BackgroundMaterial, c_HC_BACK, false);
    }

    private void Inform_ColorChanger_OfActivationChange_Instant(bool activation)
    {

        ColorChangerScript.ChangeColorActivation_Instant(HC_WireFrameRenderer, HC_WireframeMaterial, c_HC_WIRE, activation);
        ColorChangerScript.ChangeColorActivation_Instant(HC_BackgroundRenderer, HC_BackgroundMaterial, c_HC_BACK, activation);
    }

    private void Finalize_CopyAndPlaceRelevantPieces()
    {
        //loop honey slots
        foreach (var honeyslot in HoneySlotRefDict)
        {

            //condense
            GameObject slot = honeyslot.Value;

            //if piece in slot
            if (slot.transform.childCount == 3)
            {

                //condense
                GameObject OriginalPiece = slot.transform.GetChild(2).gameObject;
                Piece PieceScript = OriginalPiece.GetComponent<Piece>();

                //if (PieceScript.ActiveSpin)
                //{
                //    Debug.Log(PieceScript.TargetSpinTotal);
                //}

                //if piece is unmovable
                if (PieceScript.IsMovable)
                {

                    //duplicate piece
                    GameObject NewPiece = Instantiate(OriginalPiece);

                    //find renderer
                    MeshRenderer rend = NewPiece.GetComponent<MeshRenderer>();

                    //@@@@ I don't know why this works.  It copies the old material, making a new one.
                    //@@@@ but never sets the new one back on this new object?

                    //get material
                    Material blop = new Material(rend.material);

                    NewPiece.GetComponent<Piece>().SetSettledRotation();


                    //set same rotation
                    //NewPiece.transform.rotation = this.transform.rotation;

                    //find new home for piece
                    NewPiece.GetComponent<Piece>().FindPlacement_OnBeeBox();

                }
            }
        }
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

                //deactivate
                PieceScript.Deactivate_Piece();
            }
        }
    }

    private void Finalize_FreeHoneyLockedPiece()
    {
        //find 
        HoneyLockScript.Release_FromThisHoneyComb(HoneyComb_Address);
    }

}




