using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SwitchCamera : MonoBehaviour
{

    public Camera mainCamera;
    public Transform posCamera;

    public static SwitchCamera instance;

    void Start()
    {
        instance = this;
    }

    public void PressF(){
        if(Input.GetKeyDown(KeyCode.F)){
            mainCamera.GetComponent<CinemachineBrain>().enabled = !mainCamera.GetComponent<CinemachineBrain>().isActiveAndEnabled;
            if(!mainCamera.GetComponent<CinemachineBrain>().enabled){
                mainCamera.transform.position = posCamera.position;
                mainCamera.transform.rotation = posCamera.rotation;
            }
            else{
                mainCamera.GetComponent<CinemachineBrain>().enabled = true;
            }
        }
    }
}
