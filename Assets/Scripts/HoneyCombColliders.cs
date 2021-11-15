using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static wg_HONEYCOMB;

public class HoneyCombColliders : MonoBehaviour
{
    public wg_HONEYCOMB HoneyComb;
    private WorldGrid WorldGridScript;

    private void Start()
    {
        WorldGridScript = GetComponentInParent<WorldGrid>();
    }

    private void OnMouseOver()
    {
        WorldGridScript.Display(HoneyComb);
    }
}
