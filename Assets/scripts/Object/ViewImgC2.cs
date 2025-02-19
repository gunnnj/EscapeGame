using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ViewImgC2 : MonoBehaviour
{
    public TextMeshProUGUI text;
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player")){
            SwitchCameraChallenger2.instance.PressF();
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
        text.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        text.gameObject.SetActive(false);
    }
}
