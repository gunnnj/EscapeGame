using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowingFloor : MonoBehaviour
{
    [SerializeField] private int indexFloor = 0;
    // [SerializeField] private int indexTwin = 1;
    [SerializeField] private Material materialGlow;
    private MeshRenderer myMaterial;

    void Start()
    {
        myMaterial = GetComponent<MeshRenderer>();
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player")){
            if(!ManageGlow.instance.boolGlows[indexFloor]){
                StartCoroutine(Glowing());
                ManageGlow.instance.CheckRightIndex(indexFloor);
            }       
        }
    }

    public IEnumerator Glowing(){
        yield return new WaitForSeconds(1f);
        myMaterial.material = materialGlow;
    }

}
