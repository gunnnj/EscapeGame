using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    public GameObject itemStone;
    public GameObject particle;
    public GameObject map;
    public static PlayerController Instance;
    public GameObject key;
    private bool isColliding = false;

    void Start()
    {
        Instance = this;
        animator = GetComponent<Animator>();
        if(particle!=null){
            particle.SetActive(false);
        } 
        if(itemStone!=null){
            itemStone.SetActive(false);
        }
        map.SetActive(false);
        
    }
    
    void Update()
    {
        //Nhấn nút Tab để xem kho đồ
        if(Input.GetKeyDown(KeyCode.Tab)){
            if(itemStone!=null){
                itemStone.SetActive(!itemStone.activeSelf);
            }
        }
        //Nhấn nút F để nhặt key
        if(Input.GetKeyDown(KeyCode.F)){
            if(key!=null){
                key.SetActive(false);
                OpenBoxC3.Instance.haskeyActive = true;
            }   
        }
        //Nhấn nút M để xem map
        if(Input.GetKeyDown(KeyCode.M)){
            if(map!=null){
                map.SetActive(!map.activeSelf);
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Killer")){
            Dead1();
        }
        
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Stone")){
            isColliding = true;
            StartCoroutine(CheckCollisionDuration());
        }
    }
    void OnCollisionExit(Collision other)
    {
        if(other.gameObject.CompareTag("Stone")){
            isColliding = false;
        }
    }

    public void Dead(){
        transform.gameObject.GetComponent<PlayerMovement>().enabled = false;
        animator.SetBool("IsDying2",true);
        StartCoroutine(ActiveParticle());
        GameOverEffect.Instance.GameOver();
    }

    public void Dead1(){
        transform.gameObject.GetComponent<PlayerMovement>().isStop = true;
        animator.SetBool("IsDying",true);
        GameOverEffect.Instance.GameOver();
    }

    IEnumerator ActiveParticle(){
        yield return new WaitForSeconds(2f);
        particle.SetActive(true);
    }

    private IEnumerator CheckCollisionDuration()
    {
        float duration = 0f; // Biến lưu thời gian
        while (isColliding)
        {
            duration += Time.deltaTime; // Cộng dồn thời gian
            if (duration >= 1f) // Kiểm tra xem đã 2 giây chưa
            {

                Dead1();
                yield break; // Kết thúc Coroutine
            }
            yield return null; // Chờ cho frame tiếp theo
        }
    }
}
