using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gemLogic : MonoBehaviour
{
    [SerializeField] public TMP_Text MyScoreText;
    public int scoreNum;


    public void Start()
    {
        scoreNum = 0;
        MyScoreText.text = scoreNum.ToString();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Gem")
        {
            scoreNum += 1;
            Destroy(collision.gameObject);
            MyScoreText.text = scoreNum.ToString();
        }
    }
}
