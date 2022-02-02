using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static t_TRI;

public class Piece : MonoBehaviour
{
    int Current_TriOffset = 0;
    public fv_FACEVALUE fv_1;
    public fv_FACEVALUE fv_2;
    public fv_FACEVALUE fv_3;
    public fv_FACEVALUE fv_4;
    public fv_FACEVALUE fv_5;
    public fv_FACEVALUE fv_6;

    //@@@@ these should be more globally scoped.
    private float GrabbedPiece_LengthAwayFromCamera = 1.36f;
    private float GrabbedPiece_ScaleRate = 0.17f;
    private float BeeBoxPiece_ScaleRate = 0.16f;
    private float HoneyJarPiece_ScaleRate = 0.12f;
    private Vector3 Scale_GrabbedPiece;
    private Vector3 Scale_BeeBoxPiece;
    private Vector3 Scale_HoneyJarPiece;
    private Vector3 Scale_WorldGridPiece;

    public bool IsMovable;
    public bool IsSpinnable;
    private bool IsInHand = false;
    public Camera MainCamera;
    public PlayerController Controller;
    private PlayerControls Controls;

    bool ActiveSpin = false;
    float TargetSpinTotal = 0.0f;
    float SpinSpeed = 0.03f;

    Transform OffsiteLocation;

    MeshRenderer Rend_0;
    MeshRenderer Rend_1;
    MeshRenderer Rend_2;
    MeshRenderer Rend_3;
    MeshRenderer Rend_4;
    MeshRenderer Rend_5;
    MeshRenderer Rend_6;

    public void Awake()
    {
        Rend_0 = gameObject.GetComponent<MeshRenderer>();
        Rend_1 = gameObject.transform.Find("FaceValue_1").gameObject.GetComponent<MeshRenderer>();
        Rend_2 = gameObject.transform.Find("FaceValue_2").gameObject.GetComponent<MeshRenderer>();
        Rend_3 = gameObject.transform.Find("FaceValue_3").gameObject.GetComponent<MeshRenderer>();
        Rend_4 = gameObject.transform.Find("FaceValue_4").gameObject.GetComponent<MeshRenderer>();
        Rend_5 = gameObject.transform.Find("FaceValue_5").gameObject.GetComponent<MeshRenderer>();
        Rend_6 = gameObject.transform.Find("FaceValue_6").gameObject.GetComponent<MeshRenderer>();

        Scale_GrabbedPiece = new Vector3(GrabbedPiece_ScaleRate, GrabbedPiece_ScaleRate, GrabbedPiece_ScaleRate);
        Scale_BeeBoxPiece = new Vector3(BeeBoxPiece_ScaleRate, BeeBoxPiece_ScaleRate, BeeBoxPiece_ScaleRate);
        Scale_HoneyJarPiece = new Vector3(HoneyJarPiece_ScaleRate, HoneyJarPiece_ScaleRate, HoneyJarPiece_ScaleRate);
        Scale_WorldGridPiece = new Vector3(1.0f, 1.0f, 1.0f);
    }

    //ADMIN

    public void Start()
    {
        Controls = Controller.Get_Controls();
    } 

    public void Update()
    {
        if (IsInHand)
        {
            //get mouse position
            Vector2 MousePosition = Controls.GameLevel_Outer.MousePointer.ReadValue<Vector2>();

            //convert MousePosition to Vector 3
            Vector3 MouseVector3 = new Vector3(MousePosition.x, MousePosition.y, GrabbedPiece_LengthAwayFromCamera);

            //get WorldPosition
            Vector3 WorldPosition = MainCamera.ScreenToWorldPoint(MouseVector3);

            //set to new position
            gameObject.transform.position = WorldPosition;

        }

        if (ActiveSpin)
        {
            //if in hand
            if (IsInHand)
            {
                /* Don't need to unparent and reattach */

                float NewRotateAmount = Mathf.Lerp(0.0f, TargetSpinTotal, SpinSpeed);

                // -60 = -60 - -2

                TargetSpinTotal -= NewRotateAmount;

                //rotate
                gameObject.transform.Rotate(0.0f, 0.0f, NewRotateAmount);

                //loop children
                foreach (Transform child in gameObject.transform)
                {
                    //rotate upwards 
                    child.transform.Rotate(0.0f, 0.0f, NewRotateAmount);
                }
            }
            else
            {
                //store this piece (My Parent's Parent)
                GameObject HoneySlotParent = gameObject.transform.parent.gameObject;

                //detach from parent
                gameObject.transform.parent = null;

                float NewRotateAmount = Mathf.Lerp(0.0f, TargetSpinTotal, SpinSpeed);

                // -60 = -60 - -2

                TargetSpinTotal -= NewRotateAmount;

                //rotate
                gameObject.transform.Rotate(0.0f, 0.0f, NewRotateAmount);

                //loop children
                foreach (Transform child in gameObject.transform)
                {
                    //rotate upwards 
                    child.transform.Rotate(0.0f, 0.0f, NewRotateAmount);
                }

                //re-attach to parent
                gameObject.transform.parent = HoneySlotParent.transform;

            }




        }
    }


//ACTIONS

    public void Rotate_Piece()
    {
        //increment
        Current_TriOffset++;
 
        //possible reset
        if(Current_TriOffset > 5)
        {
            Current_TriOffset = Current_TriOffset - 6;
        }

        //if on WorldGrid
        if(gameObject.transform.parent != null)
        {
            ////store this piece (My Parent's Parent)
            //GameObject HoneySlotParent = gameObject.transform.parent.gameObject;

            ////detach from parent
            //gameObject.transform.parent = null;

            //add to target
            TargetSpinTotal += -60.0f;

            ActiveSpin = true;

            ////rotate
            //gameObject.transform.Rotate(0.0f, 0.0f, -60.0f);

            ////loop children
            //foreach (Transform child in gameObject.transform)
            //{
            //    //rotate upwards 
            //    child.transform.Rotate(0.0f, 0.0f, -60.0f);
            //}

            ////re-attach to parent
            //gameObject.transform.parent = HoneySlotParent.transform;
        }
        //if in hand
        else
        {
            //rotate
            gameObject.transform.Rotate(0.0f, 0.0f, -60.0f);

            //loop children
            foreach (Transform child in gameObject.transform)
            {
                //rotate upwards 
                child.transform.Rotate(0.0f, 0.0f, -60.0f);
            }
        }


       
    }

    public void Pickup_Piece()
    {
        //place in hand
        IsInHand = true;

        //remove parenting
        gameObject.transform.parent = null;

        //scale object down so it can get closer
        gameObject.transform.localScale = Scale_GrabbedPiece;

        //change sorting layer
        Change_SortingLayer_ToFront();
    }

    public void Place_Piece(GameObject LocationObject, bool IsPlacedOnWorldGrid)
    {
        //if on WorldGrid
        if (IsPlacedOnWorldGrid)
        {
            //scale back object to original
            gameObject.transform.localScale = Scale_WorldGridPiece;

            //change sorting layer
            Change_SortingLayer_ToBack();
        }
        else
        {
            //scale back object to original
            gameObject.transform.localScale = Scale_BeeBoxPiece;

            //change sorting layer
            Change_SortingLayer_ToMid();
        }

        //set position to LocationObject
        gameObject.transform.position = LocationObject.transform.position;

        //set piece parent to LocationObject
        gameObject.transform.parent = LocationObject.transform;

        //remove from in hand status
        IsInHand = false;
    }


//UTILITIES

    public fv_FACEVALUE Get_FaceValue_WithOffset(t_TRI tri)
    {
        /* 
        I need the current value in this triangle.
        Take into account the offset and give me the fv_FACEVALUE there.
        */

        //convert tri to IntTri
        int IntTri = Convert_TriToInt(tri);

        //find offseted new int that corresponds to the face value we need due to spinning
        int Offseted_NewInt = PossibleSpinReset(IntTri - Current_TriOffset);

        //switch based off of current offset int 1-6
        switch (Offseted_NewInt)
        {
            case 1:
                return fv_1;
            case 2:
                return fv_2;
            case 3:
                return fv_3;
            case 4:
                return fv_4;
            case 5:
                return fv_5;
            case 6:
                return fv_6;
            default:
                return fv_1;
        }

      



    }

    int PossibleSpinReset(int integer)
    {
        if(integer < 1)
        {
            return integer + 6;
        }
        else
        {
            return integer;
        }
    }

    int Convert_TriToInt(t_TRI tri)
    {
        switch (tri)
        {
            case TRI_1:
                return 1;
            case TRI_2:
                return 2;
            case TRI_3:
                return 3;
            case TRI_4:
                return 4;
            case TRI_5:
                return 5;
            case TRI_6:
                return 6;
            default:
                return 0;
        }
    }

    public void Change_SortingLayer_ToBack()
    {
        Rend_0.sortingOrder = 0;
        Rend_1.sortingOrder = 1;
        Rend_2.sortingOrder = 1;
        Rend_3.sortingOrder = 1;
        Rend_4.sortingOrder = 1;
        Rend_5.sortingOrder = 1;
        Rend_6.sortingOrder = 1;
    }

    public void Change_SortingLayer_ToMid()
    {
        Rend_0.sortingOrder = 80;
        Rend_1.sortingOrder = 81;
        Rend_2.sortingOrder = 81;
        Rend_3.sortingOrder = 81;
        Rend_4.sortingOrder = 81;
        Rend_5.sortingOrder = 81;
        Rend_6.sortingOrder = 81;
    }

    public void Change_SortingLayer_ToFront()
    {
        Rend_0.sortingOrder = 90;
        Rend_1.sortingOrder = 91;
        Rend_2.sortingOrder = 91;
        Rend_3.sortingOrder = 91;
        Rend_4.sortingOrder = 91;
        Rend_5.sortingOrder = 91;
        Rend_6.sortingOrder = 91;
    }

    public void Change_Scale_ToHoneyJar()
    {
        gameObject.transform.localScale = Scale_HoneyJarPiece;
    }


    //t_TRI Convert_IntToTri(int interger)
    //{
    //    switch (interger)
    //    {
    //        case 1:
    //            return TRI_1;
    //        case 2:
    //            return TRI_2;
    //        case 3:
    //            return TRI_3;
    //        case 4:
    //            return TRI_4;
    //        case 5:
    //            return TRI_5;
    //        case 6:
    //            return TRI_6;
    //        default:
    //            return TRI_1;
    //    }
    //}

}
