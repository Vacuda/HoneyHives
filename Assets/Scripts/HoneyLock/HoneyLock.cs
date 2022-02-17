using System.Collections;
using System.Collections.Generic;
using static wg_ADDRESS;
using static gs_GAMESTATUS;
using UnityEngine;

public class HoneyLock : MonoBehaviour
{
    private bool ActiveUp = false;
    private bool ActiveDown = false;
    private bool ActiveMovement = false;

    private Vector3 DownLocation;
    private Vector3 UpLocation;

    public WorldGrid WorldGridScript;
    private GameObject PieceSlot;
    public GameLevel GameLevelScript;

    private Dictionary<wg_ADDRESS, GameObject> HLPieceDict = new Dictionary<wg_ADDRESS, GameObject>();


    private void Awake()
    {
        PieceSlot = this.transform.Find("PieceSlot").gameObject;
    }

    void Start()
    {
        UpLocation = gameObject.transform.position;
        DownLocation = UpLocation;
        DownLocation.y -= 0.63f;
        gameObject.transform.position = DownLocation;
    }

    void Update()
    {
        if (ActiveMovement){

            if (ActiveUp){

                Vector3 CurrentLocation = this.transform.position;

                //float NewY = Mathf.Lerp(CurrentLocation.y, UpLocation.y, 4.0f * Time.deltaTime);
                float NewY = CurrentLocation.y + 0.01f;
                CurrentLocation.y = NewY;

                //Debug.Log("up up up");
                this.transform.position = CurrentLocation;

                if(Vector3.Distance(CurrentLocation, UpLocation) < 0.003f){
                    //Debug.Log("got there");
                    this.transform.position = UpLocation;
                    ActiveMovement = false;
                }



            }
            if (ActiveDown){

                gameObject.transform.position = DownLocation;

                ActiveMovement = false;

                //if has child
                if(PieceSlot.transform.childCount > 0)
                {
                    //loop all children
                    foreach (Transform child in PieceSlot.transform){

                        //remove from PieceSlot
                        child.transform.parent = null;

                        //Debug.Log("child removed");
                    }


                    ////remove from slot
                    //PieceSlot.transform.GetChild(0).transform.parent = null;

                    //Debug.Log("child removed");
                }


            }
        }
    }

    public void BringUp_HoneyLock()
    {
        //condense
        wg_ADDRESS address = WorldGridScript.HoveredOver_HoneyComb;

        //check
        if (HLPieceDict.ContainsKey(address)){

            ActiveUp = true;
            ActiveDown = false;
            ActiveMovement = true;

            //condense
            GameObject Piece = HLPieceDict[address];

            Vector3 CurrentLocation = this.transform.position;
            CurrentLocation.y += 0.15f;
            Piece.transform.position = CurrentLocation;
            Piece.transform.parent = this.transform.Find("PieceSlot");
        }



    }

    public void BringDown_HoneyLock()
    {

        if (GameLevelScript.Get_GameStatus() == OUTER){
            ActiveUp = false;
            ActiveDown = true;
            ActiveMovement = true;

        }


    }

    public void AddTo_HoneyLockPieceDictionary(wg_ADDRESS address, GameObject obj)
    {
        HLPieceDict.Add(address, obj);
    }

    public void Release_FromThisHoneyComb(wg_ADDRESS address)
    {
        //find locked piece
        GameObject LockedPiece = HLPieceDict[address];

        //remove from Honey Locked Piece RefDict
        HLPieceDict.Remove(address);

        //put piece on BeeBox
        LockedPiece.GetComponent<Piece>().FindNewHome();

        //find lid
        GameObject Lid = gameObject.transform.Find("Lid").gameObject;

        //unparent
        //Lid.transform.parent = null;

        Animation anim = Lid.GetComponent<Animation>();

        anim.Play("anim_HoneyJar_Lid_Release");
    }
}
