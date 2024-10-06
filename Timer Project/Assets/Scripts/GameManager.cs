using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Game Timer")]
    [SerializeField] Slider timerBar;
    [SerializeField] float gameTimer = 60f;
    [SerializeField] float gameOver = 0f;
    // [SerializeField] float addedTime; 

    // void Awake?
    // if game scene active
    // timer start
    // when timer zero, game over screen
    // when item collected, time added to timer

    private void Update()
    {
        if ((timerBar.value <= 60))
        {
            timerBar.value -= Time.deltaTime;
            
            if (timerBar.value <= 0)
            {
                GameOver(); 
            }
        }
    }

    void GameStart()
    {
        SceneManager.LoadScene("MainGame");
    }

    void GameOver()
    {
        // game over screen active
    }

    void RestartGame()
    {
        // reload main game scene?? 
    }
}
