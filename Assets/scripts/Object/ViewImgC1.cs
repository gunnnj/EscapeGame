using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ViewImgC1 : MonoBehaviour
{
    public TextMeshProUGUI text;
    void Start()
    {
        if(text!=null){
            text.gameObject.SetActive(false);
        }     
    }
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player")){
            SwitchCamera.instance.PressF();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            if(text!=null){
                StartCoroutine(HideTextByTime());  
            }
        }
    }
    IEnumerator HideTextByTime(){
        text.text = "F to interact";
        text.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        text.gameObject.SetActive(false);
    }
}
