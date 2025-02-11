using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseStoneDoor : MonoBehaviour
{
    public Transform posClose;
    public GameObject audioBg;
    public AudioSource soundCloseDoor;
    void Start()
    {
        audioBg.SetActive(false);
    }
    void Update()
    {
        CloseDoor();
    }

    private void CloseDoor()
    {
        if(!ActiveDoor.Instance.isActiveDoor) return;
        audioBg.SetActive(true);
        transform.position = Vector3.Lerp(transform.position, posClose.position,2f);
    }
}
