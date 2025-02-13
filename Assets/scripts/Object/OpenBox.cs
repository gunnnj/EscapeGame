using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OpenBox : MonoBehaviour
{
    [SerializeField]public float rotateX = 94f;
    public HighlightObject highlight;
    public GameObject hasKeyActive;
    public GameObject key;
    public GameObject textNoti;
    public TextMeshProUGUI text;

    void Start()
    {
        key.SetActive(false);
        textNoti.SetActive(false);
    }
    void Update()
    {
        if(highlight.isHighlight){
            textNoti.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.F) && highlight.isHighlight){
            if(hasKeyActive.activeSelf){
                OpenChest();
            }
            else{
                StartCoroutine(HideTextByTime()); //Hiện thông báo "cần vật phẩm"
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
        key.SetActive(true);
        
    }
}
