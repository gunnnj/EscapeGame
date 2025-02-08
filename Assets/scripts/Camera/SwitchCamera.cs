using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SwitchCamera : MonoBehaviour
{
    // public Camera mainCam;  // Camera ảo
    // public Camera cameraView;        // Camera 1

    // void Start()
    // {
    //     // Bắt đầu với camera ảo
    //     mainCam.enabled = true;
    //     cameraView.enabled = false;
    // }

    // void Update()
    // {
    //     // Kiểm tra nếu phím F được nhấn
    //     if (Input.GetKeyDown(KeyCode.F))
    //     {
    //         CameraSwitch();
    //     }
    // }

    // void CameraSwitch()
    // {
    //     // Chuyển đổi giữa các camera
    //     mainCam.enabled = !mainCam.enabled;
    //     cameraView.enabled = !cameraView.enabled;
    // }

    // void OnTriggerStay(Collider other)
    // {
    //     if(other.CompareTag("Player")){
    //         if (Input.GetKeyDown(KeyCode.F))
    //         {
    //             CameraSwitch();
    //         }
    //     }
    // }


    public Camera mainCamera;
    public Transform posCamera;

    public static SwitchCamera instance;

    void Start()
    {
        instance = this;
    }

    // void OnTriggerEnter(Collider other)
    // {
    //     if(other.CompareTag("Player")){
    //         PressF();
    //     }
    // }

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
