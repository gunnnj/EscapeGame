using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightObject : MonoBehaviour
{
    public GameObject goLight;
    public bool isHighlight = false;

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player")){
            goLight.SetActive(true);
            isHighlight = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player")){
            goLight.SetActive(false);
            isHighlight = false;
        }
    }
}
