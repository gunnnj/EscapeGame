using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDoor : MonoBehaviour
{
    public bool isActiveDoor = false;
    public static ActiveDoor Instance;
    void Start()
    {
        Instance = this;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            isActiveDoor = true;
        }
    }
}
