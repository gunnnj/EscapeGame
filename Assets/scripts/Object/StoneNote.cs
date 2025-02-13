using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneNote : MonoBehaviour
{
    public GameObject imgNote;
    void Start()
    {
        imgNote.SetActive(false);
    }
    void OnMouseDown()
    {
        imgNote.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
