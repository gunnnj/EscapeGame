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
        StartCoroutine(ResetFlipFlop());
        SetIDCard();
    }

    private void SetIDCard()
    {
        if(ManageChallenger4.instance.idFirstCard<0)    
        {
            ManageChallenger4.instance.idFirstCard = idCard;
        }      
        else{
            ManageChallenger4.instance.idSecondCard = idCard;
            ManageChallenger4.instance.CheckTwinCard();
        }  
    }

    public IEnumerator ResetFlipFlop(){
        yield return new WaitForSeconds(0.1f);
        anim.SetBool("IsFlip",false);
        anim.SetBool("IsFlop",false);
    }

    public void Flop(){
        anim.SetBool("IsFlop",true);
        StartCoroutine(ResetFlipFlop());
    }
}
