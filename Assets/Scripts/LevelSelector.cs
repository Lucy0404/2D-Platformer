using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public int lvl;

    public void OpenScene()
    {
        SceneManager.LoadScene("Level " + lvl.ToString());
    }
}
