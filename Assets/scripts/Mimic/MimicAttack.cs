using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicAttack : MonoBehaviour
{
    public bool isAttack = false;
    public Transform player;
    public static MimicAttack Instance;

    void Start()
    {
        Instance = this;
    }
    void Update()
    {
        if(Vector3.Distance(transform.position, player.position)<5f){
            isAttack = true;
        }
        else{
            isAttack = false;
        }
    }
    public void Attack(){
        if(Vector3.Distance(transform.position, player.position)<2f){
            PlayerController.Instance.Dead();
            Vector3 targetDirection = (transform.position - PlayerController.Instance.particle.transform.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            PlayerController.Instance.particle.transform.rotation = Quaternion.Slerp(PlayerController.Instance.particle.transform.rotation, targetRotation, 10f * Time.deltaTime);
        }
    }
}
