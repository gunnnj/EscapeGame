using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageChallenger3 : MonoBehaviour
{
    public List<Note> notes;
    public MoveWall moveWall;
    public AudioSource auMoveWall;
    public static ManageChallenger3 instance;
    void Start()
    {
        instance = this;      
        for(int i =0; i< transform.childCount; i++){
            Note note = transform.GetChild(i).GetComponent<Note>();
            note.id = i;
            notes.Add(note);
        }
    }
    
    public bool CheckSuccess(){
        foreach(Note item in notes){
            if(!item.isRightNote){
                return false;
            }
        }
        moveWall.isStop = true;
        StopSoundStoneDoor();
        return true;
    }

    public void ChangeStatus(int id){
        notes[id].isRightNote = false;
    }
    public void PlaySoundStoneDoor(){
        auMoveWall.Play();
        auMoveWall.loop=true;
    }
    public void StopSoundStoneDoor(){
        auMoveWall.Pause();
    }
}
