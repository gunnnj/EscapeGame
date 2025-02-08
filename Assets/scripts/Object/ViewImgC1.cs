using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewImgC1 : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player")){
            SwitchCamera.instance.PressF();
        }
    }
}
