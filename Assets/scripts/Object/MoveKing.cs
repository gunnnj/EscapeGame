using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveKing : MonoBehaviour
{
    private Vector3 collisionDirection;
    [SerializeField] private float distanceMove = 1.45f;
    void OnCollisionStay(Collision other)
    {
        if(other.gameObject.CompareTag("Player")){
            Vector3 direction = other.transform.position - transform.position;
            collisionDirection = direction.normalized;
            MoveToDirection();
        }
    }

    public void MoveToDirection(){
        if(Input.GetKeyDown(KeyCode.F)){
            if(collisionDirection.x<0 ){
                if(collisionDirection.x > collisionDirection.z){
                    MoveRight();

                }
                else{
                    MoveDown();
                }
            }
            if(collisionDirection.x > 0 ){
                if(collisionDirection.x > collisionDirection.z){
                    MoveUp();
                }
                else{
                    MoveLeft();
                }
            }
            
        }
        
    }

    public void MoveDown(){
        transform.position = transform.position + new Vector3(distanceMove,0f,0f);
        // transform.position = Vector3.MoveTowards(transform.position,transform.position + new Vector3(distanceMove,0f,0f),10f*Time.deltaTime);
    }
    public void MoveUp(){
        transform.position = transform.position + new Vector3(-distanceMove,0f,0f);
    }

    public void MoveRight(){
        transform.position = transform.position + new Vector3(0,0f,distanceMove);
    }
    public void MoveLeft(){
        transform.position = transform.position + new Vector3(0,0f,-distanceMove);
    }
}
