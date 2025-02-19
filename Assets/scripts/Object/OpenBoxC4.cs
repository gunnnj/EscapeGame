using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OpenBox : MonoBehaviour
{
    [SerializeField]public float rotateX = 94f;
    public HighlightObject highlight;
    public GameObject keyActive;
    public GameObject key;
    public AudioSource soundOpenChest;
    public GameObject pieceMap;
    public GameObject textNoti;
    public TextMeshProUGUI text;
    private bool isNoti = false;

    void Start()
    {
        key.SetActive(false);
        textNoti.SetActive(false);
        pieceMap.SetActive(false);
    }
    void Update()
    {
        if(highlight.isHighlight && !isNoti){
            textNoti.SetActive(true);
            if(Input.GetKeyDown(KeyCode.F)){
                isNoti = true;
                if(keyActive.activeSelf){
                    OpenChest();
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
    }

    private void OpenChest()
    {
        transform.rotation = Quaternion.Euler(rotateX,+90,0);
        soundOpenChest.Play();
        key.SetActive(true);
        pieceMap.SetActive(false);
        
    }
}
