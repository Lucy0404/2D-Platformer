using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public float startingHealth;
    [SerializeField] public GameObject gameOverUI;
    public float currentHealth;
    public Animator anim;
    public bool dead;
    private AudioManager audioManager;


    public void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponentInChildren<Animator>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if(currentHealth > 0) 
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            if(!dead)
            {
                anim.SetTrigger("die");
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;
                ShowGameOverUI();
            }
        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    private void ShowGameOverUI()
    {
        audioManager.PauseMusic();
        gameOverUI.SetActive(true); 
    }
}
