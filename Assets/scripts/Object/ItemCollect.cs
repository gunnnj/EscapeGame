using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollect : MonoBehaviour
{
    public bool isCollect = false;
    public HighlightObject highlight;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && highlight.isHighlight){
            Collect();
        }
    }
    
    void Collect()
    {
        this.gameObject.SetActive(false);
        isCollect = true;
        CollectedItem.Instance.DisplayItem();
    }
}
