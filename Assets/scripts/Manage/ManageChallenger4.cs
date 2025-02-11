using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageChallenger4 : MonoBehaviour
{
    public static ManageChallenger4 instance;
    public int idFirstCard = -1;
    public int idSecondCard = -1;
    public GameObject go1;
    public GameObject go2;
    public FlipCard[] flipCards;

    void Start()
    {
        instance = this;
    }

    public void SetIndexCard(int idx){
        if(idFirstCard ==-1){
            idFirstCard = idx;
        }
        else{
            idSecondCard = idx;
        }
    }
    public void SetGO(GameObject goCard){
        if(go1==null){
            go1 = goCard;
        }
        else{
            go2 = goCard;
        }
    }
    public void CheckTwinCard(){
        if(idSecondCard == -1) return;
        if(idFirstCard == idSecondCard){
            Debug.Log(true);
            
        }
        else{
            Debug.Log(false);
            StartCoroutine(FlopCard(go1,go2));
        }
        if(idFirstCard>=0 && idSecondCard>=0){
            ResetCard();
        }
        
    }

    private void ResetCard()
    {
        idFirstCard = -1;
        idSecondCard = -1;
        go1 = null;
        go2 = null;
    }
    public IEnumerator FlopCard(GameObject g1, GameObject g2){
        yield return new WaitForSeconds(1f);
        g1.GetComponent<FlipCard>().Flop();
        g2.GetComponent<FlipCard>().Flop();
    }
    
}
