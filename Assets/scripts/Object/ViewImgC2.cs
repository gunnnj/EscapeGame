using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewImgC2 : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player")){
            SwitchCameraChallenger2.instance.PressF();
        }
    }
}
