using System.Collections;
using System.Collections.Generic;
using static wg_ADDRESS;
using static gs_GAMESTATUS;
using UnityEngine;

public class HoneyLock : MonoBehaviour
{


    public WorldGrid WorldGridScript;
    private GameObject PieceSlot;
    public GameLevel GameLevelScript;

    private Dictionary<wg_ADDRESS, GameObject> HLPieceDict = new Dictionary<wg_ADDRESS, GameObject>();

    private Vector3 OriginLocation = new Vector3(0.0f, -0.5f, -8.4f);

    Animator _Animator;
    GameObject PieceToAttach;



    private void Awake()
    {
        PieceSlot = this.transform.Find("PieceSlot").gameObject;
        _Animator = gameObject.GetComponent<Animator>();
    }

    public void Attach_ProperPiece()
    {
        //remove and move attached pieces
        Remove_AnyAttachedPiece();

        //get pin location
        Vector3 CurrentLocation = this.transform.position;
        CurrentLocation.y += 0.15f;

        //set new location
        PieceToAttach.transform.position = CurrentLocation;

        //parent to honeylock
        PieceToAttach.transform.parent = PieceSlot.transform;
    }

    public void Remove_AnyAttachedPiece()
    {
        //loop piece slot
        foreach(Transform piece_transform in PieceSlot.transform)
        {
            //set proper scale
            piece_transform.gameObject.GetComponent<Piece>().Change_Scale_ToHoneyJar();

            //unparent from HoneyLock
            piece_transform.parent = null;

            //place below screen
            piece_transform.position = OriginLocation; 
        }
    }

    public void Trigger_Jar_UP()
    {
        //condense
        wg_ADDRESS address = WorldGridScript.HoneyComb_Hover;

        //check
        if (HLPieceDict.ContainsKey(address))
        {
            //store piece to attach
            PieceToAttach = HLPieceDict[address];

            //goto GoingUp state
            _Animator.Play("Base.state_GoingUp");

            //set to stay up until brought down by leaving honeycomb
            _Animator.SetBool("bKeepLockUp", true);
        }
    }

    public void Trigger_Jar_DOWN()
    {
        //set to bring down honey lock
        _Animator.SetBool("bKeepLockUp", false);
    }

    public void AddTo_HoneyLockPieceDictionary(wg_ADDRESS address, GameObject obj)
    {
        HLPieceDict.Add(address, obj);
    }

    public void Release_FromThisHoneyComb(wg_ADDRESS address)
    {
        //safety
        if (!HLPieceDict.ContainsKey(address))
        {
            return;
        }

        //find locked piece
        GameObject LockedPiece = HLPieceDict[address];

        //remove from Honey Locked Piece RefDict
        HLPieceDict.Remove(address);

        //put piece on BeeBox
        LockedPiece.GetComponent<Piece>().FindPlacement_OnBeeBox();

        //find lid
        GameObject Lid = gameObject.transform.Find("Lid").gameObject;

        //unparent
        //Lid.transform.parent = null;

        //Animation anim = Lid.GetComponent<Animation>();

        //anim.Play("anim_HoneyJar_Lid_Release");

    }
}
