using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Transform mainCamera;
    public InputActionReference move;
    public InputActionReference run;
    public InputActionReference jump;
    public InputActionReference turnOnLight;
    public float currentSpeed;
    private Animator animator;
    private Vector2 _moveDirection;
    private float runSpeed = 6f;
    private float walkSpeed = 2f;
    private float rotationSpeed = 10f;
    private bool IsMove = false;
    public GameObject light;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentSpeed = 0f;
    }

    void Update()
    {
        HandleCurrentSpeed();
        TurnOnLight();
        
    }
    void FixedUpdate()
    {
        // if(!IsMove){
        //     Jump();
        // }
        // else{
        //     MoveAndRotation();
        // }
        MoveAndRotation();
        // Jump();
        
    }
    public void TurnOnLight(){
        if(turnOnLight.action.IsPressed()){
            light.SetActive(!light.activeSelf);
        }
    }

    public void Jump(){
        if(jump.action.IsPressed()){
            IsMove = false;
            animator.SetBool("IsJump",true);
            StartCoroutine(ResetJump());
        }
    }

    public IEnumerator ResetJump(){
        yield return new WaitForSeconds(.5f);
        animator.SetBool("IsJump",false);
        IsMove = true;
    }

    public void HandleCurrentSpeed(){
        _moveDirection = move.action.ReadValue<Vector2>();

        if(_moveDirection.magnitude!=0){ 
           
            if(run.action.IsPressed()){
                currentSpeed = Mathf.Min(currentSpeed+4f*Time.deltaTime,runSpeed);
            }
            else{
                currentSpeed = walkSpeed;
            }
        }
        else{
            currentSpeed = 0f;
        }
        // Set tham số cho Animator
        animator.SetFloat("Move", currentSpeed);
    }

    public void MoveAndRotation(){
        Vector3 cameraForward = mainCamera.forward;
        cameraForward.y = 0; // Keep y = 0 for ground movement
        cameraForward.Normalize(); // Normalize the vector
        Vector3 cameraRight = mainCamera.right;
        cameraRight.y = 0; // Keep y = 0

        // Calculate movement direction
        Vector3 moveDirection = (cameraForward * _moveDirection.y + cameraRight * _moveDirection.x).normalized;

        rb.velocity = new Vector3(moveDirection.x * currentSpeed, rb.velocity.y, moveDirection.z * currentSpeed);
        
        if (moveDirection.magnitude > 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }
    }
    
}
