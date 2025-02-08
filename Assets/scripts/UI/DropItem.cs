using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropItem : MonoBehaviour, IDropHandler
{

    public void OnDrop(PointerEventData eventData){
        if(transform.childCount==0){
            GameObject dropped = eventData.pointerDrag;
            
            if (dropped != null)
            {
                string id = dropped.GetComponent<DragItem>().name;
                int ID = dropped.GetComponent<DragItem>().ID;
                DragEvent.dragItem?.Invoke(transform, id);

            }
        }
        
    }

}

public class DragEvent
{
    public delegate void DragItemEvent(Transform trans, string ID);
    public static DragItemEvent dragItem; 

}
