using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class OpenDoorC4 : MonoBehaviour
{
    public GameObject keyActive;
    public HighlightObject highlight;
    public GameObject textNoti;
    public TextMeshProUGUI text;
    public AudioSource soundOpenDoor;
    public GameObject teleport;
    private bool isNoti = false;
    [SerializeField]public float rotateY = 94f;


    void Update()
    {
        if(highlight.isHighlight && !isNoti){
            textNoti.SetActive(true);
            if(Input.GetKeyDown(KeyCode.F)){
                isNoti = true;
                if(keyActive.activeSelf){
                    OpenDoor();
                }
                else{
                    StartCoroutine(HideTextByTime()); //Hiện thông báo "cần vật phẩm"
                }  
            }
        }
        
        
    }

    IEnumerator HideTextByTime(){
        text.text = "Need item to open";
        yield return new WaitForSeconds(5f);
        textNoti.SetActive(false);
        text.text = "F to open";
    }
    IEnumerator HideText(){
        yield return new WaitForSeconds(5f);
        textNoti.SetActive(false);
    }

    private void OpenDoor()
    {
        transform.rotation = Quaternion.Euler(0,rotateY,0);
        soundOpenDoor.Play();
        teleport.SetActive(true);
    }
}
