using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    public string name = "A";
    public int ID;
    public Transform parentAffterDrag;
    public AudioSource audio;
    void OnEnable()
    {
        DragEvent.dragItem+=SetparrentEndDragItem;
    }
    void OnDisable()
    {
        DragEvent.dragItem-=SetparrentEndDragItem;
    }
    public void OnBeginDrag(PointerEventData eventData){

        parentAffterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
        ManageChallenger3.instance.ChangeStatus(ID);
        
    }
    public void OnDrag(PointerEventData eventData){

        transform.position = Input.mousePosition;
    }
    public void OnEndDrag(PointerEventData eventData){
        audio.Play();
        image.raycastTarget = true;
        
        DetectOut();
        CheckStatus(transform.parent);
        ManageChallenger3.instance.CheckSuccess();
        

    }

    private void DetectOut()
    {
        Transform game = null;
        try
        {
            game = transform.parent;
        }
        catch (System.Exception)
        {
            game = null;
        }
        if(game!=null && !game.gameObject.CompareTag("InventoryItem")){
            transform.SetParent(parentAffterDrag);  
        }
    }

    private void SetparrentEndDragItem(Transform trans, string name)
    {

        if(name == this.name && trans.gameObject.CompareTag("InventoryItem")){
            transform.SetParent(trans);  

        }
           
    }

    private void CheckStatus(Transform t){
        if(t.TryGetComponent(out Note note)){
            note.Check(ID);
        }
    }
}
