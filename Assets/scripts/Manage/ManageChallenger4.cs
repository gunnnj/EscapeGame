using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageChallenger4 : MonoBehaviour
{
    public static ManageChallenger4 instance;
    public int idFirstCard = -1;
    public int idSecondCard = -1;

    void Start()
    {
        instance = this;
    }

    public void CheckTwinCard(){
        if(idFirstCard>=0 && idSecondCard>=0 && idFirstCard == idSecondCard){
            Debug.Log(true);
            
        }
        else{
            Debug.Log(false);
            ResetID();
        }
        if(idFirstCard>=0 && idSecondCard>=0){
            ResetID();
        }
        
    }

    private void ResetID()
    {
        idFirstCard = -1;
        idSecondCard = -1;
    }
}
