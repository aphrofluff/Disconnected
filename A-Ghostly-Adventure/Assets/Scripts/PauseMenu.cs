using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool isPaused;

    public void Pause()
    {
        Time.timeScale = 0.0f;
        isPaused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        isPaused = false;
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
