using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingStoneSphere : MonoBehaviour
{
    public float rollingSpeed = 4f;
    public float rotationSpeed = 100f;
    public Transform posStop;
    void Update()
    {
        Rolling();   
    }
    public void Rolling(){
        if(!ActiveTrap.Instance.isActive) return;
        if(Vector3.Distance(transform.position,posStop.position)>.3f){
            transform.position = Vector3.MoveTowards(transform.position,transform.position+new Vector3(-1,0,0)*rollingSpeed*Time.deltaTime,1f);
        // Di chuyển quả cầu
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }
}
