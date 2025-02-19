using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ManageGlow : MonoBehaviour
{
    [SerializeField] private Material originMat;
    public MeshRenderer[] materials;
    public bool[] boolGlows;
    public static ManageGlow instance;
    public int currentIndex = -1;
    public int nextIndex = -1;

    public GameObject Open;
    public GameObject Close;
    public GameObject Ghost;
    public GameObject Door;
    public GameObject circle;

    void Start()
    {
        instance = this;
        circle.SetActive(false);
        Open.SetActive(false);
        Close.SetActive(true);
        Door.SetActive(true);
        boolGlows = new bool[materials.Length];
        Ghost.SetActive(false);
        GetStart();
    }

    public void GetStart(){
        for(int i=0; i<boolGlows.Length;i++){
            boolGlows[i] = false;
        }
    }

    public void ResetMaterial(){
        GetStart();
        foreach(var item in materials){
            item.material = originMat;
        }
        
    }

    public void CheckRightIndex(int index){
        if(currentIndex<0){
            currentIndex = index;
            boolGlows[currentIndex] = true;
        }
        else{
            nextIndex = index;
            //cả 2 khác -1
            TickTwin(currentIndex,nextIndex);
        }
    }

    public void TickTwin(int idx1, int idx2){
        int indexAdd = idx1%2==0 ? 1 : -1;
        if(idx2 == idx1+indexAdd){
            SetTrue(idx1,idx2);
            currentIndex = -1;
            nextIndex = -1;
            CheckPass();
        }
        else{
            currentIndex = nextIndex;
            nextIndex = -1;
            ResetMaterial();
            GetStart();
            boolGlows[currentIndex] = true;
        }
    }

    public void SetTrue(int idx1, int idx2){
        boolGlows[idx1] = true;
        boolGlows[idx2] = true;
    }
    public void CheckPass(){
        for(int i =0; i<boolGlows.Length; i++){
            if(!boolGlows[i]) return;
        }

        //Đóng mở hồm vật phẩm    
        Close.SetActive(false);    
        //Mở cửa
        Door.SetActive(false);
        StartCoroutine(DisCircleMagic());     
        Ghost.GetComponent<GhostMove>().enabled = true;
    }

    private IEnumerator DisCircleMagic()
    {
        circle.SetActive(true);
        Ghost.SetActive(true);
        Open.SetActive(true);
        yield return new WaitForSeconds(2f);
        circle.SetActive(false);
    }
}
