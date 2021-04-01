using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [Header("Components")]
    //Checking if the game is paused.
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject inventoryUI;
    public bool isInventory = false;
    public Pauseable pauseable;

    public void Update()
    {
        ////When you press escape, pause the game. Press it again to resume the game.
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    if (GameIsPaused)
        //    {
        //        Cursor.lockState = CursorLockMode.Locked;
        //        Resume();
        //    }
        //    else
        //    {
        //        Cursor.lockState = CursorLockMode.None;
        //        Pause();
        //    }
        //}
    }

    public void Resume()
    {
        //Resume the game, and reset the time to normal.
        pauseMenuUI.SetActive(!pauseMenuUI.activeInHierarchy);
        GameIsPaused = !GameIsPaused;
        pauseable.TogglePause();
    }
    public void Pause()
    {
        //Time.timeScale is to set how your time is. Set it to 0f to freeze time. 1f to make the speed normal.
        pauseMenuUI.SetActive(!pauseMenuUI.activeInHierarchy);
        GameIsPaused = !GameIsPaused;
        pauseable.TogglePause();
    }
    public void LoadMenu()
    {
        //Resetting the scale back to normal, before loading the main menu.
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        //Quit the game.
        Time.timeScale = 1f;
        Application.Quit();
    }
    public void Restart()
    {
        //Restart the game.
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("LoadingBool", 1);
        SceneManager.LoadScene("Level01");
    }
}