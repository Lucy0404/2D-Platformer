using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pause_Menu;
    private AudioManager audioManager;


    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void Pause()
    {
        pause_Menu.SetActive(true);
        Time.timeScale = 0f;
        audioManager.PauseMusic();
    }

    public void Resume()
    {
        pause_Menu.SetActive(false);
        Time.timeScale = 1f;
        audioManager.ResumeMusic();
    }

    public void Home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void Restart()
    {       
        SceneManager.LoadScene("Level 1");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Level 2");
    }

}
