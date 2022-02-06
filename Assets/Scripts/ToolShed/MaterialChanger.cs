using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MaterialChanger : MonoBehaviour
{
    List<MaterialChangeJob> JobList = new List<MaterialChangeJob>();

    public Material Piece_DeactivatedMaterial;
    public Material Piece_UnmovableMat;
    public Material Piece_UnmovableSpinableMat;

    public float DeactivatedDuration = 2.0f;

    // Update is called once per frame
    void Update()
    {
        //tracker
        Debug.Log("amount: " + JobList.Count);

        //perform all color changes
        Perform_AllMaterialChanges();
    }

    private void Perform_AllMaterialChanges()
    {
        //loop list backwards
        for(int i=JobList.Count-1; i>=0; i--){

            //condense
            Renderer rend = JobList[i].rend;
            float time_start = JobList[i].time_start;
            float duration = JobList[i].duration;

            //get time change
            float timechange = Time.time - time_start;

            //get precentage
            float percentage_complete = timechange / duration;

            rend.materials[0].Lerp(Piece_UnmovableMat, Piece_DeactivatedMaterial, percentage_complete);
            rend.materials[1].Lerp(Piece_UnmovableMat, Piece_DeactivatedMaterial, percentage_complete);

            Fade_PieceNumbers(rend);

            //finish check
            if (percentage_complete >= 1.0f)
            {
                //add to list to remove job
                JobList.RemoveAt(i);

            }





        }
    }

    public void MaterialChange_Lerp(GameObject Piece)
    {
        Renderer rend = Piece.GetComponent<Renderer>();


        MaterialChangeJob job = new MaterialChangeJob(rend, DeactivatedDuration);

        JobList.Add(job);
    }

    private void Fade_PieceNumbers(Renderer rend)
    {
        GameObject Piece = rend.gameObject;

        //loop children (6)
        for(int i=0; i<6; i++)
        {
            TextMeshPro lava = Piece.transform.GetChild(i).GetComponent<TextMeshPro>();

            lava.alpha = 0.0f;
        }
    }
}
