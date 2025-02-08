using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public bool isRightNote = false;
    public int id;



    public void Check(int id)
    {

        isRightNote = id==this.id;  
        
    }
}
