using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverEffect : MonoBehaviour
{
    public Image darkOverlay;
    public float fadeDuration = 1f;
    public static GameOverEffect Instance;

    void Start()
    {
        Instance = this;
    }
    public void GameOver() {
        darkOverlay.gameObject.SetActive(true);
        StartCoroutine(FadeToBlack());
    }

    private IEnumerator FadeToBlack() {
        float timeElapsed = 0f;
        Color color = darkOverlay.color;

        while (timeElapsed < fadeDuration) {
            timeElapsed += Time.deltaTime;
            color.a = Mathf.Clamp01(timeElapsed / fadeDuration);
            darkOverlay.color = color;
            yield return null;
        }

        SceneManager.LoadSceneAsync(0);
    }
}
