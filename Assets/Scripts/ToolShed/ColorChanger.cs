using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static c_ACTCOLOR;

public class ColorChanger : MonoBehaviour
{
    Dictionary<Renderer, ColorChangeJob> JobDict = new Dictionary<Renderer, ColorChangeJob>();
    List<Renderer> RenderRemoveList = new List<Renderer>();

    Color VineColor_GOOD = new Color32(48, 120, 43, 255);
    Color PetalsColor_GOOD = new Color32(231, 231, 231, 255);
    Color CenterColor_GOOD = new Color32(231, 186, 24, 255);
    Color HCColor_GOOD = new Color32(231, 39, 24, 255);

    Color VineColor_BAD = new Color32(55, 72, 54, 255);
    Color CenterColor_BAD = new Color32(99, 99, 99, 255);
    Color PetalsColor_BAD = new Color32(135, 125, 98, 255);
    //Color HCColor_BAD = new Color32(89, 48, 45, 255);
    //Color HCColor_BAD = new Color32(231, 186, 76, 255); //back yellow
    //Color HCColor_BAD = new Color32(181, 154, 58, 255); //darker yellow
    Color HCColor_BAD = new Color32(171, 143, 75, 255); //even darker yellow
    //Color HCColor_BAD = new Color32(24, 24, 24, 255);


    float HoneyComb_Duration = 2.0f;
    float Indicator_Duration = 0.2f;


    void Start()
    {

    }


    void Update()
    {
        //tracker
        //Debug.Log("amount: " + JobDict.Count);

        //perform all color changes
        Perform_AllColorChanges();
    }

    public void ChangeColorActivation_Instant(Renderer rend, MaterialPropertyBlock matblock, c_ACTCOLOR actcolor, bool bToActivated, int mat_index = 0)
    {
        //find color
        Color32 NewColor = GetProperColor(actcolor, bToActivated);

        //change color
        matblock.SetColor("_Color", NewColor);

        //set changes
        rend.SetPropertyBlock(matblock, mat_index);
    }


    public void ChangeColorActivation_Lerp(Renderer rend, MaterialPropertyBlock matblock, c_ACTCOLOR actcolor, bool bToActivated, int mat_index = 0)
    {
        //if job exists for renderer
        if (JobDict.ContainsKey(rend))
        {
            //remove old job
            JobDict.Remove(rend);
        }

        //find proper colors
        Color32 FinishColor = GetProperColor(actcolor, bToActivated);
        Color32 StartColor = GetProperColor(actcolor, !bToActivated);

        //find proper speed
        float duration = GetProperDuration(actcolor);

        //make new job
        ColorChangeJob job = new ColorChangeJob(StartColor, FinishColor, duration, matblock, mat_index);

        //add to dictionary
        JobDict.Add(rend, job);
    }

    void Perform_AllColorChanges()
    {
        foreach (var job in JobDict)
        {
            //condense
            Renderer rend = job.Key;
            MaterialPropertyBlock matblock = job.Value.matblock;
            float duration = job.Value.duration;
            Color color_start = job.Value.color_start;
            Color color_finish = job.Value.color_finish;
            int mat_index = job.Value.mat_index;
            float time_start = job.Value.time_start;

            //get time change
            float timechange = Time.time - time_start;

            //get precentage
            float percentage_complete = timechange / duration;

            //get new color
            Color NewColor = Color.Lerp(color_start, color_finish, percentage_complete);

            //set new color to matblock
            matblock.SetColor("_Color", NewColor);

            //set changes to renderer
            rend.SetPropertyBlock(matblock, mat_index);

            //finish check
            if (percentage_complete >= 1.0f)
            {
                //add to list to remove job
                RenderRemoveList.Add(rend);
            }
        }

        //go through remove list
        foreach (var item in RenderRemoveList)
        {
            //remove job
            JobDict.Remove(item);
        }

        //clear remove list
        RenderRemoveList.Clear();
    }

    //void Perform_AllColorChanges()
    //{
    //    foreach (var job in JobDict)
    //    {
    //        //condense
    //        Renderer rend = job.Key;
    //        MaterialPropertyBlock matblock = job.Value.matblock;
    //        float speed = job.Value.speed;
    //        Color dest_color = job.Value.color;
    //        int mat_index = job.Value.mat_index;

    //        //get current color
    //        Color old_color = matblock.GetColor("_Color");

    //        //get new color
    //        Color new_color = Color.Lerp(old_color, dest_color, speed);

    //        //if done changing
    //        if (Finished_ColorChanging(new_color, dest_color))
    //        {
    //            //set dest_color to matblock
    //            matblock.SetColor("_Color", dest_color);

    //            //add to list to remove job
    //            RenderRemoveList.Add(rend);
    //        }
    //        else
    //        {
    //            //set new color to matblock
    //            matblock.SetColor("_Color", new_color);
    //        }

    //        //set changes to renderer
    //        rend.SetPropertyBlock(matblock, mat_index);
    //    }

    //    //go through remove list
    //    foreach (var item in RenderRemoveList)
    //    {

    //        //remove job
    //        JobDict.Remove(item);
    //    }

    //    //clear remove list
    //    RenderRemoveList.Clear();
    //}

    public void SwapMaterials()
    {

    }

    public void ChangeColor_PieceDeactivation(GameObject piece)
    {



        //new material
        //old material


        Debug.Log("Piece deact");
    }


    //UTILITIES

    private Color32 GetProperColor(c_ACTCOLOR actcolor, bool bToActivated)
    {
        switch (actcolor)
        {
            case c_CENTER: return bToActivated ? CenterColor_GOOD : CenterColor_BAD;
            case c_PETALS: return bToActivated ? PetalsColor_GOOD : PetalsColor_BAD;
            case c_VINE: return bToActivated ? VineColor_GOOD : VineColor_BAD;
            case c_HONEYCOMB: return bToActivated ? HCColor_GOOD : HCColor_BAD;
            default: return CenterColor_GOOD;
        }
    }

    private float GetProperDuration(c_ACTCOLOR actcolor)
    {
        switch (actcolor)
        {
            //case c_CENTER: return IndicatorSpeed;
            //case c_PETALS: return IndicatorSpeed;
            //case c_VINE: return IndicatorSpeed;
            case c_HONEYCOMB: return HoneyComb_Duration;
            default: return Indicator_Duration;
        }
    }



    //private bool Finished_ColorChanging(Color32 new_color, Color32 dest_color)
    //{
    //    int count = 0;

    //    if (Math.Abs(Mathf.RoundToInt(new_color.r * 10000) - Mathf.RoundToInt(dest_color.r * 10000)) < 200){

    //        count++;
    //    }

    //    if (Math.Abs(Mathf.RoundToInt(new_color.g * 10000) - Mathf.RoundToInt(dest_color.g * 10000)) < 200)
    //    {

    //        count++;
    //    }

    //    if (Math.Abs(Mathf.RoundToInt(new_color.b * 10000) - Mathf.RoundToInt(dest_color.b * 10000)) < 200)
    //    {

    //        count++;
    //    }

    //    //Debug.Log("new color : " + new_color);
    //    //Debug.Log("destination color : " + dest_color);
    //    //Debug.Log("--------------------------");


    //    //r .507
    //    //g .334
    //    //b .288

    //    if (count == 3)
    //    {
    //        return true;
    //    }

    //    return false;
    //}
}
