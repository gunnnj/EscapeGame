using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class OpenDoorC4 : MonoBehaviour
{
    [SerializeField]public float rotateY = 94f;

    void OnMouseDown()
    {
        OpenDoor();
    }

    private void OpenDoor()
    {
        transform.rotation = Quaternion.Euler(0,rotateY,0);
    }
}
