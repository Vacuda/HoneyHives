using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static wg_ADDRESS;

public class SE_GameLevel : MonoBehaviour
{
    public SE_WorldGrid WorldGridObject;

    void Start()
    {
        
        //starts the CoRoutine below
        StartCoroutine(DelayedValidation());

    }

    IEnumerator DelayedValidation()
    {
        //pause 
        yield return new WaitForSeconds(1);

        //Verify each HoneyComb
        WorldGridObject.GetComponent<SE_VineValidator>().Validate_ThisHoneyComb();
    }



}
