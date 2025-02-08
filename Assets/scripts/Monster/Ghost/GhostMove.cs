using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour
{
    private Animator anim;
    public Transform target;
    [SerializeField] private float moveSpeed = 3f;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float Distance = Vector3.Distance(transform.position,target.position);
        if(Distance > 0.1f){
            MoveToTarget();
            anim.SetBool("IsMove", true);
        }else{
            anim.SetBool("IsMove",false);
        }
        
        
    }
    public void MoveToTarget(){
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10f * Time.deltaTime); 

        transform.position = Vector3.MoveTowards(transform.position,target.position,moveSpeed*Time.deltaTime);
    }
}
