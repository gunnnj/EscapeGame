using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public SphereCollider rangeAwake;
    public SphereCollider rangeAtack;
    public Animator animator;
    public ParticleSystem fire;
    void Start()
    {
        animator = GetComponent<Animator>();

    }
    
}
