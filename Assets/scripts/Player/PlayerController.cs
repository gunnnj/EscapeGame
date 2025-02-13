using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    public GameObject itemStone;
    public GameObject particle;
    public static PlayerController Instance;
    void Start()
    {
        Instance = this;
        particle.SetActive(false);
        animator = GetComponent<Animator>();
        if(itemStone!=null){
            itemStone.SetActive(false);
        }
        
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)){
            if(itemStone!=null){
                itemStone.SetActive(!itemStone.activeSelf);
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Killer")){
            animator.SetBool("IsDying",true);
        }
    }

    public void Dead(){
        transform.gameObject.GetComponent<PlayerMovement>().enabled = false;
        animator.SetBool("IsDying2",true);
        StartCoroutine(ActiveParticle());
    }

    IEnumerator ActiveParticle(){
        yield return new WaitForSeconds(2f);
        particle.SetActive(true);
    }
}
