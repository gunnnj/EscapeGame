using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeAndDestroy : MonoBehaviour
{
    public float shakeDuration = 1f; // Thời gian rung
    public float shakeMagnitude = 0.05f; // Độ mạnh rung
    public float disappearDelay = 1.0f; // Thời gian trước khi biến mất
    public static ShakeAndDestroy Instance;
    private Vector3 originalPosition;

    void Start()
    {
        Instance = this;
        originalPosition = transform.localPosition; // Lưu vị trí ban đầu
    }

    public void TriggerShakeAndDisappear()
    {
        if(gameObject.activeInHierarchy){
            StartCoroutine(Shake());
        }
        
    }

    private IEnumerator Shake()
    {
        float elapsed = 0.0f;

        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;

            transform.localPosition = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);
            elapsed += Time.deltaTime;

            yield return null; // Đợi một frame
        }

        transform.localPosition = originalPosition; // Quay lại vị trí ban đầu
        yield return new WaitForSeconds(disappearDelay); // Đợi trước khi biến mất

        // Biến mất (có thể sử dụng Destroy hoặc set Active false)
        gameObject.SetActive(false); // Hoặc Destroy(gameObject);
    }
}
