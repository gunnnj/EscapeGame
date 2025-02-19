using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    public GameObject goHiden;
    public GameObject goDis;
    public Image image;
    public PlayerMovement playerMove;
    public static ManagerScene Instance;

    void Start()
    {
        if(goDis!=null){
            goDis.SetActive(false);
        }
        
    }
    public void LoadMenu(){
        SceneManager.LoadSceneAsync(0);
    }
    public void StartGame(){
        goHiden.SetActive(false);
        goDis.SetActive(true);
        StartCoroutine(LoadScene(1));
    }
    public void LoadSceneName(string nameScene){
        if(playerMove!=null){
            playerMove.isStop = true;
        }
        SceneManager.LoadScene(2);
    }

    public IEnumerator LoadScene(int ind){
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(ind);

        while (!asyncLoad.isDone)
        {
            float progressAsyn = Mathf.Clamp01(asyncLoad.progress/0.9f);
            image.fillAmount = progressAsyn;
            yield return null; // Chờ cho đến frame tiếp theo
        }
        yield return null;
    }

     public void Quit(){
        Application.Quit();
    }
}
