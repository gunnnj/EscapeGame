using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackDragon : MonoBehaviour
{
    Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (animator.GetBool("isAttacking"))
        {
            if (other.CompareTag("Player"))
            {
                Destroy(other);
            }
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
