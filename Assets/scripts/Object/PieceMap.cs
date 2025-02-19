using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PieceMap : MonoBehaviour
{
    public MapScripttableObject map;
    public int idPiece=0;
    public TextMeshProUGUI text;

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player")){
            if(Input.GetKeyDown(KeyCode.F)){
                transform.gameObject.SetActive(false);
                map.hasPieces[idPiece] = true;
                DisplayMap.Instance.DisplayPieceOfMap();
                ManageChallenger3.instance.MessageMap();
            }
        }
    }
}
