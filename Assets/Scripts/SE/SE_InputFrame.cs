using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE_InputFrame : MonoBehaviour
{
    List<SE_DropdownCluster> clusters = new List<SE_DropdownCluster>();


    void Start()
    {
        //add to clusters
        for (int i = 0; i <= 6; i++)
        {
            clusters.Add(gameObject.transform.GetChild(i).gameObject.GetComponent<SE_DropdownCluster>());
        }

        Debug.Log("cluster count " + clusters.Count);
    }

    public void Reset_AllClusters()
    {
        foreach(var cluster in clusters)
        {
            cluster.Reset_ThisCluster();
        }
    }

}
