using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] public Health playerHealth;
    [SerializeField] public Image totalhealthBar;
    [SerializeField] public Image currenthealthBar;

    public void Start()
    {
        totalhealthBar.fillAmount = playerHealth.currentHealth / 10;
    }

    public void Update()
    {
        currenthealthBar.fillAmount = playerHealth.currentHealth / 10;

    }
}
