using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialValidate : MonoBehaviour
{
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
        gameObject.GetComponent<VineValidator>().Validate_AllHoneyCombs();
    }

}
