using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    FMOD.Studio.Bus master;

    public float masterVolume = .5f;

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject volumeMenuUI;

    private void Awake()
    {
        master = FMODUnity.RuntimeManager.GetBus("bus:/Master");
    }

    void Update()
    {
        master.setVolume(masterVolume);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void MasterVolumeLevel(float newMasterVolume)
    {
        masterVolume = newMasterVolume;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        volumeMenuUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
