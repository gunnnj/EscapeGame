using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePlayerFromCam : MonoBehaviour
{
    public GameObject player;
    private Camera cam;
    public GameObject canvas;
    private int playerLayer;
    void Start()
    {
        cam = Camera.main;
        playerLayer = LayerMask.NameToLayer("Player");
    }
    void Update()
    {
        if(canvas.activeSelf){
            cam.cullingMask &= ~(1 << playerLayer);
            player.GetComponent<PlayerMovement>().enabled = false;
        }else{
            cam.cullingMask |= (1 << playerLayer);
            player.GetComponent<PlayerMovement>().enabled = true;
        }
    }
}
