using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTrap : MonoBehaviour
{
    public static ActiveTrap Instance;
    public bool isActive = false;
    public GameObject[] traps;
    void Start()
    {
        Instance = this;
        SetActiveTrap(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            isActive = true;
            SetActiveTrap(true);
        }
    }
    public void SetActiveTrap(bool blean){
        foreach(GameObject trap in traps){
            trap.GetComponent<Animator>().enabled = blean;
        }
    }
}
