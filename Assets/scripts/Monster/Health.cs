using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float MaxHealth;
    public ChaseState isAttack;
    Animator animator;
    // Transform player;
    // Transform enermy;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "monster"){    
            print("get hit");   
        }
    }
    void OnTriggerStay(Collider other){
        if(other.gameObject.tag == "monster"){
            print("stay");
        }
    }
    void OnTriggerExit(Collider other){
        if(other.gameObject.tag == "monster"){
            print("exit");
        }
    }



}
