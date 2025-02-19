using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public GameObject partical;
    public int indexScene = 0;
    public GameObject circleMagic;
    public AudioSource aoundTele;
    void Start()
    {
        circleMagic.SetActive(false);
        partical.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            partical.SetActive(true);
            StartCoroutine(LoadScene(indexScene));
        }
    }
    private IEnumerator LoadScene(int index){
        aoundTele.Play();
        if(circleMagic!=null){
            circleMagic.SetActive(true);
        }
        yield return new WaitForSeconds(2f);
        SceneManager.LoadSceneAsync(index);
    }
}
