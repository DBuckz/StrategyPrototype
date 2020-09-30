using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public GameObject UpgradeButton;

    public GameObject upgradeMenuUI;

    public static bool upgradeM = false;


    void Start()
    {
        pauseMenuUI.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !upgradeM)

        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

            upgradeMenuUI.SetActive(false);
        }
    }
    public void Upgrade()
    {
        upgradeM = !upgradeM;
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        UpgradeButton.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    

    public void LoadMenu()
    {
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

