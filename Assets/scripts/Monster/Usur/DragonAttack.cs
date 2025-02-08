using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAttack : MonoBehaviour
{
    public GameObject dragon;
    public Animator animator;
    public ParticleSystem fire;
    private SphereCollider rangeAttack;
    void Start()
    {
        rangeAttack = GetComponent<SphereCollider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            RotationPlayer(other.transform);

            animator.SetBool("IsAttack",true);
            // animator.SetTrigger("IsAttack");
            fire.Play();
        }
    }

    public void RotationPlayer(Transform trans){
        Vector3 dir = trans.position-dragon.transform.position;
        Quaternion target = Quaternion.LookRotation(dir);
        dragon.transform.rotation = Quaternion.Slerp(dragon.transform.rotation, target, 20f * Time.deltaTime);
    }
}
