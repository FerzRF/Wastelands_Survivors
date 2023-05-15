using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausing : MonoBehaviour
{
    public bool isPaused;
    public Canvas MainUI;
    public Canvas PauseUI;
    void Start()
    {
        Resume();
    }

    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape)) return;
        if (isPaused) Resume();
        else Pause();
    }

    void Pause()
    {
        Time.timeScale = 0f;
        isPaused = true;
        MainUI.enabled = false;
        PauseUI.enabled = true;
    }

    void Resume()
    {
        Time.timeScale = 1f;
        isPaused = false;
        PauseUI.enabled = false;
        MainUI.enabled = true;
    }
}
