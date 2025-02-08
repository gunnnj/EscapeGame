using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    public bool isStop = true;
    public float speed = 1f; // Tốc độ di chuyển

    void Update()
    {
        if(!isStop){
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        
    }

   
}
