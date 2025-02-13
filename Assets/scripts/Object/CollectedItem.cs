using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class CollectedItem : MonoBehaviour
{
    public GameObject[] items;
    public GameObject[] itemsUI;
    public static CollectedItem Instance;
    void Start()
    {
        Instance = this;
        HideItemUI();
    }

    public void DisplayItem()
    {
        for(int i =0; i<items.Count(); i++){
            if(items[i].GetComponent<ItemCollect>().isCollect){
                itemsUI[i].SetActive(true);
            }
        }
    }

    private void HideItemUI()
    {
        foreach(GameObject item in itemsUI){
            item.SetActive(false);
        }
    }
}
