using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    public bool isStop;
    public Transform posStop;
    public GameObject sound;
    public float speed = 1f; // Tốc độ di chuyển

    void Start()
    {
        isStop = true;
        sound.SetActive(false);
    }
    void Update()
    {
        if(!ManageChallenger3.instance.CheckSuccess()){

            if(ActiveDoor.Instance.isActiveDoor){
                isStop = false;
            }
            if(Vector3.Distance(transform.position,posStop.position)<1.5f){
                isStop = true;
            }
            Move();

        }
        
        
    }
    public void Move(){
        if(!isStop){
            transform.position += Vector3.forward * speed * Time.deltaTime;
            if(SwitchCameraChallenger2.instance.canvas.activeSelf){
                sound.SetActive(false);
            }
            else{
                sound.SetActive(true);
            }
            
        }
        else{
            sound.SetActive(false);
        }
    }

}

