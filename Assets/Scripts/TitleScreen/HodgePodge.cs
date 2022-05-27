using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HodgePodge : MonoBehaviour
{
    private MoverBase HodgePodge_1_Mover;
    private MoverBase HodgePodge_2_Mover;
    private MoverBase HodgePodge_3_Mover;

    private void Start()
    {
        HodgePodge_1_Mover = gameObject.transform.Find("PF_Piece_Title_top").gameObject.GetComponent<MoverBase>();
        HodgePodge_2_Mover = gameObject.transform.Find("PF_Piece_Title_left").gameObject.GetComponent<MoverBase>();
        HodgePodge_3_Mover = gameObject.transform.Find("PF_Piece_Title_right").gameObject.GetComponent<MoverBase>();
    }

    public void Activate_MoveSequence()
    {
        StartCoroutine(Lava());
    }

    IEnumerator Lava()
    {

        HodgePodge_1_Mover.Activate_Move();

        yield return new WaitForSeconds(0.2f);

        HodgePodge_2_Mover.Activate_Move();

        yield return new WaitForSeconds(0.2f);

        HodgePodge_3_Mover.Activate_Move();

        yield return null;
    }
}
