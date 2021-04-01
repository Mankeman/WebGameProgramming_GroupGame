using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //To modify UI through script, you need a reference. Added a header to make it pretty
    [Header("UI Settings")]
    public GameObject gameOverUI;
    public GameObject gameWonUI;
    public GameObject mainAudio;
    public GameObject audioLose;
    public Text Kills;
    public Text timerText;
    public Text howMuchTime;
    public AudioSource MainAudio;
    public AudioSource AudioWin;

    [Header("Other Components")]
    public float currentTime = 0f;
    public int kills = 0;
    public int count = 5;
    public bool isDead = false;
    public bool levelComplete = false;
    //public Pauseable pauseable;

    [Header("Player")]
    public PlayerBehavior player;
    public CameraController playerCamera;

    [Header("Scene Data")]
    public SceneDataSO sceneData;

    // Update is called once per frame
    void Update()
    {
        //Keep timer updating
        Timer();
    }
    public void Timer()
    {
        //If game is paused, don't update the timer.
        if(PauseMenu.GameIsPaused == false)
        {
            currentTime += Time.deltaTime;
        }
        timerText.text = ($"Current Time: {currentTime.ToString("00:00.00")}");
    }
    public void EndGame()
    {
        //If you're dead, make the bool true, pause time, play music and show UI
        isDead = true;
        //Cursor.lockState = CursorLockMode.Confined;
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
        mainAudio.GetComponent<AudioSource>().Stop();
        audioLose.GetComponent<AudioSource>().Play();
    }
    public void AddScore(int newScoreValue)
    {
        //Keeps track of the score in game.
        kills += newScoreValue;
        UpdateScore();
    }

    public void UpdateScore()
    {
        //Updates the game UI that's keeping track of the score. If the score is equal to count, player passed.
        Kills.text = ($"Kills: {+kills}/{count}");
        if (kills == count)
        {
            GameWon();
        }
    }
    public void GameWon()
    {
        //If player beat the level, make it possible to restart the level and next level becomes active.
        MainAudio.GetComponent<AudioSource>().Stop();
        AudioWin.GetComponent<AudioSource>().Play();
        levelComplete = true;
        Time.timeScale = 0f;
        //Cursor.lockState = CursorLockMode.Confined;
        gameWonUI.SetActive(true);
        howMuchTime.text = $"It took you {currentTime.ToString("00:00.00")} to win. Can you do better?";
    }
    public void LoadButton()
    {
        LoadFromPlayerPrefs();
        PlayerPrefs.SetInt("LoadingBool", 0);
        SceneManager.LoadScene("Level01");
    }
    public void SaveButton()
    {
        sceneData.playerPosition = player.transform.position;
        sceneData.playerRotation = player.transform.rotation;
        sceneData.playerHealth = player.currentHealth;

        SaveToPlayerPrefs();
    }
    void SaveToPlayerPrefs()
    {
        PlayerPrefs.SetFloat("playerTransformX", sceneData.playerPosition.x);
        PlayerPrefs.SetFloat("playerTransformY", sceneData.playerPosition.y);
        PlayerPrefs.SetFloat("playerTransformZ", sceneData.playerPosition.z);

        PlayerPrefs.SetFloat("playerRotationX", sceneData.playerRotation.x);
        PlayerPrefs.SetFloat("playerRotationY", sceneData.playerRotation.y);
        PlayerPrefs.SetFloat("playerRotationZ", sceneData.playerRotation.z);
        PlayerPrefs.SetFloat("playerRotationW", sceneData.playerRotation.w);

        PlayerPrefs.SetInt("playerHealth", sceneData.playerHealth);
    }
    void LoadFromPlayerPrefs()
    {
        PlayerPrefs.SetInt("LoadingBool", 0);
        sceneData.LoadingBool = PlayerPrefs.GetInt("LoadingBool");
        sceneData.playerPosition.x = PlayerPrefs.GetFloat("playerTransformX");
        sceneData.playerPosition.y = PlayerPrefs.GetFloat("playerTransformY");
        sceneData.playerPosition.z = PlayerPrefs.GetFloat("playerTransformZ");

        sceneData.playerRotation.x = PlayerPrefs.GetFloat("playerRotationX");
        sceneData.playerRotation.y = PlayerPrefs.GetFloat("playerRotationY");
        sceneData.playerRotation.z = PlayerPrefs.GetFloat("playerRotationZ");
        sceneData.playerRotation.w = PlayerPrefs.GetFloat("playerRotationW");

        sceneData.playerHealth = PlayerPrefs.GetInt("playerHealth");
    }
}
