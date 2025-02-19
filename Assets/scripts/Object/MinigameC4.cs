using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MinigameC4 : MonoBehaviour
{
    public HighlightObject highlight;
    public GameObject textNoti;
    public TextMeshProUGUI text;
    private bool isNoti = false;

    void Update()
    {
        if(highlight.isHighlight && !isNoti){
            StartCoroutine(HideTextByTime());
            if(Input.GetKeyDown(KeyCode.F)){
                isNoti = true;
                StartCoroutine(HideText()); 
            }
        }
        
        
    }


    IEnumerator HideTextByTime(){
        textNoti.SetActive(true);
        text.text = "F to play";
        yield return new WaitForSeconds(5f);
        textNoti.SetActive(false);
        text.text = "F to open";
    }

    IEnumerator HideText(){
        textNoti.SetActive(true);
        text.text = "Click card to play";
        yield return new WaitForSeconds(5f);
        textNoti.SetActive(false);
        text.text = "F to open";
    }


}
