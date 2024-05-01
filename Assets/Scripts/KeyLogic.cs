using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class KeyLogic : MonoBehaviour
{
    [SerializeField] public TMP_Text keyCounterText;
    [SerializeField] public TMP_Text incompleteText;
    [SerializeField] public GameObject victoryUI;


    public int collectedKeys = 0;
    public int totalKeys = 2;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Key")
        {
            collectedKeys++;
            Destroy(collision.gameObject);
            keyCounterText.text = collectedKeys.ToString() + "/" + totalKeys.ToString();
        }
        if (collectedKeys == totalKeys && collision.CompareTag("Door"))
        {
            victoryUI.SetActive(true);              
        }
    }

    public void ShowIncompleteText()
    {
        incompleteText.gameObject.SetActive(true);
        Invoke("HideIncompleteText", 3f);
    }

    public void HideIncompleteText()
    {
        incompleteText.gameObject.SetActive(false);
    }
}
