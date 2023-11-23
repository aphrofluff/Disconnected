using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool playerCanFlip = true;

    public void Pause()
    {
        playerCanFlip = false;
        Time.timeScale = 0.0f;
    }

    public void Resume()
    {
        playerCanFlip = true;
        Time.timeScale = 1.0f;
    }
}
