using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class OpenBoxC3 : MonoBehaviour
{
    [SerializeField]public float rotateX = 94f;
    public bool haskeyActive = false;
    public AudioSource soundOpenChest;
    public GameObject pieceMap;
    public GameObject textNoti;
    public TextMeshProUGUI text;
    public static OpenBoxC3 Instance;

    void Start()
    {
        Instance = this;
        pieceMap.SetActive(false);
        textNoti.SetActive(false);
    }

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player")){
            if(Input.GetKeyDown(KeyCode.F) && haskeyActive){
                OpenChest();
            }
        }
    }

    private void OpenChest()
    {
        transform.rotation = Quaternion.Euler(rotateX,0,0);
        pieceMap.SetActive(true);

    }
}
