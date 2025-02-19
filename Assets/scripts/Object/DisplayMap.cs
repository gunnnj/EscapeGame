using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DisplayMap : MonoBehaviour
{
    public MapScripttableObject map;
    public GameObject[] pieceMaps;
    public static DisplayMap Instance;

    void Start()
    {
        Instance = this;
        HidePieceMap();
        DisplayPieceOfMap();
    }

    private void HidePieceMap()
    {
        foreach(var item in pieceMaps){
            item.SetActive(false);
        }
    }

    public void DisplayPieceOfMap(){
        for(int i =0; i<map.hasPieces.Count(); i++){
            if(map.hasPieces[i]){
                pieceMaps[i].SetActive(true);
            }
        }
    }
}
