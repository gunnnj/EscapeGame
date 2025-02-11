using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCard : MonoBehaviour
{
    public Animator anim;
    public int idCard;

    void OnMouseDown()
    {
        anim.SetBool("IsFlip",true);
        SetIDCard();
    }

    private void SetIDCard()
    {
        ManageChallenger4.instance.SetIndexCard(idCard);
        ManageChallenger4.instance.SetGO(transform.gameObject);
        ManageChallenger4.instance.CheckTwinCard();
    }

    public IEnumerator ResetFlip(){
        yield return new WaitForSeconds(1f);
        anim.SetBool("IsFlip",false);
    }

    public void Flop(){
        StartCoroutine(ResetFlip());
    }

}
