using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StoneNote : MonoBehaviour
{
    public GameObject imgNote;
    public GameObject textNoti;
    public TextMeshProUGUI text;
    void Start()
    {
        imgNote.SetActive(false);
        StartCoroutine(HideTextByTime());
        
    }
    void OnMouseDown()
    {
        imgNote.SetActive(true);
        this.gameObject.SetActive(false);
    }

    IEnumerator HideTextByTime(){
        textNoti.SetActive(true);
        text.text = "Click to collect item";
        yield return new WaitForSeconds(5f);
        text.text = "Tab to see the item";
        yield return new WaitForSeconds(3f);
        text.text = "F to interact";
        textNoti.SetActive(false);
        
    }
}
