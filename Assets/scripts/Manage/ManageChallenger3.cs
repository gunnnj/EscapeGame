using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;

public class ManageChallenger3 : MonoBehaviour
{
    public Camera mainCamera;
    public List<Note> notes;
    public MoveWall Wall;
    public GameObject wallRoad;
    public GameObject key;
    public GameObject canvasNote;
    public TextMeshProUGUI text;

    public static ManageChallenger3 instance;
    void Awake()
    {
        
    }
    void Start()
    {
        instance = this;      
        key.SetActive(false);
        for(int i =0; i< canvasNote.transform.childCount; i++){
            Note note = canvasNote.transform.GetChild(i).GetComponent<Note>();
            note.id = i;
            notes.Add(note);
        }
    }
    
    public bool CheckSuccess(){
        foreach(Note item in notes){
            if(!item.isRightNote){
                Debug.Log(false);
                return false;
            }
        }
        Debug.Log(true);
        return true;
    }

    public void ResetCam()
    {
        wallRoad.SetActive(false);
        key.SetActive(true);
        Wall.isStop = true;
        Debug.Log("ResetCam");
        mainCamera.GetComponent<CinemachineBrain>().enabled = true;
        canvasNote.SetActive(false);
    }

    public void ChangeStatus(int id){
        notes[id].isRightNote = false;
    }

    public void MessageMap(){
        StartCoroutine(NotiMap());
    }

    public IEnumerator NotiMap(){
        text.text = "M to see map";
        text.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        text.gameObject.SetActive(false);
    }
    
}
