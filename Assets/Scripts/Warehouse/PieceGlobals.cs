using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceGlobals : MonoBehaviour
{

    
    public float GrabbedPiece_LengthAwayFromCamera = 1.36f;
    public Vector3 Scale_GrabbedPiece;
    public Vector3 Scale_BeeBoxPiece;
    public Vector3 Scale_HoneyJarPiece;
    public Vector3 Scale_WorldGridPiece;
    public float SpinSpeed = 0.03f;
    public Vector3 OffsiteLocation;
    public Material DeactivatedMaterial;


    private float GrabbedPiece_ScaleRate = 0.17f;
    private float BeeBoxPiece_ScaleRate = 0.16f;
    private float HoneyJarPiece_ScaleRate = 0.12f;
    private float WorldGridPiece_ScaleRate = 1.0f;

    private void Awake()
    {
        Scale_GrabbedPiece = new Vector3(GrabbedPiece_ScaleRate, GrabbedPiece_ScaleRate, GrabbedPiece_ScaleRate);
        Scale_BeeBoxPiece = new Vector3(BeeBoxPiece_ScaleRate, BeeBoxPiece_ScaleRate, BeeBoxPiece_ScaleRate);
        Scale_HoneyJarPiece = new Vector3(HoneyJarPiece_ScaleRate, HoneyJarPiece_ScaleRate, HoneyJarPiece_ScaleRate);
        Scale_WorldGridPiece = new Vector3(WorldGridPiece_ScaleRate, WorldGridPiece_ScaleRate, WorldGridPiece_ScaleRate);

        OffsiteLocation = new Vector3(0.0199999996f, -0.239999995f, -8.39999962f);
    }
}
