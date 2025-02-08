using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class SwitchCameraChallenger2 : MonoBehaviour
{
    public Camera mainCamera;
    public Transform posCamera;
    public GameObject canvas;
    public static SwitchCameraChallenger2 instance;

    void Start()
    {
        instance = this;
        if(canvas!=null){
            canvas.SetActive(false);
        }   
    }

    // void OnTriggerEnter(Collider other)
    // {
    //     if(other.CompareTag("Player")){
    //         PressF();
    //     }
    // }

    public void PressF(){
        if(Input.GetKeyDown(KeyCode.F)){
            if(canvas!=null){
                canvas.SetActive(!canvas.activeSelf);
            }
            if(canvas.activeSelf){
                if(ManageChallenger3.instance!=null){ManageChallenger3.instance.StopSoundStoneDoor();}
            }
            else{
                if(ManageChallenger3.instance!=null){ManageChallenger3.instance.PlaySoundStoneDoor();}
            }
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
