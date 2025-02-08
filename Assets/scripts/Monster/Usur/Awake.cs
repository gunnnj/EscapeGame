using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Awake : MonoBehaviour
{
    public GameObject dragon;
    public Animator animator;
    private SphereCollider rangeAwake;
    void Start()
    {
        rangeAwake = GetComponent<SphereCollider>();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            RotationPlayer(other.transform);
            animator.SetBool("IsScream",true);
        }
    }
    public void RotationPlayer(Transform trans){
        Vector3 dir = trans.position-dragon.transform.position;
        Quaternion target = Quaternion.LookRotation(dir);
        dragon.transform.rotation = Quaternion.Slerp(dragon.transform.rotation, target, 20f * Time.deltaTime);
    }
}
